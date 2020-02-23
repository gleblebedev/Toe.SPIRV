using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public partial class FPFastMathMode : ValueEnum
    {
        [Flags]
        public enum Enumerant
        {
            None = 0x0000,
            [Capability(Capability.Enumerant.Kernel)]
            NotNaN = 0x0001,
            [Capability(Capability.Enumerant.Kernel)]
            NotInf = 0x0002,
            [Capability(Capability.Enumerant.Kernel)]
            NSZ = 0x0004,
            [Capability(Capability.Enumerant.Kernel)]
            AllowRecip = 0x0008,
            [Capability(Capability.Enumerant.Kernel)]
            Fast = 0x0010,
        }

        public FPFastMathMode(Enumerant value)
        {
            Value = value;
        }

        public Enumerant Value { get; }



        public static FPFastMathMode Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount;
            var id = (Enumerant) reader.ReadWord();
            var value = new FPFastMathMode(id);
            value.PostParse(reader, wordCount - 1);
            return value;
        }

        public static FPFastMathMode ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<FPFastMathMode> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<FPFastMathMode>();
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