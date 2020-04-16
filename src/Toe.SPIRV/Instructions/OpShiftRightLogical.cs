using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpShiftRightLogical: InstructionWithId
    {
        public OpShiftRightLogical()
        {
        }

        public override Op OpCode { get { return Op.OpShiftRightLogical; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef Base { get; set; }

        public Spv.IdRef Shift { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Base", Base);
            yield return new ReferenceProperty("Shift", Shift);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            Base = Spv.IdRef.Parse(reader, end-reader.Position);
            Shift = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += Base.GetWordCount();
            wordCount += Shift.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            Base.Write(writer);
            Shift.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Base} {Shift}";
        }
    }
}
