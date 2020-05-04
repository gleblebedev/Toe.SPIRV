using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toe.SPIRV.CodeGenerator.Model.Grammar;

namespace Toe.SPIRV.CodeGenerator.Views
{
    public partial class NestedInstruction
    {
        private readonly IList<SpirvInstruction> _instructions;

        public NestedInstruction(IEnumerable<SpirvInstruction> instructions)
        {
            _instructions = instructions.ToList();
        }
    }
    public partial class TypeTemplate
    {
        private SpirvInstruction _instruction;
        private string name;
        public TypeTemplate(SpirvInstruction instruction)
        {
            _instruction = instruction;
            name = _instruction.Name.Substring(2);
        }
    }
    public partial class NodeTemplate
    {
        private readonly SpirvInstruction _instruction;
        private readonly string opname;
        private readonly string name;
        private readonly string baseClass;
        private List<KeyValuePair<string, string>> _operands;

        public NodeTemplate(SpirvInstruction instruction)
        {
            _instruction = instruction;
            opname = _instruction.Name;
            switch (instruction.Kind)
            {
                case InstructionKind.Type:
                    baseClass = "SpirvTypeBase";
                    name = _instruction.Name.Substring(2);
                    break;
                default:
                    baseClass = _instruction.HasDefaultEnter ? "ExecutableNode" : "Node";
                    name = _instruction.Name.Substring(2);
                    break;
            }

            _operands = new List<KeyValuePair<string, string>>(_instruction.Operands.Count+1);
            if (_instruction.IdResultType != null)
                _operands.Add(new KeyValuePair<string, string>("ResultType", "SpirvTypeBase"));
            _operands.AddRange(_instruction.Operands.Select(MakeOperandKeyValue));
        }

        private KeyValuePair<string, string> MakeOperandKeyValue(SpirvOperand op)
        {
            switch (op.Class)
            {
                case SpirvOperandClassification.Type:
                    return new KeyValuePair<string, string>(op.Name, "SpirvTypeBase");
                case SpirvOperandClassification.Exit:
                case SpirvOperandClassification.Input:
                    return new KeyValuePair<string, string>(op.Name, GetNodeType(op));
                case SpirvOperandClassification.RepeatedInput:
                    return new KeyValuePair<string, string>(op.Name, $"IEnumerable<{GetNodeType(op)}>");
                default:
                    return new KeyValuePair<string, string>(op.Name, GetPropertyType(op));
            }
        }

        public static string GetNodeType(SpirvOperand operand)
        {
            if (!string.IsNullOrWhiteSpace(operand.OperandType))
                return operand.OperandType.Substring(2);
            return "Node";
        }
        public static string CastNodeType(SpirvOperand operand)
        {
            var t = GetNodeType(operand);
            if (t == "Node")
                return "";
            return "("+t+")";
        }


