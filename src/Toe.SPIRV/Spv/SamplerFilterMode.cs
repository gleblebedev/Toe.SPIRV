using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public class SamplerFilterMode : ValueEnum
    {
        public enum Enumerant
        {
            [Capability(Capability.Enumerant.Kernel)]
            Nearest = 0,

            [Capability(Capability.Enumerant.Kernel)]
            Linear = 1
        }


        public SamplerFilterMode(Enumerant value)
        {
            Value = value;
        }

        public Enumerant Value { get; }

        public static SamplerFilterMode Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                default:
                    return new SamplerFilterMode(id);
            }
        }

        public static SamplerFilterMode ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<SamplerFilterMode> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<SamplerFilterMode>();
            while (reader.Position < end) res.Add(Parse(reader, end - reader.Position));
            return res;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}