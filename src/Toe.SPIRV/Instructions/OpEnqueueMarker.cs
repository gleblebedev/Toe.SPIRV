using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpEnqueueMarker : InstructionWithId
    {
        public override Op OpCode => Op.OpEnqueueMarker;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IdRef Queue { get; set; }
        public IdRef NumEvents { get; set; }
        public IdRef WaitEvents { get; set; }
        public IdRef RetEvent { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Queue", Queue);
            yield return new ReferenceProperty("NumEvents", NumEvents);
            yield return new ReferenceProperty("WaitEvents", WaitEvents);
            yield return new ReferenceProperty("RetEvent", RetEvent);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Queue = IdRef.Parse(reader, end - reader.Position);
            NumEvents = IdRef.Parse(reader, end - reader.Position);
            WaitEvents = IdRef.Parse(reader, end - reader.Position);
            RetEvent = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Queue} {NumEvents} {WaitEvents} {RetEvent}";
        }
    }
}