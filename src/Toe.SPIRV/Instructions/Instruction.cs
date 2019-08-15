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

        public virtual IEnumerable<ReferenceProperty> GetReferences()
        {
            yield break;
        }

        public virtual void Parse(WordReader reader, uint wordCount)
        {
            for (uint i = 1; i < wordCount; ++i) reader.ReadWord();
        }

        public override string ToString()
        {
            return OpCode.ToString();
        }
    }
}