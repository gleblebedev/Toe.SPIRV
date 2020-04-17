using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpGroupNonUniformQuadSwap: InstructionWithId
    {
        public OpGroupNonUniformQuadSwap()
        {
        }

        public override Op OpCode { get { return Op.OpGroupNonUniformQuadSwap; } }

        public Spv.IdRef IdResultType { get; set; }

        public uint Execution { get; set; }

        public Spv.IdRef Value { get; set; }

        public Spv.IdRef Direction { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Value", Value);
            yield return new ReferenceProperty("Direction", Direction);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            Execution = Spv.IdScope.Parse(reader, end-reader.Position);
            Value = Spv.IdRef.Parse(reader, end-reader.Position);
            Direction = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += Execution.GetWordCount();
            wordCount += Value.GetWordCount();
            wordCount += Direction.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            Execution.Write(writer);
            Value.Write(writer);
            Direction.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Execution} {Value} {Direction}";
        }
    }
}
