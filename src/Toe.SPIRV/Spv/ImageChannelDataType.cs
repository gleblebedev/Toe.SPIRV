using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public class ImageChannelDataType : ValueEnum
    {
        public ImageChannelDataType(Enumerant value)
        {
            Value = value;
        }

        public enum Enumerant
        {
            [Capability(Capability.Enumerant.Kernel)]
            SnormInt8 = 0,

            [Capability(Capability.Enumerant.Kernel)]
            SnormInt16 = 1,

            [Capability(Capability.Enumerant.Kernel)]
            UnormInt8 = 2,

            [Capability(Capability.Enumerant.Kernel)]
            UnormInt16 = 3,

            [Capability(Capability.Enumerant.Kernel)]
            UnormShort565 = 4,

            [Capability(Capability.Enumerant.Kernel)]
            UnormShort555 = 5,

            [Capability(Capability.Enumerant.Kernel)]
            UnormInt101010 = 6,

            [Capability(Capability.Enumerant.Kernel)]
            SignedInt8 = 7,

            [Capability(Capability.Enumerant.Kernel)]
            SignedInt16 = 8,

            [Capability(Capability.Enumerant.Kernel)]
            SignedInt32 = 9,

            [Capability(Capability.Enumerant.Kernel)]
            UnsignedInt8 = 10,

            [Capability(Capability.Enumerant.Kernel)]
            UnsignedInt16 = 11,

            [Capability(Capability.Enumerant.Kernel)]
            UnsignedInt32 = 12,

            [Capability(Capability.Enumerant.Kernel)]
            HalfFloat = 13,

            [Capability(Capability.Enumerant.Kernel)]
            Float = 14,

            [Capability(Capability.Enumerant.Kernel)]
            UnormInt24 = 15,

            [Capability(Capability.Enumerant.Kernel)]
            UnormInt101010_2 = 16
        }

        public Enumerant Value { get; }

        public static ImageChannelDataType Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                default:
                    return new ImageChannelDataType(id);
            }
        }

        public static ImageChannelDataType ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<ImageChannelDataType> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<ImageChannelDataType>();
            while (reader.Position < end) res.Add(Parse(reader, end - reader.Position));
            return res;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}