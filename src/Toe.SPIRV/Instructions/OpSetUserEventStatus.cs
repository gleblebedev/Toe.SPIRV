using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSetUserEventStatus: Instruction
    {
        public OpSetUserEventStatus()
        {
        }

        public override Op OpCode { get { return Op.OpSetUserEventStatus; } }

        public Spv.IdRef Event { get; set; }
        public Spv.IdRef Status { get; set; }
        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Event", Event);
            yield return new ReferenceProperty("Status", Status);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            Event = Spv.IdRef.Parse(reader, end-reader.Position);
            Status = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += Event.GetWordCount();
            wordCount += Status.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            Event.Write(writer);
            Status.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {Event} {Status}";
        }
    }
}
