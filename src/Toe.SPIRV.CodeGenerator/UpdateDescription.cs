using System;
using System.Collections.Generic;
using System.Linq;
using CommandLine;
using Toe.SPIRV.CodeGenerator.Model.Grammar;
using Toe.SPIRV.CodeGenerator.Model.Spv;

namespace Toe.SPIRV.CodeGenerator
{
    public class UpdateDescription
    {
        [Verb("updategrammar")]
        public class Options
        {
            [Option('i', "input", Required = false, HelpText = "Path to spirv.core.grammar.json file")]
            public string Input { get; set; } = "spirv.core.grammar.json";

            [Option('o', "output", Required = false, HelpText = "Path to toe.spirv.grammar.json file")]
            public string Output { get; set; } = "toe.spirv.grammar.json";

            [Option('r', "rebuild", Required = false, HelpText = "Completely rebuild toe.spirv.grammar.json")]
            public bool Rebuild { get; set; }
        }

        private Operands _operands;
        private SpirvInstructions _grammar;
        private Dictionary<SpirvOperandKind, SpirvOperandCategory> _operandKindCategories = new Dictionary<SpirvOperandKind, SpirvOperandCategory>();

        public void Run(Options options)
        {
            _operands =  Utils.LoadOperands(options.Input);

            ////var enumerable = _operands.operand_kinds.Select(_=>_.kind);
            //var enumerable = _operands.operand_kinds.Select(_ => _.category);
            //foreach (var kind  in enumerable.Distinct().OrderBy(_=>_))
            //{
            //    Console.WriteLine($"                {kind},");
            //    Console.WriteLine($"                case \"{kind}\": return SpirvOperandKind.{kind};");
            //}
            foreach (var operandKind in _operands.operand_kinds)
            {
                var kind = GetKind(operandKind.kind);
                _operandKindCategories.Add(kind, GetOperandCategory(operandKind.category));
            }

            if (options.Rebuild)
            {
                _grammar = new SpirvInstructions();
            }
            else
            {
                _grammar = Utils.LoadGrammar(options.Output);
            }

            foreach (var instruction in _operands.instructions)
            {
                if (!_grammar.Instructions.ContainsKey(instruction.opcode))
                {
                    _grammar.Instructions.Add(instruction.opcode, CreateInstruction(instruction));
                }
            }
            foreach (var operandKind in _operands.operand_kinds)
            {
                var spirvOperandKind = GetKind(operandKind.kind);
                if (!_grammar.OperandKinds.ContainsKey(spirvOperandKind))
                {
                    _grammar.OperandKinds.Add(spirvOperandKind, GetOperandDescription(operandKind));
                }
            }
            Utils.SaveGrammar(options.Output, _grammar);
        }

        private SpirvOperandDescription GetOperandDescription(OperandKind operandKind)
        {
            return new SpirvOperandDescription()
            {
                Name = operandKind.kind,
                Category = GetOperandCategory(operandKind.category),
                Kind = GetKind(operandKind.kind),
                Bases = operandKind.bases,
                Doc = operandKind.doc,
                Enumerants = operandKind.enumerants
            };
        }

        private SpirvOperandCategory GetOperandCategory(string category)
        {
            switch (category)
            {
                case "BitEnum": return SpirvOperandCategory.BitEnum;
                case "ValueEnum": return SpirvOperandCategory.ValueEnum;
                case "Id": return SpirvOperandCategory.Id;
                case "Literal": return SpirvOperandCategory.Literal;
                case "Composite": return SpirvOperandCategory.Composite;
                default:
                    throw new NotImplementedException(category+" not supported");
            }
        }

