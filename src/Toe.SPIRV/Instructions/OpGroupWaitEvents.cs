using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpGroupWaitEvents : Instruction
    {
        public override Op OpCode => Op.OpGroupWaitEvents;

        public uint Execution { get; set; }
        public IdRef NumEvents { get; set; }
        public IdRef EventsList { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("NumEvents", NumEvents);
            yield return new ReferenceProperty("EventsList", EventsList);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            Execution = IdScope.Parse(reader, end - reader.Position);
            NumEvents = IdRef.Parse(reader, end - reader.Position);
            EventsList = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {Execution} {NumEvents} {EventsList}";
        }
    }
}