using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpImageDrefGather: InstructionWithId
    {
        public OpImageDrefGather()
        {
        }

        public override Op OpCode { get { return Op.OpImageDrefGather; } }

        public Spv.IdRef<TypeInstruction> IdResultType { get; set; }
        public Spv.IdRef SampledImage { get; set; }
        public Spv.IdRef Coordinate { get; set; }
        public Spv.IdRef D_ref { get; set; }
        public Spv.ImageOperands ImageOperands { get; set; }
        public IList<Spv.IdRef> Operands { get; set; }
        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("SampledImage", SampledImage);
            yield return new ReferenceProperty("Coordinate", Coordinate);
            yield return new ReferenceProperty("D_ref", D_ref);
            for (int i=0; i<Operands.Count; ++i)
                yield return new ReferenceProperty("Operands"+i, Operands[i]);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            SampledImage = Spv.IdRef.Parse(reader, end-reader.Position);
            Coordinate = Spv.IdRef.Parse(reader, end-reader.Position);
            D_ref = Spv.IdRef.Parse(reader, end-reader.Position);
            ImageOperands = Spv.ImageOperands.ParseOptional(reader, end-reader.Position);
            Operands = Spv.IdRef.ParseCollection(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += SampledImage.GetWordCount();
            wordCount += Coordinate.GetWordCount();
            wordCount += D_ref.GetWordCount();
            wordCount += ImageOperands?.GetWordCount() ?? (uint)0;
            wordCount += Operands.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            SampledImage.Write(writer);
            Coordinate.Write(writer);
            D_ref.Write(writer);
            if (ImageOperands != null) ImageOperands.Write(writer);
            Operands.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {SampledImage} {Coordinate} {D_ref} {ImageOperands} {Operands}";
        }
    }
}
