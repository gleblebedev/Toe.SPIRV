using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public class MemoryAccess : ValueEnum
    {
        [Flags]
        public enum Enumerant
        {
            None = 0x0000,
            Volatile = 0x0001,
            Aligned = 0x0002,
            Nontemporal = 0x0004
        }

        public MemoryAccess(Enumerant value)
        {
            Value = value;
        }

        public Enumerant Value { get; }

        public uint Aligned { get; set; }


        public static MemoryAccess Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var id = (Enumerant) reader.ReadWord();
            var value = new MemoryAccess(id);
            if (Enumerant.Aligned == (id & Enumerant.Aligned))
                value.Aligned = LiteralInteger.Parse(reader, wordCount - 1);
            value.PostParse(reader, wordCount - 1);
            return value;
        }

        public static MemoryAccess ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<MemoryAccess> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<MemoryAccess>();
            while (reader.Position < end) res.Add(Parse(reader, end - reader.Position));
            return res;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}