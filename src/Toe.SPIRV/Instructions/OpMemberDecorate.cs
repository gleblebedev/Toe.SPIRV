using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpMemberDecorate : Instruction
    {
        public override Op OpCode => Op.OpMemberDecorate;

        public IdRef StructureType { get; set; }
        public uint Member { get; set; }
        public Decoration Decoration { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("StructureType", StructureType);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            StructureType = IdRef.Parse(reader, end - reader.Position);
            Member = LiteralInteger.Parse(reader, end - reader.Position);
            Decoration = Decoration.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {StructureType} {Member} {Decoration}";
        }
    }
}