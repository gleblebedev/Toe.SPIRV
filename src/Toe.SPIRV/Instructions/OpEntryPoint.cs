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

        public Spv.IdRef Value { get; set; }

        public string Name { get; set; }

        public IList<Spv.IdRef> Interface { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            ExecutionModel = Spv.ExecutionModel.Parse(reader, end-reader.Position);
            Value = Spv.IdRef.Parse(reader, end-reader.Position);
            Name = Spv.LiteralString.Parse(reader, end-reader.Position);
            Interface = Spv.IdRef.ParseCollection(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += ExecutionModel.GetWordCount();
            wordCount += Value.GetWordCount();
            wordCount += Name.GetWordCount();
            wordCount += Interface.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            ExecutionModel.Write(writer);
            Value.Write(writer);
            Name.Write(writer);
            Interface.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {ExecutionModel} {Value} {Name} {Interface}";
        }
    }
}
