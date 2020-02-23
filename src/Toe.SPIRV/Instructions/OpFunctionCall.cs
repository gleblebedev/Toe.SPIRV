using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpFunctionCall: InstructionWithId
    {
        public OpFunctionCall()
        {
        }

        public override Op OpCode { get { return Op.OpFunctionCall; } }

        public Spv.IdRef<TypeInstruction> IdResultType { get; set; }
        public Spv.IdRef Function { get; set; }
        public IList<Spv.IdRef> Arguments { get; set; }
        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Function", Function);
            for (int i=0; i<Arguments.Count; ++i)
                yield return new ReferenceProperty("Arguments"+i, Arguments[i]);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            Function = Spv.IdRef.Parse(reader, end-reader.Position);
            Arguments = Spv.IdRef.ParseCollection(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += Function.GetWordCount();
            wordCount += Arguments.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            Function.Write(writer);
            Arguments.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Function} {Arguments}";
        }
    }
}
