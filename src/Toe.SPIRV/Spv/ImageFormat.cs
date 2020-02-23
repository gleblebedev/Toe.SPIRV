using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public partial class ImageFormat : ValueEnum
    {
        public ImageFormat(Enumerant value)
        {
            Value = value;
        }

        public enum Enumerant
        {
            Unknown = 0,
            [Capability(Capability.Enumerant.Shader)]
            Rgba32f = 1,
            [Capability(Capability.Enumerant.Shader)]
            Rgba16f = 2,
            [Capability(Capability.Enumerant.Shader)]
            R32f = 3,
            [Capability(Capability.Enumerant.Shader)]
            Rgba8 = 4,
            [Capability(Capability.Enumerant.Shader)]
            Rgba8Snorm = 5,
            [Capability(Capability.Enumerant.StorageImageExtendedFormats)]
            Rg32f = 6,
            [Capability(Capability.Enumerant.StorageImageExtendedFormats)]
            Rg16f = 7,
            [Capability(Capability.Enumerant.StorageImageExtendedFormats)]
            R11fG11fB10f = 8,
            [Capability(Capability.Enumerant.StorageImageExtendedFormats)]
            R16f = 9,
            [Capability(Capability.Enumerant.StorageImageExtendedFormats)]
            Rgba16 = 10,
            [Capability(Capability.Enumerant.StorageImageExtendedFormats)]
            Rgb10A2 = 11,
            [Capability(Capability.Enumerant.StorageImageExtendedFormats)]
            Rg16 = 12,
            [Capability(Capability.Enumerant.StorageImageExtendedFormats)]
            Rg8 = 13,
            [Capability(Capability.Enumerant.StorageImageExtendedFormats)]
            R16 = 14,
            [Capability(Capability.Enumerant.StorageImageExtendedFormats)]
            R8 = 15,
            [Capability(Capability.Enumerant.StorageImageExtendedFormats)]
            Rgba16Snorm = 16,
            [Capability(Capability.Enumerant.StorageImageExtendedFormats)]
            Rg16Snorm = 17,
            [Capability(Capability.Enumerant.StorageImageExtendedFormats)]
            Rg8Snorm = 18,
            [Capability(Capability.Enumerant.StorageImageExtendedFormats)]
            R16Snorm = 19,
            [Capability(Capability.Enumerant.StorageImageExtendedFormats)]
            R8Snorm = 20,
            [Capability(Capability.Enumerant.Shader)]
            Rgba32i = 21,
            [Capability(Capability.Enumerant.Shader)]
            Rgba16i = 22,
            [Capability(Capability.Enumerant.Shader)]
            Rgba8i = 23,
            [Capability(Capability.Enumerant.Shader)]
            R32i = 24,
            [Capability(Capability.Enumerant.StorageImageExtendedFormats)]
            Rg32i = 25,
            [Capability(Capability.Enumerant.StorageImageExtendedFormats)]
            Rg16i = 26,
            [Capability(Capability.Enumerant.StorageImageExtendedFormats)]
            Rg8i = 27,
            [Capability(Capability.Enumerant.StorageImageExtendedFormats)]
            R16i = 28,
            [Capability(Capability.Enumerant.StorageImageExtendedFormats)]
            R8i = 29,
            [Capability(Capability.Enumerant.Shader)]
            Rgba32ui = 30,
            [Capability(Capability.Enumerant.Shader)]
            Rgba16ui = 31,
            [Capability(Capability.Enumerant.Shader)]
            Rgba8ui = 32,
            [Capability(Capability.Enumerant.Shader)]
            R32ui = 33,
            [Capability(Capability.Enumerant.StorageImageExtendedFormats)]
            Rgb10a2ui = 34,
            [Capability(Capability.Enumerant.StorageImageExtendedFormats)]
            Rg32ui = 35,
            [Capability(Capability.Enumerant.StorageImageExtendedFormats)]
            Rg16ui = 36,
            [Capability(Capability.Enumerant.StorageImageExtendedFormats)]
            Rg8ui = 37,
            [Capability(Capability.Enumerant.StorageImageExtendedFormats)]
            R16ui = 38,
            [Capability(Capability.Enumerant.StorageImageExtendedFormats)]
            R8ui = 39,
        }


        public Enumerant Value { get; }

        public static ImageFormat Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                default:
                    return new ImageFormat(id);
            }
        }
        
        public static ImageFormat ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<ImageFormat> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<ImageFormat>();
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