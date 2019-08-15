using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpGroupAsyncCopy : InstructionWithId
    {
        public override Op OpCode => Op.OpGroupAsyncCopy;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public uint Execution { get; set; }
        public IdRef Destination { get; set; }
        public IdRef Source { get; set; }
        public IdRef NumElements { get; set; }
        public IdRef Stride { get; set; }
        public IdRef Event { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Destination", Destination);
            yield return new ReferenceProperty("Source", Source);
            yield return new ReferenceProperty("NumElements", NumElements);
            yield return new ReferenceProperty("Stride", Stride);
            yield return new ReferenceProperty("Event", Event);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Execution = IdScope.Parse(reader, end - reader.Position);
            Destination = IdRef.Parse(reader, end - reader.Position);
            Source = IdRef.Parse(reader, end - reader.Position);
            NumElements = IdRef.Parse(reader, end - reader.Position);
            Stride = IdRef.Parse(reader, end - reader.Position);
            Event = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return
                $"{IdResultType} {IdResult} = {OpCode} {Execution} {Destination} {Source} {NumElements} {Stride} {Event}";
        }
    }
}