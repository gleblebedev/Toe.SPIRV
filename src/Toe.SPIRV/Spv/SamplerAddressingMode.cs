using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public partial class SamplerAddressingMode : ValueEnum
    {
        public SamplerAddressingMode(Enumerant value)
        {
            Value = value;
        }

        public enum Enumerant
        {
            [Capability(Capability.Enumerant.Kernel)]
            None = 0,
            [Capability(Capability.Enumerant.Kernel)]
            ClampToEdge = 1,
            [Capability(Capability.Enumerant.Kernel)]
            Clamp = 2,
            [Capability(Capability.Enumerant.Kernel)]
            Repeat = 3,
            [Capability(Capability.Enumerant.Kernel)]
            RepeatMirrored = 4,
        }


        public Enumerant Value { get; }

        public static SamplerAddressingMode Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                default:
                    return new SamplerAddressingMode(id);
            }
        }
        
        public static SamplerAddressingMode ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<SamplerAddressingMode> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<SamplerAddressingMode>();
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
            return 1;
        }

        public virtual void Write(WordWriter writer)
        {
            writer.WriteWord((uint)Value);
        }
    }
}