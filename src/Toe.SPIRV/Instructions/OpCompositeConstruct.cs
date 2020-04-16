using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpCompositeConstruct: InstructionWithId
    {
        public OpCompositeConstruct()
        {
        }

        public override Op OpCode { get { return Op.OpCompositeConstruct; } }

        public Spv.IdRef IdResultType { get; set; }

        public IList<Spv.IdRef> Constituents { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            for (int i=0; i<Constituents.Count; ++i)
                yield return new ReferenceProperty("Constituents"+i, Constituents[i]);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            Constituents = Spv.IdRef.ParseCollection(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += Constituents.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            Constituents.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Constituents}";
        }
    }
}
