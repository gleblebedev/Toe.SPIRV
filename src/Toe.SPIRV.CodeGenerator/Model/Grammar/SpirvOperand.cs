namespace Toe.SPIRV.CodeGenerator.Model.Grammar
{
    public class SpirvOperand
    {
        public SpirvOperandKind Kind { get; set; }
        
        public string SpirvName { get; set; }

        public string Name { get; set; }

        public SpirvOperandQuantifier Quantifier { get; set; }
    }
    
}