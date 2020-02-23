using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public partial class SelectionControl : ValueEnum
    {
        [Flags]
        public enum Enumerant
        {
            None = 0x0000,
            Flatten = 0x0001,
            DontFlatten = 0x0002,
        }

        public SelectionControl(Enumerant value)
        {
            Value = value;
        }

        public Enumerant Value { get; }



        public static SelectionControl Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount;
            var id = (Enumerant) reader.ReadWord();
            var value = new SelectionControl(id);
            value.PostParse(reader, wordCount - 1);
            return value;
        }

        public static SelectionControl ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<SelectionControl> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<SelectionControl>();
            while (reader.Position < end)
            {
                res.Add(Parse(reader, end-reader.Position));
            }
            return res;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public virtual uint GetWordCount()
        {
            uint wordCount = 1;
            return wordCount;
        }

        public void Write(WordWriter writer)
        {
             writer.WriteWord((uint)Value);
        }
    }
}