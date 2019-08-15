using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpTypeImage : TypeInstruction
    {
        public override Op OpCode => Op.OpTypeImage;

        public IdRef SampledType { get; set; }
        public Dim Dim { get; set; }
        public uint Depth { get; set; }
        public uint Arrayed { get; set; }
        public uint MS { get; set; }
        public uint Sampled { get; set; }
        public ImageFormat ImageFormat { get; set; }
        public AccessQualifier AccessQualifier { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("SampledType", SampledType);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            SampledType = IdRef.Parse(reader, end - reader.Position);
            Dim = Dim.Parse(reader, end - reader.Position);
            Depth = LiteralInteger.Parse(reader, end - reader.Position);
            Arrayed = LiteralInteger.Parse(reader, end - reader.Position);
            MS = LiteralInteger.Parse(reader, end - reader.Position);
            Sampled = LiteralInteger.Parse(reader, end - reader.Position);
            ImageFormat = ImageFormat.Parse(reader, end - reader.Position);
            AccessQualifier = AccessQualifier.ParseOptional(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return
                $"{IdResult} = {OpCode} {SampledType} {Dim} {Depth} {Arrayed} {MS} {Sampled} {ImageFormat} {AccessQualifier}";
        }
    }
}