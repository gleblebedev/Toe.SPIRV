using System;
using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public abstract class Instruction
    {
        public abstract Op OpCode { get; }

        public virtual bool TryGetResultId(out uint id)
        {
            id = 0;
            return false;
        }

        public virtual void Parse(WordReader reader, uint wordCount)
        {
            for (uint i = 1; i < wordCount; ++i) reader.ReadWord();
        }

        public override string ToString()
        {
            return OpCode.ToString();
        }

        public virtual uint GetWordCount()
        {
            throw new NotImplementedException(OpCode + " not implemented yet.");
        }

        public virtual void Write(WordWriter writer)
        {
            throw new NotImplementedException(OpCode + " not implemented yet.");
        }

        public void Build(WordWriter writer)
        {
            uint wordCount = GetWordCount() + 1;
            uint opCode = (uint)OpCode | ((wordCount) << 16);
            writer.WriteWord(opCode);
            var expectedEnd = writer.Position + wordCount - 1;
            Write(writer);
            if (writer.Position != expectedEnd)
            {
                throw new InvalidOperationException("Written word count doesn't match expected word count");
            }
        }
    }
}