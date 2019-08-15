using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpSetUserEventStatus : Instruction
    {
        public override Op OpCode => Op.OpSetUserEventStatus;

        public IdRef Event { get; set; }
        public IdRef Status { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Event", Event);
            yield return new ReferenceProperty("Status", Status);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            Event = IdRef.Parse(reader, end - reader.Position);
            Status = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {Event} {Status}";
        }
    }
}