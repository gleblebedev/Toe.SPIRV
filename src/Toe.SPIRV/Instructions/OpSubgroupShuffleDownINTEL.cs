using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSubgroupShuffleDownINTEL: InstructionWithId
    {
        public OpSubgroupShuffleDownINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpSubgroupShuffleDownINTEL; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef Current { get; set; }

        public Spv.IdRef Next { get; set; }

        public Spv.IdRef Delta { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Current", Current);
            yield return new ReferenceProperty("Next", Next);
            yield return new ReferenceProperty("Delta", Delta);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            Current = Spv.IdRef.Parse(reader, end-reader.Position);
            Next = Spv.IdRef.Parse(reader, end-reader.Position);
            Delta = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += Current.GetWordCount();
            wordCount += Next.GetWordCount();
            wordCount += Delta.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            Current.Write(writer);
            Next.Write(writer);
            Delta.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Current} {Next} {Delta}";
        }
    }
}
