using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public partial class LoopControl : ValueEnum
    {
        [Flags]
        public enum Enumerant
        {
            None = 0x0000,
            Unroll = 0x0001,
            DontUnroll = 0x0002,
            DependencyInfinite = 0x0004,
            DependencyLength = 0x0008,
            MinIterations = 0x0010,
            MaxIterations = 0x0020,
            IterationMultiple = 0x0040,
            PeelCount = 0x0080,
            PartialCount = 0x0100,
        }

        public LoopControl(Enumerant value)
        {
            Value = value;
        }

        public Enumerant Value { get; }

        public uint DependencyLength { get; set; }
        public uint MinIterations { get; set; }
        public uint MaxIterations { get; set; }
        public uint IterationMultiple { get; set; }
        public uint PeelCount { get; set; }
        public uint PartialCount { get; set; }


        public static LoopControl Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount;
            var id = (Enumerant) reader.ReadWord();
            var value = new LoopControl(id);
            if (Enumerant.DependencyLength == (id & Enumerant.DependencyLength))
            {
                value.DependencyLength = Spv.LiteralInteger.Parse(reader, wordCount - 1);
            }
            if (Enumerant.MinIterations == (id & Enumerant.MinIterations))
            {
                value.MinIterations = Spv.LiteralInteger.Parse(reader, wordCount - 1);
            }
            if (Enumerant.MaxIterations == (id & Enumerant.MaxIterations))
            {
                value.MaxIterations = Spv.LiteralInteger.Parse(reader, wordCount - 1);
            }
            if (Enumerant.IterationMultiple == (id & Enumerant.IterationMultiple))
            {
                value.IterationMultiple = Spv.LiteralInteger.Parse(reader, wordCount - 1);
            }
            if (Enumerant.PeelCount == (id & Enumerant.PeelCount))
            {
                value.PeelCount = Spv.LiteralInteger.Parse(reader, wordCount - 1);
            }
            if (Enumerant.PartialCount == (id & Enumerant.PartialCount))
            {
                value.PartialCount = Spv.LiteralInteger.Parse(reader, wordCount - 1);
            }
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
            if (Enumerant.DependencyLength == (Value & Enumerant.DependencyLength))
            {
                wordCount += DependencyLength.GetWordCount();
            }
            if (Enumerant.MinIterations == (Value & Enumerant.MinIterations))
            {
                wordCount += MinIterations.GetWordCount();
            }
            if (Enumerant.MaxIterations == (Value & Enumerant.MaxIterations))
            {
                wordCount += MaxIterations.GetWordCount();
            }
            if (Enumerant.IterationMultiple == (Value & Enumerant.IterationMultiple))
            {
                wordCount += IterationMultiple.GetWordCount();
            }
            if (Enumerant.PeelCount == (Value & Enumerant.PeelCount))
            {
                wordCount += PeelCount.GetWordCount();
            }
            if (Enumerant.PartialCount == (Value & Enumerant.PartialCount))
            {
                wordCount += PartialCount.GetWordCount();
            }
            return wordCount;
        }

        public void Write(WordWriter writer)
        {
             writer.WriteWord((uint)Value);
            if (Enumerant.DependencyLength == (Value & Enumerant.DependencyLength))
            {
                DependencyLength.Write(writer);
            }
            if (Enumerant.MinIterations == (Value & Enumerant.MinIterations))
            {
                MinIterations.Write(writer);
            }
            if (Enumerant.MaxIterations == (Value & Enumerant.MaxIterations))
            {
                MaxIterations.Write(writer);
            }
            if (Enumerant.IterationMultiple == (Value & Enumerant.IterationMultiple))
            {
                IterationMultiple.Write(writer);
            }
            if (Enumerant.PeelCount == (Value & Enumerant.PeelCount))
            {
                PeelCount.Write(writer);
            }
            if (Enumerant.PartialCount == (Value & Enumerant.PartialCount))
            {
                PartialCount.Write(writer);
            }
        }
    }
}