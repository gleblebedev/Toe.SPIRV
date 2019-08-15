using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpImageQuerySizeLod : InstructionWithId
    {
        public override Op OpCode => Op.OpImageQuerySizeLod;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IdRef Image { get; set; }
        public IdRef LevelofDetail { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Image", Image);
            yield return new ReferenceProperty("LevelofDetail", LevelofDetail);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Image = IdRef.Parse(reader, end - reader.Position);
            LevelofDetail = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Image} {LevelofDetail}";
        }
    }
}