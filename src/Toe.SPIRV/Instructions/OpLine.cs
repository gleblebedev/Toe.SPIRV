using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpLine : Instruction
    {
        public override Op OpCode => Op.OpLine;

        public IdRef File { get; set; }
        public uint Line { get; set; }
        public uint Column { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("File", File);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            File = IdRef.Parse(reader, end - reader.Position);
            Line = LiteralInteger.Parse(reader, end - reader.Position);
            Column = LiteralInteger.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {File} {Line} {Column}";
        }
    }
}