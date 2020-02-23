using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public abstract partial class SamplerFilterMode : ValueEnum
    {
        public enum Enumerant
        {
            [Capability(Capability.Enumerant.Kernel)]
            Nearest = 0,
            [Capability(Capability.Enumerant.Kernel)]
            Linear = 1,
        }

        public class Nearest: SamplerFilterMode
        {
            public override Enumerant Value => SamplerFilterMode.Enumerant.Nearest;
            public new static Nearest Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Nearest();
                return res;
            }
        }
        public class Linear: SamplerFilterMode
        {
            public override Enumerant Value => SamplerFilterMode.Enumerant.Linear;
            public new static Linear Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Linear();
                return res;
            }
        }

        public abstract Enumerant Value { get; }

        public static SamplerFilterMode Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                case Enumerant.Nearest :
                    return Nearest.Parse(reader, wordCount - 1);
                case Enumerant.Linear :
                    return Linear.Parse(reader, wordCount - 1);
                default:
                    throw new IndexOutOfRangeException("Unknown SamplerFilterMode "+id);
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