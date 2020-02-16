using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public class KernelEnqueueFlags : ValueEnum
    {
        public KernelEnqueueFlags(Enumerant value)
        {
            Value = value;
        }

        public enum Enumerant
        {
            [Capability(Capability.Enumerant.Kernel)]
            NoWait = 0,

            [Capability(Capability.Enumerant.Kernel)]
            WaitKernel = 1,

            [Capability(Capability.Enumerant.Kernel)]
            WaitWorkGroup = 2
        }

        public Enumerant Value { get; }

        public static KernelEnqueueFlags Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                default:
                    return new KernelEnqueueFlags(id);
            }
        }

        public static KernelEnqueueFlags ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<KernelEnqueueFlags> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<KernelEnqueueFlags>();
            while (reader.Position < end) res.Add(Parse(reader, end - reader.Position));
            return res;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}