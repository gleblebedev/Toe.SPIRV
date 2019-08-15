using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpTypeSampler : TypeInstruction
    {
        public override Op OpCode => Op.OpTypeSampler;

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
        }

        public override string ToString()
        {
            return $"{IdResult} = {OpCode} ";
        }
    }
}