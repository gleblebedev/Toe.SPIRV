using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public abstract partial class ImageFormat : ValueEnum
    {
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

        public class Unknown: ImageFormat
        {
            public static readonly Unknown Instance = new Unknown();
            public override Enumerant Value => ImageFormat.Enumerant.Unknown;
            public new static Unknown Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Rgba32f: ImageFormat
        {
            public static readonly Rgba32f Instance = new Rgba32f();
            public override Enumerant Value => ImageFormat.Enumerant.Rgba32f;
            public new static Rgba32f Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Rgba16f: ImageFormat
        {
            public static readonly Rgba16f Instance = new Rgba16f();
            public override Enumerant Value => ImageFormat.Enumerant.Rgba16f;
            public new static Rgba16f Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class R32f: ImageFormat
        {
            public static readonly R32f Instance = new R32f();
            public override Enumerant Value => ImageFormat.Enumerant.R32f;
            public new static R32f Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Rgba8: ImageFormat
        {
            public static readonly Rgba8 Instance = new Rgba8();
            public override Enumerant Value => ImageFormat.Enumerant.Rgba8;
            public new static Rgba8 Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Rgba8Snorm: ImageFormat
        {
            public static readonly Rgba8Snorm Instance = new Rgba8Snorm();
            public override Enumerant Value => ImageFormat.Enumerant.Rgba8Snorm;
            public new static Rgba8Snorm Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Rg32f: ImageFormat
        {
            public static readonly Rg32f Instance = new Rg32f();
            public override Enumerant Value => ImageFormat.Enumerant.Rg32f;
            public new static Rg32f Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Rg16f: ImageFormat
        {
            public static readonly Rg16f Instance = new Rg16f();
            public override Enumerant Value => ImageFormat.Enumerant.Rg16f;
            public new static Rg16f Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class R11fG11fB10f: ImageFormat
        {
            public static readonly R11fG11fB10f Instance = new R11fG11fB10f();
            public override Enumerant Value => ImageFormat.Enumerant.R11fG11fB10f;
            public new static R11fG11fB10f Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class R16f: ImageFormat
        {
            public static readonly R16f Instance = new R16f();
            public override Enumerant Value => ImageFormat.Enumerant.R16f;
            public new static R16f Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Rgba16: ImageFormat
        {
            public static readonly Rgba16 Instance = new Rgba16();
            public override Enumerant Value => ImageFormat.Enumerant.Rgba16;
            public new static Rgba16 Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Rgb10A2: ImageFormat
        {
            public static readonly Rgb10A2 Instance = new Rgb10A2();
            public override Enumerant Value => ImageFormat.Enumerant.Rgb10A2;
            public new static Rgb10A2 Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Rg16: ImageFormat
        {
            public static readonly Rg16 Instance = new Rg16();
            public override Enumerant Value => ImageFormat.Enumerant.Rg16;
            public new static Rg16 Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Rg8: ImageFormat
        {
            public static readonly Rg8 Instance = new Rg8();
            public override Enumerant Value => ImageFormat.Enumerant.Rg8;
            public new static Rg8 Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class R16: ImageFormat
        {
            public static readonly R16 Instance = new R16();
            public override Enumerant Value => ImageFormat.Enumerant.R16;
            public new static R16 Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class R8: ImageFormat
        {
            public static readonly R8 Instance = new R8();
            public override Enumerant Value => ImageFormat.Enumerant.R8;
            public new static R8 Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Rgba16Snorm: ImageFormat
        {
            public static readonly Rgba16Snorm Instance = new Rgba16Snorm();
            public override Enumerant Value => ImageFormat.Enumerant.Rgba16Snorm;
            public new static Rgba16Snorm Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Rg16Snorm: ImageFormat
        {
            public static readonly Rg16Snorm Instance = new Rg16Snorm();
            public override Enumerant Value => ImageFormat.Enumerant.Rg16Snorm;
            public new static Rg16Snorm Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Rg8Snorm: ImageFormat
        {
            public static readonly Rg8Snorm Instance = new Rg8Snorm();
            public override Enumerant Value => ImageFormat.Enumerant.Rg8Snorm;
            public new static Rg8Snorm Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class R16Snorm: ImageFormat
        {
            public static readonly R16Snorm Instance = new R16Snorm();
            public override Enumerant Value => ImageFormat.Enumerant.R16Snorm;
            public new static R16Snorm Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class R8Snorm: ImageFormat
        {
            public static readonly R8Snorm Instance = new R8Snorm();
            public override Enumerant Value => ImageFormat.Enumerant.R8Snorm;
            public new static R8Snorm Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Rgba32i: ImageFormat
        {
            public static readonly Rgba32i Instance = new Rgba32i();
            public override Enumerant Value => ImageFormat.Enumerant.Rgba32i;
            public new static Rgba32i Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Rgba16i: ImageFormat
        {
            public static readonly Rgba16i Instance = new Rgba16i();
            public override Enumerant Value => ImageFormat.Enumerant.Rgba16i;
            public new static Rgba16i Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Rgba8i: ImageFormat
        {
            public static readonly Rgba8i Instance = new Rgba8i();
            public override Enumerant Value => ImageFormat.Enumerant.Rgba8i;
            public new static Rgba8i Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class R32i: ImageFormat
        {
            public static readonly R32i Instance = new R32i();
            public override Enumerant Value => ImageFormat.Enumerant.R32i;
            public new static R32i Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Rg32i: ImageFormat
        {
            public static readonly Rg32i Instance = new Rg32i();
            public override Enumerant Value => ImageFormat.Enumerant.Rg32i;
            public new static Rg32i Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Rg16i: ImageFormat
        {
            public static readonly Rg16i Instance = new Rg16i();
            public override Enumerant Value => ImageFormat.Enumerant.Rg16i;
            public new static Rg16i Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Rg8i: ImageFormat
        {
            public static readonly Rg8i Instance = new Rg8i();
            public override Enumerant Value => ImageFormat.Enumerant.Rg8i;
            public new static Rg8i Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class R16i: ImageFormat
        {
            public static readonly R16i Instance = new R16i();
            public override Enumerant Value => ImageFormat.Enumerant.R16i;
            public new static R16i Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class R8i: ImageFormat
        {
            public static readonly R8i Instance = new R8i();
            public override Enumerant Value => ImageFormat.Enumerant.R8i;
            public new static R8i Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Rgba32ui: ImageFormat
        {
            public static readonly Rgba32ui Instance = new Rgba32ui();
            public override Enumerant Value => ImageFormat.Enumerant.Rgba32ui;
            public new static Rgba32ui Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Rgba16ui: ImageFormat
        {
            public static readonly Rgba16ui Instance = new Rgba16ui();
            public override Enumerant Value => ImageFormat.Enumerant.Rgba16ui;
            public new static Rgba16ui Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Rgba8ui: ImageFormat
        {
            public static readonly Rgba8ui Instance = new Rgba8ui();
            public override Enumerant Value => ImageFormat.Enumerant.Rgba8ui;
            public new static Rgba8ui Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class R32ui: ImageFormat
        {
            public static readonly R32ui Instance = new R32ui();
            public override Enumerant Value => ImageFormat.Enumerant.R32ui;
            public new static R32ui Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Rgb10a2ui: ImageFormat
        {
            public static readonly Rgb10a2ui Instance = new Rgb10a2ui();
            public override Enumerant Value => ImageFormat.Enumerant.Rgb10a2ui;
            public new static Rgb10a2ui Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Rg32ui: ImageFormat
        {
            public static readonly Rg32ui Instance = new Rg32ui();
            public override Enumerant Value => ImageFormat.Enumerant.Rg32ui;
            public new static Rg32ui Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Rg16ui: ImageFormat
        {
            public static readonly Rg16ui Instance = new Rg16ui();
            public override Enumerant Value => ImageFormat.Enumerant.Rg16ui;
            public new static Rg16ui Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Rg8ui: ImageFormat
        {
            public static readonly Rg8ui Instance = new Rg8ui();
            public override Enumerant Value => ImageFormat.Enumerant.Rg8ui;
            public new static Rg8ui Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class R16ui: ImageFormat
        {
            public static readonly R16ui Instance = new R16ui();
            public override Enumerant Value => ImageFormat.Enumerant.R16ui;
            public new static R16ui Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class R8ui: ImageFormat
        {
            public static readonly R8ui Instance = new R8ui();
            public override Enumerant Value => ImageFormat.Enumerant.R8ui;
            public new static R8ui Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }

        public abstract Enumerant Value { get; }

        public static ImageFormat Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                case Enumerant.Unknown :
                    return Unknown.Parse(reader, wordCount - 1);
                case Enumerant.Rgba32f :
                    return Rgba32f.Parse(reader, wordCount - 1);
                case Enumerant.Rgba16f :
                    return Rgba16f.Parse(reader, wordCount - 1);
                case Enumerant.R32f :
                    return R32f.Parse(reader, wordCount - 1);
                case Enumerant.Rgba8 :
                    return Rgba8.Parse(reader, wordCount - 1);
                case Enumerant.Rgba8Snorm :
                    return Rgba8Snorm.Parse(reader, wordCount - 1);
                case Enumerant.Rg32f :
                    return Rg32f.Parse(reader, wordCount - 1);
                case Enumerant.Rg16f :
                    return Rg16f.Parse(reader, wordCount - 1);
                case Enumerant.R11fG11fB10f :
                    return R11fG11fB10f.Parse(reader, wordCount - 1);
                case Enumerant.R16f :
                    return R16f.Parse(reader, wordCount - 1);
                case Enumerant.Rgba16 :
                    return Rgba16.Parse(reader, wordCount - 1);
                case Enumerant.Rgb10A2 :
                    return Rgb10A2.Parse(reader, wordCount - 1);
                case Enumerant.Rg16 :
                    return Rg16.Parse(reader, wordCount - 1);
                case Enumerant.Rg8 :
                    return Rg8.Parse(reader, wordCount - 1);
                case Enumerant.R16 :
                    return R16.Parse(reader, wordCount - 1);
                case Enumerant.R8 :
                    return R8.Parse(reader, wordCount - 1);
                case Enumerant.Rgba16Snorm :
                    return Rgba16Snorm.Parse(reader, wordCount - 1);
                case Enumerant.Rg16Snorm :
                    return Rg16Snorm.Parse(reader, wordCount - 1);
                case Enumerant.Rg8Snorm :
                    return Rg8Snorm.Parse(reader, wordCount - 1);
                case Enumerant.R16Snorm :
                    return R16Snorm.Parse(reader, wordCount - 1);
                case Enumerant.R8Snorm :
                    return R8Snorm.Parse(reader, wordCount - 1);
                case Enumerant.Rgba32i :
                    return Rgba32i.Parse(reader, wordCount - 1);
                case Enumerant.Rgba16i :
                    return Rgba16i.Parse(reader, wordCount - 1);
                case Enumerant.Rgba8i :
                    return Rgba8i.Parse(reader, wordCount - 1);
                case Enumerant.R32i :
                    return R32i.Parse(reader, wordCount - 1);
                case Enumerant.Rg32i :
                    return Rg32i.Parse(reader, wordCount - 1);
                case Enumerant.Rg16i :
                    return Rg16i.Parse(reader, wordCount - 1);
                case Enumerant.Rg8i :
                    return Rg8i.Parse(reader, wordCount - 1);
                case Enumerant.R16i :
                    return R16i.Parse(reader, wordCount - 1);
                case Enumerant.R8i :
                    return R8i.Parse(reader, wordCount - 1);
                case Enumerant.Rgba32ui :
                    return Rgba32ui.Parse(reader, wordCount - 1);
                case Enumerant.Rgba16ui :
                    return Rgba16ui.Parse(reader, wordCount - 1);
                case Enumerant.Rgba8ui :
                    return Rgba8ui.Parse(reader, wordCount - 1);
                case Enumerant.R32ui :
                    return R32ui.Parse(reader, wordCount - 1);
                case Enumerant.Rgb10a2ui :
                    return Rgb10a2ui.Parse(reader, wordCount - 1);
                case Enumerant.Rg32ui :
                    return Rg32ui.Parse(reader, wordCount - 1);
                case Enumerant.Rg16ui :
                    return Rg16ui.Parse(reader, wordCount - 1);
                case Enumerant.Rg8ui :
                    return Rg8ui.Parse(reader, wordCount - 1);
                case Enumerant.R16ui :
                    return R16ui.Parse(reader, wordCount - 1);
                case Enumerant.R8ui :
                    return R8ui.Parse(reader, wordCount - 1);
                default:
                    throw new IndexOutOfRangeException("Unknown ImageFormat "+id);
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