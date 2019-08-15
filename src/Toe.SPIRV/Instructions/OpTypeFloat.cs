using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public partial class OpTypeFloat : TypeInstruction
    {
        public override Op OpCode => Op.OpTypeFloat;

        public uint Width { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Width = LiteralInteger.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResult} = {OpCode} {Width}";
        }
    }
}