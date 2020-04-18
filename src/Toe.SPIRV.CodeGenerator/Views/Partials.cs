using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toe.SPIRV.CodeGenerator.Model.Grammar;

namespace Toe.SPIRV.CodeGenerator.Views
{
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
                        return "uint";
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
