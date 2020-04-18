using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public abstract partial class Dim : ValueEnum
    {
        public enum Enumerant
        {
            [Capability(Capability.Enumerant.Sampled1D)]
            [Capability(Capability.Enumerant.Image1D)]
            Dim1D = 0,
            [Capability(Capability.Enumerant.Shader)]
            [Capability(Capability.Enumerant.Kernel)]
            [Capability(Capability.Enumerant.ImageMSArray)]
            Dim2D = 1,
            Dim3D = 2,
            [Capability(Capability.Enumerant.Shader)]
            [Capability(Capability.Enumerant.ImageCubeArray)]
            Cube = 3,
            [Capability(Capability.Enumerant.SampledRect)]
            [Capability(Capability.Enumerant.ImageRect)]
            Rect = 4,
            [Capability(Capability.Enumerant.SampledBuffer)]
            [Capability(Capability.Enumerant.ImageBuffer)]
            Buffer = 5,
            [Capability(Capability.Enumerant.InputAttachment)]
            SubpassData = 6,
        }

        public class Dim1D: Dim
        {
            public static readonly Dim1D Instance = new Dim1D();
            public override Enumerant Value => Dim.Enumerant.Dim1D;
            public new static Dim1D Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Dim2D: Dim
        {
            public static readonly Dim2D Instance = new Dim2D();
            public override Enumerant Value => Dim.Enumerant.Dim2D;
            public new static Dim2D Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Dim3D: Dim
        {
            public static readonly Dim3D Instance = new Dim3D();
            public override Enumerant Value => Dim.Enumerant.Dim3D;
            public new static Dim3D Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Cube: Dim
        {
            public static readonly Cube Instance = new Cube();
            public override Enumerant Value => Dim.Enumerant.Cube;
            public new static Cube Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Rect: Dim
        {
            public static readonly Rect Instance = new Rect();
            public override Enumerant Value => Dim.Enumerant.Rect;
            public new static Rect Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Buffer: Dim
        {
            public static readonly Buffer Instance = new Buffer();
            public override Enumerant Value => Dim.Enumerant.Buffer;
            public new static Buffer Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SubpassData: Dim
        {
            public static readonly SubpassData Instance = new SubpassData();
            public override Enumerant Value => Dim.Enumerant.SubpassData;
            public new static SubpassData Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }

        public abstract Enumerant Value { get; }

        public static Dim Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                case Enumerant.Dim1D :
                    return Dim1D.Parse(reader, wordCount - 1);
                case Enumerant.Dim2D :
                    return Dim2D.Parse(reader, wordCount - 1);
                case Enumerant.Dim3D :
                    return Dim3D.Parse(reader, wordCount - 1);
                case Enumerant.Cube :
                    return Cube.Parse(reader, wordCount - 1);
                case Enumerant.Rect :
                    return Rect.Parse(reader, wordCount - 1);
                case Enumerant.Buffer :
                    return Buffer.Parse(reader, wordCount - 1);
                case Enumerant.SubpassData :
                    return SubpassData.Parse(reader, wordCount - 1);
                default:
                    throw new IndexOutOfRangeException("Unknown Dim "+id);
            }
        }
        
        public static Dim ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<Dim> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<Dim>();
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