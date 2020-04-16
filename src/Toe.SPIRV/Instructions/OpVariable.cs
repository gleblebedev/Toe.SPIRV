using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpVariable: InstructionWithId
    {
        public OpVariable()
        {
        }

        public override Op OpCode { get { return Op.OpVariable; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.StorageClass StorageClass { get; set; }

        public Spv.IdRef Initializer { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Initializer", Initializer);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            StorageClass = Spv.StorageClass.Parse(reader, end-reader.Position);
            Initializer = Spv.IdRef.ParseOptional(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += StorageClass.GetWordCount();
            wordCount += Initializer.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            StorageClass.Write(writer);
            Initializer.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {StorageClass} {Initializer}";
        }
    }
}
