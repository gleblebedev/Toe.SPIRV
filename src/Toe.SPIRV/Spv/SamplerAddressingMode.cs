using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public abstract partial class SamplerAddressingMode : ValueEnum
    {
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

        public class None: SamplerAddressingMode
        {
            public override Enumerant Value => SamplerAddressingMode.Enumerant.None;
            public new static None Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new None();
                return res;
            }
        }
        public class ClampToEdge: SamplerAddressingMode
        {
            public override Enumerant Value => SamplerAddressingMode.Enumerant.ClampToEdge;
            public new static ClampToEdge Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ClampToEdge();
                return res;
            }
        }
        public class Clamp: SamplerAddressingMode
        {
            public override Enumerant Value => SamplerAddressingMode.Enumerant.Clamp;
            public new static Clamp Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Clamp();
                return res;
            }
        }
        public class Repeat: SamplerAddressingMode
        {
            public override Enumerant Value => SamplerAddressingMode.Enumerant.Repeat;
            public new static Repeat Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Repeat();
                return res;
            }
        }
        public class RepeatMirrored: SamplerAddressingMode
        {
            public override Enumerant Value => SamplerAddressingMode.Enumerant.RepeatMirrored;
            public new static RepeatMirrored Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new RepeatMirrored();
                return res;
            }
        }

        public abstract Enumerant Value { get; }

        public static SamplerAddressingMode Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                case Enumerant.None :
                    return None.Parse(reader, wordCount - 1);
                case Enumerant.ClampToEdge :
                    return ClampToEdge.Parse(reader, wordCount - 1);
                case Enumerant.Clamp :
                    return Clamp.Parse(reader, wordCount - 1);
                case Enumerant.Repeat :
                    return Repeat.Parse(reader, wordCount - 1);
                case Enumerant.RepeatMirrored :
                    return RepeatMirrored.Parse(reader, wordCount - 1);
                default:
                    throw new IndexOutOfRangeException("Unknown SamplerAddressingMode "+id);
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