        private SpirvInstruction CreateInstruction(Instruction instruction)
        {
            var spirvInstruction = new SpirvInstruction()
            {
                Name = instruction.opname,
                OpCode = instruction.opcode,
                Class = GetInstructionClass(instruction.@class)
            };

            if (instruction.capabilities != null)
                spirvInstruction.Capabilities.AddRange(instruction.capabilities);
            if (instruction.extensions != null)
                spirvInstruction.Extensions.AddRange(instruction.extensions);
            switch (spirvInstruction.Name)
            {
                case "OpUnreachable":
                case "OpReturnValue":
                case "OpReturn":
                case "OpKill":
                case "OpSwitch":
                case "OpBranchConditional":
                case "OpBranch":
                    spirvInstruction.LastInstructionInABlock = true;
                    break;
            }

            for (var index = 0; index < instruction.operands.Count; index++)
            {
                var operand = instruction.operands[index];
                var spirvOperand = CreateOperand(instruction, operand);
                switch (spirvOperand.Kind)
                {
                    case SpirvOperandKind.IdResult:
                        if (instruction.operands[0].kind == "IdResultType")
                        {
                            if (index != 1)
                                throw new Exception("IdResult expected to be second operand");
                        }
                        else
                        {
                            if (index != 0)
                                throw new Exception("IdResult expected to be first operand");
                        }
                        spirvInstruction.IdResult = spirvOperand;
                        break;
                    case SpirvOperandKind.IdResultType:
                        if (index != 0)
                            throw new Exception("IdResultType expected to be first operand");
                        spirvInstruction.IdResultType = spirvOperand;
                        break;
                    default:
                        int suffix = 1;
                        var prefix = spirvOperand.Name;
                        foreach (var op in spirvInstruction.Operands)
                        {
                            if (op.Name == spirvOperand.Name)
                            {
                                ++suffix;
                                spirvOperand.Name = $"{prefix}{suffix}";
                            }
                        }
                        spirvInstruction.Operands.Add(spirvOperand);
                        break;
                }
            }

            spirvInstruction.Kind = EvaluateInstructionKind(spirvInstruction);
            switch (spirvInstruction.Kind)
            {
                case InstructionKind.Function:
                    spirvInstruction.HasDefaultEnter = false;
                    spirvInstruction.HasDefaultExit = false;
                    break;
                case InstructionKind.Executable:
                    spirvInstruction.HasDefaultEnter = spirvInstruction.Name != "OpFunction";
                    if (spirvInstruction.LastInstructionInABlock)
                    {
                        spirvInstruction.HasDefaultExit = false;
                    }
                    else
                    {
                        spirvInstruction.HasDefaultExit = true;
                    }
                    break;
                default:
                    spirvInstruction.HasDefaultEnter = false;
                    spirvInstruction.HasDefaultExit = false;
                    break;
            }

            return spirvInstruction;
        }

        private InstructionClass GetInstructionClass(string instructionClass)
        {
            if (string.IsNullOrWhiteSpace(instructionClass))
                return InstructionClass.Unknown;
            switch (instructionClass)
            {
                case "Miscellaneous": return InstructionClass.Miscellaneous;
                case "Debug": return InstructionClass.Debug;
                case "Extension": return InstructionClass.Extension;
                case "Mode-Setting": return InstructionClass.ModeSetting;
                case "Type-Declaration": return InstructionClass.TypeDeclaration;
                case "Constant-Creation": return InstructionClass.ConstantCreation;
                case "Function": return InstructionClass.Function;
                case "Memory": return InstructionClass.Memory;
                case "Annotation": return InstructionClass.Annotation;
                case "Composite": return InstructionClass.Composite;
                case "Image": return InstructionClass.Image;
                case "Conversion": return InstructionClass.Conversion;
                case "Arithmetic": return InstructionClass.Arithmetic;
                case "Relational_and_Logical": return InstructionClass.Relational_and_Logical;
                case "Bit": return InstructionClass.Bit;
                case "Derivative": return InstructionClass.Derivative;
                case "Primitive": return InstructionClass.Primitive;
                case "Barrier": return InstructionClass.Barrier;
                case "Atomic": return InstructionClass.Atomic;
                case "Control-Flow": return InstructionClass.ControlFlow;
                case "Group": return InstructionClass.Group;
                case "Pipe": return InstructionClass.Pipe;
                case "Device-Side_Enqueue": return InstructionClass.DeviceSide_Enqueue;
                case "Non-Uniform": return InstructionClass.NonUniform;
                case "Reserved": return InstructionClass.Reserved;
                case "@exclude": return InstructionClass.@exclude;
                default:
                    throw new NotImplementedException("Instruction class "+instructionClass+" not implemented");
            }
        }

