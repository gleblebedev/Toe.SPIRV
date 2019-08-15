using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public partial class OpTypeArray : TypeInstruction
    {
        public override Op OpCode => Op.OpTypeArray;

        public IdRef ElementType { get; set; }
        public IdRef Length { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("ElementType", ElementType);
            yield return new ReferenceProperty("Length", Length);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            ElementType = IdRef.Parse(reader, end - reader.Position);
            Length = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResult} = {OpCode} {ElementType} {Length}";
        }
    }
}