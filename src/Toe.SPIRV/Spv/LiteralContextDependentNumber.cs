using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Spv
{
    public class LiteralContextDependentNumber
    {
        public Value Value { get; set; }

        public static LiteralContextDependentNumber Parse(WordReader reader, uint wordCount, TypeInstruction type)
        {
            var size = type.SizeInWords;
            return new LiteralContextDependentNumber {Value = new Value(reader.ReadBytes(size), type)};
        }

        public static LiteralContextDependentNumber ParseOptional(WordReader reader, uint wordCount,
            TypeInstruction type)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount, type);
        }

        public static IList<LiteralContextDependentNumber> ParseCollection(WordReader reader, uint wordCount,
            TypeInstruction type)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<LiteralContextDependentNumber>();
            while (reader.Position < end) res.Add(Parse(reader, end - reader.Position, type));
            return res;
        }

        public override string ToString()
        {
            if (Value != null)
                return Value.ToString();
            return base.ToString();
        }
    }
}