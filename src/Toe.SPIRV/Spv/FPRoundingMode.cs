using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public abstract partial class FPRoundingMode : ValueEnum
    {
        public enum Enumerant
        {
            [Capability(Capability.Enumerant.Kernel)]
            [Capability(Capability.Enumerant.StorageUniformBufferBlock16)]
            [Capability(Capability.Enumerant.StorageUniform16)]
            [Capability(Capability.Enumerant.StoragePushConstant16)]
            [Capability(Capability.Enumerant.StorageInputOutput16)]
            RTE = 0,
            [Capability(Capability.Enumerant.Kernel)]
            [Capability(Capability.Enumerant.StorageUniformBufferBlock16)]
            [Capability(Capability.Enumerant.StorageUniform16)]
            [Capability(Capability.Enumerant.StoragePushConstant16)]
            [Capability(Capability.Enumerant.StorageInputOutput16)]
            RTZ = 1,
            [Capability(Capability.Enumerant.Kernel)]
            [Capability(Capability.Enumerant.StorageUniformBufferBlock16)]
            [Capability(Capability.Enumerant.StorageUniform16)]
            [Capability(Capability.Enumerant.StoragePushConstant16)]
            [Capability(Capability.Enumerant.StorageInputOutput16)]
            RTP = 2,
            [Capability(Capability.Enumerant.Kernel)]
            [Capability(Capability.Enumerant.StorageUniformBufferBlock16)]
            [Capability(Capability.Enumerant.StorageUniform16)]
            [Capability(Capability.Enumerant.StoragePushConstant16)]
            [Capability(Capability.Enumerant.StorageInputOutput16)]
            RTN = 3,
        }

        public class RTE: FPRoundingMode
        {
            public override Enumerant Value => FPRoundingMode.Enumerant.RTE;
            public new static RTE Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new RTE();
                return res;
            }
        }
        public class RTZ: FPRoundingMode
        {
            public override Enumerant Value => FPRoundingMode.Enumerant.RTZ;
            public new static RTZ Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new RTZ();
                return res;
            }
        }
        public class RTP: FPRoundingMode
        {
            public override Enumerant Value => FPRoundingMode.Enumerant.RTP;
            public new static RTP Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new RTP();
                return res;
            }
        }
        public class RTN: FPRoundingMode
        {
            public override Enumerant Value => FPRoundingMode.Enumerant.RTN;
            public new static RTN Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new RTN();
                return res;
            }
        }

        public abstract Enumerant Value { get; }

        public static FPRoundingMode Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                case Enumerant.RTE :
                    return RTE.Parse(reader, wordCount - 1);
                case Enumerant.RTZ :
                    return RTZ.Parse(reader, wordCount - 1);
                case Enumerant.RTP :
                    return RTP.Parse(reader, wordCount - 1);
                case Enumerant.RTN :
                    return RTN.Parse(reader, wordCount - 1);
                default:
                    throw new IndexOutOfRangeException("Unknown FPRoundingMode "+id);
            }
        }
        
        public static FPRoundingMode ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<FPRoundingMode> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<FPRoundingMode>();
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