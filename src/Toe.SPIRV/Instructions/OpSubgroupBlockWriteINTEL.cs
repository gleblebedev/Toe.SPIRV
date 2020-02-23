using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSubgroupBlockWriteINTEL: Instruction
    {
        public OpSubgroupBlockWriteINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpSubgroupBlockWriteINTEL; } }

        public Spv.IdRef Ptr { get; set; }
        public Spv.IdRef Data { get; set; }
        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Ptr", Ptr);
            yield return new ReferenceProperty("Data", Data);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            Ptr = Spv.IdRef.Parse(reader, end-reader.Position);
            Data = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += Ptr.GetWordCount();
            wordCount += Data.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            Ptr.Write(writer);
            Data.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {Ptr} {Data}";
        }
    }
}
