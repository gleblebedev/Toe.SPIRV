using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpTypeImage: TypeInstruction
    {
        public OpTypeImage()
        {
        }

        public override Op OpCode { get { return Op.OpTypeImage; } }

        public Spv.IdRef SampledType { get; set; }
        public Spv.Dim Dim { get; set; }
        public uint Depth { get; set; }
        public uint Arrayed { get; set; }
        public uint MS { get; set; }
        public uint Sampled { get; set; }
        public Spv.ImageFormat ImageFormat { get; set; }
        public Spv.AccessQualifier AccessQualifier { get; set; }
        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("SampledType", SampledType);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            SampledType = Spv.IdRef.Parse(reader, end-reader.Position);
            Dim = Spv.Dim.Parse(reader, end-reader.Position);
            Depth = Spv.LiteralInteger.Parse(reader, end-reader.Position);
            Arrayed = Spv.LiteralInteger.Parse(reader, end-reader.Position);
            MS = Spv.LiteralInteger.Parse(reader, end-reader.Position);
            Sampled = Spv.LiteralInteger.Parse(reader, end-reader.Position);
            ImageFormat = Spv.ImageFormat.Parse(reader, end-reader.Position);
            AccessQualifier = Spv.AccessQualifier.ParseOptional(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResult.GetWordCount();
            wordCount += SampledType.GetWordCount();
            wordCount += Dim.GetWordCount();
            wordCount += Depth.GetWordCount();
            wordCount += Arrayed.GetWordCount();
            wordCount += MS.GetWordCount();
            wordCount += Sampled.GetWordCount();
            wordCount += ImageFormat.GetWordCount();
            wordCount += AccessQualifier?.GetWordCount() ?? (uint)0;
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResult.Write(writer);
            SampledType.Write(writer);
            Dim.Write(writer);
            Depth.Write(writer);
            Arrayed.Write(writer);
            MS.Write(writer);
            Sampled.Write(writer);
            ImageFormat.Write(writer);
            if (AccessQualifier != null) AccessQualifier.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResult} = {OpCode} {SampledType} {Dim} {Depth} {Arrayed} {MS} {Sampled} {ImageFormat} {AccessQualifier}";
        }
    }
}
