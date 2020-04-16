using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpTypeFunction: TypeInstruction
    {
        public OpTypeFunction()
        {
        }

        public override Op OpCode { get { return Op.OpTypeFunction; } }

        public Spv.IdRef ReturnType { get; set; }

        public IList<Spv.IdRef> ParameterTypes { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("ReturnType", ReturnType);
            for (int i=0; i<ParameterTypes.Count; ++i)
                yield return new ReferenceProperty("ParameterTypes"+i, ParameterTypes[i]);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            ReturnType = Spv.IdRef.Parse(reader, end-reader.Position);
            ParameterTypes = Spv.IdRef.ParseCollection(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResult.GetWordCount();
            wordCount += ReturnType.GetWordCount();
            wordCount += ParameterTypes.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResult.Write(writer);
            ReturnType.Write(writer);
            ParameterTypes.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResult} = {OpCode} {ReturnType} {ParameterTypes}";
        }
    }
}
