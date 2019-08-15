using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpGroupReserveReadPipePackets : InstructionWithId
    {
        public override Op OpCode => Op.OpGroupReserveReadPipePackets;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public uint Execution { get; set; }
        public IdRef Pipe { get; set; }
        public IdRef NumPackets { get; set; }
        public IdRef PacketSize { get; set; }
        public IdRef PacketAlignment { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Pipe", Pipe);
            yield return new ReferenceProperty("NumPackets", NumPackets);
            yield return new ReferenceProperty("PacketSize", PacketSize);
            yield return new ReferenceProperty("PacketAlignment", PacketAlignment);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Execution = IdScope.Parse(reader, end - reader.Position);
            Pipe = IdRef.Parse(reader, end - reader.Position);
            NumPackets = IdRef.Parse(reader, end - reader.Position);
            PacketSize = IdRef.Parse(reader, end - reader.Position);
            PacketAlignment = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return
                $"{IdResultType} {IdResult} = {OpCode} {Execution} {Pipe} {NumPackets} {PacketSize} {PacketAlignment}";
        }
    }
}