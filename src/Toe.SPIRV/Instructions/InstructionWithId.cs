using System.Collections.Generic;

namespace Toe.SPIRV.Instructions
{
    public abstract class InstructionWithId : Instruction
    {
        public uint IdResult { get; set; }

        public OpName OpName { get; set; }

        public IList<OpDecorate> Decorations { get; } = new List<OpDecorate>();

        public override bool TryGetResultId(out uint id)
        {
            id = IdResult;
            return true;
        }
    }
}