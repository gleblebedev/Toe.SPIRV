using System.Collections.Generic;

namespace Toe.SPIRV.CodeGenerator.Model.Spv
{
    public partial class Instruction
    {
        public string opname { get; set; }
        public int opcode { get; set; }
        public List<Operand> operands { get; } = new List<Operand>();
        public List<string> capabilities { get; set; }
        public List<string> extensions { get; set; }
    }
}