using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.CustomTool.Generators
{
    public abstract class AbstractGenerator
    {
        private readonly Shader _shader;
        private readonly string _fileName;
        private StringBuilder _stringBuilder;
        private StringWriter _writer;
        private string _namespace;
        private bool _hasNamespace;
        private string _offset;

        public AbstractGenerator(Shader shader, string fileName)
        {
            _shader = shader;
            _fileName = fileName;
        }

        public Shader Shader
        {
            get { return _shader; }
        }

        public string FileName
        {
            get { return _fileName; }
        }

        public virtual void WriteUsings()
        {
            WriteLine("using System.Numerics;");
            WriteLine("using System.Runtime.InteropServices;");
        }
        internal static Project GetActiveProject()
        {
            DTE dte = Package.GetGlobalService(typeof(SDTE)) as DTE;
            return GetActiveProject(dte);
        }
        internal static Project GetActiveProject(DTE dte)
        {
            Project activeProject = null;

            Array activeSolutionProjects = dte.ActiveSolutionProjects as Array;
            if (activeSolutionProjects != null && activeSolutionProjects.Length > 0)
            {
                activeProject = activeSolutionProjects.GetValue(0) as Project;
            }

            return activeProject;
        }
        public string GetNamespace()
        {
            var project = GetActiveProject();
            var defaultNamespace = project.Properties.Item("DefaultNamespace")?.Value?.ToString();
            var fileNameWithoutExtension = Path.GetFileName(_fileName);
            var extPos = fileNameWithoutExtension.IndexOf('.');
            if (extPos > 0)
                fileNameWithoutExtension = fileNameWithoutExtension.Substring(0, extPos);
           
            var stringBuilder = new StringBuilder();

            if (!string.IsNullOrEmpty(defaultNamespace))
            {
                stringBuilder.Append(defaultNamespace);
                stringBuilder.Append(".");
            }

            var dir = Path.GetDirectoryName(_fileName);
            var projectDir = Path.GetDirectoryName(project.FileName);
            if (dir.StartsWith(projectDir))
            {
                dir = dir.Substring(projectDir.Length).TrimStart(Path.DirectorySeparatorChar);
                if (!string.IsNullOrEmpty(dir))
                {
                    stringBuilder.Append(dir.Replace(Path.DirectorySeparatorChar, '.'));
                    stringBuilder.Append(".");
                }
            }


            stringBuilder.Append(fileNameWithoutExtension);
            return stringBuilder.ToString();
        }

        public virtual string GenerateText()
        {
            _namespace = GetNamespace();
            _hasNamespace = !string.IsNullOrWhiteSpace(_namespace);
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
            var structs = _shader.Instructions.Where(_ => _.OpCode == Op.OpTypeStruct)
                .Select(_ => (OpTypeStruct)_).ToList();
            for (var index = 0; index < structs.Count; index++)
            {
                var opTypeStruct = structs[index];
                WriteStruct(opTypeStruct);
            }
        }

        private void WriteStruct(OpTypeStruct opTypeStruct)
        {
            var name = opTypeStruct.OpName?.Name ?? "Struct" + opTypeStruct.IdResult;
            if (name == "gl_PerVertex")
            {
                return;
            }
            var memberTypes = opTypeStruct.MemberTypes.Select(_ => ResolveType((TypeInstruction)_.Instruction)).ToList();
            var isUnsafe = memberTypes.Any(_ => _.IsArray());
            WriteLine("[StructLayout(LayoutKind.Explicit)]");
            if (isUnsafe)
            {
                WriteLine("public unsafe struct " + name);
            }
            else
            {
                WriteLine("public struct " + name);
            }
            WriteLine("{");
            for (var memberIndex = 0; memberIndex < opTypeStruct.MemberTypes.Count; memberIndex++)
            {
                var memberName = opTypeStruct.MemberNames.FirstOrDefault(_ => _.Member == memberIndex)?.Name ?? ("field"+memberIndex);
                var byteOffset = opTypeStruct.FindMemberDecoration<Decoration.Offset>((uint)memberIndex)?.ByteOffset ?? 0;
                var type = memberTypes[memberIndex];

                WriteLine($"    [FieldOffset({byteOffset})]");
                if (type.IsArray())
                {
                    WriteLine($"    public fixed {type.ElementType} {memberName} [{type.ArraySize}];");
                }
                else
                {
                    WriteLine($"    public {type.ElementType} {memberName};");
                }
                WriteLine();
            }
            WriteLine("}");
        }


        public struct TypeDesc
        {
            public string ElementType;
            public int ArraySize;

            public TypeDesc(string elementType)
            {
                ElementType = elementType;
                ArraySize = 1;
            }
            public TypeDesc(string elementType, int arraySize)
            {
                ElementType = elementType;
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
                    return new TypeDesc("void");
                case Op.OpTypeStruct:
                    {
                        var opType = (OpTypeStruct)type;
                        return new TypeDesc(opType.OpName?.Name ?? ("Struct"+opType.IdResult));
                    }
                case Op.OpTypeArray:
                    {
                        var opType = (OpTypeArray)type;
                        var element = ResolveType(opType.ElementType);
                        var length = ((OpConstant)opType.Length.Instruction).Value.Value.ToInt32();
                        return new TypeDesc(element.ElementType, length * element.ArraySize);
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
                                return new TypeDesc("float");
                            case 64:
                                return new TypeDesc("double");
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
                                    return new TypeDesc("sbyte");
                                case 16:
                                    return new TypeDesc("short");
                                case 32:
                                    return new TypeDesc("int");
                                case 64:
                                    return new TypeDesc("long");
                            }
                        }
                        else
                        {
                            switch (opType.Width)
                            {
                                case 8:
                                    return new TypeDesc("byte");
                                case 16:
                                    return new TypeDesc("ushort");
                                case 32:
                                    return new TypeDesc("uint" );
                                case 64:
                                    return new TypeDesc("ulong" );
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
                    return new TypeDesc("Matrix4x4");
                }
            }
            return new TypeDesc(element.ElementType, length * element.ArraySize);
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
                            return new TypeDesc("Vector2");
                        case 3:
                            return new TypeDesc("Vector3");
                        case 4:
                            return new TypeDesc("Vector4");
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
