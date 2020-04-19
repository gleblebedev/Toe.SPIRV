using System.Collections.Generic;

namespace Toe.SPIRV.CodeGenerator.Model.Grammar
{
    public class SpirvInstruction
    {
        public InstructionKind Kind { get; set; }
        public string Name { get; set; }
        public int OpCode { get; set; }
        public List<string> Capabilities { get; } = new List<string>();
        public List<string> Extensions { get; } = new List<string>();

        public SpirvOperand IdResult { get; set; }
        public SpirvOperand IdResultType { get; set; }

        public List<SpirvOperand> Operands { get; } = new List<SpirvOperand>();
        public bool LastInstructionInABlock { get; set; }
        public bool HasDefaultEnter { get; set; }
        public bool HasDefaultExit { get; set; }
        public InstructionClass Class { get; set; } = InstructionClass.Unknown;

        public IEnumerable<SpirvOperand> AllOperands()
        {
            if (IdResultType != null)
                yield return IdResultType;
            if (IdResult != null)
                yield return IdResult;
            foreach (var operand in Operands)
            {
                yield return operand;
            }
        }

        public override string ToString()
        {
            return Name ?? OpCode.ToString();
        }
    }
}