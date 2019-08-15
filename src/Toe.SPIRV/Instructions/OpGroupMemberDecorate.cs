using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpGroupMemberDecorate : Instruction
    {
        public override Op OpCode => Op.OpGroupMemberDecorate;

        public IdRef DecorationGroup { get; set; }
        public IList<PairIdRefLiteralInteger> Targets { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("DecorationGroup", DecorationGroup);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            DecorationGroup = IdRef.Parse(reader, end - reader.Position);
            Targets = PairIdRefLiteralInteger.ParseCollection(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {DecorationGroup} {Targets}";
        }
    }
}