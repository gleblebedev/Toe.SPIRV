using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpGroupWaitEvents: Instruction
    {
        public OpGroupWaitEvents()
        {
        }

        public override Op OpCode { get { return Op.OpGroupWaitEvents; } }

        public uint Execution { get; set; }

        public Spv.IdRef NumEvents { get; set; }

        public Spv.IdRef EventsList { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("NumEvents", NumEvents);
            yield return new ReferenceProperty("EventsList", EventsList);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            Execution = Spv.IdScope.Parse(reader, end-reader.Position);
            NumEvents = Spv.IdRef.Parse(reader, end-reader.Position);
            EventsList = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += Execution.GetWordCount();
            wordCount += NumEvents.GetWordCount();
            wordCount += EventsList.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            Execution.Write(writer);
            NumEvents.Write(writer);
            EventsList.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {Execution} {NumEvents} {EventsList}";
        }
    }
}
