using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSubgroupAvcImeRefWindowSizeINTEL: InstructionWithId
    {
        public OpSubgroupAvcImeRefWindowSizeINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpSubgroupAvcImeRefWindowSizeINTEL; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef SearchWindowConfig { get; set; }

        public Spv.IdRef DualRef { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("SearchWindowConfig", SearchWindowConfig);
            yield return new ReferenceProperty("DualRef", DualRef);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            SearchWindowConfig = Spv.IdRef.Parse(reader, end-reader.Position);
            DualRef = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += SearchWindowConfig.GetWordCount();
            wordCount += DualRef.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            SearchWindowConfig.Write(writer);
            DualRef.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {SearchWindowConfig} {DualRef}";
        }
    }
}