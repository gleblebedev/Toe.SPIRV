using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public abstract partial class ImageChannelDataType : ValueEnum
    {
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
            UnormInt101010_2 = 16,
        }

        public class SnormInt8: ImageChannelDataType
        {
            public static readonly SnormInt8 Instance = new SnormInt8();
            public override Enumerant Value => ImageChannelDataType.Enumerant.SnormInt8;
            public new static SnormInt8 Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SnormInt16: ImageChannelDataType
        {
            public static readonly SnormInt16 Instance = new SnormInt16();
            public override Enumerant Value => ImageChannelDataType.Enumerant.SnormInt16;
            public new static SnormInt16 Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class UnormInt8: ImageChannelDataType
        {
            public static readonly UnormInt8 Instance = new UnormInt8();
            public override Enumerant Value => ImageChannelDataType.Enumerant.UnormInt8;
            public new static UnormInt8 Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class UnormInt16: ImageChannelDataType
        {
            public static readonly UnormInt16 Instance = new UnormInt16();
            public override Enumerant Value => ImageChannelDataType.Enumerant.UnormInt16;
            public new static UnormInt16 Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class UnormShort565: ImageChannelDataType
        {
            public static readonly UnormShort565 Instance = new UnormShort565();
            public override Enumerant Value => ImageChannelDataType.Enumerant.UnormShort565;
            public new static UnormShort565 Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class UnormShort555: ImageChannelDataType
        {
            public static readonly UnormShort555 Instance = new UnormShort555();
            public override Enumerant Value => ImageChannelDataType.Enumerant.UnormShort555;
            public new static UnormShort555 Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class UnormInt101010: ImageChannelDataType
        {
            public static readonly UnormInt101010 Instance = new UnormInt101010();
            public override Enumerant Value => ImageChannelDataType.Enumerant.UnormInt101010;
            public new static UnormInt101010 Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SignedInt8: ImageChannelDataType
        {
            public static readonly SignedInt8 Instance = new SignedInt8();
            public override Enumerant Value => ImageChannelDataType.Enumerant.SignedInt8;
            public new static SignedInt8 Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SignedInt16: ImageChannelDataType
        {
            public static readonly SignedInt16 Instance = new SignedInt16();
            public override Enumerant Value => ImageChannelDataType.Enumerant.SignedInt16;
            public new static SignedInt16 Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SignedInt32: ImageChannelDataType
        {
            public static readonly SignedInt32 Instance = new SignedInt32();
            public override Enumerant Value => ImageChannelDataType.Enumerant.SignedInt32;
            public new static SignedInt32 Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class UnsignedInt8: ImageChannelDataType
        {
            public static readonly UnsignedInt8 Instance = new UnsignedInt8();
            public override Enumerant Value => ImageChannelDataType.Enumerant.UnsignedInt8;
            public new static UnsignedInt8 Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class UnsignedInt16: ImageChannelDataType
        {
            public static readonly UnsignedInt16 Instance = new UnsignedInt16();
            public override Enumerant Value => ImageChannelDataType.Enumerant.UnsignedInt16;
            public new static UnsignedInt16 Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class UnsignedInt32: ImageChannelDataType
        {
            public static readonly UnsignedInt32 Instance = new UnsignedInt32();
            public override Enumerant Value => ImageChannelDataType.Enumerant.UnsignedInt32;
            public new static UnsignedInt32 Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class HalfFloat: ImageChannelDataType
        {
            public static readonly HalfFloat Instance = new HalfFloat();
            public override Enumerant Value => ImageChannelDataType.Enumerant.HalfFloat;
            public new static HalfFloat Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Float: ImageChannelDataType
        {
            public static readonly Float Instance = new Float();
            public override Enumerant Value => ImageChannelDataType.Enumerant.Float;
            public new static Float Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class UnormInt24: ImageChannelDataType
        {
            public static readonly UnormInt24 Instance = new UnormInt24();
            public override Enumerant Value => ImageChannelDataType.Enumerant.UnormInt24;
            public new static UnormInt24 Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class UnormInt101010_2: ImageChannelDataType
        {
            public static readonly UnormInt101010_2 Instance = new UnormInt101010_2();
            public override Enumerant Value => ImageChannelDataType.Enumerant.UnormInt101010_2;
            public new static UnormInt101010_2 Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }

        public abstract Enumerant Value { get; }

        public static ImageChannelDataType Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                case Enumerant.SnormInt8 :
                    return SnormInt8.Parse(reader, wordCount - 1);
                case Enumerant.SnormInt16 :
                    return SnormInt16.Parse(reader, wordCount - 1);
                case Enumerant.UnormInt8 :
                    return UnormInt8.Parse(reader, wordCount - 1);
                case Enumerant.UnormInt16 :
                    return UnormInt16.Parse(reader, wordCount - 1);
                case Enumerant.UnormShort565 :
                    return UnormShort565.Parse(reader, wordCount - 1);
                case Enumerant.UnormShort555 :
                    return UnormShort555.Parse(reader, wordCount - 1);
                case Enumerant.UnormInt101010 :
                    return UnormInt101010.Parse(reader, wordCount - 1);
                case Enumerant.SignedInt8 :
                    return SignedInt8.Parse(reader, wordCount - 1);
                case Enumerant.SignedInt16 :
                    return SignedInt16.Parse(reader, wordCount - 1);
                case Enumerant.SignedInt32 :
                    return SignedInt32.Parse(reader, wordCount - 1);
                case Enumerant.UnsignedInt8 :
                    return UnsignedInt8.Parse(reader, wordCount - 1);
                case Enumerant.UnsignedInt16 :
                    return UnsignedInt16.Parse(reader, wordCount - 1);
                case Enumerant.UnsignedInt32 :
                    return UnsignedInt32.Parse(reader, wordCount - 1);
                case Enumerant.HalfFloat :
                    return HalfFloat.Parse(reader, wordCount - 1);
                case Enumerant.Float :
                    return Float.Parse(reader, wordCount - 1);
                case Enumerant.UnormInt24 :
                    return UnormInt24.Parse(reader, wordCount - 1);
                case Enumerant.UnormInt101010_2 :
                    return UnormInt101010_2.Parse(reader, wordCount - 1);
                default:
                    throw new IndexOutOfRangeException("Unknown ImageChannelDataType "+id);
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