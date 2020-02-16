using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public class LoopControl : ValueEnum
    {
        public LoopControl(Enumerant value)
        {
            Value = value;
        }

        [Flags]
        public enum Enumerant
        {
            None = 0x0000,
            Unroll = 0x0001,
            DontUnroll = 0x0002
        }

        public Enumerant Value { get; }


        public static LoopControl Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var id = (Enumerant) reader.ReadWord();
            var value = new LoopControl(id);
            value.PostParse(reader, wordCount - 1);
            return value;
        }

        public static LoopControl ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<LoopControl> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<LoopControl>();
            while (reader.Position < end) res.Add(Parse(reader, end - reader.Position));
            return res;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}