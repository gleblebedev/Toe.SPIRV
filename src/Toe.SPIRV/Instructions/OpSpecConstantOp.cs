using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSpecConstantOp: InstructionWithId
    {
        public OpSpecConstantOp()
        {
        }

        public override Op OpCode { get { return Op.OpSpecConstantOp; } }

        public Spv.IdRef<TypeInstruction> IdResultType { get; set; }
        public uint Opcode { get; set; }
        public IList<Spv.IdRef> Operands { get; set; }
        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            for (int i=0; i<Operands.Count; ++i)
                yield return new ReferenceProperty("Operands"+i, Operands[i]);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            Opcode = Spv.LiteralSpecConstantOpInteger.Parse(reader, end-reader.Position);
            Operands = Spv.IdRef.ParseCollection(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += Opcode.GetWordCount();
            wordCount += Operands.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            Opcode.Write(writer);
            Operands.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Opcode} {Operands}";
        }
    }
}
