using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpMemberName : Instruction
    {
        public override Op OpCode => Op.OpMemberName;

        public IdRef Type { get; set; }
        public uint Member { get; set; }
        public string Name { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Type", Type);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            Type = IdRef.Parse(reader, end - reader.Position);
            Member = LiteralInteger.Parse(reader, end - reader.Position);
            Name = LiteralString.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {Type} {Member} {Name}";
        }
    }
}