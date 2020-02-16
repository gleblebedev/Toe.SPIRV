using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public class FPRoundingMode : ValueEnum
    {
        public FPRoundingMode(Enumerant value)
        {
            Value = value;
        }

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
            RTN = 3
        }

        public Enumerant Value { get; }

        public static FPRoundingMode Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                default:
                    return new FPRoundingMode(id);
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
            while (reader.Position < end) res.Add(Parse(reader, end - reader.Position));
            return res;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}