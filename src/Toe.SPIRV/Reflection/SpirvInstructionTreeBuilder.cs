using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Nodes;
using Toe.SPIRV.Spv;
using Capability = Toe.SPIRV.Reflection.Nodes.Capability;
using ExecutionMode = Toe.SPIRV.Reflection.Nodes.ExecutionMode;
using MemoryModel = Toe.SPIRV.Reflection.Nodes.MemoryModel;
using String = System.String;

namespace Toe.SPIRV.Reflection
{
    public class SpirvInstructionTreeBuilder
    {
        private readonly Dictionary<uint, SpirvTypeBase> _types = new Dictionary<uint, SpirvTypeBase>();
        private readonly Dictionary<uint, Node> _nodeMap = new Dictionary<uint, Node>();
        private readonly List<KeyValuePair<Instruction, Node>> _nodes = new List<KeyValuePair<Instruction, Node>>();
        Dictionary<uint, string> _names = new Dictionary<uint, string>();

        private Shader _shader;

        public SpirvTypeBase ResolveType(IdRef idRef)
        {
            if (idRef == IdRef.Empty)
                return null;
            return _types[idRef.Id];
        }
        public SpirvTypeBase ResolveType(uint id)
        {
            if (_types.TryGetValue(id, out var type))
                return type;
            return null;
        }

        public void AddType(InstructionWithId instruction, SpirvTypeBase type)
        {
            _types.Add(instruction.IdResult, type);
            TypeInstructions.Add(type);
        }
        public void ParseFloat(Instruction instruction)
        {
            var opTypeFloat = (OpTypeFloat)instruction;
            switch (opTypeFloat.Width)
            {
                case 16:
                    AddType(opTypeFloat, SpirvTypeBase.Half);
                    break;
                case 32:
                    AddType(opTypeFloat, SpirvTypeBase.Float);
                    break;
                case 64:
                    AddType(opTypeFloat, SpirvTypeBase.Double);
                    break;
            }
        }

        public void ParseInt(Instruction instruction)
        {
            var opTypeInt = (OpTypeInt)instruction;
            switch (opTypeInt.Width)
            {
                case 32:
                    if (opTypeInt.Signedness == 0)
                        AddType(opTypeInt, SpirvTypeBase.UInt);
                    else
                        AddType(opTypeInt, SpirvTypeBase.Int);
                    break;
                case 16:
                    if (opTypeInt.Signedness == 0)
                        AddType(opTypeInt, SpirvTypeBase.UShort);
                    else
                        AddType(opTypeInt, SpirvTypeBase.Short);
                    break;
                case 8:
                    if (opTypeInt.Signedness == 0)
                        AddType(opTypeInt, SpirvTypeBase.Byte);
                    else
                        AddType(opTypeInt, SpirvTypeBase.SByte);
                    break;
            }
        }

        public void ParseArray(OpTypeArray instruction)
        {
            var length = instruction.Length.Instruction as OpConstant;
            var lengthType = _types[length.IdResultType.Id];
            SpirvArrayLayout array;
            var arrayStrideValue = instruction.FindDecoration<Decoration.ArrayStride>()?.ArrayStrideValue;
            if (lengthType == SpirvTypeBase.UInt)
                array = new SpirvArrayLayout(
                    new SpirvArray(_types[instruction.ElementType.Id], length.Value.Value.ToUInt32()),
                    arrayStrideValue);
            else if (lengthType == SpirvTypeBase.Int)
                array = new SpirvArrayLayout(
                    new SpirvArray(_types[instruction.ElementType.Id], (uint)length.Value.Value.ToInt32()),
                    arrayStrideValue);
            else
                throw new NotImplementedException();
            AddType(instruction, array);
        }


        public void ParseMatrix(OpTypeMatrix instruction)
        {
            var columnType = _types[instruction.ColumnType.Id];
            var columnCount = instruction.ColumnCount;
            var vector = SpirvTypeBase.ResolveMatrix((SpirvVector)columnType, columnCount);
            AddType(instruction, vector);
        }

        public void ParseVector(OpTypeVector instruction)
        {
            var componentType = _types[instruction.ComponentType.Id];
            var instructionComponentCount = instruction.ComponentCount;
            var vector = SpirvTypeBase.ResolveVector(componentType, instructionComponentCount);
            AddType(instruction, vector);
        }

