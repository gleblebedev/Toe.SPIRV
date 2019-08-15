using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpExecutionMode : Instruction
    {
        public override Op OpCode => Op.OpExecutionMode;

        public IdRef EntryPoint { get; set; }
        public ExecutionMode Mode { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("EntryPoint", EntryPoint);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            EntryPoint = IdRef.Parse(reader, end - reader.Position);
            Mode = ExecutionMode.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {EntryPoint} {Mode}";
        }
    }
}