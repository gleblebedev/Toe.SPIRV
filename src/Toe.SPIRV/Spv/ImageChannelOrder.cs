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
            public static readonly R Instance = new R();
            public override Enumerant Value => ImageChannelOrder.Enumerant.R;
            public new static R Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class A: ImageChannelOrder
        {
            public static readonly A Instance = new A();
            public override Enumerant Value => ImageChannelOrder.Enumerant.A;
            public new static A Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class RG: ImageChannelOrder
        {
            public static readonly RG Instance = new RG();
            public override Enumerant Value => ImageChannelOrder.Enumerant.RG;
            public new static RG Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class RA: ImageChannelOrder
        {
            public static readonly RA Instance = new RA();
            public override Enumerant Value => ImageChannelOrder.Enumerant.RA;
            public new static RA Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class RGB: ImageChannelOrder
        {
            public static readonly RGB Instance = new RGB();
            public override Enumerant Value => ImageChannelOrder.Enumerant.RGB;
            public new static RGB Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class RGBA: ImageChannelOrder
        {
            public static readonly RGBA Instance = new RGBA();
            public override Enumerant Value => ImageChannelOrder.Enumerant.RGBA;
            public new static RGBA Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class BGRA: ImageChannelOrder
        {
            public static readonly BGRA Instance = new BGRA();
            public override Enumerant Value => ImageChannelOrder.Enumerant.BGRA;
            public new static BGRA Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class ARGB: ImageChannelOrder
        {
            public static readonly ARGB Instance = new ARGB();
            public override Enumerant Value => ImageChannelOrder.Enumerant.ARGB;
            public new static ARGB Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Intensity: ImageChannelOrder
        {
            public static readonly Intensity Instance = new Intensity();
            public override Enumerant Value => ImageChannelOrder.Enumerant.Intensity;
            public new static Intensity Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Luminance: ImageChannelOrder
        {
            public static readonly Luminance Instance = new Luminance();
            public override Enumerant Value => ImageChannelOrder.Enumerant.Luminance;
            public new static Luminance Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Rx: ImageChannelOrder
        {
            public static readonly Rx Instance = new Rx();
            public override Enumerant Value => ImageChannelOrder.Enumerant.Rx;
            public new static Rx Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class RGx: ImageChannelOrder
        {
            public static readonly RGx Instance = new RGx();
            public override Enumerant Value => ImageChannelOrder.Enumerant.RGx;
            public new static RGx Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class RGBx: ImageChannelOrder
        {
            public static readonly RGBx Instance = new RGBx();
            public override Enumerant Value => ImageChannelOrder.Enumerant.RGBx;
            public new static RGBx Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Depth: ImageChannelOrder
        {
            public static readonly Depth Instance = new Depth();
            public override Enumerant Value => ImageChannelOrder.Enumerant.Depth;
            public new static Depth Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class DepthStencil: ImageChannelOrder
        {
            public static readonly DepthStencil Instance = new DepthStencil();
            public override Enumerant Value => ImageChannelOrder.Enumerant.DepthStencil;
            public new static DepthStencil Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class sRGB: ImageChannelOrder
        {
            public static readonly sRGB Instance = new sRGB();
            public override Enumerant Value => ImageChannelOrder.Enumerant.sRGB;
            public new static sRGB Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class sRGBx: ImageChannelOrder
        {
            public static readonly sRGBx Instance = new sRGBx();
            public override Enumerant Value => ImageChannelOrder.Enumerant.sRGBx;
            public new static sRGBx Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class sRGBA: ImageChannelOrder
        {
            public static readonly sRGBA Instance = new sRGBA();
            public override Enumerant Value => ImageChannelOrder.Enumerant.sRGBA;
            public new static sRGBA Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class sBGRA: ImageChannelOrder
        {
            public static readonly sBGRA Instance = new sBGRA();
            public override Enumerant Value => ImageChannelOrder.Enumerant.sBGRA;
            public new static sBGRA Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class ABGR: ImageChannelOrder
        {
            public static readonly ABGR Instance = new ABGR();
            public override Enumerant Value => ImageChannelOrder.Enumerant.ABGR;
            public new static ABGR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
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