namespace Toe.SPIRV.Instructions
{
    public abstract class InstructionWithId : Instruction
    {
        public uint IdResult { get; set; }

        public override bool TryGetResultId(out uint id)
        {
            id = IdResult;
            return true;
        }
    }
}