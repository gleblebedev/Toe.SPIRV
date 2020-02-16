using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public class ImageChannelOrder : ValueEnum
    {
        public ImageChannelOrder(Enumerant value)
        {
            Value = value;
        }

        public enum Enumerant
        {
            [Capability(Capability.Enumerant.Kernel)]
            R = 0,

            [Capability(Capability.Enumerant.Kernel)]
            A = 1,

            [Capability(Capability.Enumerant.Kernel)]
            RG = 2,

            [Capability(Capability.Enumerant.Kernel)]
            RA = 3,

            [Capability(Capability.Enumerant.Kernel)]
            RGB = 4,

            [Capability(Capability.Enumerant.Kernel)]
            RGBA = 5,

            [Capability(Capability.Enumerant.Kernel)]
            BGRA = 6,

            [Capability(Capability.Enumerant.Kernel)]
            ARGB = 7,

            [Capability(Capability.Enumerant.Kernel)]
            Intensity = 8,

            [Capability(Capability.Enumerant.Kernel)]
            Luminance = 9,

            [Capability(Capability.Enumerant.Kernel)]
            Rx = 10,

            [Capability(Capability.Enumerant.Kernel)]
            RGx = 11,

            [Capability(Capability.Enumerant.Kernel)]
            RGBx = 12,

            [Capability(Capability.Enumerant.Kernel)]
            Depth = 13,

            [Capability(Capability.Enumerant.Kernel)]
            DepthStencil = 14,

            [Capability(Capability.Enumerant.Kernel)]
            sRGB = 15,

            [Capability(Capability.Enumerant.Kernel)]
            sRGBx = 16,

            [Capability(Capability.Enumerant.Kernel)]
            sRGBA = 17,

            [Capability(Capability.Enumerant.Kernel)]
            sBGRA = 18,

            [Capability(Capability.Enumerant.Kernel)]
            ABGR = 19
        }

        public Enumerant Value { get; }

        public static ImageChannelOrder Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                default:
                    return new ImageChannelOrder(id);
            }
        }

        public static ImageChannelOrder ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<ImageChannelOrder> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<ImageChannelOrder>();
            while (reader.Position < end) res.Add(Parse(reader, end - reader.Position));
            return res;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}