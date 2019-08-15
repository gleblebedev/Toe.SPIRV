using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public class FunctionControl : ValueEnum
    {
        [Flags]
        public enum Enumerant
        {
            None = 0x0000,
            Inline = 0x0001,
            DontInline = 0x0002,
            Pure = 0x0004,
            Const = 0x0008
        }

        public FunctionControl(Enumerant value)
        {
            Value = value;
        }

        public Enumerant Value { get; }


        public static FunctionControl Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var id = (Enumerant) reader.ReadWord();
            var value = new FunctionControl(id);
            value.PostParse(reader, wordCount - 1);
            return value;
        }

        public static FunctionControl ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<FunctionControl> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<FunctionControl>();
            while (reader.Position < end) res.Add(Parse(reader, end - reader.Position));
            return res;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}