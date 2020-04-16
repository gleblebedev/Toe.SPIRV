using Toe.SPIRV.CodeGenerator.Model.Grammar;

namespace Toe.SPIRV.CodeGenerator.Views
{
    public class ViewUtils
    {
        public static string GetTypeName(SpirvOperandKind kind)
        {
            if (kind == SpirvOperandKind.IdResultType)
                return "Spv.IdRef";
            if (kind == SpirvOperandKind.IdRef)
                return "Spv.IdRef";
            if (IsId(kind))
                return "uint";
            switch (kind)
            {
                case SpirvOperandKind.LiteralExtInstInteger:
                case SpirvOperandKind.LiteralInteger:
                case SpirvOperandKind.LiteralSpecConstantOpInteger:
                    return "uint";
                case SpirvOperandKind.LiteralString:
                    return "string";
                default:
                    return "Spv." + kind;

            }
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
        public static bool IsId(SpirvOperandKind kind)
        {
            switch (kind)
            {
                case SpirvOperandKind.IdResultType:
                case SpirvOperandKind.IdResult:
                case SpirvOperandKind.IdMemorySemantics:
                case SpirvOperandKind.IdScope:
                case SpirvOperandKind.IdRef:
                    return true;
            }
            return false;
        }
    }
}