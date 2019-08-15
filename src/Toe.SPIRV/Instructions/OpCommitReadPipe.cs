using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpCommitReadPipe : Instruction
    {
        public override Op OpCode => Op.OpCommitReadPipe;

        public IdRef Pipe { get; set; }
        public IdRef ReserveId { get; set; }
        public IdRef PacketSize { get; set; }
        public IdRef PacketAlignment { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Pipe", Pipe);
            yield return new ReferenceProperty("ReserveId", ReserveId);
            yield return new ReferenceProperty("PacketSize", PacketSize);
            yield return new ReferenceProperty("PacketAlignment", PacketAlignment);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            Pipe = IdRef.Parse(reader, end - reader.Position);
            ReserveId = IdRef.Parse(reader, end - reader.Position);
            PacketSize = IdRef.Parse(reader, end - reader.Position);
            PacketAlignment = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {Pipe} {ReserveId} {PacketSize} {PacketAlignment}";
        }
    }
}