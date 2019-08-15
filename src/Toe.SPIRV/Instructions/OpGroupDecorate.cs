using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpGroupDecorate : Instruction
    {
        public override Op OpCode => Op.OpGroupDecorate;

        public IdRef DecorationGroup { get; set; }
        public IList<IdRef> Targets { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("DecorationGroup", DecorationGroup);
            for (var i = 0; i < Targets.Count; ++i)
                yield return new ReferenceProperty("Targets" + i, Targets[i]);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            DecorationGroup = IdRef.Parse(reader, end - reader.Position);
            Targets = IdRef.ParseCollection(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {DecorationGroup} {Targets}";
        }
    }
}