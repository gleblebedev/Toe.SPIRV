using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public partial class OpTypeMatrix : TypeInstruction
    {
        public override Op OpCode => Op.OpTypeMatrix;

        public IdRef ColumnType { get; set; }
        public uint ColumnCount { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("ColumnType", ColumnType);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            ColumnType = IdRef.Parse(reader, end - reader.Position);
            ColumnCount = LiteralInteger.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResult} = {OpCode} {ColumnType} {ColumnCount}";
        }
    }
}