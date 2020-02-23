using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public abstract partial class BuiltIn : ValueEnum
    {
        public enum Enumerant
        {
            [Capability(Capability.Enumerant.Shader)]
            Position = 0,
            [Capability(Capability.Enumerant.Shader)]
            PointSize = 1,
            [Capability(Capability.Enumerant.ClipDistance)]
            ClipDistance = 3,
            [Capability(Capability.Enumerant.CullDistance)]
            CullDistance = 4,
            [Capability(Capability.Enumerant.Shader)]
            VertexId = 5,
            [Capability(Capability.Enumerant.Shader)]
            InstanceId = 6,
            [Capability(Capability.Enumerant.Geometry)]
            [Capability(Capability.Enumerant.Tessellation)]
            PrimitiveId = 7,
            [Capability(Capability.Enumerant.Geometry)]
            [Capability(Capability.Enumerant.Tessellation)]
            InvocationId = 8,
            [Capability(Capability.Enumerant.Geometry)]
            Layer = 9,
            [Capability(Capability.Enumerant.MultiViewport)]
            ViewportIndex = 10,
            [Capability(Capability.Enumerant.Tessellation)]
            TessLevelOuter = 11,
            [Capability(Capability.Enumerant.Tessellation)]
            TessLevelInner = 12,
            [Capability(Capability.Enumerant.Tessellation)]
            TessCoord = 13,
            [Capability(Capability.Enumerant.Tessellation)]
            PatchVertices = 14,
            [Capability(Capability.Enumerant.Shader)]
            FragCoord = 15,
            [Capability(Capability.Enumerant.Shader)]
            PointCoord = 16,
            [Capability(Capability.Enumerant.Shader)]
            FrontFacing = 17,
            [Capability(Capability.Enumerant.SampleRateShading)]
            SampleId = 18,
            [Capability(Capability.Enumerant.SampleRateShading)]
            SamplePosition = 19,
            [Capability(Capability.Enumerant.Shader)]
            SampleMask = 20,
            [Capability(Capability.Enumerant.Shader)]
            FragDepth = 22,
            [Capability(Capability.Enumerant.Shader)]
            HelperInvocation = 23,
            NumWorkgroups = 24,
            WorkgroupSize = 25,
            WorkgroupId = 26,
            LocalInvocationId = 27,
            GlobalInvocationId = 28,
            LocalInvocationIndex = 29,
            [Capability(Capability.Enumerant.Kernel)]
            WorkDim = 30,
            [Capability(Capability.Enumerant.Kernel)]
            GlobalSize = 31,
            [Capability(Capability.Enumerant.Kernel)]
            EnqueuedWorkgroupSize = 32,
            [Capability(Capability.Enumerant.Kernel)]
            GlobalOffset = 33,
            [Capability(Capability.Enumerant.Kernel)]
            GlobalLinearId = 34,
            [Capability(Capability.Enumerant.Kernel)]
            [Capability(Capability.Enumerant.SubgroupBallotKHR)]
            SubgroupSize = 36,
            [Capability(Capability.Enumerant.Kernel)]
            SubgroupMaxSize = 37,
            [Capability(Capability.Enumerant.Kernel)]
            NumSubgroups = 38,
            [Capability(Capability.Enumerant.Kernel)]
            NumEnqueuedSubgroups = 39,
            [Capability(Capability.Enumerant.Kernel)]
            SubgroupId = 40,
            [Capability(Capability.Enumerant.Kernel)]
            [Capability(Capability.Enumerant.SubgroupBallotKHR)]
            SubgroupLocalInvocationId = 41,
            [Capability(Capability.Enumerant.Shader)]
            VertexIndex = 42,
            [Capability(Capability.Enumerant.Shader)]
            InstanceIndex = 43,
            [Capability(Capability.Enumerant.SubgroupBallotKHR)]
            SubgroupEqMaskKHR = 4416,
            [Capability(Capability.Enumerant.SubgroupBallotKHR)]
            SubgroupGeMaskKHR = 4417,
            [Capability(Capability.Enumerant.SubgroupBallotKHR)]
            SubgroupGtMaskKHR = 4418,
            [Capability(Capability.Enumerant.SubgroupBallotKHR)]
            SubgroupLeMaskKHR = 4419,
            [Capability(Capability.Enumerant.SubgroupBallotKHR)]
            SubgroupLtMaskKHR = 4420,
            [Capability(Capability.Enumerant.DrawParameters)]
            BaseVertex = 4424,
            [Capability(Capability.Enumerant.DrawParameters)]
            BaseInstance = 4425,
            [Capability(Capability.Enumerant.DrawParameters)]
            DrawIndex = 4426,
            [Capability(Capability.Enumerant.DeviceGroup)]
            DeviceIndex = 4438,
            [Capability(Capability.Enumerant.MultiView)]
            ViewIndex = 4440,
            BaryCoordNoPerspAMD = 4992,
            BaryCoordNoPerspCentroidAMD = 4993,
            BaryCoordNoPerspSampleAMD = 4994,
            BaryCoordSmoothAMD = 4995,
            BaryCoordSmoothCentroidAMD = 4996,
            BaryCoordSmoothSampleAMD = 4997,
            BaryCoordPullModelAMD = 4998,
            [Capability(Capability.Enumerant.StencilExportEXT)]
            FragStencilRefEXT = 5014,
            [Capability(Capability.Enumerant.ShaderViewportMaskNV)]
            ViewportMaskNV = 5253,
            [Capability(Capability.Enumerant.ShaderStereoViewNV)]
            SecondaryPositionNV = 5257,
            [Capability(Capability.Enumerant.ShaderStereoViewNV)]
            SecondaryViewportMaskNV = 5258,
            [Capability(Capability.Enumerant.PerViewAttributesNV)]
            PositionPerViewNV = 5261,
            [Capability(Capability.Enumerant.PerViewAttributesNV)]
            ViewportMaskPerViewNV = 5262,
        }

        public class Position: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.Position;
            public new static Position Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Position();
                return res;
            }
        }
        public class PointSize: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.PointSize;
            public new static PointSize Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new PointSize();
                return res;
            }
        }
        public class ClipDistance: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.ClipDistance;
            public new static ClipDistance Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ClipDistance();
                return res;
            }
        }
        public class CullDistance: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.CullDistance;
            public new static CullDistance Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new CullDistance();
                return res;
            }
        }
        public class VertexId: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.VertexId;
            public new static VertexId Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new VertexId();
                return res;
            }
        }
        public class InstanceId: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.InstanceId;
            public new static InstanceId Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new InstanceId();
                return res;
            }
        }
        public class PrimitiveId: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.PrimitiveId;
            public new static PrimitiveId Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new PrimitiveId();
                return res;
            }
        }
        public class InvocationId: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.InvocationId;
            public new static InvocationId Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new InvocationId();
                return res;
            }
        }
        public class Layer: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.Layer;
            public new static Layer Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Layer();
                return res;
            }
        }
        public class ViewportIndex: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.ViewportIndex;
            public new static ViewportIndex Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ViewportIndex();
                return res;
            }
        }
        public class TessLevelOuter: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.TessLevelOuter;
            public new static TessLevelOuter Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new TessLevelOuter();
                return res;
            }
        }
        public class TessLevelInner: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.TessLevelInner;
            public new static TessLevelInner Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new TessLevelInner();
                return res;
            }
        }
        public class TessCoord: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.TessCoord;
            public new static TessCoord Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new TessCoord();
                return res;
            }
        }
        public class PatchVertices: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.PatchVertices;
            public new static PatchVertices Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new PatchVertices();
                return res;
            }
        }
        public class FragCoord: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.FragCoord;
            public new static FragCoord Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new FragCoord();
                return res;
            }
        }
        public class PointCoord: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.PointCoord;
            public new static PointCoord Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new PointCoord();
                return res;
            }
        }
        public class FrontFacing: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.FrontFacing;
            public new static FrontFacing Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new FrontFacing();
                return res;
            }
        }
        public class SampleId: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.SampleId;
            public new static SampleId Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SampleId();
                return res;
            }
        }
        public class SamplePosition: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.SamplePosition;
            public new static SamplePosition Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SamplePosition();
                return res;
            }
        }
        public class SampleMask: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.SampleMask;
            public new static SampleMask Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SampleMask();
                return res;
            }
        }
        public class FragDepth: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.FragDepth;
            public new static FragDepth Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new FragDepth();
                return res;
            }
        }
        public class HelperInvocation: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.HelperInvocation;
            public new static HelperInvocation Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new HelperInvocation();
                return res;
            }
        }
        public class NumWorkgroups: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.NumWorkgroups;
            public new static NumWorkgroups Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new NumWorkgroups();
                return res;
            }
        }
        public class WorkgroupSize: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.WorkgroupSize;
            public new static WorkgroupSize Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new WorkgroupSize();
                return res;
            }
        }
        public class WorkgroupId: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.WorkgroupId;
            public new static WorkgroupId Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new WorkgroupId();
                return res;
            }
        }
        public class LocalInvocationId: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.LocalInvocationId;
            public new static LocalInvocationId Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new LocalInvocationId();
                return res;
            }
        }
        public class GlobalInvocationId: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.GlobalInvocationId;
            public new static GlobalInvocationId Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new GlobalInvocationId();
                return res;
            }
        }
        public class LocalInvocationIndex: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.LocalInvocationIndex;
            public new static LocalInvocationIndex Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new LocalInvocationIndex();
                return res;
            }
        }
        public class WorkDim: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.WorkDim;
            public new static WorkDim Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new WorkDim();
                return res;
            }
        }
        public class GlobalSize: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.GlobalSize;
            public new static GlobalSize Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new GlobalSize();
                return res;
            }
        }
        public class EnqueuedWorkgroupSize: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.EnqueuedWorkgroupSize;
            public new static EnqueuedWorkgroupSize Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new EnqueuedWorkgroupSize();
                return res;
            }
        }
        public class GlobalOffset: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.GlobalOffset;
            public new static GlobalOffset Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new GlobalOffset();
                return res;
            }
        }
        public class GlobalLinearId: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.GlobalLinearId;
            public new static GlobalLinearId Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new GlobalLinearId();
                return res;
            }
        }
        public class SubgroupSize: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.SubgroupSize;
            public new static SubgroupSize Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SubgroupSize();
                return res;
            }
        }
        public class SubgroupMaxSize: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.SubgroupMaxSize;
            public new static SubgroupMaxSize Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SubgroupMaxSize();
                return res;
            }
        }
        public class NumSubgroups: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.NumSubgroups;
            public new static NumSubgroups Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new NumSubgroups();
                return res;
            }
        }
        public class NumEnqueuedSubgroups: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.NumEnqueuedSubgroups;
            public new static NumEnqueuedSubgroups Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new NumEnqueuedSubgroups();
                return res;
            }
        }
        public class SubgroupId: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.SubgroupId;
            public new static SubgroupId Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SubgroupId();
                return res;
            }
        }
        public class SubgroupLocalInvocationId: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.SubgroupLocalInvocationId;
            public new static SubgroupLocalInvocationId Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SubgroupLocalInvocationId();
                return res;
            }
        }
        public class VertexIndex: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.VertexIndex;
            public new static VertexIndex Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new VertexIndex();
                return res;
            }
        }
        public class InstanceIndex: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.InstanceIndex;
            public new static InstanceIndex Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new InstanceIndex();
                return res;
            }
        }
        public class SubgroupEqMaskKHR: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.SubgroupEqMaskKHR;
            public new static SubgroupEqMaskKHR Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SubgroupEqMaskKHR();
                return res;
            }
        }
        public class SubgroupGeMaskKHR: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.SubgroupGeMaskKHR;
            public new static SubgroupGeMaskKHR Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SubgroupGeMaskKHR();
                return res;
            }
        }
        public class SubgroupGtMaskKHR: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.SubgroupGtMaskKHR;
            public new static SubgroupGtMaskKHR Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SubgroupGtMaskKHR();
                return res;
            }
        }
        public class SubgroupLeMaskKHR: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.SubgroupLeMaskKHR;
            public new static SubgroupLeMaskKHR Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SubgroupLeMaskKHR();
                return res;
            }
        }
        public class SubgroupLtMaskKHR: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.SubgroupLtMaskKHR;
            public new static SubgroupLtMaskKHR Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SubgroupLtMaskKHR();
                return res;
            }
        }
        public class BaseVertex: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.BaseVertex;
            public new static BaseVertex Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new BaseVertex();
                return res;
            }
        }
        public class BaseInstance: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.BaseInstance;
            public new static BaseInstance Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new BaseInstance();
                return res;
            }
        }
        public class DrawIndex: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.DrawIndex;
            public new static DrawIndex Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new DrawIndex();
                return res;
            }
        }
        public class DeviceIndex: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.DeviceIndex;
            public new static DeviceIndex Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new DeviceIndex();
                return res;
            }
        }
        public class ViewIndex: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.ViewIndex;
            public new static ViewIndex Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ViewIndex();
                return res;
            }
        }
        public class BaryCoordNoPerspAMD: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.BaryCoordNoPerspAMD;
            public new static BaryCoordNoPerspAMD Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new BaryCoordNoPerspAMD();
                return res;
            }
        }
        public class BaryCoordNoPerspCentroidAMD: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.BaryCoordNoPerspCentroidAMD;
            public new static BaryCoordNoPerspCentroidAMD Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new BaryCoordNoPerspCentroidAMD();
                return res;
            }
        }
        public class BaryCoordNoPerspSampleAMD: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.BaryCoordNoPerspSampleAMD;
            public new static BaryCoordNoPerspSampleAMD Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new BaryCoordNoPerspSampleAMD();
                return res;
            }
        }
        public class BaryCoordSmoothAMD: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.BaryCoordSmoothAMD;
            public new static BaryCoordSmoothAMD Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new BaryCoordSmoothAMD();
                return res;
            }
        }
        public class BaryCoordSmoothCentroidAMD: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.BaryCoordSmoothCentroidAMD;
            public new static BaryCoordSmoothCentroidAMD Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new BaryCoordSmoothCentroidAMD();
                return res;
            }
        }
        public class BaryCoordSmoothSampleAMD: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.BaryCoordSmoothSampleAMD;
            public new static BaryCoordSmoothSampleAMD Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new BaryCoordSmoothSampleAMD();
                return res;
            }
        }
        public class BaryCoordPullModelAMD: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.BaryCoordPullModelAMD;
            public new static BaryCoordPullModelAMD Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new BaryCoordPullModelAMD();
                return res;
            }
        }
        public class FragStencilRefEXT: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.FragStencilRefEXT;
            public new static FragStencilRefEXT Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new FragStencilRefEXT();
                return res;
            }
        }
        public class ViewportMaskNV: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.ViewportMaskNV;
            public new static ViewportMaskNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ViewportMaskNV();
                return res;
            }
        }
        public class SecondaryPositionNV: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.SecondaryPositionNV;
            public new static SecondaryPositionNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SecondaryPositionNV();
                return res;
            }
        }
        public class SecondaryViewportMaskNV: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.SecondaryViewportMaskNV;
            public new static SecondaryViewportMaskNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SecondaryViewportMaskNV();
                return res;
            }
        }
        public class PositionPerViewNV: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.PositionPerViewNV;
            public new static PositionPerViewNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new PositionPerViewNV();
                return res;
            }
        }
        public class ViewportMaskPerViewNV: BuiltIn
        {
            public override Enumerant Value => BuiltIn.Enumerant.ViewportMaskPerViewNV;
            public new static ViewportMaskPerViewNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ViewportMaskPerViewNV();
                return res;
            }
        }

        public abstract Enumerant Value { get; }

        public static BuiltIn Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                case Enumerant.Position :
                    return Position.Parse(reader, wordCount - 1);
                case Enumerant.PointSize :
                    return PointSize.Parse(reader, wordCount - 1);
                case Enumerant.ClipDistance :
                    return ClipDistance.Parse(reader, wordCount - 1);
                case Enumerant.CullDistance :
                    return CullDistance.Parse(reader, wordCount - 1);
                case Enumerant.VertexId :
                    return VertexId.Parse(reader, wordCount - 1);
                case Enumerant.InstanceId :
                    return InstanceId.Parse(reader, wordCount - 1);
                case Enumerant.PrimitiveId :
                    return PrimitiveId.Parse(reader, wordCount - 1);
                case Enumerant.InvocationId :
                    return InvocationId.Parse(reader, wordCount - 1);
                case Enumerant.Layer :
                    return Layer.Parse(reader, wordCount - 1);
                case Enumerant.ViewportIndex :
                    return ViewportIndex.Parse(reader, wordCount - 1);
                case Enumerant.TessLevelOuter :
                    return TessLevelOuter.Parse(reader, wordCount - 1);
                case Enumerant.TessLevelInner :
                    return TessLevelInner.Parse(reader, wordCount - 1);
                case Enumerant.TessCoord :
                    return TessCoord.Parse(reader, wordCount - 1);
                case Enumerant.PatchVertices :
                    return PatchVertices.Parse(reader, wordCount - 1);
                case Enumerant.FragCoord :
                    return FragCoord.Parse(reader, wordCount - 1);
                case Enumerant.PointCoord :
                    return PointCoord.Parse(reader, wordCount - 1);
                case Enumerant.FrontFacing :
                    return FrontFacing.Parse(reader, wordCount - 1);
                case Enumerant.SampleId :
                    return SampleId.Parse(reader, wordCount - 1);
                case Enumerant.SamplePosition :
                    return SamplePosition.Parse(reader, wordCount - 1);
                case Enumerant.SampleMask :
                    return SampleMask.Parse(reader, wordCount - 1);
                case Enumerant.FragDepth :
                    return FragDepth.Parse(reader, wordCount - 1);
                case Enumerant.HelperInvocation :
                    return HelperInvocation.Parse(reader, wordCount - 1);
                case Enumerant.NumWorkgroups :
                    return NumWorkgroups.Parse(reader, wordCount - 1);
                case Enumerant.WorkgroupSize :
                    return WorkgroupSize.Parse(reader, wordCount - 1);
                case Enumerant.WorkgroupId :
                    return WorkgroupId.Parse(reader, wordCount - 1);
                case Enumerant.LocalInvocationId :
                    return LocalInvocationId.Parse(reader, wordCount - 1);
                case Enumerant.GlobalInvocationId :
                    return GlobalInvocationId.Parse(reader, wordCount - 1);
                case Enumerant.LocalInvocationIndex :
                    return LocalInvocationIndex.Parse(reader, wordCount - 1);
                case Enumerant.WorkDim :
                    return WorkDim.Parse(reader, wordCount - 1);
                case Enumerant.GlobalSize :
                    return GlobalSize.Parse(reader, wordCount - 1);
                case Enumerant.EnqueuedWorkgroupSize :
                    return EnqueuedWorkgroupSize.Parse(reader, wordCount - 1);
                case Enumerant.GlobalOffset :
                    return GlobalOffset.Parse(reader, wordCount - 1);
                case Enumerant.GlobalLinearId :
                    return GlobalLinearId.Parse(reader, wordCount - 1);
                case Enumerant.SubgroupSize :
                    return SubgroupSize.Parse(reader, wordCount - 1);
                case Enumerant.SubgroupMaxSize :
                    return SubgroupMaxSize.Parse(reader, wordCount - 1);
                case Enumerant.NumSubgroups :
                    return NumSubgroups.Parse(reader, wordCount - 1);
                case Enumerant.NumEnqueuedSubgroups :
                    return NumEnqueuedSubgroups.Parse(reader, wordCount - 1);
                case Enumerant.SubgroupId :
                    return SubgroupId.Parse(reader, wordCount - 1);
                case Enumerant.SubgroupLocalInvocationId :
                    return SubgroupLocalInvocationId.Parse(reader, wordCount - 1);
                case Enumerant.VertexIndex :
                    return VertexIndex.Parse(reader, wordCount - 1);
                case Enumerant.InstanceIndex :
                    return InstanceIndex.Parse(reader, wordCount - 1);
                case Enumerant.SubgroupEqMaskKHR :
                    return SubgroupEqMaskKHR.Parse(reader, wordCount - 1);
                case Enumerant.SubgroupGeMaskKHR :
                    return SubgroupGeMaskKHR.Parse(reader, wordCount - 1);
                case Enumerant.SubgroupGtMaskKHR :
                    return SubgroupGtMaskKHR.Parse(reader, wordCount - 1);
                case Enumerant.SubgroupLeMaskKHR :
                    return SubgroupLeMaskKHR.Parse(reader, wordCount - 1);
                case Enumerant.SubgroupLtMaskKHR :
                    return SubgroupLtMaskKHR.Parse(reader, wordCount - 1);
                case Enumerant.BaseVertex :
                    return BaseVertex.Parse(reader, wordCount - 1);
                case Enumerant.BaseInstance :
                    return BaseInstance.Parse(reader, wordCount - 1);
                case Enumerant.DrawIndex :
                    return DrawIndex.Parse(reader, wordCount - 1);
                case Enumerant.DeviceIndex :
                    return DeviceIndex.Parse(reader, wordCount - 1);
                case Enumerant.ViewIndex :
                    return ViewIndex.Parse(reader, wordCount - 1);
                case Enumerant.BaryCoordNoPerspAMD :
                    return BaryCoordNoPerspAMD.Parse(reader, wordCount - 1);
                case Enumerant.BaryCoordNoPerspCentroidAMD :
                    return BaryCoordNoPerspCentroidAMD.Parse(reader, wordCount - 1);
                case Enumerant.BaryCoordNoPerspSampleAMD :
                    return BaryCoordNoPerspSampleAMD.Parse(reader, wordCount - 1);
                case Enumerant.BaryCoordSmoothAMD :
                    return BaryCoordSmoothAMD.Parse(reader, wordCount - 1);
                case Enumerant.BaryCoordSmoothCentroidAMD :
                    return BaryCoordSmoothCentroidAMD.Parse(reader, wordCount - 1);
                case Enumerant.BaryCoordSmoothSampleAMD :
                    return BaryCoordSmoothSampleAMD.Parse(reader, wordCount - 1);
                case Enumerant.BaryCoordPullModelAMD :
                    return BaryCoordPullModelAMD.Parse(reader, wordCount - 1);
                case Enumerant.FragStencilRefEXT :
                    return FragStencilRefEXT.Parse(reader, wordCount - 1);
                case Enumerant.ViewportMaskNV :
                    return ViewportMaskNV.Parse(reader, wordCount - 1);
                case Enumerant.SecondaryPositionNV :
                    return SecondaryPositionNV.Parse(reader, wordCount - 1);
                case Enumerant.SecondaryViewportMaskNV :
                    return SecondaryViewportMaskNV.Parse(reader, wordCount - 1);
                case Enumerant.PositionPerViewNV :
                    return PositionPerViewNV.Parse(reader, wordCount - 1);
                case Enumerant.ViewportMaskPerViewNV :
                    return ViewportMaskPerViewNV.Parse(reader, wordCount - 1);
                default:
                    throw new IndexOutOfRangeException("Unknown BuiltIn "+id);
            }
        }
        
        public static BuiltIn ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<BuiltIn> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<BuiltIn>();
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