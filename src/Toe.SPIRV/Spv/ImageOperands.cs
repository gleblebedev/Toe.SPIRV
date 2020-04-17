using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public partial class ImageOperands : ValueEnum
    {
        [Flags]
        public enum Enumerant
        {
            None = 0x0000,
            [Capability(Capability.Enumerant.Shader)]
            Bias = 0x0001,
            Lod = 0x0002,
            Grad = 0x0004,
            ConstOffset = 0x0008,
            [Capability(Capability.Enumerant.ImageGatherExtended)]
            Offset = 0x0010,
            [Capability(Capability.Enumerant.ImageGatherExtended)]
            ConstOffsets = 0x0020,
            Sample = 0x0040,
            [Capability(Capability.Enumerant.MinLod)]
            MinLod = 0x0080,
            [Capability(Capability.Enumerant.VulkanMemoryModel)]
            MakeTexelAvailable = 0x0100,
            [Capability(Capability.Enumerant.VulkanMemoryModel)]
            MakeTexelAvailableKHR = 0x0100,
            [Capability(Capability.Enumerant.VulkanMemoryModel)]
            MakeTexelVisible = 0x0200,
            [Capability(Capability.Enumerant.VulkanMemoryModel)]
            MakeTexelVisibleKHR = 0x0200,
            [Capability(Capability.Enumerant.VulkanMemoryModel)]
            NonPrivateTexel = 0x0400,
            [Capability(Capability.Enumerant.VulkanMemoryModel)]
            NonPrivateTexelKHR = 0x0400,
            [Capability(Capability.Enumerant.VulkanMemoryModel)]
            VolatileTexel = 0x0800,
            [Capability(Capability.Enumerant.VulkanMemoryModel)]
            VolatileTexelKHR = 0x0800,
            SignExtend = 0x1000,
            ZeroExtend = 0x2000,
        }

        public ImageOperands(Enumerant value)
        {
            Value = value;
        }

        public Enumerant Value { get; }

        public Spv.IdRef Bias { get; set; }
        public Spv.IdRef Lod { get; set; }
        public Spv.IdRef Grad1 { get; set; }
        public Spv.IdRef Grad2 { get; set; }
        public Spv.IdRef ConstOffset { get; set; }
        public Spv.IdRef Offset { get; set; }
        public Spv.IdRef ConstOffsets { get; set; }
        public Spv.IdRef Sample { get; set; }
        public Spv.IdRef MinLod { get; set; }
        public uint MakeTexelAvailable { get; set; }
        public uint MakeTexelAvailableKHR { get; set; }
        public uint MakeTexelVisible { get; set; }
        public uint MakeTexelVisibleKHR { get; set; }


        public static ImageOperands Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount;
            var id = (Enumerant) reader.ReadWord();
            var value = new ImageOperands(id);
            if (Enumerant.Bias == (id & Enumerant.Bias))
            {
                value.Bias = Spv.IdRef.Parse(reader, wordCount - 1);
            }
            if (Enumerant.Lod == (id & Enumerant.Lod))
            {
                value.Lod = Spv.IdRef.Parse(reader, wordCount - 1);
            }
            if (Enumerant.Grad == (id & Enumerant.Grad))
            {
                value.Grad1 = Spv.IdRef.Parse(reader, wordCount - 1);
                value.Grad2 = Spv.IdRef.Parse(reader, wordCount - 1);
            }
            if (Enumerant.ConstOffset == (id & Enumerant.ConstOffset))
            {
                value.ConstOffset = Spv.IdRef.Parse(reader, wordCount - 1);
            }
            if (Enumerant.Offset == (id & Enumerant.Offset))
            {
                value.Offset = Spv.IdRef.Parse(reader, wordCount - 1);
            }
            if (Enumerant.ConstOffsets == (id & Enumerant.ConstOffsets))
            {
                value.ConstOffsets = Spv.IdRef.Parse(reader, wordCount - 1);
            }
            if (Enumerant.Sample == (id & Enumerant.Sample))
            {
                value.Sample = Spv.IdRef.Parse(reader, wordCount - 1);
            }
            if (Enumerant.MinLod == (id & Enumerant.MinLod))
            {
                value.MinLod = Spv.IdRef.Parse(reader, wordCount - 1);
            }
            if (Enumerant.MakeTexelAvailable == (id & Enumerant.MakeTexelAvailable))
            {
                value.MakeTexelAvailable = Spv.IdScope.Parse(reader, wordCount - 1);
            }
            if (Enumerant.MakeTexelAvailableKHR == (id & Enumerant.MakeTexelAvailableKHR))
            {
                value.MakeTexelAvailableKHR = Spv.IdScope.Parse(reader, wordCount - 1);
            }
            if (Enumerant.MakeTexelVisible == (id & Enumerant.MakeTexelVisible))
            {
                value.MakeTexelVisible = Spv.IdScope.Parse(reader, wordCount - 1);
            }
            if (Enumerant.MakeTexelVisibleKHR == (id & Enumerant.MakeTexelVisibleKHR))
            {
                value.MakeTexelVisibleKHR = Spv.IdScope.Parse(reader, wordCount - 1);
            }
            value.PostParse(reader, wordCount - 1);
            return value;
        }

        public static ImageOperands ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<ImageOperands> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<ImageOperands>();
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
            if (Enumerant.Bias == (Value & Enumerant.Bias))
            {
                wordCount += Bias.GetWordCount();
            }
            if (Enumerant.Lod == (Value & Enumerant.Lod))
            {
                wordCount += Lod.GetWordCount();
            }
            if (Enumerant.Grad == (Value & Enumerant.Grad))
            {
                wordCount += Grad1.GetWordCount();
                wordCount += Grad2.GetWordCount();
            }
            if (Enumerant.ConstOffset == (Value & Enumerant.ConstOffset))
            {
                wordCount += ConstOffset.GetWordCount();
            }
            if (Enumerant.Offset == (Value & Enumerant.Offset))
            {
                wordCount += Offset.GetWordCount();
            }
            if (Enumerant.ConstOffsets == (Value & Enumerant.ConstOffsets))
            {
                wordCount += ConstOffsets.GetWordCount();
            }
            if (Enumerant.Sample == (Value & Enumerant.Sample))
            {
                wordCount += Sample.GetWordCount();
            }
            if (Enumerant.MinLod == (Value & Enumerant.MinLod))
            {
                wordCount += MinLod.GetWordCount();
            }
            if (Enumerant.MakeTexelAvailable == (Value & Enumerant.MakeTexelAvailable))
            {
                wordCount += MakeTexelAvailable.GetWordCount();
            }
            if (Enumerant.MakeTexelAvailableKHR == (Value & Enumerant.MakeTexelAvailableKHR))
            {
                wordCount += MakeTexelAvailableKHR.GetWordCount();
            }
            if (Enumerant.MakeTexelVisible == (Value & Enumerant.MakeTexelVisible))
            {
                wordCount += MakeTexelVisible.GetWordCount();
            }
            if (Enumerant.MakeTexelVisibleKHR == (Value & Enumerant.MakeTexelVisibleKHR))
            {
                wordCount += MakeTexelVisibleKHR.GetWordCount();
            }
            return wordCount;
        }

        public void Write(WordWriter writer)
        {
             writer.WriteWord((uint)Value);
            if (Enumerant.Bias == (Value & Enumerant.Bias))
            {
                Bias.Write(writer);
            }
            if (Enumerant.Lod == (Value & Enumerant.Lod))
            {
                Lod.Write(writer);
            }
            if (Enumerant.Grad == (Value & Enumerant.Grad))
            {
                Grad1.Write(writer);
                Grad2.Write(writer);
            }
            if (Enumerant.ConstOffset == (Value & Enumerant.ConstOffset))
            {
                ConstOffset.Write(writer);
            }
            if (Enumerant.Offset == (Value & Enumerant.Offset))
            {
                Offset.Write(writer);
            }
            if (Enumerant.ConstOffsets == (Value & Enumerant.ConstOffsets))
            {
                ConstOffsets.Write(writer);
            }
            if (Enumerant.Sample == (Value & Enumerant.Sample))
            {
                Sample.Write(writer);
            }
            if (Enumerant.MinLod == (Value & Enumerant.MinLod))
            {
                MinLod.Write(writer);
            }
            if (Enumerant.MakeTexelAvailable == (Value & Enumerant.MakeTexelAvailable))
            {
                MakeTexelAvailable.Write(writer);
            }
            if (Enumerant.MakeTexelAvailableKHR == (Value & Enumerant.MakeTexelAvailableKHR))
            {
                MakeTexelAvailableKHR.Write(writer);
            }
            if (Enumerant.MakeTexelVisible == (Value & Enumerant.MakeTexelVisible))
            {
                MakeTexelVisible.Write(writer);
            }
            if (Enumerant.MakeTexelVisibleKHR == (Value & Enumerant.MakeTexelVisibleKHR))
            {
                MakeTexelVisibleKHR.Write(writer);
            }
        }
    }
}