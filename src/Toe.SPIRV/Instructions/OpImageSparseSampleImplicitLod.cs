using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpImageSparseSampleImplicitLod : InstructionWithId
    {
        public override Op OpCode => Op.OpImageSparseSampleImplicitLod;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IdRef SampledImage { get; set; }
        public IdRef Coordinate { get; set; }
        public ImageOperands ImageOperands { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("SampledImage", SampledImage);
            yield return new ReferenceProperty("Coordinate", Coordinate);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            SampledImage = IdRef.Parse(reader, end - reader.Position);
            Coordinate = IdRef.Parse(reader, end - reader.Position);
            ImageOperands = ImageOperands.ParseOptional(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {SampledImage} {Coordinate} {ImageOperands}";
        }
    }
}