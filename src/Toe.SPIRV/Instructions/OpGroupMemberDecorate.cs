using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpGroupMemberDecorate: Instruction
    {
        public OpGroupMemberDecorate()
        {
        }

        public override Op OpCode { get { return Op.OpGroupMemberDecorate; } }

        public Spv.IdRef DecorationGroup { get; set; }

        public IList<Spv.PairIdRefLiteralInteger> Targets { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("DecorationGroup", DecorationGroup);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            DecorationGroup = Spv.IdRef.Parse(reader, end-reader.Position);
            Targets = Spv.PairIdRefLiteralInteger.ParseCollection(reader, end-reader.Position);
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