        public void ParseStructure(OpTypeStruct instruction)
        {
            var fields = new SpirvStructureField[instruction.MemberTypes.Count];
            for (var index = 0; index < instruction.MemberTypes.Count; index++)
            {
                var instructionMemberType = instruction.MemberTypes[index];
                string name = null;
                if (instruction.MemberNames != null && instruction.MemberNames.Count > index)
                    name = instruction.MemberNames[index].Name;
                var spirvTypeBase = _types[instructionMemberType.Id];
                if (spirvTypeBase.TypeCategory == SpirvTypeCategory.Array)
                {
                    var arrayStride = instruction.FindMemberDecoration<Decoration.ArrayStride>((uint)index)
                        ?.ArrayStrideValue;
                    spirvTypeBase = new SpirvArrayLayout((SpirvArrayBase)spirvTypeBase, arrayStride);
                }
                else if (spirvTypeBase.TypeCategory == SpirvTypeCategory.Matrix)
                {
                    var matrixStride = instruction.FindMemberDecoration<Decoration.MatrixStride>((uint)index)
                        ?.MatrixStrideValue;
                    var rowMajor = instruction.FindMemberDecoration((uint)index, Decoration.Enumerant.RowMajor) !=
                                   null;
                    var colMajor = instruction.FindMemberDecoration((uint)index, Decoration.Enumerant.ColMajor) !=
                                   null;
                    var matrixOrientation = MatrixOrientation.ColMajor;
                    if (rowMajor && colMajor)
                        throw new InvalidDataException("Matrix can't have both ColMajor and RowMajor declarations");
                    if (rowMajor)
                        matrixOrientation = MatrixOrientation.RowMajor;
                    else if (colMajor)
                        matrixOrientation = MatrixOrientation.ColMajor;
                    spirvTypeBase =
                        new SpirvMatrixLayout((SpirvMatrixBase)spirvTypeBase, matrixOrientation, matrixStride);
                }

                fields[index] = new SpirvStructureField(spirvTypeBase, name, instruction.MemberDecorations.Where(_=>_.Member == index));
            }

            Array.Sort(fields);
            var structure = new SpirvStruct(instruction.OpName?.Value, fields);
            foreach (var decoration in instruction.Decorations)
            {
                switch (decoration.Decoration.Value)
                {
                    case Decoration.Enumerant.Block:
                        structure.Block = true;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            AddType(instruction, structure);
        }

        public void ParseFunctionType(OpTypeFunction instruction)
        {
            var function = new SpirvFunction();
            function.DebugName = instruction.OpName?.Value;
            function.ReturnType = ResolveType(instruction.ReturnType);
            foreach (var parameterType in instruction.ParameterTypes)
            {
                function.Arguments.Add(new SpirvFunctionArgument(ResolveType(parameterType.Id)));
            }
            AddType(instruction, function);
        }

        public void ParsePointerType(OpTypePointer instruction)
        {
            var function = new SpirvPointer();
            function.DebugName = instruction.OpName?.Value;
            function.Type = ResolveType(instruction.Type);
            function.StorageClass = instruction.StorageClass;
            AddType(instruction, function);
        }

        public void RegisterNodeResult(uint id, Node node)
        {
            _nodeMap.Add(id, node);
        }

        public Node GetNode(IdRef id)
        {
            if (id == IdRef.Empty)
                return null;
            return _nodeMap[id.Id];
        }

        public IList<Node> GetNodes(IList<IdRef> ids)
        {
            var nodes = new List<Node>();
            if (ids != null)
            {
                foreach (var idRef in ids)
                {
                    nodes.Add(GetNode(idRef));
                }
            }

            return nodes;
        }

        public void BuildTree(Shader shader)
        {
            _shader = shader;
            Function currentFunction = null;
            for (var index = 0; index < _shader.Instructions.Count; index++)
            {
                var instruction = _shader.Instructions[index];
                switch (instruction.OpCode)
                {
                    case Op.OpCapability:
                        CapabilityInstructions.Add((Capability)ParseNode(instruction));
                        break;
                    case Op.OpExtInstImport:
                        ExtInstImportInstructions.Add((ExtInstImport)ParseNode(instruction));
                        break;
                    case Op.OpExtension:
                        ExtensionInstructions.Add((Extension)ParseNode(instruction));
                        break;
                    case Op.OpMemoryModel:
                        MemoryModel = (MemoryModel)ParseNode(instruction);
                        break;
                    case Op.OpEntryPoint:
                    {
                        EntryPointInstructions.Add((EntryPoint) ParseNode(instruction));
                        break;
                    }
                    case Op.OpExecutionMode:
                    {
                        ExecutionModeInstructions.Add((ExecutionMode)ParseNode(instruction));
                        break;
                    }
                    case Op.OpString:
                    case Op.OpSource:
                    case Op.OpSourceExtension:
                    case Op.OpSourceContinued:
                    {
                        ParseNode(instruction);
                        break;
                    }
                    
                    case Op.OpName:
                        _names[((OpName) instruction).Target.Id] = ((OpName) instruction).Value;
                        break;
                    case Op.OpMemberName:
                        break;

                    case Op.OpDecorate:
                    case Op.OpMemberDecorate:
                        break;
                    case Op.OpGroupDecorate:
                    case Op.OpGroupMemberDecorate:
                    case Op.OpDecorationGroup:
                        throw new NotImplementedException(instruction.OpCode+" not implemented yet.");

                    case Op.OpLine:
                    case Op.OpExtInst:
                        break;

                    case Op.OpTypeVector:
                        ParseVector((OpTypeVector)instruction);
                        break;
                    case Op.OpTypeStruct:
                        ParseStructure((OpTypeStruct)instruction);
                        break;
                    case Op.OpTypeMatrix:
                        ParseMatrix((OpTypeMatrix)instruction);
                        break;
                    case Op.OpTypeArray:
                        ParseArray((OpTypeArray)instruction);
                        break;
                    case Op.OpTypeFloat:
                        ParseFloat(instruction);
                        break;
                    case Op.OpTypeBool:
                        AddType((InstructionWithId)instruction, SpirvTypeBase.Bool);
                        break;
                    case Op.OpTypeVoid:
                        AddType((InstructionWithId)instruction, SpirvTypeBase.Void);
                        break;
                    case Op.OpTypeInt:
                        ParseInt(instruction);
                        break;
                 
                    case Op.OpTypeFunction:
                        ParseFunctionType((OpTypeFunction)instruction);
                        break;
                    case Op.OpTypePointer:
                        ParsePointerType((OpTypePointer)instruction);
                        break;
                    case Op.OpFunction:
                    {
                        var function = ParseNode(instruction);
                        currentFunction = (Function) function;
                        var hasId = _shader.Instructions[index].TryGetResultId(out var id);
                        if (hasId)
                        {
                            //if (entryPoint != null && id == entryPoint.Value.Id)
                            //{
                            //    function = (Function)function;
                            //}
                        }
                        break;
                    }
                    case Op.OpFunctionParameter:
                    {
                        var param = (FunctionParameter)ParseNode(instruction);
                        currentFunction.Parameters.Add(param);
                        break;
                    }
                    case Op.OpFunctionEnd:
                    {
                        ParseNode(instruction);
                        currentFunction = null;
                        break;
                    }
                    default:
                        ParseNode(instruction);
                        break;
                }
            }
            // Fix forward references.
            INodeWithNext prevSequentialInstruction = null;
            foreach (var instructionAndNode in _nodes)
            {
                var key = instructionAndNode.Key;
                var value = instructionAndNode.Value;
                value.SetUp(key, this);
                if (value is ExecutableNode executableNode)
                {
                    if (prevSequentialInstruction != null)
                        prevSequentialInstruction.Next = executableNode;
                    prevSequentialInstruction = null;
                }

                if (value is INodeWithNext nodeWithNext)
                {
                    prevSequentialInstruction = nodeWithNext;
                }
            }
        }

        /// <summary>
        /// All OpCapability instructions. 
        /// </summary>
        public List<Capability> CapabilityInstructions { get; } = new List<Capability>();
        /// <summary>
        /// Optional OpExtension instructions (extensions to SPIR-V).
        /// </summary>
        public List<Extension> ExtensionInstructions { get; } = new List<Extension>();
        /// <summary>
        /// Optional OpExtInstImport instructions.
        /// </summary>
        public List<ExtInstImport> ExtInstImportInstructions { get; } = new List<ExtInstImport>();
        /// <summary>
        /// The single required OpMemoryModel instruction.
        /// </summary>
        public MemoryModel MemoryModel { get; set; }
        /// <summary>
        /// All entry point declarations, using OpEntryPoint.
        /// </summary>
        public List<EntryPoint> EntryPointInstructions { get; } = new List<EntryPoint>();
        /// <summary>
        /// All entry point declarations, using OpEntryPoint.
        /// </summary>
        public List<ExecutionMode> ExecutionModeInstructions { get; } = new List<ExecutionMode>();
        /// <summary>
        /// All type declarations (OpTypeXXX instructions).
        /// </summary>
        public List<SpirvTypeBase> TypeInstructions { get; } = new List<SpirvTypeBase>();

        private void AddNode(Instruction instruction, Node node)
        {
            _nodes.Add(new KeyValuePair<Instruction, Node>(instruction, node));
        }

        private Node ParseNode(Instruction op)
        {
            Node node = Node.Create(op, this);
            if (node != null)
            {
                if (op.TryGetResultId(out var id))
                {
                    if (_names.TryGetValue(id, out var name))
                        node.DebugName = name;
                    RegisterNodeResult(id, node);
                }

                AddNode(op, node);
            }

            return node;
        }
    }
}