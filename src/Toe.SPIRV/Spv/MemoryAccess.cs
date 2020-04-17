using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public partial class MemoryAccess : ValueEnum
    {
        [Flags]
        public enum Enumerant
        {
            None = 0x0000,
            Volatile = 0x0001,
            Aligned = 0x0002,
            Nontemporal = 0x0004,
            [Capability(Capability.Enumerant.VulkanMemoryModel)]
            MakePointerAvailable = 0x0008,
            [Capability(Capability.Enumerant.VulkanMemoryModel)]
            MakePointerAvailableKHR = 0x0008,
            [Capability(Capability.Enumerant.VulkanMemoryModel)]
            MakePointerVisible = 0x0010,
            [Capability(Capability.Enumerant.VulkanMemoryModel)]
            MakePointerVisibleKHR = 0x0010,
            [Capability(Capability.Enumerant.VulkanMemoryModel)]
            NonPrivatePointer = 0x0020,
            [Capability(Capability.Enumerant.VulkanMemoryModel)]
            NonPrivatePointerKHR = 0x0020,
        }

        public MemoryAccess(Enumerant value)
        {
            Value = value;
        }

        public Enumerant Value { get; }

        public uint Aligned { get; set; }
        public uint MakePointerAvailable { get; set; }
        public uint MakePointerAvailableKHR { get; set; }
        public uint MakePointerVisible { get; set; }
        public uint MakePointerVisibleKHR { get; set; }


        public static MemoryAccess Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount;
            var id = (Enumerant) reader.ReadWord();
            var value = new MemoryAccess(id);
            if (Enumerant.Aligned == (id & Enumerant.Aligned))
            {
                value.Aligned = Spv.LiteralInteger.Parse(reader, wordCount - 1);
            }
            if (Enumerant.MakePointerAvailable == (id & Enumerant.MakePointerAvailable))
            {
                value.MakePointerAvailable = Spv.IdScope.Parse(reader, wordCount - 1);
            }
            if (Enumerant.MakePointerAvailableKHR == (id & Enumerant.MakePointerAvailableKHR))
            {
                value.MakePointerAvailableKHR = Spv.IdScope.Parse(reader, wordCount - 1);
            }
            if (Enumerant.MakePointerVisible == (id & Enumerant.MakePointerVisible))
            {
                value.MakePointerVisible = Spv.IdScope.Parse(reader, wordCount - 1);
            }
            if (Enumerant.MakePointerVisibleKHR == (id & Enumerant.MakePointerVisibleKHR))
            {
                value.MakePointerVisibleKHR = Spv.IdScope.Parse(reader, wordCount - 1);
            }
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
            if (Enumerant.Aligned == (Value & Enumerant.Aligned))
            {
                wordCount += Aligned.GetWordCount();
            }
            if (Enumerant.MakePointerAvailable == (Value & Enumerant.MakePointerAvailable))
            {
                wordCount += MakePointerAvailable.GetWordCount();
            }
            if (Enumerant.MakePointerAvailableKHR == (Value & Enumerant.MakePointerAvailableKHR))
            {
                wordCount += MakePointerAvailableKHR.GetWordCount();
            }
            if (Enumerant.MakePointerVisible == (Value & Enumerant.MakePointerVisible))
            {
                wordCount += MakePointerVisible.GetWordCount();
            }
            if (Enumerant.MakePointerVisibleKHR == (Value & Enumerant.MakePointerVisibleKHR))
            {
                wordCount += MakePointerVisibleKHR.GetWordCount();
            }
            return wordCount;
        }

        public void Write(WordWriter writer)
        {
             writer.WriteWord((uint)Value);
            if (Enumerant.Aligned == (Value & Enumerant.Aligned))
            {
                Aligned.Write(writer);
            }
            if (Enumerant.MakePointerAvailable == (Value & Enumerant.MakePointerAvailable))
            {
                MakePointerAvailable.Write(writer);
            }
            if (Enumerant.MakePointerAvailableKHR == (Value & Enumerant.MakePointerAvailableKHR))
            {
                MakePointerAvailableKHR.Write(writer);
            }
            if (Enumerant.MakePointerVisible == (Value & Enumerant.MakePointerVisible))
            {
                MakePointerVisible.Write(writer);
            }
            if (Enumerant.MakePointerVisibleKHR == (Value & Enumerant.MakePointerVisibleKHR))
            {
                MakePointerVisibleKHR.Write(writer);
            }
        }
    }
}