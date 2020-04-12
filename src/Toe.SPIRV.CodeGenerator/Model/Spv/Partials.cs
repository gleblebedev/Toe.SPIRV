namespace Toe.SPIRV.CodeGenerator.Model.Spv
{
    public partial class Enum
    {
        public override string ToString()
        {
            return Name ?? base.ToString();
        }
    }
    public partial class Instruction
    {
        public override string ToString()
        {
            return opname ?? base.ToString();
        }
    }

    public partial class OperandKind
    {
        public override string ToString()
        {
            return kind ?? base.ToString();
        }

    }
}