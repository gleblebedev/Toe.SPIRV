﻿using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Nodes;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;
using Capability = Toe.SPIRV.Spv.Capability;
using ExecutionMode = Toe.SPIRV.Reflection.Nodes.ExecutionMode;
using MemoryModel = Toe.SPIRV.Spv.MemoryModel;
using String = Toe.SPIRV.Reflection.Nodes.String;

namespace Toe.SPIRV.Reflection
{
    public class SpirvInstructionsBuilder: SpirvInstructionsBuilderBase
    {
        /// <summary>
        /// All OpCapability instructions. 
        /// </summary>
        private readonly List<OpCapability> _capabilityInstructions = new List<OpCapability>();
        /// <summary>
        /// Optional OpExtension instructions (extensions to SPIR-V).
        /// </summary>
        private readonly List<OpExtension> _extensionInstructions = new List<OpExtension>();
        /// <summary>
        /// Optional OpExtInstImport instructions.
        /// </summary>
        private readonly List<OpExtInstImport> _extInstImportInstructions = new List<OpExtInstImport>();
        /// <summary>
        /// The single required OpMemoryModel instruction.
        /// </summary>
        private OpMemoryModel _memoryModel { get; set; }
        /// <summary>
        /// All entry point declarations, using OpEntryPoint.
        /// </summary>
        private readonly List<OpEntryPoint> _entryPointInstructions = new List<OpEntryPoint>();
        /// <summary>
        /// All entry point declarations, using OpEntryPoint.
        /// </summary>
        private readonly List<OpExecutionMode> _executionModeInstructions = new List<OpExecutionMode>();
        /// <summary>
        /// All OpString, OpSourceExtension, OpSource, and OpSourceContinued, without forward references.
        /// </summary>
        private readonly List<Instruction> _debugInstructions = new List<Instruction>();
        /// <summary>
        /// All OpName and all OpMemberName.
        /// </summary>
        private readonly List<Instruction> _nameInstructions = new List<Instruction>();
        /// <summary>
        ///  All decoration instructions (OpDecorate, OpMemberDecorate, OpGroupDecorate, OpGroupMemberDecorate and OpDecorationGroup).
        /// </summary>
        private readonly List<Instruction> _declarationInstructions = new List<Instruction>();
        /// <summary>
        /// All type declarations (OpTypeXXX instructions), all constant instructions, and all global variable declarations
        /// (all OpVariable instructions whose Storage Class is not Function). This is the preferred location for OpUndef
        /// instructions, though they can also appear in function bodies.All operands in all these instructions must be declared
        /// before being used.Otherwise, they can be in any order. This section is the first section to allow use of OpLine debug
        /// information.
        /// </summary>
        private readonly List<Instruction> _typeInstructions = new List<Instruction>();
        /// <summary>
        /// All function definitions (functions with a body). A function definition is as follows.
        /// </summary>
        private readonly List<List<Instruction>> _functions = new List<List<Instruction>>();

        private readonly InstructionRegistry _instructionRegistry = new InstructionRegistry();

        public Shader Build(ShaderReflection shaderReflection)
        {
            var shader = new Shader();

            _results.Add(null);

            foreach (var capability in shaderReflection.CapabilityInstructions)
            {
                Visit(capability);
            }
            foreach (var extension in shaderReflection.ExtensionInstructions)
            {
                Visit(extension);
            }
            foreach (var extInstImport in shaderReflection.ExtInstImportInstructions)
            {
                Visit(extInstImport);
            }
            Visit(shaderReflection.MemoryModel);
            foreach (var entryPoint in shaderReflection.EntryPointInstructions)
            {
                Visit(entryPoint);
            }
            foreach (var executionMode in shaderReflection.ExecutionModeInstructions)
            {
                Visit(executionMode);
            }
            shader.Bound = (uint)_results.Count;
            Write(shader, _capabilityInstructions);
            Write(shader, _extensionInstructions);
            Write(shader, _extInstImportInstructions);
            Write(shader, _memoryModel);
            Write(shader, _entryPointInstructions);
            Write(shader, _executionModeInstructions);
            Write(shader, _debugInstructions);
            Write(shader, _nameInstructions);
            Write(shader, _declarationInstructions);
            Write(shader, _typeInstructions);
            foreach (var function in _functions)
            {
                Write(shader, function);
            }
            return shader;
        }

        private void Write(Shader shader, Instruction instruction)
        {
            if (instruction != null)
            {
                shader.Instructions.Add(instruction);
            }
        }
        private void Write<T>(Shader shader, IEnumerable<T> instructions) where T:Instruction
        {
            if (instructions != null)
            {
                foreach (var instruction in instructions)
                {
                    Write(shader, instruction);
                }
            }
        }

        protected T2 Register<T1,T2>(T2 node, IList<T1> collection) where T2:T1
        {
            collection.Add(node);
            return node;
        }

