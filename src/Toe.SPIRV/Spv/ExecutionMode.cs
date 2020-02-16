using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public class ExecutionMode : ValueEnum
    {
        public ExecutionMode(Enumerant value)
        {
            Value = value;
        }

        public enum Enumerant
        {
            [Capability(Capability.Enumerant.Geometry)]
            Invocations = 0,

            [Capability(Capability.Enumerant.Tessellation)]
            SpacingEqual = 1,

            [Capability(Capability.Enumerant.Tessellation)]
            SpacingFractionalEven = 2,

            [Capability(Capability.Enumerant.Tessellation)]
            SpacingFractionalOdd = 3,

            [Capability(Capability.Enumerant.Tessellation)]
            VertexOrderCw = 4,

            [Capability(Capability.Enumerant.Tessellation)]
            VertexOrderCcw = 5,

            [Capability(Capability.Enumerant.Shader)]
            PixelCenterInteger = 6,

            [Capability(Capability.Enumerant.Shader)]
            OriginUpperLeft = 7,

            [Capability(Capability.Enumerant.Shader)]
            OriginLowerLeft = 8,

            [Capability(Capability.Enumerant.Shader)]
            EarlyFragmentTests = 9,

            [Capability(Capability.Enumerant.Tessellation)]
            PointMode = 10,

            [Capability(Capability.Enumerant.TransformFeedback)]
            Xfb = 11,

            [Capability(Capability.Enumerant.Shader)]
            DepthReplacing = 12,

            [Capability(Capability.Enumerant.Shader)]
            DepthGreater = 14,

            [Capability(Capability.Enumerant.Shader)]
            DepthLess = 15,

            [Capability(Capability.Enumerant.Shader)]
            DepthUnchanged = 16,
            LocalSize = 17,

            [Capability(Capability.Enumerant.Kernel)]
            LocalSizeHint = 18,

            [Capability(Capability.Enumerant.Geometry)]
            InputPoints = 19,

            [Capability(Capability.Enumerant.Geometry)]
            InputLines = 20,

            [Capability(Capability.Enumerant.Geometry)]
            InputLinesAdjacency = 21,

            [Capability(Capability.Enumerant.Geometry)] [Capability(Capability.Enumerant.Tessellation)]
            Triangles = 22,

            [Capability(Capability.Enumerant.Geometry)]
            InputTrianglesAdjacency = 23,

            [Capability(Capability.Enumerant.Tessellation)]
            Quads = 24,

            [Capability(Capability.Enumerant.Tessellation)]
            Isolines = 25,

            [Capability(Capability.Enumerant.Geometry)] [Capability(Capability.Enumerant.Tessellation)]
            OutputVertices = 26,

            [Capability(Capability.Enumerant.Geometry)]
            OutputPoints = 27,

            [Capability(Capability.Enumerant.Geometry)]
            OutputLineStrip = 28,

            [Capability(Capability.Enumerant.Geometry)]
            OutputTriangleStrip = 29,

            [Capability(Capability.Enumerant.Kernel)]
            VecTypeHint = 30,

            [Capability(Capability.Enumerant.Kernel)]
            ContractionOff = 31,

            [Capability(Capability.Enumerant.SampleMaskPostDepthCoverage)]
            PostDepthCoverage = 4446,

            [Capability(Capability.Enumerant.StencilExportEXT)]
            StencilRefReplacingEXT = 5027
        }

        public Enumerant Value { get; }

        public static ExecutionMode Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                case Enumerant.Invocations:
                    return Invocations.Parse(reader, wordCount - 1);
                case Enumerant.LocalSize:
                    return LocalSize.Parse(reader, wordCount - 1);
                case Enumerant.LocalSizeHint:
                    return LocalSizeHint.Parse(reader, wordCount - 1);
                case Enumerant.OutputVertices:
                    return OutputVertices.Parse(reader, wordCount - 1);
                case Enumerant.VecTypeHint:
                    return VecTypeHint.Parse(reader, wordCount - 1);
                default:
                    return new ExecutionMode(id);
            }
        }

        public static ExecutionMode ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<ExecutionMode> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<ExecutionMode>();
            while (reader.Position < end) res.Add(Parse(reader, end - reader.Position));
            return res;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public class Invocations : ExecutionMode
        {
            public Invocations() : base(Enumerant.Invocations)
            {
            }

            public uint NumberofInvocations { get; set; }

            public new static Invocations Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position + wordCount;
                var res = new Invocations();
                res.NumberofInvocations = LiteralInteger.Parse(reader, end - reader.Position);
                return res;
            }
        }

        public class LocalSize : ExecutionMode
        {
            public LocalSize() : base(Enumerant.LocalSize)
            {
            }

            public uint xsize { get; set; }
            public uint ysize { get; set; }
            public uint zsize { get; set; }

            public new static LocalSize Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position + wordCount;
                var res = new LocalSize();
                res.xsize = LiteralInteger.Parse(reader, end - reader.Position);
                res.ysize = LiteralInteger.Parse(reader, end - reader.Position);
                res.zsize = LiteralInteger.Parse(reader, end - reader.Position);
                return res;
            }
        }

        public class LocalSizeHint : ExecutionMode
        {
            public LocalSizeHint() : base(Enumerant.LocalSizeHint)
            {
            }

            public uint xsize { get; set; }
            public uint ysize { get; set; }
            public uint zsize { get; set; }

            public new static LocalSizeHint Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position + wordCount;
                var res = new LocalSizeHint();
                res.xsize = LiteralInteger.Parse(reader, end - reader.Position);
                res.ysize = LiteralInteger.Parse(reader, end - reader.Position);
                res.zsize = LiteralInteger.Parse(reader, end - reader.Position);
                return res;
            }
        }

        public class OutputVertices : ExecutionMode
        {
            public OutputVertices() : base(Enumerant.OutputVertices)
            {
            }

            public uint Vertexcount { get; set; }

            public new static OutputVertices Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position + wordCount;
                var res = new OutputVertices();
                res.Vertexcount = LiteralInteger.Parse(reader, end - reader.Position);
                return res;
            }
        }

        public class VecTypeHint : ExecutionMode
        {
            public VecTypeHint() : base(Enumerant.VecTypeHint)
            {
            }

            public uint Vectortype { get; set; }

            public new static VecTypeHint Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position + wordCount;
                var res = new VecTypeHint();
                res.Vectortype = LiteralInteger.Parse(reader, end - reader.Position);
                return res;
            }
        }
    }
}