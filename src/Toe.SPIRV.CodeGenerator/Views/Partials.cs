using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toe.SPIRV.CodeGenerator.Model.Grammar;

namespace Toe.SPIRV.CodeGenerator.Views
{
    public partial class NodeTemplate
    {
        private readonly SpirvInstruction _instruction;
        private readonly string opname;
        private readonly string name;
        private readonly string baseClass;

        public string GetNodeType(SpirvOperand operand)
        {
            if (!string.IsNullOrWhiteSpace(operand.OperandType))
                return operand.OperandType.Substring(2);
            return "Node";
        }
        public string CastNodeType(SpirvOperand operand)
        {
            var t = GetNodeType(operand);
            if (t == "Node")
                return "";
            return "("+t+")";
        }
        public NodeTemplate(SpirvInstruction instruction)
        {
            _instruction = instruction;
            opname = _instruction.Name;
            name = _instruction.Name.Substring(2);
            baseClass = _instruction.HasDefaultEnter ? "ExecutableNode" : "Node";
        }

        private string GetPropertyType(SpirvOperand op)
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
        private string GetBasePropertyType(SpirvOperand op)
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
}