        protected override OpFunction VisitFunction(Function node)
        {
            var visitFunction = base.VisitFunction(node);
            var instructions = new List<Instruction>();
            instructions.Add(visitFunction);
            AddBlock(instructions, node.Next);
            instructions.Add(new OpFunctionEnd());
            _functions.Add(instructions);
            return visitFunction;
        }

        private void AddBlock(List<Instruction> instructions, ExecutableNode node)
        {
            while (node != null)
            {
                EnsureInputs(instructions, node);
                node = node.GetNext();
            }
        }

        private void EnsureInputs(List<Instruction> instructions, Node node)
        {
            var instruction = Visit(node);
            switch (node.OpCode)
            {
                case Op.OpConstant:
                case Op.OpConstantComposite:
                case Op.OpConstantFalse:
                case Op.OpConstantNull:
                case Op.OpConstantSampler:
                case Op.OpConstantTrue:
                case Op.OpFunctionParameter:
                    return;
                case Op.OpVariable:
                {
                    if (((OpVariable)instruction).StorageClass.Value != StorageClass.Enumerant.Function)
                        return;
                    break;
                }
            }
            foreach (var input in node.InputPins)
            {
                var inputNode = input.ConnectedPin?.Node;
                if (inputNode != null)
                {
                    EnsureInputs(instructions, inputNode);
                }
            }
            instructions.Add(instruction);
        }

        protected override OpCapability VisitCapability(Nodes.Capability node)
        {
            return Register(base.VisitCapability(node), _capabilityInstructions);
        }

        protected override OpExtension VisitExtension(Extension node)
        {
            return Register(base.VisitExtension(node), _extensionInstructions);
        }

        protected override OpExtInstImport VisitExtInstImport(ExtInstImport node)
        {
            return Register(base.VisitExtInstImport(node), _extInstImportInstructions);
        }

        protected override OpMemoryModel VisitMemoryModel(Nodes.MemoryModel node)
        {
            return (_memoryModel = base.VisitMemoryModel(node));
        }

        protected override OpEntryPoint VisitEntryPoint(EntryPoint node)
        {
            return Register(base.VisitEntryPoint(node), _entryPointInstructions);
        }

        protected override OpExecutionMode VisitExecutionMode(ExecutionMode node)
        {
            return Register(base.VisitExecutionMode(node), _executionModeInstructions);
        }

        protected override OpString VisitString(String node)
        {
            return Register(base.VisitString(node), _debugInstructions);
        }

        protected override OpSourceExtension VisitSourceExtension(SourceExtension node)
        {
            return Register(base.VisitSourceExtension(node), _debugInstructions);
        }

        protected override OpSource VisitSource(Source node)
        {
            return Register(base.VisitSource(node), _debugInstructions);
        }

        protected override OpSourceContinued VisitSourceContinued(SourceContinued node)
        {
            return Register(base.VisitSourceContinued(node), _debugInstructions);
        }

        protected override OpName VisitName(Name node)
        {
            return Register(base.VisitName(node), _nameInstructions);
        }

        protected override OpMemberName VisitMemberName(MemberName node)
        {
            return Register(base.VisitMemberName(node), _nameInstructions);
        }

        protected override OpDecorate VisitDecorate(Decorate node)
        {
            return Register(base.VisitDecorate(node), _declarationInstructions);
        }

        protected override OpMemberDecorate VisitMemberDecorate(MemberDecorate node)
        {
            return Register(base.VisitMemberDecorate(node), _declarationInstructions);
        }

        protected override OpGroupDecorate VisitGroupDecorate(GroupDecorate node)
        {
            return Register(base.VisitGroupDecorate(node), _declarationInstructions);
        }

        protected override OpGroupMemberDecorate VisitGroupMemberDecorate(GroupMemberDecorate node)
        {
            return Register(base.VisitGroupMemberDecorate(node), _declarationInstructions);
        }

        protected override OpDecorationGroup VisitDecorationGroup(DecorationGroup node)
        {
            return Register(base.VisitDecorationGroup(node), _declarationInstructions);
        }

        protected override OpVariable VisitVariable(Variable node)
        {
            var variable = base.VisitVariable(node);
            if (variable.StorageClass.Value != StorageClass.Enumerant.Function)
                _typeInstructions.Add(variable);
            
            return variable;
        }

        protected override OpConstant VisitConstant(Constant node)
        {
            return Register(base.VisitConstant(node), _typeInstructions);
        }

        protected override OpConstantComposite VisitConstantComposite(ConstantComposite node)
        {
            return Register(base.VisitConstantComposite(node), _typeInstructions);
        }

        protected override OpConstantFalse VisitConstantFalse(ConstantFalse node)
        {
            return Register(base.VisitConstantFalse(node), _typeInstructions);
        }

        protected override OpConstantNull VisitConstantNull(ConstantNull node)
        {
            return Register(base.VisitConstantNull(node), _typeInstructions);
        }

        protected override OpConstantSampler VisitConstantSampler(ConstantSampler node)
        {
            return Register(base.VisitConstantSampler(node), _typeInstructions);
        }

