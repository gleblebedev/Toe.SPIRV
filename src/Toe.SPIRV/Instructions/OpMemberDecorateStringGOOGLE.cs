using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpMemberDecorateStringGOOGLE : Instruction
    {
        public override Op OpCode => Op.OpMemberDecorateStringGOOGLE;

        public IdRef StructType { get; set; }
        public uint Member { get; set; }
        public Decoration Decoration { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("StructType", StructType);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            StructType = IdRef.Parse(reader, end - reader.Position);
            Member = LiteralInteger.Parse(reader, end - reader.Position);
            Decoration = Decoration.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {StructType} {Member} {Decoration}";
        }
    }
}