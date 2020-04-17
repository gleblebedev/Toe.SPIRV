using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public partial class MemorySemantics : ValueEnum
    {
        [Flags]
        public enum Enumerant
        {
            Relaxed = 0x0000,
            None = 0x0000,
            Acquire = 0x0002,
            Release = 0x0004,
            AcquireRelease = 0x0008,
            SequentiallyConsistent = 0x0010,
            [Capability(Capability.Enumerant.Shader)]
            UniformMemory = 0x0040,
            SubgroupMemory = 0x0080,
            WorkgroupMemory = 0x0100,
            CrossWorkgroupMemory = 0x0200,
            [Capability(Capability.Enumerant.AtomicStorage)]
            AtomicCounterMemory = 0x0400,
            ImageMemory = 0x0800,
            [Capability(Capability.Enumerant.VulkanMemoryModel)]
            OutputMemory = 0x1000,
            [Capability(Capability.Enumerant.VulkanMemoryModel)]
            OutputMemoryKHR = 0x1000,
            [Capability(Capability.Enumerant.VulkanMemoryModel)]
            MakeAvailable = 0x2000,
            [Capability(Capability.Enumerant.VulkanMemoryModel)]
            MakeAvailableKHR = 0x2000,
            [Capability(Capability.Enumerant.VulkanMemoryModel)]
            MakeVisible = 0x4000,
            [Capability(Capability.Enumerant.VulkanMemoryModel)]
            MakeVisibleKHR = 0x4000,
            [Capability(Capability.Enumerant.VulkanMemoryModel)]
            Volatile = 0x8000,
        }

        public MemorySemantics(Enumerant value)
        {
            Value = value;
        }

        public Enumerant Value { get; }



        public static MemorySemantics Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount;
            var id = (Enumerant) reader.ReadWord();
            var value = new MemorySemantics(id);
            value.PostParse(reader, wordCount - 1);
            return value;
        }

        public static MemorySemantics ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<MemorySemantics> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<MemorySemantics>();
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