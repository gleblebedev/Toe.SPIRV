using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpExecuteCallableNV: Instruction
    {
        public OpExecuteCallableNV()
        {
        }

        public override Op OpCode { get { return Op.OpExecuteCallableNV; } }

        public Spv.IdRef SBTIndex { get; set; }

        public Spv.IdRef CallableDataId { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            SBTIndex = Spv.IdRef.Parse(reader, end-reader.Position);
            CallableDataId = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += SBTIndex.GetWordCount();
            wordCount += CallableDataId.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            SBTIndex.Write(writer);
            CallableDataId.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {SBTIndex} {CallableDataId}";
        }
    }
}
