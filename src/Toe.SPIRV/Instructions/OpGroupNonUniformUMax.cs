using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpGroupNonUniformUMax: InstructionWithId
    {
        public OpGroupNonUniformUMax()
        {
        }

        public override Op OpCode { get { return Op.OpGroupNonUniformUMax; } }

        public Spv.IdRef IdResultType { get; set; }

        public uint Execution { get; set; }

        public Spv.GroupOperation Operation { get; set; }

        public Spv.IdRef Value { get; set; }

        public Spv.IdRef ClusterSize { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Value", Value);
            yield return new ReferenceProperty("ClusterSize", ClusterSize);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            Execution = Spv.IdScope.Parse(reader, end-reader.Position);
            Operation = Spv.GroupOperation.Parse(reader, end-reader.Position);
            Value = Spv.IdRef.Parse(reader, end-reader.Position);
            ClusterSize = Spv.IdRef.ParseOptional(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += Execution.GetWordCount();
            wordCount += Operation.GetWordCount();
            wordCount += Value.GetWordCount();
            wordCount += ClusterSize.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            Execution.Write(writer);
            Operation.Write(writer);
            Value.Write(writer);
            if (ClusterSize != null) ClusterSize.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Execution} {Operation} {Value} {ClusterSize}";
        }
    }
}
