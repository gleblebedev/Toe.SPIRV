using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpImageSparseSampleDrefExplicitLod : InstructionWithId
    {
        public override Op OpCode => Op.OpImageSparseSampleDrefExplicitLod;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IdRef SampledImage { get; set; }
        public IdRef Coordinate { get; set; }
        public IdRef D_ref { get; set; }
        public ImageOperands ImageOperands { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("SampledImage", SampledImage);
            yield return new ReferenceProperty("Coordinate", Coordinate);
            yield return new ReferenceProperty("D_ref", D_ref);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            SampledImage = IdRef.Parse(reader, end - reader.Position);
            Coordinate = IdRef.Parse(reader, end - reader.Position);
            D_ref = IdRef.Parse(reader, end - reader.Position);
            ImageOperands = ImageOperands.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {SampledImage} {Coordinate} {D_ref} {ImageOperands}";
        }
    }
}