        public static string GetPropertyType(SpirvOperand op)
        {
            var baseType = GetBasePropertyType(op);
            switch (baseType)
            {
                case "Spv.LiteralContextDependentNumber":
                    baseType = "Operands.NumberLiteral";
                    break;
                case "Spv.PairLiteralIntegerIdRef":
                    baseType = "Operands.PairLiteralIntegerNode";
                    break;
                case "Spv.PairIdRefLiteralInteger":
                    baseType = "Operands.PairNodeLiteralInteger";
                    break;
                case "Spv.PairIdRefIdRef":
                    baseType = "Operands.PairNodeNode";
                    break;
            }
            switch (op.Quantifier)
            {
                case SpirvOperandQuantifier.Required:
                    return baseType;
                case SpirvOperandQuantifier.Optional:
                    if (baseType == "uint")
                        return "uint?";
                    return baseType;
                case SpirvOperandQuantifier.Repeated:
                    return "IList<"+baseType+">";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private static string GetBasePropertyType(SpirvOperand op)
        {
            switch (op.Category)
            {
                case SpirvOperandCategory.Id:
                    return "uint";
                case SpirvOperandCategory.BitEnum:
                case SpirvOperandCategory.ValueEnum:
                    return "Spv."+op.Kind;
                case SpirvOperandCategory.Composite:
                    switch (op.Kind)
                    {
                        case SpirvOperandKind.PairIdRefLiteralInteger:
                            return "Spv.PairIdRefLiteralInteger";
                        case SpirvOperandKind.PairIdRefIdRef:
                            return "Spv.PairIdRefIdRef";
                        case SpirvOperandKind.PairLiteralIntegerIdRef:
                            return "Spv.PairLiteralIntegerIdRef";
                    }
                    return "object";
                case SpirvOperandCategory.Literal:
                    if (op.Kind == SpirvOperandKind.LiteralExtInstInteger)
                        return "uint";
                    if (op.Kind == SpirvOperandKind.LiteralSpecConstantOpInteger)
                        return "NestedNode";
                    if (op.Kind == SpirvOperandKind.LiteralInteger)
                        return "uint";
                    if (op.Kind == SpirvOperandKind.LiteralString)
                        return "string";
                    if (op.Kind == SpirvOperandKind.LiteralContextDependentNumber)
                        return "Spv." + op.Kind;
                    break;
            }
            return "object";
        }
    }
    public partial class ShaderToScriptConverterTemplate
    {
        private readonly SpirvInstructions _grammar;

        public ShaderToScriptConverterTemplate(SpirvInstructions grammar)
        {
            _grammar = grammar;
        }

        private string GetNodeCategory(SpirvInstruction instruction)
        {
            /*
            Unknown,
            Function,
            Converter,
            Procedure,
            Event,
            Parameter,
            Value,
            Result
            */
            if (instruction.Name == "OpConstant")
            {
                return "Value";
            }
            if (instruction.Name == "OpReturn" || instruction.Name == "OpReturnValue")
            {
                return "Result";
            }
            if (instruction.Name == "OpFunctionParameter" || instruction.Name == "OpVariable")
            {
                return "Parameter";
            }
            if (instruction.HasDefaultExit)
            {
                return "Procedure";
            }
            if (instruction.IdResultType != null)
            {
                return "Function";
            }
            return "Unknown";
        }
    }

    public partial class SpirvInstructionsBuilderTemplate
    {
        private readonly SpirvInstructions _grammar;

        public SpirvInstructionsBuilderTemplate(SpirvInstructions grammar)
        {
            _grammar = grammar;
        }
    }

    public partial class NodeVisitor
    {
        private readonly SpirvInstructions _grammar;

        public NodeVisitor(SpirvInstructions grammar)
        {
            _grammar = grammar;
        }
    }

    public partial class EnumTemplate
    {
        private readonly SpirvOperandDescription _operand;

        public EnumTemplate(SpirvOperandDescription operand)
        {
            _operand = operand;
        }
    }
    public partial class FlagTemplate
    {
        private readonly SpirvOperandDescription _operand;

        public FlagTemplate(SpirvOperandDescription operand)
        {
            _operand = operand;
        }
    }

    public partial class InstructionTemplate
    {
        private readonly SpirvInstruction _instruction;

        public InstructionTemplate(SpirvInstruction instruction)
        {
            _instruction = instruction;
        }

        public static string GetOperandParser(SpirvOperand operand)
        {
            if (operand.Kind == SpirvOperandKind.LiteralContextDependentNumber)
            {
                return "Spv." + operand.Kind + ".ParseOptional(reader, end-reader.Position, IdResultType.Instruction)";
            }
            if (operand.Quantifier == SpirvOperandQuantifier.Optional)
                return "Spv." + operand.Kind + ".ParseOptional(reader, end-reader.Position)";
            if (operand.Quantifier == SpirvOperandQuantifier.Repeated)
                return "Spv." + operand.Kind + ".ParseCollection(reader, end-reader.Position)";
            return "Spv." + operand.Kind + ".Parse(reader, end-reader.Position)";
        }

        public static string GetOperandType(SpirvOperand operand)
        {
            var type = ViewUtils.GetTypeName(operand.Kind);
            if (operand.Quantifier == SpirvOperandQuantifier.Optional)
            {
                if (type == "uint")
                    return "uint?";
                if (type == "Spv.Op")
                    return "Spv.Op?";
                return type;
            }
            if (operand.Quantifier == SpirvOperandQuantifier.Repeated)
            {
                return "IList<" + type + ">";
            }

            return type;
        }
    }
}