        private InstructionKind EvaluateInstructionKind(SpirvInstruction spirvInstruction)
        {
            if (spirvInstruction.LastInstructionInABlock)
                return InstructionKind.Executable;
            if (spirvInstruction.Name.StartsWith("OpType"))
                return InstructionKind.Type;
            if (spirvInstruction.Name == "OpFunction")
                return InstructionKind.Executable;
            if (spirvInstruction.Name == "OpFunctionCall")
                return InstructionKind.Executable;
            if (spirvInstruction.IdResultType != null)
                return InstructionKind.Function;
            if (spirvInstruction.Name == "OpDecorate")
                return InstructionKind.Other;
            if (spirvInstruction.OpCode <= 40)
                return InstructionKind.Other;
            if (spirvInstruction.Class == InstructionClass.Annotation)
                return InstructionKind.Other;
            return InstructionKind.Executable;
        }

        private SpirvOperand CreateOperand(Instruction instruction, Operand operand)
        {
            var spirvOperandKind = GetKind(operand.kind);
            var spirvOperand = new SpirvOperand()
            {
                Kind = spirvOperandKind,
                SpirvName = operand.name,
                Quantifier = GetQuantifier(operand.quantifier),
                Category = _operandKindCategories[spirvOperandKind]
            };

            var name = GetOperandName(instruction, spirvOperand);
            spirvOperand.Name = name;
            SetOperandClass(instruction, spirvOperand);
            return spirvOperand;
        }

        private void SetOperandClass(Instruction instruction, SpirvOperand spirvOperand)
        {
            if (spirvOperand.Kind == SpirvOperandKind.IdRef)
            {
                switch (instruction.opname)
                {
                    case "OpEntryPoint":
                        if (spirvOperand.Name == "Value")
                        {
                            spirvOperand.Class = SpirvOperandClassification.Exit;
                            spirvOperand.OperandType = "OpFunction";
                            return;
                        }
                        break;
                    case "OpFunction":
                        if (spirvOperand.Name == "FunctionType")
                        {
                            spirvOperand.Class = SpirvOperandClassification.Type;
                            return;
                        }
                        break;
                    case "OpFunctionCall":
                        if (spirvOperand.Name == "Function")
                        {
                            spirvOperand.Class = SpirvOperandClassification.Input;
                            spirvOperand.OperandType = "OpFunction";
                            return;
                        }
                        break;
                    case "OpSelectionMerge":
                        if (spirvOperand.Name == "MergeBlock")
                        {
                            spirvOperand.Class = SpirvOperandClassification.Exit;
                            spirvOperand.OperandType = "OpLabel";
                            return;
                        }
                        break;
                    case "OpLoopMerge":
                        if (spirvOperand.Name == "MergeBlock")
                        {
                            spirvOperand.Class = SpirvOperandClassification.Exit;
                            spirvOperand.OperandType = "OpLabel";
                            return;
                        }
                        if (spirvOperand.Name == "ContinueTarget")
                        {
                            spirvOperand.Class = SpirvOperandClassification.Exit;
                            spirvOperand.OperandType = "OpLabel";
                            return;
                        }
                        break;
                    case "OpBranchConditional":
                        if (spirvOperand.Name == "TrueLabel")
                        {
                            spirvOperand.Class = SpirvOperandClassification.Exit;
                            spirvOperand.OperandType = "OpLabel";
                            return;
                        }

                        if (spirvOperand.Name == "FalseLabel")
                        {
                            spirvOperand.Class = SpirvOperandClassification.Exit;
                            spirvOperand.OperandType = "OpLabel";
                            return;
                        }
                        break;
                    case "OpBranch":
                        if (spirvOperand.Name == "TargetLabel")
                        { 
                            spirvOperand.Class = SpirvOperandClassification.Exit;
                            spirvOperand.OperandType = "OpLabel";
                            return;
                        }
                        break;
                    case "OpMemberName":
                        if (spirvOperand.Name == "Type")
                        {
                            spirvOperand.Class = SpirvOperandClassification.Type;
                            return;
                        }
                        break;
                    case "OpMemberDecorate":
                        if (spirvOperand.Name == "StructureType")
                        {
                            spirvOperand.Class = SpirvOperandClassification.Type;
                            return;
                        }
                        break;
                    case "OpDecorate":
                    case "OpDecorateId":
                    case "OpDecorateString":
                        if (spirvOperand.Name == "Target")
                        {
                            spirvOperand.Class = SpirvOperandClassification.Exit;
                            spirvOperand.OperandType = "OpNode";
                            return;
                        }
                        break;
                        
                    case "OpTypeForwardPointer":
                        if (spirvOperand.Name == "PointerType")
                        {
                            spirvOperand.Class = SpirvOperandClassification.Type;
                            return;
                        }
                        break;
                    case "OpTypePointer":
                        if (spirvOperand.Name == "Type")
                        {
                            spirvOperand.Class = SpirvOperandClassification.Type;
                            return;
                        }
                        break;
                    case "OpTypeImage":
                        if (spirvOperand.Name == "SampledType")
                        {
                            spirvOperand.Class = SpirvOperandClassification.Type;
                            return;
                        }
                        break;
                    case "OpTypeRuntimeArray":
                        if (spirvOperand.Name == "ElementType")
                        {
                            spirvOperand.Class = SpirvOperandClassification.Type;
                            return;
                        }
                        break;
                    case "OpTypeSampledImage":
                        if (spirvOperand.Name == "ImageType")
                        {
                            spirvOperand.Class = SpirvOperandClassification.Type;
                            return;
                        }
                        break;
                    case "OpSwitch":
                        if (spirvOperand.Name == "Default")
                        {
                            spirvOperand.Class = SpirvOperandClassification.Exit;
                            return;
                        }
                        break;
                }

                if (spirvOperand.Quantifier == SpirvOperandQuantifier.Repeated)
                {
                    spirvOperand.Class = SpirvOperandClassification.RepeatedInput;
                }
                else
                {
                    spirvOperand.Class = SpirvOperandClassification.Input;
                }
                return;
            }

            spirvOperand.Class = SpirvOperandClassification.Other;
            //switch (spirvOperand.Category)
            //{
            //    case SpirvOperandCategory.BitEnum:
            //    case SpirvOperandCategory.ValueEnum:
            //        spirvOperand.OperandType = spirvOperand.Category + ".Enumerant";
            //        break;
            //    default:
            //        break;
            //}
            spirvOperand.Class = SpirvOperandClassification.Other;
        }

