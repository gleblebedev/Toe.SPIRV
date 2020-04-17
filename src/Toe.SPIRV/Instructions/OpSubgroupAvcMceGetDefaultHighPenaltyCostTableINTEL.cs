using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSubgroupAvcMceGetDefaultHighPenaltyCostTableINTEL: InstructionWithId
    {
        public OpSubgroupAvcMceGetDefaultHighPenaltyCostTableINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpSubgroupAvcMceGetDefaultHighPenaltyCostTableINTEL; } }

        public Spv.IdRef IdResultType { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} ";
        }
    }
}
