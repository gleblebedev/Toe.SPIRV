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
        public class Initializer: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.Initializer;
            public new static Initializer Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Initializer();
                return res;
            }
        }
        public class Finalizer: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.Finalizer;
            public new static Finalizer Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Finalizer();
                return res;
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
            public override Enumerant Value => ExecutionMode.Enumerant.PostDepthCoverage;
            public new static PostDepthCoverage Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new PostDepthCoverage();
                return res;
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
            public override Enumerant Value => ExecutionMode.Enumerant.StencilRefReplacingEXT;
            public new static StencilRefReplacingEXT Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new StencilRefReplacingEXT();
                return res;
            }
        }
        public class OutputLinesNV: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.OutputLinesNV;
            public new static OutputLinesNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new OutputLinesNV();
                return res;
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
            public override Enumerant Value => ExecutionMode.Enumerant.DerivativeGroupQuadsNV;
            public new static DerivativeGroupQuadsNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new DerivativeGroupQuadsNV();
                return res;
            }
        }
        public class DerivativeGroupLinearNV: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.DerivativeGroupLinearNV;
            public new static DerivativeGroupLinearNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new DerivativeGroupLinearNV();
                return res;
            }
        }
        public class OutputTrianglesNV: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.OutputTrianglesNV;
            public new static OutputTrianglesNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new OutputTrianglesNV();
                return res;
            }
        }
        public class PixelInterlockOrderedEXT: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.PixelInterlockOrderedEXT;
            public new static PixelInterlockOrderedEXT Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new PixelInterlockOrderedEXT();
                return res;
            }
        }
        public class PixelInterlockUnorderedEXT: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.PixelInterlockUnorderedEXT;
            public new static PixelInterlockUnorderedEXT Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new PixelInterlockUnorderedEXT();
                return res;
            }
        }
        public class SampleInterlockOrderedEXT: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.SampleInterlockOrderedEXT;
            public new static SampleInterlockOrderedEXT Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SampleInterlockOrderedEXT();
                return res;
            }
        }
        public class SampleInterlockUnorderedEXT: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.SampleInterlockUnorderedEXT;
            public new static SampleInterlockUnorderedEXT Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SampleInterlockUnorderedEXT();
                return res;
            }
        }
        public class ShadingRateInterlockOrderedEXT: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.ShadingRateInterlockOrderedEXT;
            public new static ShadingRateInterlockOrderedEXT Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ShadingRateInterlockOrderedEXT();
                return res;
            }
        }
        public class ShadingRateInterlockUnorderedEXT: ExecutionMode
        {
            public override Enumerant Value => ExecutionMode.Enumerant.ShadingRateInterlockUnorderedEXT;
            public new static ShadingRateInterlockUnorderedEXT Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ShadingRateInterlockUnorderedEXT();
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