        protected override OpConstantTrue VisitConstantTrue(ConstantTrue node)
        {
            return Register(base.VisitConstantTrue(node), _typeInstructions);
        }

        protected override OpTypeBool VisitTypeBool(TypeBool node)
        {
            return Register(base.VisitTypeBool(node), _typeInstructions);
        }

        protected override OpTypeDeviceEvent VisitTypeDeviceEvent(TypeDeviceEvent node)
        {
            return Register(base.VisitTypeDeviceEvent(node), _typeInstructions);
        }

        protected override OpTypeEvent VisitTypeEvent(TypeEvent node)
        {
            return Register(base.VisitTypeEvent(node), _typeInstructions);
        }

        protected override OpTypeFloat VisitTypeFloat(TypeFloat node)
        {
            var visitTypeFloat = base.VisitTypeFloat(node);
            visitTypeFloat.Width = node.Width;
            return Register(visitTypeFloat, _typeInstructions);
        }

        protected override OpTypeForwardPointer VisitTypeForwardPointer(TypeForwardPointer node)
        {
            return Register(base.VisitTypeForwardPointer(node), _typeInstructions);
        }

        protected override OpTypeFunction VisitTypeFunction(TypeFunction node)
        {
            var visitTypeFunction = base.VisitTypeFunction(node);
            Register(visitTypeFunction, _typeInstructions);

            visitTypeFunction.ParameterTypes = new List<IdRef>();
            foreach (var argument in node.Arguments)
            {
                visitTypeFunction.ParameterTypes.Add(Visit(argument.Type));
            }

            visitTypeFunction.ReturnType = Visit(node.ReturnType);
            return  visitTypeFunction;
        }
        protected override OpTypeVector VisitTypeVector(TypeVector node)
        {
            var vector = base.VisitTypeVector(node);
            vector.ComponentCount = node.ComponentCount;
            vector.ComponentType = Visit(node.ComponentType);
            return Register(vector, _typeInstructions);
        }

        protected override OpTypeImage VisitTypeImage(TypeImage node)
        {
            return Register(base.VisitTypeImage(node), _typeInstructions);
        }

        protected override OpTypeInt VisitTypeInt(TypeInt node)
        {
            var visitTypeInt = base.VisitTypeInt(node);
            visitTypeInt.Signedness = node.Signed?1u:0;
            visitTypeInt.Width = node.Width;
            return Register(visitTypeInt, _typeInstructions);
        }

        protected override OpTypeMatrix VisitTypeMatrix(TypeMatrix node)
        {
            return Register(base.VisitTypeMatrix(node), _typeInstructions);
        }

        protected override OpTypeOpaque VisitTypeOpaque(TypeOpaque node)
        {
            return Register(base.VisitTypeOpaque(node), _typeInstructions);
        }

        protected override OpTypePipe VisitTypePipe(TypePipe node)
        {
            return Register(base.VisitTypePipe(node), _typeInstructions);
        }

        protected override OpTypePointer VisitTypePointer(TypePointer node)
        {
            return Register(base.VisitTypePointer(node), _typeInstructions);
        }

        protected override OpTypeQueue VisitTypeQueue(TypeQueue node)
        {
            return Register(base.VisitTypeQueue(node), _typeInstructions);
        }

        protected override OpTypeReserveId VisitTypeReserveId(TypeReserveId node)
        {
            return Register(base.VisitTypeReserveId(node), _typeInstructions);
        }

        protected override OpTypeRuntimeArray VisitTypeRuntimeArray(TypeRuntimeArray node)
        {
            return Register(base.VisitTypeRuntimeArray(node), _typeInstructions);
        }

        protected override OpTypeSampledImage VisitTypeSampledImage(TypeSampledImage node)
        {
            return Register(base.VisitTypeSampledImage(node), _typeInstructions);
        }

        protected override OpTypeSampler VisitTypeSampler(TypeSampler node)
        {
            return Register(base.VisitTypeSampler(node), _typeInstructions);
        }

        protected override OpTypeVoid VisitTypeVoid(TypeVoid node)
        {
            return Register(base.VisitTypeVoid(node), _typeInstructions);
        }

        protected override OpTypeStruct VisitTypeStruct(TypeStruct node)
        {
            var visitTypeStruct = base.VisitTypeStruct(node);
            visitTypeStruct.MemberTypes = node.Fields.Select(_ => (IdRef)Visit(_.Type)).ToList();
            return Register(visitTypeStruct, _typeInstructions);
        }

        protected override OpTypeArray VisitTypeArray(TypeArray node)
        {
            var visitTypeArray = base.VisitTypeArray(node);
            visitTypeArray.ElementType = Visit(node.ElementType);
            var val = new Value(BitConverter.GetBytes(node.Length), (TypeInstruction)Visit(SpirvTypeBase.UInt));
            visitTypeArray.Length = Visit(new Constant(SpirvTypeBase.UInt, new LiteralContextDependentNumber(val)));
            return Register(visitTypeArray, _typeInstructions);
        }
    }
}