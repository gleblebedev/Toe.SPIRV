using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpGroupDecorate: Instruction
    {
        public OpGroupDecorate()
        {
        }

        public override Op OpCode { get { return Op.OpGroupDecorate; } }

        public Spv.IdRef DecorationGroup { get; set; }
        public IList<Spv.IdRef> Targets { get; set; }
        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("DecorationGroup", DecorationGroup);
            for (int i=0; i<Targets.Count; ++i)
                yield return new ReferenceProperty("Targets"+i, Targets[i]);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            DecorationGroup = Spv.IdRef.Parse(reader, end-reader.Position);
            Targets = Spv.IdRef.ParseCollection(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += DecorationGroup.GetWordCount();
            wordCount += Targets.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            DecorationGroup.Write(writer);
            Targets.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {DecorationGroup} {Targets}";
        }
    }
}
