using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public partial class OpTypeVector : TypeInstruction
    {
        public override Op OpCode => Op.OpTypeVector;

        public IdRef ComponentType { get; set; }
        public uint ComponentCount { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("ComponentType", ComponentType);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            ComponentType = IdRef.Parse(reader, end - reader.Position);
            ComponentCount = LiteralInteger.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResult} = {OpCode} {ComponentType} {ComponentCount}";
        }
    }
}