        private string GetOperandName(Instruction instruction, SpirvOperand spirvOperand)
        {
            string name;
            if (spirvOperand.SpirvName == null)
            {
                name = spirvOperand.Kind.ToString();
                if (name == instruction.opname.Substring(2))
                    return "Value";
                return name;
            }

            name = spirvOperand.SpirvName;
            name = name.Trim('\'').Trim('.');
            if (name.StartsWith("id> "))
                name = name.Substring("id> ".Length);
            name = name.Replace(" ", "");
            name = name.Replace("<<Invocation,invocations>>", "Invocations");
            name = name.Replace("-", "");
            name = name.Replace(",", "");
            name = name.Replace("~ref~", "_ref");

            {
                var collectionIndex = name.IndexOf("0\'");
                if (collectionIndex > 0)
                {
                    name = name.Substring(0, collectionIndex) + "s";
                }
            }
            {
                var collectionIndex = name.IndexOf("1\'");
                if (collectionIndex > 0)
                {
                    name = name.Substring(0, collectionIndex) + "s";
                }
            }
            {
                var collectionIndex = name.IndexOf("0Type\'", StringComparison.InvariantCultureIgnoreCase);
                if (collectionIndex > 0)
                {
                    name = name.Substring(0, collectionIndex) + "Types";
                }
            }
            if (name == instruction.opname.Substring(2))
                return "Value";
            return name;
        }

        private SpirvOperandQuantifier GetQuantifier(string quantifier)
        {
            if (string.IsNullOrWhiteSpace(quantifier))
                return SpirvOperandQuantifier.Required;
            if (quantifier == "?")
                return SpirvOperandQuantifier.Optional;
            if (quantifier == "*")
                return SpirvOperandQuantifier.Repeated;
            throw new NotImplementedException($"\"{quantifier}\" not supported yet.");
        }

