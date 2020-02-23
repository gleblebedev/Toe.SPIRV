using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpEntryPoint: Instruction
    {
        public OpEntryPoint()
        {
        }

        public override Op OpCode { get { return Op.OpEntryPoint; } }

        public Spv.ExecutionModel ExecutionModel { get; set; }
        public Spv.IdRef EntryPoint { get; set; }
        public string Name { get; set; }
        public IList<Spv.IdRef> Interface { get; set; }
        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("EntryPoint", EntryPoint);
            for (int i=0; i<Interface.Count; ++i)
                yield return new ReferenceProperty("Interface"+i, Interface[i]);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            ExecutionModel = Spv.ExecutionModel.Parse(reader, end-reader.Position);
            EntryPoint = Spv.IdRef.Parse(reader, end-reader.Position);
            Name = Spv.LiteralString.Parse(reader, end-reader.Position);
            Interface = Spv.IdRef.ParseCollection(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += ExecutionModel.GetWordCount();
            wordCount += EntryPoint.GetWordCount();
            wordCount += Name.GetWordCount();
            wordCount += Interface.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            ExecutionModel.Write(writer);
            EntryPoint.Write(writer);
            Name.Write(writer);
            Interface.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {ExecutionModel} {EntryPoint} {Name} {Interface}";
        }
    }
}
