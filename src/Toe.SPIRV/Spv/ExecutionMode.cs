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
            [Capability(Capability.Enumerant.MeshShadingNV)]
            OutputVertices = 26,
            [Capability(Capability.Enumerant.Geometry)]
            [Capability(Capability.Enumerant.MeshShadingNV)]
            OutputPoints = 27,
            [Capability(Capability.Enumerant.Geometry)]
            OutputLineStrip = 28,
            [Capability(Capability.Enumerant.Geometry)]
            OutputTriangleStrip = 29,
            [Capability(Capability.Enumerant.Kernel)]
            VecTypeHint = 30,
            [Capability(Capability.Enumerant.Kernel)]
            ContractionOff = 31,
            [Capability(Capability.Enumerant.Kernel)]
            Initializer = 33,
            [Capability(Capability.Enumerant.Kernel)]
            Finalizer = 34,
            [Capability(Capability.Enumerant.SubgroupDispatch)]
            SubgroupSize = 35,
            [Capability(Capability.Enumerant.SubgroupDispatch)]
            SubgroupsPerWorkgroup = 36,
            [Capability(Capability.Enumerant.SubgroupDispatch)]
            SubgroupsPerWorkgroupId = 37,
            LocalSizeId = 38,
            [Capability(Capability.Enumerant.Kernel)]
            LocalSizeHintId = 39,
            [Capability(Capability.Enumerant.SampleMaskPostDepthCoverage)]
            PostDepthCoverage = 4446,
            [Capability(Capability.Enumerant.DenormPreserve)]
            DenormPreserve = 4459,
            [Capability(Capability.Enumerant.DenormFlushToZero)]
            DenormFlushToZero = 4460,
            [Capability(Capability.Enumerant.SignedZeroInfNanPreserve)]
            SignedZeroInfNanPreserve = 4461,
            [Capability(Capability.Enumerant.RoundingModeRTE)]
            RoundingModeRTE = 4462,
            [Capability(Capability.Enumerant.RoundingModeRTZ)]
            RoundingModeRTZ = 4463,
            [Capability(Capability.Enumerant.StencilExportEXT)]
            StencilRefReplacingEXT = 5027,
            [Capability(Capability.Enumerant.MeshShadingNV)]
            OutputLinesNV = 5269,
            [Capability(Capability.Enumerant.MeshShadingNV)]
            OutputPrimitivesNV = 5270,
            [Capability(Capability.Enumerant.ComputeDerivativeGroupQuadsNV)]
            DerivativeGroupQuadsNV = 5289,
            [Capability(Capability.Enumerant.ComputeDerivativeGroupLinearNV)]
            DerivativeGroupLinearNV = 5290,
            [Capability(Capability.Enumerant.MeshShadingNV)]
            OutputTrianglesNV = 5298,
            [Capability(Capability.Enumerant.FragmentShaderPixelInterlockEXT)]
            PixelInterlockOrderedEXT = 5366,
            [Capability(Capability.Enumerant.FragmentShaderPixelInterlockEXT)]
            PixelInterlockUnorderedEXT = 5367,
            [Capability(Capability.Enumerant.FragmentShaderSampleInterlockEXT)]
            SampleInterlockOrderedEXT = 5368,
            [Capability(Capability.Enumerant.FragmentShaderSampleInterlockEXT)]
            SampleInterlockUnorderedEXT = 5369,
            [Capability(Capability.Enumerant.FragmentShaderShadingRateInterlockEXT)]
            ShadingRateInterlockOrderedEXT = 5370,
            [Capability(Capability.Enumerant.FragmentShaderShadingRateInterlockEXT)]
            ShadingRateInterlockUnorderedEXT = 5371,
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
            public static readonly SpacingEqual Instance = new SpacingEqual();
            public override Enumerant Value => ExecutionMode.Enumerant.SpacingEqual;
            public new static SpacingEqual Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SpacingFractionalEven: ExecutionMode
        {
            public static readonly SpacingFractionalEven Instance = new SpacingFractionalEven();
            public override Enumerant Value => ExecutionMode.Enumerant.SpacingFractionalEven;
            public new static SpacingFractionalEven Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SpacingFractionalOdd: ExecutionMode
        {
            public static readonly SpacingFractionalOdd Instance = new SpacingFractionalOdd();
            public override Enumerant Value => ExecutionMode.Enumerant.SpacingFractionalOdd;
            public new static SpacingFractionalOdd Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class VertexOrderCw: ExecutionMode
        {
            public static readonly VertexOrderCw Instance = new VertexOrderCw();
            public override Enumerant Value => ExecutionMode.Enumerant.VertexOrderCw;
            public new static VertexOrderCw Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class VertexOrderCcw: ExecutionMode
        {
            public static readonly VertexOrderCcw Instance = new VertexOrderCcw();
            public override Enumerant Value => ExecutionMode.Enumerant.VertexOrderCcw;
            public new static VertexOrderCcw Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class PixelCenterInteger: ExecutionMode
        {
            public static readonly PixelCenterInteger Instance = new PixelCenterInteger();
            public override Enumerant Value => ExecutionMode.Enumerant.PixelCenterInteger;
            public new static PixelCenterInteger Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class OriginUpperLeft: ExecutionMode
        {
            public static readonly OriginUpperLeft Instance = new OriginUpperLeft();
            public override Enumerant Value => ExecutionMode.Enumerant.OriginUpperLeft;
            public new static OriginUpperLeft Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class OriginLowerLeft: ExecutionMode
        {
            public static readonly OriginLowerLeft Instance = new OriginLowerLeft();
            public override Enumerant Value => ExecutionMode.Enumerant.OriginLowerLeft;
            public new static OriginLowerLeft Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class EarlyFragmentTests: ExecutionMode
        {
            public static readonly EarlyFragmentTests Instance = new EarlyFragmentTests();
            public override Enumerant Value => ExecutionMode.Enumerant.EarlyFragmentTests;
            public new static EarlyFragmentTests Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class PointMode: ExecutionMode
        {
            public static readonly PointMode Instance = new PointMode();
            public override Enumerant Value => ExecutionMode.Enumerant.PointMode;
            public new static PointMode Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Xfb: ExecutionMode
        {
            public static readonly Xfb Instance = new Xfb();
            public override Enumerant Value => ExecutionMode.Enumerant.Xfb;
            public new static Xfb Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class DepthReplacing: ExecutionMode
        {
            public static readonly DepthReplacing Instance = new DepthReplacing();
            public override Enumerant Value => ExecutionMode.Enumerant.DepthReplacing;
            public new static DepthReplacing Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class DepthGreater: ExecutionMode
        {
            public static readonly DepthGreater Instance = new DepthGreater();
            public override Enumerant Value => ExecutionMode.Enumerant.DepthGreater;
            public new static DepthGreater Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class DepthLess: ExecutionMode
        {
            public static readonly DepthLess Instance = new DepthLess();
            public override Enumerant Value => ExecutionMode.Enumerant.DepthLess;
            public new static DepthLess Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class DepthUnchanged: ExecutionMode
        {
            public static readonly DepthUnchanged Instance = new DepthUnchanged();
            public override Enumerant Value => ExecutionMode.Enumerant.DepthUnchanged;
            public new static DepthUnchanged Parse(WordReader reader, uint wordCount)
            {
                return Instance;
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
            public static readonly InputPoints Instance = new InputPoints();
            public override Enumerant Value => ExecutionMode.Enumerant.InputPoints;
            public new static InputPoints Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class InputLines: ExecutionMode
        {
            public static readonly InputLines Instance = new InputLines();
            public override Enumerant Value => ExecutionMode.Enumerant.InputLines;
            public new static InputLines Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class InputLinesAdjacency: ExecutionMode
        {
            public static readonly InputLinesAdjacency Instance = new InputLinesAdjacency();
            public override Enumerant Value => ExecutionMode.Enumerant.InputLinesAdjacency;
            public new static InputLinesAdjacency Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Triangles: ExecutionMode
        {
            public static readonly Triangles Instance = new Triangles();
            public override Enumerant Value => ExecutionMode.Enumerant.Triangles;
            public new static Triangles Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class InputTrianglesAdjacency: ExecutionMode
        {
            public static readonly InputTrianglesAdjacency Instance = new InputTrianglesAdjacency();
            public override Enumerant Value => ExecutionMode.Enumerant.InputTrianglesAdjacency;
            public new static InputTrianglesAdjacency Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Quads: ExecutionMode
        {
            public static readonly Quads Instance = new Quads();
            public override Enumerant Value => ExecutionMode.Enumerant.Quads;
            public new static Quads Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Isolines: ExecutionMode
        {
            public static readonly Isolines Instance = new Isolines();
            public override Enumerant Value => ExecutionMode.Enumerant.Isolines;
            public new static Isolines Parse(WordReader reader, uint wordCount)
            {
                return Instance;
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
            public static readonly OutputPoints Instance = new OutputPoints();
            public override Enumerant Value => ExecutionMode.Enumerant.OutputPoints;
            public new static OutputPoints Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class OutputLineStrip: ExecutionMode
        {
            public static readonly OutputLineStrip Instance = new OutputLineStrip();
            public override Enumerant Value => ExecutionMode.Enumerant.OutputLineStrip;
            public new static OutputLineStrip Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class OutputTriangleStrip: ExecutionMode
        {
            public static readonly OutputTriangleStrip Instance = new OutputTriangleStrip();
            public override Enumerant Value => ExecutionMode.Enumerant.OutputTriangleStrip;
            public new static OutputTriangleStrip Parse(WordReader reader, uint wordCount)
            {
                return Instance;
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
            public static readonly ContractionOff Instance = new ContractionOff();
            public override Enumerant Value => ExecutionMode.Enumerant.ContractionOff;
            public new static ContractionOff Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Initializer: ExecutionMode
        {
            public static readonly Initializer Instance = new Initializer();
            public override Enumerant Value => ExecutionMode.Enumerant.Initializer;
            public new static Initializer Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Finalizer: ExecutionMode
        {
            public static readonly Finalizer Instance = new Finalizer();
            public override Enumerant Value => ExecutionMode.Enumerant.Finalizer;
            public new static Finalizer Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SubgroupSize: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.SubgroupSize;
            public uint SubgroupSizeValue { get; set; }
            public new static SubgroupSize Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SubgroupSize();
                res.SubgroupSizeValue = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += SubgroupSizeValue.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                SubgroupSizeValue.Write(writer);
            }
        }
        public class SubgroupsPerWorkgroup: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.SubgroupsPerWorkgroup;
            public uint SubgroupsPerWorkgroupValue { get; set; }
            public new static SubgroupsPerWorkgroup Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SubgroupsPerWorkgroup();
                res.SubgroupsPerWorkgroupValue = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += SubgroupsPerWorkgroupValue.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                SubgroupsPerWorkgroupValue.Write(writer);
            }
        }
        public class SubgroupsPerWorkgroupId: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.SubgroupsPerWorkgroupId;
            public Spv.IdRef SubgroupsPerWorkgroup { get; set; }
            public new static SubgroupsPerWorkgroupId Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SubgroupsPerWorkgroupId();
                res.SubgroupsPerWorkgroup = Spv.IdRef.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += SubgroupsPerWorkgroup.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                SubgroupsPerWorkgroup.Write(writer);
            }
        }
        public class LocalSizeId: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.LocalSizeId;
            public Spv.IdRef xsize { get; set; }
            public Spv.IdRef ysize { get; set; }
            public Spv.IdRef zsize { get; set; }
            public new static LocalSizeId Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new LocalSizeId();
                res.xsize = Spv.IdRef.Parse(reader, end-reader.Position);
                res.ysize = Spv.IdRef.Parse(reader, end-reader.Position);
                res.zsize = Spv.IdRef.Parse(reader, end-reader.Position);
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
        public class LocalSizeHintId: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.LocalSizeHintId;
            public Spv.IdRef LocalSizeHint { get; set; }
            public new static LocalSizeHintId Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new LocalSizeHintId();
                res.LocalSizeHint = Spv.IdRef.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += LocalSizeHint.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                LocalSizeHint.Write(writer);
            }
        }
        public class PostDepthCoverage: ExecutionMode
        {
            public static readonly PostDepthCoverage Instance = new PostDepthCoverage();
            public override Enumerant Value => ExecutionMode.Enumerant.PostDepthCoverage;
            public new static PostDepthCoverage Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class DenormPreserve: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.DenormPreserve;
            public uint TargetWidth { get; set; }
            public new static DenormPreserve Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new DenormPreserve();
                res.TargetWidth = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += TargetWidth.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                TargetWidth.Write(writer);
            }
        }
        public class DenormFlushToZero: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.DenormFlushToZero;
            public uint TargetWidth { get; set; }
            public new static DenormFlushToZero Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new DenormFlushToZero();
                res.TargetWidth = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += TargetWidth.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                TargetWidth.Write(writer);
            }
        }
        public class SignedZeroInfNanPreserve: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.SignedZeroInfNanPreserve;
            public uint TargetWidth { get; set; }
            public new static SignedZeroInfNanPreserve Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SignedZeroInfNanPreserve();
                res.TargetWidth = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += TargetWidth.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                TargetWidth.Write(writer);
            }
        }
        public class RoundingModeRTE: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.RoundingModeRTE;
            public uint TargetWidth { get; set; }
            public new static RoundingModeRTE Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new RoundingModeRTE();
                res.TargetWidth = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += TargetWidth.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                TargetWidth.Write(writer);
            }
        }
        public class RoundingModeRTZ: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.RoundingModeRTZ;
            public uint TargetWidth { get; set; }
            public new static RoundingModeRTZ Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new RoundingModeRTZ();
                res.TargetWidth = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += TargetWidth.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                TargetWidth.Write(writer);
            }
        }
        public class StencilRefReplacingEXT: ExecutionMode
        {
            public static readonly StencilRefReplacingEXT Instance = new StencilRefReplacingEXT();
            public override Enumerant Value => ExecutionMode.Enumerant.StencilRefReplacingEXT;
            public new static StencilRefReplacingEXT Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class OutputLinesNV: ExecutionMode
        {
            public static readonly OutputLinesNV Instance = new OutputLinesNV();
            public override Enumerant Value => ExecutionMode.Enumerant.OutputLinesNV;
            public new static OutputLinesNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class OutputPrimitivesNV: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.OutputPrimitivesNV;
            public uint Primitivecount { get; set; }
            public new static OutputPrimitivesNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new OutputPrimitivesNV();
                res.Primitivecount = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += Primitivecount.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                Primitivecount.Write(writer);
            }
        }
        public class DerivativeGroupQuadsNV: ExecutionMode
        {
            public static readonly DerivativeGroupQuadsNV Instance = new DerivativeGroupQuadsNV();
            public override Enumerant Value => ExecutionMode.Enumerant.DerivativeGroupQuadsNV;
            public new static DerivativeGroupQuadsNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class DerivativeGroupLinearNV: ExecutionMode
        {
            public static readonly DerivativeGroupLinearNV Instance = new DerivativeGroupLinearNV();
            public override Enumerant Value => ExecutionMode.Enumerant.DerivativeGroupLinearNV;
            public new static DerivativeGroupLinearNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class OutputTrianglesNV: ExecutionMode
        {
            public static readonly OutputTrianglesNV Instance = new OutputTrianglesNV();
            public override Enumerant Value => ExecutionMode.Enumerant.OutputTrianglesNV;
            public new static OutputTrianglesNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class PixelInterlockOrderedEXT: ExecutionMode
        {
            public static readonly PixelInterlockOrderedEXT Instance = new PixelInterlockOrderedEXT();
            public override Enumerant Value => ExecutionMode.Enumerant.PixelInterlockOrderedEXT;
            public new static PixelInterlockOrderedEXT Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class PixelInterlockUnorderedEXT: ExecutionMode
        {
            public static readonly PixelInterlockUnorderedEXT Instance = new PixelInterlockUnorderedEXT();
            public override Enumerant Value => ExecutionMode.Enumerant.PixelInterlockUnorderedEXT;
            public new static PixelInterlockUnorderedEXT Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SampleInterlockOrderedEXT: ExecutionMode
        {
            public static readonly SampleInterlockOrderedEXT Instance = new SampleInterlockOrderedEXT();
            public override Enumerant Value => ExecutionMode.Enumerant.SampleInterlockOrderedEXT;
            public new static SampleInterlockOrderedEXT Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SampleInterlockUnorderedEXT: ExecutionMode
        {
            public static readonly SampleInterlockUnorderedEXT Instance = new SampleInterlockUnorderedEXT();
            public override Enumerant Value => ExecutionMode.Enumerant.SampleInterlockUnorderedEXT;
            public new static SampleInterlockUnorderedEXT Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class ShadingRateInterlockOrderedEXT: ExecutionMode
        {
            public static readonly ShadingRateInterlockOrderedEXT Instance = new ShadingRateInterlockOrderedEXT();
            public override Enumerant Value => ExecutionMode.Enumerant.ShadingRateInterlockOrderedEXT;
            public new static ShadingRateInterlockOrderedEXT Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class ShadingRateInterlockUnorderedEXT: ExecutionMode
        {
            public static readonly ShadingRateInterlockUnorderedEXT Instance = new ShadingRateInterlockUnorderedEXT();
            public override Enumerant Value => ExecutionMode.Enumerant.ShadingRateInterlockUnorderedEXT;
            public new static ShadingRateInterlockUnorderedEXT Parse(WordReader reader, uint wordCount)
            {
                return Instance;
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
                case Enumerant.Initializer :
                    return Initializer.Parse(reader, wordCount - 1);
                case Enumerant.Finalizer :
                    return Finalizer.Parse(reader, wordCount - 1);
                case Enumerant.SubgroupSize :
                    return SubgroupSize.Parse(reader, wordCount - 1);
                case Enumerant.SubgroupsPerWorkgroup :
                    return SubgroupsPerWorkgroup.Parse(reader, wordCount - 1);
                case Enumerant.SubgroupsPerWorkgroupId :
                    return SubgroupsPerWorkgroupId.Parse(reader, wordCount - 1);
                case Enumerant.LocalSizeId :
                    return LocalSizeId.Parse(reader, wordCount - 1);
                case Enumerant.LocalSizeHintId :
                    return LocalSizeHintId.Parse(reader, wordCount - 1);
                case Enumerant.PostDepthCoverage :
                    return PostDepthCoverage.Parse(reader, wordCount - 1);
                case Enumerant.DenormPreserve :
                    return DenormPreserve.Parse(reader, wordCount - 1);
                case Enumerant.DenormFlushToZero :
                    return DenormFlushToZero.Parse(reader, wordCount - 1);
                case Enumerant.SignedZeroInfNanPreserve :
                    return SignedZeroInfNanPreserve.Parse(reader, wordCount - 1);
                case Enumerant.RoundingModeRTE :
                    return RoundingModeRTE.Parse(reader, wordCount - 1);
                case Enumerant.RoundingModeRTZ :
                    return RoundingModeRTZ.Parse(reader, wordCount - 1);
                case Enumerant.StencilRefReplacingEXT :
                    return StencilRefReplacingEXT.Parse(reader, wordCount - 1);
                case Enumerant.OutputLinesNV :
                    return OutputLinesNV.Parse(reader, wordCount - 1);
                case Enumerant.OutputPrimitivesNV :
                    return OutputPrimitivesNV.Parse(reader, wordCount - 1);
                case Enumerant.DerivativeGroupQuadsNV :
                    return DerivativeGroupQuadsNV.Parse(reader, wordCount - 1);
                case Enumerant.DerivativeGroupLinearNV :
                    return DerivativeGroupLinearNV.Parse(reader, wordCount - 1);
                case Enumerant.OutputTrianglesNV :
                    return OutputTrianglesNV.Parse(reader, wordCount - 1);
                case Enumerant.PixelInterlockOrderedEXT :
                    return PixelInterlockOrderedEXT.Parse(reader, wordCount - 1);
                case Enumerant.PixelInterlockUnorderedEXT :
                    return PixelInterlockUnorderedEXT.Parse(reader, wordCount - 1);
                case Enumerant.SampleInterlockOrderedEXT :
                    return SampleInterlockOrderedEXT.Parse(reader, wordCount - 1);
                case Enumerant.SampleInterlockUnorderedEXT :
                    return SampleInterlockUnorderedEXT.Parse(reader, wordCount - 1);
                case Enumerant.ShadingRateInterlockOrderedEXT :
                    return ShadingRateInterlockOrderedEXT.Parse(reader, wordCount - 1);
                case Enumerant.ShadingRateInterlockUnorderedEXT :
                    return ShadingRateInterlockUnorderedEXT.Parse(reader, wordCount - 1);
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