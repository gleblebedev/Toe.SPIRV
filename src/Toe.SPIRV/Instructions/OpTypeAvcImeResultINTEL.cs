using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpTypeAvcImeResultINTEL: TypeInstruction
    {
        public OpTypeAvcImeResultINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpTypeAvcImeResultINTEL; } }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResult.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResult.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResult} = {OpCode} ";
        }
    }
}
