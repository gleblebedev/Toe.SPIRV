using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public abstract partial class ExecutionMode : ValueEnum
    {
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
            [Capability(Capability.Enumerant.Geometry)]
            [Capability(Capability.Enumerant.Tessellation)]
            Triangles = 22,
            [Capability(Capability.Enumerant.Geometry)]
            InputTrianglesAdjacency = 23,
            [Capability(Capability.Enumerant.Tessellation)]
            Quads = 24,
            [Capability(Capability.Enumerant.Tessellation)]
            Isolines = 25,
            [Capability(Capability.Enumerant.Geometry)]
            [Capability(Capability.Enumerant.Tessellation)]
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
            StencilRefReplacingEXT = 5027,
        }

        public class Invocations: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.Invocations;
            public uint NumberofInvocations { get; set; }
            public new static Invocations Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Invocations();
                res.NumberofInvocations = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += NumberofInvocations.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                NumberofInvocations.Write(writer);
            }
        }
        public class SpacingEqual: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.SpacingEqual;
            public new static SpacingEqual Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SpacingEqual();
                return res;
            }
        }
        public class SpacingFractionalEven: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.SpacingFractionalEven;
            public new static SpacingFractionalEven Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SpacingFractionalEven();
                return res;
            }
        }
        public class SpacingFractionalOdd: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.SpacingFractionalOdd;
            public new static SpacingFractionalOdd Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SpacingFractionalOdd();
                return res;
            }
        }
        public class VertexOrderCw: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.VertexOrderCw;
            public new static VertexOrderCw Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new VertexOrderCw();
                return res;
            }
        }
        public class VertexOrderCcw: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.VertexOrderCcw;
            public new static VertexOrderCcw Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new VertexOrderCcw();
                return res;
            }
        }
        public class PixelCenterInteger: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.PixelCenterInteger;
            public new static PixelCenterInteger Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new PixelCenterInteger();
                return res;
            }
        }
        public class OriginUpperLeft: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.OriginUpperLeft;
            public new static OriginUpperLeft Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new OriginUpperLeft();
                return res;
            }
        }
        public class OriginLowerLeft: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.OriginLowerLeft;
            public new static OriginLowerLeft Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new OriginLowerLeft();
                return res;
            }
        }
        public class EarlyFragmentTests: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.EarlyFragmentTests;
            public new static EarlyFragmentTests Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new EarlyFragmentTests();
                return res;
            }
        }
        public class PointMode: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.PointMode;
            public new static PointMode Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new PointMode();
                return res;
            }
        }
        public class Xfb: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.Xfb;
            public new static Xfb Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Xfb();
                return res;
            }
        }
        public class DepthReplacing: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.DepthReplacing;
            public new static DepthReplacing Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new DepthReplacing();
                return res;
            }
        }
        public class DepthGreater: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.DepthGreater;
            public new static DepthGreater Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new DepthGreater();
                return res;
            }
        }
        public class DepthLess: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.DepthLess;
            public new static DepthLess Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new DepthLess();
                return res;
            }
        }
        public class DepthUnchanged: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.DepthUnchanged;
            public new static DepthUnchanged Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new DepthUnchanged();
                return res;
            }
        }
        public class LocalSize: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.LocalSize;
            public uint xsize { get; set; }
            public uint ysize { get; set; }
            public uint zsize { get; set; }
            public new static LocalSize Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new LocalSize();
                res.xsize = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                res.ysize = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                res.zsize = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += xsize.GetWordCount();
                wordCount += ysize.GetWordCount();
                wordCount += zsize.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                xsize.Write(writer);
                ysize.Write(writer);
                zsize.Write(writer);
            }
        }
        public class LocalSizeHint: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.LocalSizeHint;
            public uint xsize { get; set; }
            public uint ysize { get; set; }
            public uint zsize { get; set; }
            public new static LocalSizeHint Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new LocalSizeHint();
                res.xsize = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                res.ysize = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                res.zsize = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += xsize.GetWordCount();
                wordCount += ysize.GetWordCount();
                wordCount += zsize.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                xsize.Write(writer);
                ysize.Write(writer);
                zsize.Write(writer);
            }
        }
        public class InputPoints: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.InputPoints;
            public new static InputPoints Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new InputPoints();
                return res;
            }
        }
        public class InputLines: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.InputLines;
            public new static InputLines Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new InputLines();
                return res;
            }
        }
        public class InputLinesAdjacency: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.InputLinesAdjacency;
            public new static InputLinesAdjacency Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new InputLinesAdjacency();
                return res;
            }
        }
        public class Triangles: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.Triangles;
            public new static Triangles Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Triangles();
                return res;
            }
        }
        public class InputTrianglesAdjacency: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.InputTrianglesAdjacency;
            public new static InputTrianglesAdjacency Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new InputTrianglesAdjacency();
                return res;
            }
        }
        public class Quads: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.Quads;
            public new static Quads Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Quads();
                return res;
            }
        }
        public class Isolines: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.Isolines;
            public new static Isolines Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Isolines();
                return res;
            }
        }
        public class OutputVertices: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.OutputVertices;
            public uint Vertexcount { get; set; }
            public new static OutputVertices Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new OutputVertices();
                res.Vertexcount = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += Vertexcount.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                Vertexcount.Write(writer);
            }
        }
        public class OutputPoints: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.OutputPoints;
            public new static OutputPoints Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new OutputPoints();
                return res;
            }
        }
        public class OutputLineStrip: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.OutputLineStrip;
            public new static OutputLineStrip Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new OutputLineStrip();
                return res;
            }
        }
        public class OutputTriangleStrip: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.OutputTriangleStrip;
            public new static OutputTriangleStrip Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new OutputTriangleStrip();
                return res;
            }
        }
        public class VecTypeHint: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.VecTypeHint;
            public uint Vectortype { get; set; }
            public new static VecTypeHint Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new VecTypeHint();
                res.Vectortype = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += Vectortype.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                Vectortype.Write(writer);
            }
        }
        public class ContractionOff: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.ContractionOff;
            public new static ContractionOff Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ContractionOff();
                return res;
            }
        }
        public class PostDepthCoverage: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.PostDepthCoverage;
            public new static PostDepthCoverage Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new PostDepthCoverage();
                return res;
            }
        }
        public class StencilRefReplacingEXT: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.StencilRefReplacingEXT;
            public new static StencilRefReplacingEXT Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new StencilRefReplacingEXT();
                return res;
            }
        }

        public abstract Enumerant Value { get; }

        public static ExecutionMode Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                case Enumerant.Invocations :
                    return Invocations.Parse(reader, wordCount - 1);
                case Enumerant.SpacingEqual :
                    return SpacingEqual.Parse(reader, wordCount - 1);
                case Enumerant.SpacingFractionalEven :
                    return SpacingFractionalEven.Parse(reader, wordCount - 1);
                case Enumerant.SpacingFractionalOdd :
                    return SpacingFractionalOdd.Parse(reader, wordCount - 1);
                case Enumerant.VertexOrderCw :
                    return VertexOrderCw.Parse(reader, wordCount - 1);
                case Enumerant.VertexOrderCcw :
                    return VertexOrderCcw.Parse(reader, wordCount - 1);
                case Enumerant.PixelCenterInteger :
                    return PixelCenterInteger.Parse(reader, wordCount - 1);
                case Enumerant.OriginUpperLeft :
                    return OriginUpperLeft.Parse(reader, wordCount - 1);
                case Enumerant.OriginLowerLeft :
                    return OriginLowerLeft.Parse(reader, wordCount - 1);
                case Enumerant.EarlyFragmentTests :
                    return EarlyFragmentTests.Parse(reader, wordCount - 1);
                case Enumerant.PointMode :
                    return PointMode.Parse(reader, wordCount - 1);
                case Enumerant.Xfb :
                    return Xfb.Parse(reader, wordCount - 1);
                case Enumerant.DepthReplacing :
                    return DepthReplacing.Parse(reader, wordCount - 1);
                case Enumerant.DepthGreater :
                    return DepthGreater.Parse(reader, wordCount - 1);
                case Enumerant.DepthLess :
                    return DepthLess.Parse(reader, wordCount - 1);
                case Enumerant.DepthUnchanged :
                    return DepthUnchanged.Parse(reader, wordCount - 1);
                case Enumerant.LocalSize :
                    return LocalSize.Parse(reader, wordCount - 1);
                case Enumerant.LocalSizeHint :
                    return LocalSizeHint.Parse(reader, wordCount - 1);
                case Enumerant.InputPoints :
                    return InputPoints.Parse(reader, wordCount - 1);
                case Enumerant.InputLines :
                    return InputLines.Parse(reader, wordCount - 1);
                case Enumerant.InputLinesAdjacency :
                    return InputLinesAdjacency.Parse(reader, wordCount - 1);
                case Enumerant.Triangles :
                    return Triangles.Parse(reader, wordCount - 1);
                case Enumerant.InputTrianglesAdjacency :
                    return InputTrianglesAdjacency.Parse(reader, wordCount - 1);
                case Enumerant.Quads :
                    return Quads.Parse(reader, wordCount - 1);
                case Enumerant.Isolines :
                    return Isolines.Parse(reader, wordCount - 1);
                case Enumerant.OutputVertices :
                    return OutputVertices.Parse(reader, wordCount - 1);
                case Enumerant.OutputPoints :
                    return OutputPoints.Parse(reader, wordCount - 1);
                case Enumerant.OutputLineStrip :
                    return OutputLineStrip.Parse(reader, wordCount - 1);
                case Enumerant.OutputTriangleStrip :
                    return OutputTriangleStrip.Parse(reader, wordCount - 1);
                case Enumerant.VecTypeHint :
                    return VecTypeHint.Parse(reader, wordCount - 1);
                case Enumerant.ContractionOff :
                    return ContractionOff.Parse(reader, wordCount - 1);
                case Enumerant.PostDepthCoverage :
                    return PostDepthCoverage.Parse(reader, wordCount - 1);
                case Enumerant.StencilRefReplacingEXT :
                    return StencilRefReplacingEXT.Parse(reader, wordCount - 1);
                default:
                    throw new IndexOutOfRangeException("Unknown ExecutionMode "+id);
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