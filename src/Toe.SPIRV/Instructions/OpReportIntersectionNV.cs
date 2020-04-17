using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpReportIntersectionNV: InstructionWithId
    {
        public OpReportIntersectionNV()
        {
        }

        public override Op OpCode { get { return Op.OpReportIntersectionNV; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef Hit { get; set; }

        public Spv.IdRef HitKind { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Hit", Hit);
            yield return new ReferenceProperty("HitKind", HitKind);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            Hit = Spv.IdRef.Parse(reader, end-reader.Position);
            HitKind = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += Hit.GetWordCount();
            wordCount += HitKind.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            Hit.Write(writer);
            HitKind.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Hit} {HitKind}";
        }
    }
}
