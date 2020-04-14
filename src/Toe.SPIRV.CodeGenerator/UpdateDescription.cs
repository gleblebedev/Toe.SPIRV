using System;
using Toe.SPIRV.CodeGenerator.Model.Grammar;
using Toe.SPIRV.CodeGenerator.Model.Spv;

namespace Toe.SPIRV.CodeGenerator
{
    public class UpdateDescription
    {
        private Operands _operands;
        private SpirvInstructions _grammar;

        public void Run(UpdateDescriptionOptions options)
        {
            _operands =  Utils.LoadOperands(options.Input);

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
            Utils.SaveGrammar(options.Output, _grammar);
        }

        private SpirvInstruction CreateInstruction(Instruction instruction)
        {
            var spirvInstruction = new SpirvInstruction()
            {
                Name = instruction.opname,
                OpCode = instruction.opcode,
            };
            if (instruction.capabilities != null)
                spirvInstruction.Capabilities.AddRange(instruction.capabilities);
            if (instruction.extensions != null)
                spirvInstruction.Extensions.AddRange(instruction.extensions);

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
                        spirvInstruction.Operands.Add(spirvOperand);
                        break;
                }
            }

            spirvInstruction.Kind = EvaluateInstructionKind(spirvInstruction);

            return spirvInstruction;
        }

        private InstructionKind EvaluateInstructionKind(SpirvInstruction spirvInstruction)
        {
            if (spirvInstruction.Name.StartsWith("OpType"))
                return InstructionKind.Type;
            if (spirvInstruction.Name == "OpFunction")
                return InstructionKind.Executable;
            if (spirvInstruction.Name == "OpFunctionCall")
                return InstructionKind.Executable;
            if (spirvInstruction.IdResultType != null)
                return InstructionKind.Function;
            if (spirvInstruction.OpCode <= 40)
                return InstructionKind.Other;
            return InstructionKind.Executable;
        }

        private SpirvOperand CreateOperand(Instruction instruction, Operand operand)
        {
            var spirvOperand = new SpirvOperand()
            {
                Kind = GetKind(operand.kind),
                SpirvName = operand.name,
                Quantifier = GetQuantifier(operand.quantifier)
            };
            spirvOperand.Name = GetOperandName(spirvOperand);
            spirvOperand.Class = GetOperandClass(instruction, spirvOperand);
            return spirvOperand;
        }

        private SpirvOperandClassification GetOperandClass(Instruction instruction, SpirvOperand spirvOperand)
        {
            if (spirvOperand.Kind == SpirvOperandKind.IdRef)
            {
                switch (instruction.opname)
                {
                    case "OpFunction":
                        if (spirvOperand.Name == "FunctionType")
                            return SpirvOperandClassification.Type;
                        break;
                    case "OpSelectionMerge":
                        if (spirvOperand.Name == "MergeBlock")
                            return SpirvOperandClassification.Exit;
                        break;
                    case "OpBranchConditional":
                        if (spirvOperand.Name == "TrueLabel")
                            return SpirvOperandClassification.Exit;
                        if (spirvOperand.Name == "FalseLabel")
                            return SpirvOperandClassification.Exit;
                        break;
                    case "OpBranch":
                        if (spirvOperand.Name == "TargetLabel")
                            return SpirvOperandClassification.Exit;
                        break;
                }
                if (spirvOperand.Quantifier == SpirvOperandQuantifier.Repeated)
                    return SpirvOperandClassification.RepeatedInput;
                return SpirvOperandClassification.Input;
            }

            return SpirvOperandClassification.Other;
        }

        private string GetOperandName(SpirvOperand spirvOperand)
        {
            if (spirvOperand.SpirvName == null)
                return spirvOperand.Kind.ToString();
            var name = spirvOperand.SpirvName;
            name = name.Trim('\'').Trim('.');
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
                case "IdResultType": return SpirvOperandKind.IdResultType;
                case "IdResult": return SpirvOperandKind.IdResult;
                case "LiteralString": return SpirvOperandKind.LiteralString;
                case "SourceLanguage": return SpirvOperandKind.SourceLanguage;
                case "LiteralInteger": return SpirvOperandKind.LiteralInteger;
                case "IdRef": return SpirvOperandKind.IdRef;
                case "LiteralExtInstInteger": return SpirvOperandKind.LiteralExtInstInteger;
                case "AddressingModel": return SpirvOperandKind.AddressingModel;
                case "MemoryModel": return SpirvOperandKind.MemoryModel;
                case "ExecutionModel": return SpirvOperandKind.ExecutionModel;
                case "ExecutionMode": return SpirvOperandKind.ExecutionMode;
                case "Capability": return SpirvOperandKind.Capability;
                case "Dim": return SpirvOperandKind.Dim;
                case "ImageFormat": return SpirvOperandKind.ImageFormat;
                case "AccessQualifier": return SpirvOperandKind.AccessQualifier;
                case "StorageClass": return SpirvOperandKind.StorageClass;
                case "LiteralContextDependentNumber": return SpirvOperandKind.LiteralContextDependentNumber;
                case "SamplerAddressingMode": return SpirvOperandKind.SamplerAddressingMode;
                case "SamplerFilterMode": return SpirvOperandKind.SamplerFilterMode;
                case "LiteralSpecConstantOpInteger": return SpirvOperandKind.LiteralSpecConstantOpInteger;
                case "FunctionControl": return SpirvOperandKind.FunctionControl;
                case "MemoryAccess": return SpirvOperandKind.MemoryAccess;
                case "Decoration": return SpirvOperandKind.Decoration;
                case "PairIdRefLiteralInteger": return SpirvOperandKind.PairIdRefLiteralInteger;
                case "ImageOperands": return SpirvOperandKind.ImageOperands;
                case "IdScope": return SpirvOperandKind.IdScope;
                case "IdMemorySemantics": return SpirvOperandKind.IdMemorySemantics;
                case "PairIdRefIdRef": return SpirvOperandKind.PairIdRefIdRef;
                case "LoopControl": return SpirvOperandKind.LoopControl;
                case "SelectionControl": return SpirvOperandKind.SelectionControl;
                case "PairLiteralIntegerIdRef": return SpirvOperandKind.PairLiteralIntegerIdRef;
                case "GroupOperation": return SpirvOperandKind.GroupOperation;
                default: throw new NotImplementedException(operandKind+" not supported");
            }
        }
    }
}