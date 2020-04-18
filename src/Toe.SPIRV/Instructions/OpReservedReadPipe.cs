using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpReservedReadPipe: InstructionWithId
    {
        public OpReservedReadPipe()
        {
        }

        public override Op OpCode { get { return Op.OpReservedReadPipe; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef Pipe { get; set; }

        public Spv.IdRef ReserveId { get; set; }

        public Spv.IdRef Index { get; set; }

        public Spv.IdRef Pointer { get; set; }

        public Spv.IdRef PacketSize { get; set; }

        public Spv.IdRef PacketAlignment { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            Pipe = Spv.IdRef.Parse(reader, end-reader.Position);
            ReserveId = Spv.IdRef.Parse(reader, end-reader.Position);
            Index = Spv.IdRef.Parse(reader, end-reader.Position);
            Pointer = Spv.IdRef.Parse(reader, end-reader.Position);
            PacketSize = Spv.IdRef.Parse(reader, end-reader.Position);
            PacketAlignment = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += Pipe.GetWordCount();
            wordCount += ReserveId.GetWordCount();
            wordCount += Index.GetWordCount();
            wordCount += Pointer.GetWordCount();
            wordCount += PacketSize.GetWordCount();
            wordCount += PacketAlignment.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            Pipe.Write(writer);
            ReserveId.Write(writer);
            Index.Write(writer);
            Pointer.Write(writer);
            PacketSize.Write(writer);
            PacketAlignment.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Pipe} {ReserveId} {Index} {Pointer} {PacketSize} {PacketAlignment}";
        }
    }
}
