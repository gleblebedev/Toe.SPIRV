using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpGroupAsyncCopy: InstructionWithId
    {
        public OpGroupAsyncCopy()
        {
        }

        public override Op OpCode { get { return Op.OpGroupAsyncCopy; } }

        public Spv.IdRef IdResultType { get; set; }

        public uint Execution { get; set; }

        public Spv.IdRef Destination { get; set; }

        public Spv.IdRef Source { get; set; }

        public Spv.IdRef NumElements { get; set; }

        public Spv.IdRef Stride { get; set; }

        public Spv.IdRef Event { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Destination", Destination);
            yield return new ReferenceProperty("Source", Source);
            yield return new ReferenceProperty("NumElements", NumElements);
            yield return new ReferenceProperty("Stride", Stride);
            yield return new ReferenceProperty("Event", Event);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            Execution = Spv.IdScope.Parse(reader, end-reader.Position);
            Destination = Spv.IdRef.Parse(reader, end-reader.Position);
            Source = Spv.IdRef.Parse(reader, end-reader.Position);
            NumElements = Spv.IdRef.Parse(reader, end-reader.Position);
            Stride = Spv.IdRef.Parse(reader, end-reader.Position);
            Event = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += Execution.GetWordCount();
            wordCount += Destination.GetWordCount();
            wordCount += Source.GetWordCount();
            wordCount += NumElements.GetWordCount();
            wordCount += Stride.GetWordCount();
            wordCount += Event.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            Execution.Write(writer);
            Destination.Write(writer);
            Source.Write(writer);
            NumElements.Write(writer);
            Stride.Write(writer);
            Event.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Execution} {Destination} {Source} {NumElements} {Stride} {Event}";
        }
    }
}