        private SpirvOperandKind GetKind(string operandKind)
        {
            switch (operandKind)
            {
                case "AccessQualifier": return SpirvOperandKind.AccessQualifier;
                case "AddressingModel": return SpirvOperandKind.AddressingModel;
                case "BuiltIn": return SpirvOperandKind.BuiltIn;
                case "Capability": return SpirvOperandKind.Capability;
                case "Decoration": return SpirvOperandKind.Decoration;
                case "Dim": return SpirvOperandKind.Dim;
                case "ExecutionMode": return SpirvOperandKind.ExecutionMode;
                case "ExecutionModel": return SpirvOperandKind.ExecutionModel;
                case "FPFastMathMode": return SpirvOperandKind.FPFastMathMode;
                case "FPRoundingMode": return SpirvOperandKind.FPRoundingMode;
                case "FunctionControl": return SpirvOperandKind.FunctionControl;
                case "FunctionParameterAttribute": return SpirvOperandKind.FunctionParameterAttribute;
                case "GroupOperation": return SpirvOperandKind.GroupOperation;
                case "IdMemorySemantics": return SpirvOperandKind.IdMemorySemantics;
                case "IdRef": return SpirvOperandKind.IdRef;
                case "IdResult": return SpirvOperandKind.IdResult;
                case "IdResultType": return SpirvOperandKind.IdResultType;
                case "IdScope": return SpirvOperandKind.IdScope;
                case "ImageChannelDataType": return SpirvOperandKind.ImageChannelDataType;
                case "ImageChannelOrder": return SpirvOperandKind.ImageChannelOrder;
                case "ImageFormat": return SpirvOperandKind.ImageFormat;
                case "ImageOperands": return SpirvOperandKind.ImageOperands;
                case "KernelEnqueueFlags": return SpirvOperandKind.KernelEnqueueFlags;
                case "KernelProfilingInfo": return SpirvOperandKind.KernelProfilingInfo;
                case "LinkageType": return SpirvOperandKind.LinkageType;
                case "LiteralContextDependentNumber": return SpirvOperandKind.LiteralContextDependentNumber;
                case "LiteralExtInstInteger": return SpirvOperandKind.LiteralExtInstInteger;
                case "LiteralInteger": return SpirvOperandKind.LiteralInteger;
                case "LiteralSpecConstantOpInteger": return SpirvOperandKind.LiteralSpecConstantOpInteger;
                case "LiteralString": return SpirvOperandKind.LiteralString;
                case "LoopControl": return SpirvOperandKind.LoopControl;
                case "MemoryAccess": return SpirvOperandKind.MemoryAccess;
                case "MemoryModel": return SpirvOperandKind.MemoryModel;
                case "MemorySemantics": return SpirvOperandKind.MemorySemantics;
                case "PairIdRefIdRef": return SpirvOperandKind.PairIdRefIdRef;
                case "PairIdRefLiteralInteger": return SpirvOperandKind.PairIdRefLiteralInteger;
                case "PairLiteralIntegerIdRef": return SpirvOperandKind.PairLiteralIntegerIdRef;
                case "RayFlags": return SpirvOperandKind.RayFlags;
                case "RayQueryCandidateIntersectionType": return SpirvOperandKind.RayQueryCandidateIntersectionType;
                case "RayQueryCommittedIntersectionType": return SpirvOperandKind.RayQueryCommittedIntersectionType;
                case "RayQueryIntersection": return SpirvOperandKind.RayQueryIntersection;
                case "SamplerAddressingMode": return SpirvOperandKind.SamplerAddressingMode;
                case "SamplerFilterMode": return SpirvOperandKind.SamplerFilterMode;
                case "Scope": return SpirvOperandKind.Scope;
                case "SelectionControl": return SpirvOperandKind.SelectionControl;
                case "SourceLanguage": return SpirvOperandKind.SourceLanguage;
                case "StorageClass": return SpirvOperandKind.StorageClass;
                default: throw new NotImplementedException(operandKind+" not supported");
            }
        }
    }
}