using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpFunction: InstructionWithId
    {
        public OpFunction()
        {
        }

        public override Op OpCode { get { return Op.OpFunction; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.FunctionControl FunctionControl { get; set; }

        public Spv.IdRef FunctionType { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            FunctionControl = Spv.FunctionControl.Parse(reader, end-reader.Position);
            FunctionType = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += FunctionControl.GetWordCount();
            wordCount += FunctionType.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            FunctionControl.Write(writer);
            FunctionType.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {FunctionControl} {FunctionType}";
        }
    }
}
