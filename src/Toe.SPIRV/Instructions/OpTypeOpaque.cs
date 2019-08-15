using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpTypeOpaque : TypeInstruction
    {
        public override Op OpCode => Op.OpTypeOpaque;

        public string Thenameoftheopaquetype { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Thenameoftheopaquetype = LiteralString.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResult} = {OpCode} {Thenameoftheopaquetype}";
        }
    }
}