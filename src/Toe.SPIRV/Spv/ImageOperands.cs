using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public class ImageOperands : ValueEnum
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
            ConstOffsets = 0x0020,
            Sample = 0x0040,

            [Capability(Capability.Enumerant.MinLod)]
            MinLod = 0x0080
        }

        public ImageOperands(Enumerant value)
        {
            Value = value;
        }

        public Enumerant Value { get; }

        public IdRef Bias { get; set; }
        public IdRef Lod { get; set; }
        public IdRef Grad1 { get; set; }
        public IdRef Grad2 { get; set; }
        public IdRef ConstOffset { get; set; }
        public IdRef Offset { get; set; }
        public IdRef ConstOffsets { get; set; }
        public IdRef Sample { get; set; }
        public IdRef MinLod { get; set; }


        public static ImageOperands Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var id = (Enumerant) reader.ReadWord();
            var value = new ImageOperands(id);
            if (Enumerant.Bias == (id & Enumerant.Bias)) value.Bias = IdRef.Parse(reader, wordCount - 1);
            if (Enumerant.Lod == (id & Enumerant.Lod)) value.Lod = IdRef.Parse(reader, wordCount - 1);
            if (Enumerant.Grad == (id & Enumerant.Grad))
            {
                value.Grad1 = IdRef.Parse(reader, wordCount - 1);
                value.Grad2 = IdRef.Parse(reader, wordCount - 1);
            }

            if (Enumerant.ConstOffset == (id & Enumerant.ConstOffset))
                value.ConstOffset = IdRef.Parse(reader, wordCount - 1);
            if (Enumerant.Offset == (id & Enumerant.Offset)) value.Offset = IdRef.Parse(reader, wordCount - 1);
            if (Enumerant.ConstOffsets == (id & Enumerant.ConstOffsets))
                value.ConstOffsets = IdRef.Parse(reader, wordCount - 1);
            if (Enumerant.Sample == (id & Enumerant.Sample)) value.Sample = IdRef.Parse(reader, wordCount - 1);
            if (Enumerant.MinLod == (id & Enumerant.MinLod)) value.MinLod = IdRef.Parse(reader, wordCount - 1);
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
            while (reader.Position < end) res.Add(Parse(reader, end - reader.Position));
            return res;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}