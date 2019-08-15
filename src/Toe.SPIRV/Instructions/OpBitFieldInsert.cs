using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpBitFieldInsert : InstructionWithId
    {
        public override Op OpCode => Op.OpBitFieldInsert;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IdRef Base { get; set; }
        public IdRef Insert { get; set; }
        public IdRef Offset { get; set; }
        public IdRef Count { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Base", Base);
            yield return new ReferenceProperty("Insert", Insert);
            yield return new ReferenceProperty("Offset", Offset);
            yield return new ReferenceProperty("Count", Count);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Base = IdRef.Parse(reader, end - reader.Position);
            Insert = IdRef.Parse(reader, end - reader.Position);
            Offset = IdRef.Parse(reader, end - reader.Position);
            Count = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Base} {Insert} {Offset} {Count}";
        }
    }
}