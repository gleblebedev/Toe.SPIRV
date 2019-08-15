using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpCaptureEventProfilingInfo : Instruction
    {
        public override Op OpCode => Op.OpCaptureEventProfilingInfo;

        public IdRef Event { get; set; }
        public IdRef ProfilingInfo { get; set; }
        public IdRef Value { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Event", Event);
            yield return new ReferenceProperty("ProfilingInfo", ProfilingInfo);
            yield return new ReferenceProperty("Value", Value);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            Event = IdRef.Parse(reader, end - reader.Position);
            ProfilingInfo = IdRef.Parse(reader, end - reader.Position);
            Value = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {Event} {ProfilingInfo} {Value}";
        }
    }
}