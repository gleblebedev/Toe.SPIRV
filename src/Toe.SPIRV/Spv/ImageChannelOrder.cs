using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public abstract partial class ImageChannelOrder : ValueEnum
    {
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
            ABGR = 19,
        }

        public class R: ImageChannelOrder
        {
            public override Enumerant Value => ImageChannelOrder.Enumerant.R;
            public new static R Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new R();
                return res;
            }
        }
        public class A: ImageChannelOrder
        {
            public override Enumerant Value => ImageChannelOrder.Enumerant.A;
            public new static A Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new A();
                return res;
            }
        }
        public class RG: ImageChannelOrder
        {
            public override Enumerant Value => ImageChannelOrder.Enumerant.RG;
            public new static RG Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new RG();
                return res;
            }
        }
        public class RA: ImageChannelOrder
        {
            public override Enumerant Value => ImageChannelOrder.Enumerant.RA;
            public new static RA Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new RA();
                return res;
            }
        }
        public class RGB: ImageChannelOrder
        {
            public override Enumerant Value => ImageChannelOrder.Enumerant.RGB;
            public new static RGB Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new RGB();
                return res;
            }
        }
        public class RGBA: ImageChannelOrder
        {
            public override Enumerant Value => ImageChannelOrder.Enumerant.RGBA;
            public new static RGBA Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new RGBA();
                return res;
            }
        }
        public class BGRA: ImageChannelOrder
        {
            public override Enumerant Value => ImageChannelOrder.Enumerant.BGRA;
            public new static BGRA Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new BGRA();
                return res;
            }
        }
        public class ARGB: ImageChannelOrder
        {
            public override Enumerant Value => ImageChannelOrder.Enumerant.ARGB;
            public new static ARGB Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ARGB();
                return res;
            }
        }
        public class Intensity: ImageChannelOrder
        {
            public override Enumerant Value => ImageChannelOrder.Enumerant.Intensity;
            public new static Intensity Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Intensity();
                return res;
            }
        }
        public class Luminance: ImageChannelOrder
        {
            public override Enumerant Value => ImageChannelOrder.Enumerant.Luminance;
            public new static Luminance Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Luminance();
                return res;
            }
        }
        public class Rx: ImageChannelOrder
        {
            public override Enumerant Value => ImageChannelOrder.Enumerant.Rx;
            public new static Rx Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Rx();
                return res;
            }
        }
        public class RGx: ImageChannelOrder
        {
            public override Enumerant Value => ImageChannelOrder.Enumerant.RGx;
            public new static RGx Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new RGx();
                return res;
            }
        }
        public class RGBx: ImageChannelOrder
        {
            public override Enumerant Value => ImageChannelOrder.Enumerant.RGBx;
            public new static RGBx Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new RGBx();
                return res;
            }
        }
        public class Depth: ImageChannelOrder
        {
            public override Enumerant Value => ImageChannelOrder.Enumerant.Depth;
            public new static Depth Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Depth();
                return res;
            }
        }
        public class DepthStencil: ImageChannelOrder
        {
            public override Enumerant Value => ImageChannelOrder.Enumerant.DepthStencil;
            public new static DepthStencil Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new DepthStencil();
                return res;
            }
        }
        public class sRGB: ImageChannelOrder
        {
            public override Enumerant Value => ImageChannelOrder.Enumerant.sRGB;
            public new static sRGB Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new sRGB();
                return res;
            }
        }
        public class sRGBx: ImageChannelOrder
        {
            public override Enumerant Value => ImageChannelOrder.Enumerant.sRGBx;
            public new static sRGBx Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new sRGBx();
                return res;
            }
        }
        public class sRGBA: ImageChannelOrder
        {
            public override Enumerant Value => ImageChannelOrder.Enumerant.sRGBA;
            public new static sRGBA Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new sRGBA();
                return res;
            }
        }
        public class sBGRA: ImageChannelOrder
        {
            public override Enumerant Value => ImageChannelOrder.Enumerant.sBGRA;
            public new static sBGRA Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new sBGRA();
                return res;
            }
        }
        public class ABGR: ImageChannelOrder
        {
            public override Enumerant Value => ImageChannelOrder.Enumerant.ABGR;
            public new static ABGR Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ABGR();
                return res;
            }
        }

        public abstract Enumerant Value { get; }

        public static ImageChannelOrder Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                case Enumerant.R :
                    return R.Parse(reader, wordCount - 1);
                case Enumerant.A :
                    return A.Parse(reader, wordCount - 1);
                case Enumerant.RG :
                    return RG.Parse(reader, wordCount - 1);
                case Enumerant.RA :
                    return RA.Parse(reader, wordCount - 1);
                case Enumerant.RGB :
                    return RGB.Parse(reader, wordCount - 1);
                case Enumerant.RGBA :
                    return RGBA.Parse(reader, wordCount - 1);
                case Enumerant.BGRA :
                    return BGRA.Parse(reader, wordCount - 1);
                case Enumerant.ARGB :
                    return ARGB.Parse(reader, wordCount - 1);
                case Enumerant.Intensity :
                    return Intensity.Parse(reader, wordCount - 1);
                case Enumerant.Luminance :
                    return Luminance.Parse(reader, wordCount - 1);
                case Enumerant.Rx :
                    return Rx.Parse(reader, wordCount - 1);
                case Enumerant.RGx :
                    return RGx.Parse(reader, wordCount - 1);
                case Enumerant.RGBx :
                    return RGBx.Parse(reader, wordCount - 1);
                case Enumerant.Depth :
                    return Depth.Parse(reader, wordCount - 1);
                case Enumerant.DepthStencil :
                    return DepthStencil.Parse(reader, wordCount - 1);
                case Enumerant.sRGB :
                    return sRGB.Parse(reader, wordCount - 1);
                case Enumerant.sRGBx :
                    return sRGBx.Parse(reader, wordCount - 1);
                case Enumerant.sRGBA :
                    return sRGBA.Parse(reader, wordCount - 1);
                case Enumerant.sBGRA :
                    return sBGRA.Parse(reader, wordCount - 1);
                case Enumerant.ABGR :
                    return ABGR.Parse(reader, wordCount - 1);
                default:
                    throw new IndexOutOfRangeException("Unknown ImageChannelOrder "+id);
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