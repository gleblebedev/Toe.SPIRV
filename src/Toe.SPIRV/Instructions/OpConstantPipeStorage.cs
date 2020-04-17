using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpConstantPipeStorage: InstructionWithId
    {
        public OpConstantPipeStorage()
        {
        }

        public override Op OpCode { get { return Op.OpConstantPipeStorage; } }

        public Spv.IdRef IdResultType { get; set; }

        public uint PacketSize { get; set; }

        public uint PacketAlignment { get; set; }

        public uint Capacity { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            PacketSize = Spv.LiteralInteger.Parse(reader, end-reader.Position);
            PacketAlignment = Spv.LiteralInteger.Parse(reader, end-reader.Position);
            Capacity = Spv.LiteralInteger.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += PacketSize.GetWordCount();
            wordCount += PacketAlignment.GetWordCount();
            wordCount += Capacity.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            PacketSize.Write(writer);
            PacketAlignment.Write(writer);
            Capacity.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {PacketSize} {PacketAlignment} {Capacity}";
        }
    }
}
