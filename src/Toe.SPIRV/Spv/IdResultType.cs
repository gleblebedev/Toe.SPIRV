using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Spv
{
    public static class IdResultType
    {
        public static IdRef<TypeInstruction> Parse(WordReader reader, uint wordCount)
        {
            return IdRef<TypeInstruction>.Parse(reader, wordCount);
        }

        public static IdRef<TypeInstruction> ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<IdRef<TypeInstruction>> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<IdRef<TypeInstruction>>();
            while (reader.Position < end) res.Add(Parse(reader, end - reader.Position));
            return res;
        }
    }
}