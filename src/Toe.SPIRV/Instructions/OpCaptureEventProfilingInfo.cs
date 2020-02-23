using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpCaptureEventProfilingInfo: Instruction
    {
        public OpCaptureEventProfilingInfo()
        {
        }

        public override Op OpCode { get { return Op.OpCaptureEventProfilingInfo; } }

        public Spv.IdRef Event { get; set; }
        public Spv.IdRef ProfilingInfo { get; set; }
        public Spv.IdRef Value { get; set; }
        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Event", Event);
            yield return new ReferenceProperty("ProfilingInfo", ProfilingInfo);
            yield return new ReferenceProperty("Value", Value);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            Event = Spv.IdRef.Parse(reader, end-reader.Position);
            ProfilingInfo = Spv.IdRef.Parse(reader, end-reader.Position);
            Value = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += Event.GetWordCount();
            wordCount += ProfilingInfo.GetWordCount();
            wordCount += Value.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            Event.Write(writer);
            ProfilingInfo.Write(writer);
            Value.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {Event} {ProfilingInfo} {Value}";
        }
    }
}
