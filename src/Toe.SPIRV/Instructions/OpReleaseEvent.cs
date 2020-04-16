using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpReleaseEvent: Instruction
    {
        public OpReleaseEvent()
        {
        }

        public override Op OpCode { get { return Op.OpReleaseEvent; } }

        public Spv.IdRef Event { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Event", Event);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            Event = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += Event.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            Event.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {Event}";
        }
    }
}
