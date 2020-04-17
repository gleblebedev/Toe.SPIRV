using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpUCountTrailingZerosINTEL: InstructionWithId
    {
        public OpUCountTrailingZerosINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpUCountTrailingZerosINTEL; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef Operand { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Operand", Operand);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            Operand = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += Operand.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            Operand.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Operand}";
        }
    }
}
