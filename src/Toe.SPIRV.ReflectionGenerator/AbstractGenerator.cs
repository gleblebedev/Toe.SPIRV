using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV
{
    public class ReflectionGenerator
    {
        private readonly Shader _shader;
        private StringBuilder _stringBuilder;
        private StringWriter _writer;
        private string _namespace;
        private bool _hasNamespace;
        private string _offset;

        public ReflectionGenerator(Shader shader, string @namespace = null)
        {
            _shader = shader;
            _namespace = @namespace;
            _hasNamespace = !string.IsNullOrWhiteSpace(_namespace);
        }

        public virtual void WriteUsings()
        {
            WriteLine("using System;");
            WriteLine("using System.Numerics;");
            WriteLine("using System.Runtime.InteropServices;");
        }
    
        public virtual string GenerateText()
        {
            _stringBuilder = new StringBuilder();
            _offset = "";
            using (_writer = new StringWriter(_stringBuilder))
            {
                WriteUsings();
                WriteLine("");
                if (_hasNamespace)
                {
                    WriteLine($"namespace {_namespace}");
                    WriteLine("{");
                    _offset = "    ";
                }

                WriteStructs();

                _offset = "";
                if (_hasNamespace)
                {
                    WriteLine("}");
                }

            }

            return _stringBuilder.ToString();
        }

        protected virtual void WriteStructs()
        {
            var structs = new ShaderReflection(_shader).Structures
                .Where(_=>_.Name != "gl_PerVertex")
                .ToList();

            for (var index = 0; index < structs.Count; index++)
            {
                var opTypeStruct = structs[index];
                WriteStruct(opTypeStruct);
            }
        }

        protected virtual void WriteStruct(SpirvStructure structure)
        {
            var fields = structure.Fields;
            WriteLine("[StructLayout(LayoutKind.Explicit)]");
            WriteLine("public partial struct " + structure.Name);
            WriteLine("{");
            for (var memberIndex = 0; memberIndex < fields.Count; memberIndex++)
            {
                var field = fields[memberIndex];
                WriteStructField(field.Name, field.ByteOffset.Value, field.Type);
                if (memberIndex != fields.Count-1)
                    WriteLine();
            }
            WriteLine("}");
        }

        protected virtual void WriteStructField(string fieldName, uint byteOffset, SpirvTypeBase fieldType)
        {
            switch (fieldType.TypeCategory)
            {
                case SpirvTypeCategory.Void:
                    return;
                case SpirvTypeCategory.Array:
                {
                    WriteArrayField(fieldName, byteOffset, (SpirvArrayBase)fieldType);
                    return;
                }
                case SpirvTypeCategory.Float:
                {
                    if (WriteFloatField(fieldName, byteOffset, (SpirvFloat)fieldType)) return;
                    break;
                }
                case SpirvTypeCategory.Int:
                {
                    if (WriteIntField(fieldName, byteOffset, (SpirvInt)fieldType)) return;
                    break;
                }
                case SpirvTypeCategory.Vector:
                {
                    if (WriteVectorField(fieldName, byteOffset, (SpirvVector)fieldType)) return;
                    break;
                }
                case SpirvTypeCategory.Matrix:
                {
                    if (WriteMatrixField(fieldName, byteOffset, (SpirvMatrixBase)fieldType)) return;
                    break;
                }
                case SpirvTypeCategory.Struct:
                {
                    WriteLine($"    [FieldOffset({byteOffset})]");
                    WriteLine($"    public {fieldType} {fieldName};");
                    return;
                }
            }
            WriteLine($"    //[FieldOffset({byteOffset})]");
            WriteLine($"    //public {fieldType} {fieldName};");
        }

        protected virtual bool WriteMatrixField(string fieldName, uint byteOffset, SpirvMatrixBase fieldType)
        {
            if (fieldType.ColumnType == SpirvTypeBase.Vec4 && fieldType.ColumnCount == 4 &&
                fieldType.ColumnStride == 16 && fieldType.MatrixOrientation == MatrixOrientation.ColMajor)
            {
                WriteLine($"    [FieldOffset({byteOffset})]");
                WriteLine($"    public Matrix4x4 {fieldName};");
                return true;
            }

            for (uint i = 0; i < fieldType.ColumnCount; ++i)
            {
                if (fieldType.MatrixOrientation == MatrixOrientation.ColMajor)
                    WriteStructField(fieldName + "Col" + i, byteOffset + i * fieldType.ColumnStride, fieldType.ColumnType);
                else
                    WriteStructField(fieldName + "Row" + i, byteOffset + i * fieldType.ColumnStride, fieldType.ColumnType);
            }
            return true;
        }

        protected virtual bool WriteVectorField(string fieldName, uint byteOffset, SpirvVector fieldType)
        {
            switch (fieldType.VectorType)
            {
                case VectorType.Vec2:
                    WriteLine($"    [FieldOffset({byteOffset})]");
                    WriteLine($"    public Vector2 {fieldName};");
                    return true;
                case VectorType.Vec3:
                    WriteLine($"    [FieldOffset({byteOffset})]");
                    WriteLine($"    public Vector3 {fieldName};");
                    return true;
                case VectorType.Vec4:
                    WriteLine($"    [FieldOffset({byteOffset})]");
                    WriteLine($"    public Vector4 {fieldName};");
                    return true;
            }
            for (uint i = 0; i < fieldType.ComponentCount; ++i)
            {
                string letter = null;
                switch (i)
                {
                    case 0: letter = "X"; break;
                    case 1: letter = "Y"; break;
                    case 2: letter = "Z"; break;
                    case 3: letter = "W"; break;
                    default: letter = "_" + i; break;
                }
                WriteStructField(fieldName + letter, byteOffset + i * fieldType.ComponentType.Alignment, fieldType.ComponentType);
            }
            return true;
        }

        protected virtual bool WriteFloatField(string fieldName, uint byteOffset, SpirvFloat floatType)
        {
            string actualName = null;
            switch (floatType.Width)
            {
                case 32:
                    actualName = "float";
                    break;
                case 64:
                    actualName = "double";
                    break;
            }

            if (actualName != null)
            {
                WriteLine($"    [FieldOffset({byteOffset})]");
                WriteLine($"    public {actualName} {fieldName};");
                return true;
            }

            return false;
        }

        protected virtual bool WriteIntField(string fieldName, uint byteOffset, SpirvInt intType)
        {
            string actualName = null;
            if (intType.Signed)
            {
                switch (intType.Width)
                {
                    case 8:
                        actualName = "sbyte";
                        break;
                    case 16:
                        actualName = "short";
                        break;
                    case 32:
                        actualName = "int";
                        break;
                    case 64:
                        actualName = "long";
                        break;
                }

            }
            else
            {
                switch (intType.Width)
                {
                    case 8:
                        actualName = "byte";
                        break;
                    case 16:
                        actualName = "ushort";
                        break;
                    case 32:
                        actualName = "uint";
                        break;
                    case 64:
                        actualName = "ulong";
                        break;
                }
            }
            if (actualName != null)
            {
                WriteLine($"    [FieldOffset({byteOffset})]");
                WriteLine($"    public {actualName} {fieldName};");
                return true;
            }

            return false;
        }

        private void WriteArrayField(string fieldName, uint byteOffset, SpirvArrayBase arrayType)
        {
            var sep = char.IsDigit(fieldName[fieldName.Length - 1]) ? "_" : "";
            for (uint i = 0; i < arrayType.Length; ++i)
            {
                WriteStructField(fieldName + sep + i, byteOffset + i * arrayType.ArrayStride, arrayType.ElementType);
            }

            return;
        }

        private bool CanBeFixedArray(string typeElementType)
        {
            switch (typeElementType)
            {
                case "bool":
                case "byte":
                case "short":
                case "int":
                case "long":
                case "char":
                case "sbyte":
                case "ushort":
                case "uint":
                case "ulong":
                case "float":
                case "double":
                    return true;
            }

            return false;
        }

        public struct TypeDesc
        {
            public string ElementType;
            public int ElementSize;
            public int ArraySize;

            public TypeDesc(string elementType, int elementSize)
            {
                ElementType = elementType;
                ElementSize = elementSize;
                ArraySize = 1;
            }
            public TypeDesc(string elementType, int elementSize, int arraySize)
            {
                ElementType = elementType;
                ElementSize = elementSize;
                ArraySize = arraySize;
            }

            public bool IsArray()
            {
                return ArraySize != 1;
            }
        }

        Dictionary<uint, TypeDesc> _knownTypes = new Dictionary<uint,TypeDesc>();

        protected virtual TypeDesc ResolveType(IdRef type)
        {
            return ResolveType((TypeInstruction) type.Instruction);
        }

        protected virtual TypeDesc ResolveType(TypeInstruction type)
        {
            if (_knownTypes.TryGetValue(type.IdResult, out var desc))
            {
                return desc;
            }
            desc = ResolveUnknownType(type);
            _knownTypes.Add(type.IdResult, desc);
            return desc;

        }

        protected virtual TypeDesc ResolveUnknownType(TypeInstruction type)
        {
            switch (type.OpCode)
            {
                case Op.OpTypeVoid:
                    return new TypeDesc("void", 0);
                case Op.OpTypeStruct:
                    {
                        var opType = (OpTypeStruct)type;
                        return new TypeDesc(opType.OpName?.Name ?? ("Struct"+opType.IdResult), 0); //TODO: calc size
                    }
                case Op.OpTypeArray:
                    {
                        var opType = (OpTypeArray)type;
                        var element = ResolveType(opType.ElementType);
                        var length = ((OpConstant)opType.Length.Instruction).Value.Value.ToInt32();
                        return new TypeDesc(element.ElementType, element.ElementSize, length * element.ArraySize);
                    }
                case Op.OpTypeVector:
                    return GenerateVector((OpTypeVector)type);
                case Op.OpTypeMatrix:
                    return GenerateMatrix((OpTypeMatrix)type);
                case Op.OpTypeFloat:
                    {
                        var opType = (OpTypeFloat)type;
                        switch (opType.Width)
                        {
                            case 32:
                                return new TypeDesc("float",4);
                            case 64:
                                return new TypeDesc("double", 8);
                        }

                        break;
                    }

                case Op.OpTypeInt:
                    {
                        var opType = (OpTypeInt)type;
                        if (opType.Signedness == 0)
                        {
                            switch (opType.Width)
                            {
                                case 8:
                                    return new TypeDesc("sbyte",1);
                                case 16:
                                    return new TypeDesc("short",2);
                                case 32:
                                    return new TypeDesc("int",4);
                                case 64:
                                    return new TypeDesc("long",8);
                            }
                        }
                        else
                        {
                            switch (opType.Width)
                            {
                                case 8:
                                    return new TypeDesc("byte",1);
                                case 16:
                                    return new TypeDesc("ushort",2);
                                case 32:
                                    return new TypeDesc("uint",4);
                                case 64:
                                    return new TypeDesc("ulong",8);
                            }
                        }
                        break;
                    }
            }

            throw new NotImplementedException("Not implemented yet (" + type + ")");
        }

        protected virtual TypeDesc GenerateMatrix(OpTypeMatrix type)
        {
            return GenerateMatrix(type, ResolveType(type.ColumnType));
        }

        protected virtual TypeDesc GenerateMatrix(OpTypeMatrix type, TypeDesc element)
        {
            var length = (int)type.ColumnCount;
            if (!element.IsArray())
            {
                if (element.ElementType == "Vector4" && length == 4)
                {
                    return new TypeDesc("Matrix4x4",element.ElementSize*length);
                }
            }
            return new TypeDesc(element.ElementType, length * element.ElementSize);
        }

        protected virtual TypeDesc GenerateVector(OpTypeVector type)
        {
            return GenerateVector(type, ResolveType(type.ComponentType));
        }

        protected virtual TypeDesc GenerateVector(OpTypeVector type, TypeDesc element)
        {
            var length = (int)type.ComponentCount;

            if (!element.IsArray())
            {
                if (element.ElementType == "float")
                {
                    switch (length)
                    {
                        case 2:
                            return new TypeDesc("Vector2", length * element.ElementSize);
                        case 3:
                            return new TypeDesc("Vector3", length * element.ElementSize);
                        case 4:
                            return new TypeDesc("Vector4", length * element.ElementSize);
                    }
                }
            }

            return new TypeDesc(element.ElementType, length * element.ArraySize);
        }

        protected void WriteLine()
        {
            _writer.WriteLine();
        }
        protected void WriteLine(string value)
        {
            _writer.Write(_offset);
            _writer.WriteLine(value);
        }
    }
}
