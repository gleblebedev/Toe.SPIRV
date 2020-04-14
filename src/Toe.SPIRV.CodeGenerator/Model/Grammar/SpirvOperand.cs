namespace Toe.SPIRV.CodeGenerator.Model.Grammar
{
    public class SpirvOperand
    {
        public SpirvOperandKind Kind { get; set; }

        public SpirvOperandClassification Class { get; set; }

        public string SpirvName { get; set; }

        public string Name { get; set; }

        public SpirvOperandQuantifier Quantifier { get; set; }

        public string OperandType { get; set; }
        public SpirvOperandCategory Category { get; set; }

        public override string ToString()
        {
            return Name ?? SpirvName ?? base.ToString();
        }
    }
    
}