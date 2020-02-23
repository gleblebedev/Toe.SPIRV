using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public abstract partial class KernelEnqueueFlags : ValueEnum
    {
        public enum Enumerant
        {
            [Capability(Capability.Enumerant.Kernel)]
            NoWait = 0,
            [Capability(Capability.Enumerant.Kernel)]
            WaitKernel = 1,
            [Capability(Capability.Enumerant.Kernel)]
            WaitWorkGroup = 2,
        }

        public class NoWait: KernelEnqueueFlags
        {
            public override Enumerant Value => KernelEnqueueFlags.Enumerant.NoWait;
            public new static NoWait Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new NoWait();
                return res;
            }
        }
        public class WaitKernel: KernelEnqueueFlags
        {
            public override Enumerant Value => KernelEnqueueFlags.Enumerant.WaitKernel;
            public new static WaitKernel Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new WaitKernel();
                return res;
            }
        }
        public class WaitWorkGroup: KernelEnqueueFlags
        {
            public override Enumerant Value => KernelEnqueueFlags.Enumerant.WaitWorkGroup;
            public new static WaitWorkGroup Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new WaitWorkGroup();
                return res;
            }
        }

        public abstract Enumerant Value { get; }

        public static KernelEnqueueFlags Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                case Enumerant.NoWait :
                    return NoWait.Parse(reader, wordCount - 1);
                case Enumerant.WaitKernel :
                    return WaitKernel.Parse(reader, wordCount - 1);
                case Enumerant.WaitWorkGroup :
                    return WaitWorkGroup.Parse(reader, wordCount - 1);
                default:
                    throw new IndexOutOfRangeException("Unknown KernelEnqueueFlags "+id);
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