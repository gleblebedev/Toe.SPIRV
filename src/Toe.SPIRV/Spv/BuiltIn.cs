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
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            PrimitiveId = 7,
            [Capability(Capability.Enumerant.Geometry)]
            [Capability(Capability.Enumerant.Tessellation)]
            InvocationId = 8,
            [Capability(Capability.Enumerant.Geometry)]
            [Capability(Capability.Enumerant.ShaderLayer)]
            [Capability(Capability.Enumerant.ShaderViewportIndexLayerEXT)]
            Layer = 9,
            [Capability(Capability.Enumerant.MultiViewport)]
            [Capability(Capability.Enumerant.ShaderViewportIndex)]
            [Capability(Capability.Enumerant.ShaderViewportIndexLayerEXT)]
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
            [Capability(Capability.Enumerant.GroupNonUniform)]
            [Capability(Capability.Enumerant.SubgroupBallotKHR)]
            SubgroupSize = 36,
            [Capability(Capability.Enumerant.Kernel)]
            SubgroupMaxSize = 37,
            [Capability(Capability.Enumerant.Kernel)]
            [Capability(Capability.Enumerant.GroupNonUniform)]
            NumSubgroups = 38,
            [Capability(Capability.Enumerant.Kernel)]
            NumEnqueuedSubgroups = 39,
            [Capability(Capability.Enumerant.Kernel)]
            [Capability(Capability.Enumerant.GroupNonUniform)]
            SubgroupId = 40,
            [Capability(Capability.Enumerant.Kernel)]
            [Capability(Capability.Enumerant.GroupNonUniform)]
            [Capability(Capability.Enumerant.SubgroupBallotKHR)]
            SubgroupLocalInvocationId = 41,
            [Capability(Capability.Enumerant.Shader)]
            VertexIndex = 42,
            [Capability(Capability.Enumerant.Shader)]
            InstanceIndex = 43,
            [Capability(Capability.Enumerant.SubgroupBallotKHR)]
            [Capability(Capability.Enumerant.GroupNonUniformBallot)]
            SubgroupEqMask = 4416,
            [Capability(Capability.Enumerant.SubgroupBallotKHR)]
            [Capability(Capability.Enumerant.GroupNonUniformBallot)]
            SubgroupGeMask = 4417,
            [Capability(Capability.Enumerant.SubgroupBallotKHR)]
            [Capability(Capability.Enumerant.GroupNonUniformBallot)]
            SubgroupGtMask = 4418,
            [Capability(Capability.Enumerant.SubgroupBallotKHR)]
            [Capability(Capability.Enumerant.GroupNonUniformBallot)]
            SubgroupLeMask = 4419,
            [Capability(Capability.Enumerant.SubgroupBallotKHR)]
            [Capability(Capability.Enumerant.GroupNonUniformBallot)]
            SubgroupLtMask = 4420,
            [Capability(Capability.Enumerant.SubgroupBallotKHR)]
            [Capability(Capability.Enumerant.GroupNonUniformBallot)]
            SubgroupEqMaskKHR = 4416,
            [Capability(Capability.Enumerant.SubgroupBallotKHR)]
            [Capability(Capability.Enumerant.GroupNonUniformBallot)]
            SubgroupGeMaskKHR = 4417,
            [Capability(Capability.Enumerant.SubgroupBallotKHR)]
            [Capability(Capability.Enumerant.GroupNonUniformBallot)]
            SubgroupGtMaskKHR = 4418,
            [Capability(Capability.Enumerant.SubgroupBallotKHR)]
            [Capability(Capability.Enumerant.GroupNonUniformBallot)]
            SubgroupLeMaskKHR = 4419,
            [Capability(Capability.Enumerant.SubgroupBallotKHR)]
            [Capability(Capability.Enumerant.GroupNonUniformBallot)]
            SubgroupLtMaskKHR = 4420,
            [Capability(Capability.Enumerant.DrawParameters)]
            BaseVertex = 4424,
            [Capability(Capability.Enumerant.DrawParameters)]
            BaseInstance = 4425,
            [Capability(Capability.Enumerant.DrawParameters)]
            [Capability(Capability.Enumerant.MeshShadingNV)]
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
            [Capability(Capability.Enumerant.MeshShadingNV)]
            ViewportMaskNV = 5253,
            [Capability(Capability.Enumerant.ShaderStereoViewNV)]
            SecondaryPositionNV = 5257,
            [Capability(Capability.Enumerant.ShaderStereoViewNV)]
            SecondaryViewportMaskNV = 5258,
            [Capability(Capability.Enumerant.PerViewAttributesNV)]
            [Capability(Capability.Enumerant.MeshShadingNV)]
            PositionPerViewNV = 5261,
            [Capability(Capability.Enumerant.PerViewAttributesNV)]
            [Capability(Capability.Enumerant.MeshShadingNV)]
            ViewportMaskPerViewNV = 5262,
            [Capability(Capability.Enumerant.FragmentFullyCoveredEXT)]
            FullyCoveredEXT = 5264,
            [Capability(Capability.Enumerant.MeshShadingNV)]
            TaskCountNV = 5274,
            [Capability(Capability.Enumerant.MeshShadingNV)]
            PrimitiveCountNV = 5275,
            [Capability(Capability.Enumerant.MeshShadingNV)]
            PrimitiveIndicesNV = 5276,
            [Capability(Capability.Enumerant.MeshShadingNV)]
            ClipDistancePerViewNV = 5277,
            [Capability(Capability.Enumerant.MeshShadingNV)]
            CullDistancePerViewNV = 5278,
            [Capability(Capability.Enumerant.MeshShadingNV)]
            LayerPerViewNV = 5279,
            [Capability(Capability.Enumerant.MeshShadingNV)]
            MeshViewCountNV = 5280,
            [Capability(Capability.Enumerant.MeshShadingNV)]
            MeshViewIndicesNV = 5281,
            [Capability(Capability.Enumerant.FragmentBarycentricNV)]
            BaryCoordNV = 5286,
            [Capability(Capability.Enumerant.FragmentBarycentricNV)]
            BaryCoordNoPerspNV = 5287,
            [Capability(Capability.Enumerant.FragmentDensityEXT)]
            [Capability(Capability.Enumerant.ShadingRateNV)]
            FragSizeEXT = 5292,
            [Capability(Capability.Enumerant.ShadingRateNV)]
            [Capability(Capability.Enumerant.FragmentDensityEXT)]
            FragmentSizeNV = 5292,
            [Capability(Capability.Enumerant.FragmentDensityEXT)]
            [Capability(Capability.Enumerant.ShadingRateNV)]
            FragInvocationCountEXT = 5293,
            [Capability(Capability.Enumerant.ShadingRateNV)]
            [Capability(Capability.Enumerant.FragmentDensityEXT)]
            InvocationsPerPixelNV = 5293,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            LaunchIdNV = 5319,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            LaunchIdKHR = 5319,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            LaunchSizeNV = 5320,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            LaunchSizeKHR = 5320,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            WorldRayOriginNV = 5321,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            WorldRayOriginKHR = 5321,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            WorldRayDirectionNV = 5322,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            WorldRayDirectionKHR = 5322,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            ObjectRayOriginNV = 5323,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            ObjectRayOriginKHR = 5323,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            ObjectRayDirectionNV = 5324,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            ObjectRayDirectionKHR = 5324,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            RayTminNV = 5325,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            RayTminKHR = 5325,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            RayTmaxNV = 5326,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            RayTmaxKHR = 5326,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            InstanceCustomIndexNV = 5327,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            InstanceCustomIndexKHR = 5327,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            ObjectToWorldNV = 5330,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            ObjectToWorldKHR = 5330,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            WorldToObjectNV = 5331,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            WorldToObjectKHR = 5331,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            HitTNV = 5332,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            HitTKHR = 5332,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            HitKindNV = 5333,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            HitKindKHR = 5333,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            IncomingRayFlagsNV = 5351,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            IncomingRayFlagsKHR = 5351,
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            RayGeometryIndexKHR = 5352,
            [Capability(Capability.Enumerant.ShaderSMBuiltinsNV)]
            WarpsPerSMNV = 5374,
            [Capability(Capability.Enumerant.ShaderSMBuiltinsNV)]
            SMCountNV = 5375,
            [Capability(Capability.Enumerant.ShaderSMBuiltinsNV)]
            WarpIDNV = 5376,
            [Capability(Capability.Enumerant.ShaderSMBuiltinsNV)]
            SMIDNV = 5377,
        }

        public class Position: BuiltIn
        {
            public static readonly Position Instance = new Position();
            public override Enumerant Value => BuiltIn.Enumerant.Position;
            public new static Position Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class PointSize: BuiltIn
        {
            public static readonly PointSize Instance = new PointSize();
            public override Enumerant Value => BuiltIn.Enumerant.PointSize;
            public new static PointSize Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class ClipDistance: BuiltIn
        {
            public static readonly ClipDistance Instance = new ClipDistance();
            public override Enumerant Value => BuiltIn.Enumerant.ClipDistance;
            public new static ClipDistance Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class CullDistance: BuiltIn
        {
            public static readonly CullDistance Instance = new CullDistance();
            public override Enumerant Value => BuiltIn.Enumerant.CullDistance;
            public new static CullDistance Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class VertexId: BuiltIn
        {
            public static readonly VertexId Instance = new VertexId();
            public override Enumerant Value => BuiltIn.Enumerant.VertexId;
            public new static VertexId Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class InstanceId: BuiltIn
        {
            public static readonly InstanceId Instance = new InstanceId();
            public override Enumerant Value => BuiltIn.Enumerant.InstanceId;
            public new static InstanceId Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class PrimitiveId: BuiltIn
        {
            public static readonly PrimitiveId Instance = new PrimitiveId();
            public override Enumerant Value => BuiltIn.Enumerant.PrimitiveId;
            public new static PrimitiveId Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class InvocationId: BuiltIn
        {
            public static readonly InvocationId Instance = new InvocationId();
            public override Enumerant Value => BuiltIn.Enumerant.InvocationId;
            public new static InvocationId Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Layer: BuiltIn
        {
            public static readonly Layer Instance = new Layer();
            public override Enumerant Value => BuiltIn.Enumerant.Layer;
            public new static Layer Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class ViewportIndex: BuiltIn
        {
            public static readonly ViewportIndex Instance = new ViewportIndex();
            public override Enumerant Value => BuiltIn.Enumerant.ViewportIndex;
            public new static ViewportIndex Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class TessLevelOuter: BuiltIn
        {
            public static readonly TessLevelOuter Instance = new TessLevelOuter();
            public override Enumerant Value => BuiltIn.Enumerant.TessLevelOuter;
            public new static TessLevelOuter Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class TessLevelInner: BuiltIn
        {
            public static readonly TessLevelInner Instance = new TessLevelInner();
            public override Enumerant Value => BuiltIn.Enumerant.TessLevelInner;
            public new static TessLevelInner Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class TessCoord: BuiltIn
        {
            public static readonly TessCoord Instance = new TessCoord();
            public override Enumerant Value => BuiltIn.Enumerant.TessCoord;
            public new static TessCoord Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class PatchVertices: BuiltIn
        {
            public static readonly PatchVertices Instance = new PatchVertices();
            public override Enumerant Value => BuiltIn.Enumerant.PatchVertices;
            public new static PatchVertices Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class FragCoord: BuiltIn
        {
            public static readonly FragCoord Instance = new FragCoord();
            public override Enumerant Value => BuiltIn.Enumerant.FragCoord;
            public new static FragCoord Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class PointCoord: BuiltIn
        {
            public static readonly PointCoord Instance = new PointCoord();
            public override Enumerant Value => BuiltIn.Enumerant.PointCoord;
            public new static PointCoord Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class FrontFacing: BuiltIn
        {
            public static readonly FrontFacing Instance = new FrontFacing();
            public override Enumerant Value => BuiltIn.Enumerant.FrontFacing;
            public new static FrontFacing Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SampleId: BuiltIn
        {
            public static readonly SampleId Instance = new SampleId();
            public override Enumerant Value => BuiltIn.Enumerant.SampleId;
            public new static SampleId Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SamplePosition: BuiltIn
        {
            public static readonly SamplePosition Instance = new SamplePosition();
            public override Enumerant Value => BuiltIn.Enumerant.SamplePosition;
            public new static SamplePosition Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SampleMask: BuiltIn
        {
            public static readonly SampleMask Instance = new SampleMask();
            public override Enumerant Value => BuiltIn.Enumerant.SampleMask;
            public new static SampleMask Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class FragDepth: BuiltIn
        {
            public static readonly FragDepth Instance = new FragDepth();
            public override Enumerant Value => BuiltIn.Enumerant.FragDepth;
            public new static FragDepth Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class HelperInvocation: BuiltIn
        {
            public static readonly HelperInvocation Instance = new HelperInvocation();
            public override Enumerant Value => BuiltIn.Enumerant.HelperInvocation;
            public new static HelperInvocation Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class NumWorkgroups: BuiltIn
        {
            public static readonly NumWorkgroups Instance = new NumWorkgroups();
            public override Enumerant Value => BuiltIn.Enumerant.NumWorkgroups;
            public new static NumWorkgroups Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class WorkgroupSize: BuiltIn
        {
            public static readonly WorkgroupSize Instance = new WorkgroupSize();
            public override Enumerant Value => BuiltIn.Enumerant.WorkgroupSize;
            public new static WorkgroupSize Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class WorkgroupId: BuiltIn
        {
            public static readonly WorkgroupId Instance = new WorkgroupId();
            public override Enumerant Value => BuiltIn.Enumerant.WorkgroupId;
            public new static WorkgroupId Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class LocalInvocationId: BuiltIn
        {
            public static readonly LocalInvocationId Instance = new LocalInvocationId();
            public override Enumerant Value => BuiltIn.Enumerant.LocalInvocationId;
            public new static LocalInvocationId Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class GlobalInvocationId: BuiltIn
        {
            public static readonly GlobalInvocationId Instance = new GlobalInvocationId();
            public override Enumerant Value => BuiltIn.Enumerant.GlobalInvocationId;
            public new static GlobalInvocationId Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class LocalInvocationIndex: BuiltIn
        {
            public static readonly LocalInvocationIndex Instance = new LocalInvocationIndex();
            public override Enumerant Value => BuiltIn.Enumerant.LocalInvocationIndex;
            public new static LocalInvocationIndex Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class WorkDim: BuiltIn
        {
            public static readonly WorkDim Instance = new WorkDim();
            public override Enumerant Value => BuiltIn.Enumerant.WorkDim;
            public new static WorkDim Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class GlobalSize: BuiltIn
        {
            public static readonly GlobalSize Instance = new GlobalSize();
            public override Enumerant Value => BuiltIn.Enumerant.GlobalSize;
            public new static GlobalSize Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class EnqueuedWorkgroupSize: BuiltIn
        {
            public static readonly EnqueuedWorkgroupSize Instance = new EnqueuedWorkgroupSize();
            public override Enumerant Value => BuiltIn.Enumerant.EnqueuedWorkgroupSize;
            public new static EnqueuedWorkgroupSize Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class GlobalOffset: BuiltIn
        {
            public static readonly GlobalOffset Instance = new GlobalOffset();
            public override Enumerant Value => BuiltIn.Enumerant.GlobalOffset;
            public new static GlobalOffset Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class GlobalLinearId: BuiltIn
        {
            public static readonly GlobalLinearId Instance = new GlobalLinearId();
            public override Enumerant Value => BuiltIn.Enumerant.GlobalLinearId;
            public new static GlobalLinearId Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SubgroupSize: BuiltIn
        {
            public static readonly SubgroupSize Instance = new SubgroupSize();
            public override Enumerant Value => BuiltIn.Enumerant.SubgroupSize;
            public new static SubgroupSize Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SubgroupMaxSize: BuiltIn
        {
            public static readonly SubgroupMaxSize Instance = new SubgroupMaxSize();
            public override Enumerant Value => BuiltIn.Enumerant.SubgroupMaxSize;
            public new static SubgroupMaxSize Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class NumSubgroups: BuiltIn
        {
            public static readonly NumSubgroups Instance = new NumSubgroups();
            public override Enumerant Value => BuiltIn.Enumerant.NumSubgroups;
            public new static NumSubgroups Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class NumEnqueuedSubgroups: BuiltIn
        {
            public static readonly NumEnqueuedSubgroups Instance = new NumEnqueuedSubgroups();
            public override Enumerant Value => BuiltIn.Enumerant.NumEnqueuedSubgroups;
            public new static NumEnqueuedSubgroups Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SubgroupId: BuiltIn
        {
            public static readonly SubgroupId Instance = new SubgroupId();
            public override Enumerant Value => BuiltIn.Enumerant.SubgroupId;
            public new static SubgroupId Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SubgroupLocalInvocationId: BuiltIn
        {
            public static readonly SubgroupLocalInvocationId Instance = new SubgroupLocalInvocationId();
            public override Enumerant Value => BuiltIn.Enumerant.SubgroupLocalInvocationId;
            public new static SubgroupLocalInvocationId Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class VertexIndex: BuiltIn
        {
            public static readonly VertexIndex Instance = new VertexIndex();
            public override Enumerant Value => BuiltIn.Enumerant.VertexIndex;
            public new static VertexIndex Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class InstanceIndex: BuiltIn
        {
            public static readonly InstanceIndex Instance = new InstanceIndex();
            public override Enumerant Value => BuiltIn.Enumerant.InstanceIndex;
            public new static InstanceIndex Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SubgroupEqMask: BuiltIn
        {
            public static readonly SubgroupEqMask Instance = new SubgroupEqMask();
            public override Enumerant Value => BuiltIn.Enumerant.SubgroupEqMask;
            public new static SubgroupEqMask Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SubgroupGeMask: BuiltIn
        {
            public static readonly SubgroupGeMask Instance = new SubgroupGeMask();
            public override Enumerant Value => BuiltIn.Enumerant.SubgroupGeMask;
            public new static SubgroupGeMask Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SubgroupGtMask: BuiltIn
        {
            public static readonly SubgroupGtMask Instance = new SubgroupGtMask();
            public override Enumerant Value => BuiltIn.Enumerant.SubgroupGtMask;
            public new static SubgroupGtMask Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SubgroupLeMask: BuiltIn
        {
            public static readonly SubgroupLeMask Instance = new SubgroupLeMask();
            public override Enumerant Value => BuiltIn.Enumerant.SubgroupLeMask;
            public new static SubgroupLeMask Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SubgroupLtMask: BuiltIn
        {
            public static readonly SubgroupLtMask Instance = new SubgroupLtMask();
            public override Enumerant Value => BuiltIn.Enumerant.SubgroupLtMask;
            public new static SubgroupLtMask Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SubgroupEqMaskKHR: BuiltIn
        {
            public static readonly SubgroupEqMaskKHR Instance = new SubgroupEqMaskKHR();
            public override Enumerant Value => BuiltIn.Enumerant.SubgroupEqMaskKHR;
            public new static SubgroupEqMaskKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SubgroupGeMaskKHR: BuiltIn
        {
            public static readonly SubgroupGeMaskKHR Instance = new SubgroupGeMaskKHR();
            public override Enumerant Value => BuiltIn.Enumerant.SubgroupGeMaskKHR;
            public new static SubgroupGeMaskKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SubgroupGtMaskKHR: BuiltIn
        {
            public static readonly SubgroupGtMaskKHR Instance = new SubgroupGtMaskKHR();
            public override Enumerant Value => BuiltIn.Enumerant.SubgroupGtMaskKHR;
            public new static SubgroupGtMaskKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SubgroupLeMaskKHR: BuiltIn
        {
            public static readonly SubgroupLeMaskKHR Instance = new SubgroupLeMaskKHR();
            public override Enumerant Value => BuiltIn.Enumerant.SubgroupLeMaskKHR;
            public new static SubgroupLeMaskKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SubgroupLtMaskKHR: BuiltIn
        {
            public static readonly SubgroupLtMaskKHR Instance = new SubgroupLtMaskKHR();
            public override Enumerant Value => BuiltIn.Enumerant.SubgroupLtMaskKHR;
            public new static SubgroupLtMaskKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class BaseVertex: BuiltIn
        {
            public static readonly BaseVertex Instance = new BaseVertex();
            public override Enumerant Value => BuiltIn.Enumerant.BaseVertex;
            public new static BaseVertex Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class BaseInstance: BuiltIn
        {
            public static readonly BaseInstance Instance = new BaseInstance();
            public override Enumerant Value => BuiltIn.Enumerant.BaseInstance;
            public new static BaseInstance Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class DrawIndex: BuiltIn
        {
            public static readonly DrawIndex Instance = new DrawIndex();
            public override Enumerant Value => BuiltIn.Enumerant.DrawIndex;
            public new static DrawIndex Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class DeviceIndex: BuiltIn
        {
            public static readonly DeviceIndex Instance = new DeviceIndex();
            public override Enumerant Value => BuiltIn.Enumerant.DeviceIndex;
            public new static DeviceIndex Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class ViewIndex: BuiltIn
        {
            public static readonly ViewIndex Instance = new ViewIndex();
            public override Enumerant Value => BuiltIn.Enumerant.ViewIndex;
            public new static ViewIndex Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class BaryCoordNoPerspAMD: BuiltIn
        {
            public static readonly BaryCoordNoPerspAMD Instance = new BaryCoordNoPerspAMD();
            public override Enumerant Value => BuiltIn.Enumerant.BaryCoordNoPerspAMD;
            public new static BaryCoordNoPerspAMD Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class BaryCoordNoPerspCentroidAMD: BuiltIn
        {
            public static readonly BaryCoordNoPerspCentroidAMD Instance = new BaryCoordNoPerspCentroidAMD();
            public override Enumerant Value => BuiltIn.Enumerant.BaryCoordNoPerspCentroidAMD;
            public new static BaryCoordNoPerspCentroidAMD Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class BaryCoordNoPerspSampleAMD: BuiltIn
        {
            public static readonly BaryCoordNoPerspSampleAMD Instance = new BaryCoordNoPerspSampleAMD();
            public override Enumerant Value => BuiltIn.Enumerant.BaryCoordNoPerspSampleAMD;
            public new static BaryCoordNoPerspSampleAMD Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class BaryCoordSmoothAMD: BuiltIn
        {
            public static readonly BaryCoordSmoothAMD Instance = new BaryCoordSmoothAMD();
            public override Enumerant Value => BuiltIn.Enumerant.BaryCoordSmoothAMD;
            public new static BaryCoordSmoothAMD Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class BaryCoordSmoothCentroidAMD: BuiltIn
        {
            public static readonly BaryCoordSmoothCentroidAMD Instance = new BaryCoordSmoothCentroidAMD();
            public override Enumerant Value => BuiltIn.Enumerant.BaryCoordSmoothCentroidAMD;
            public new static BaryCoordSmoothCentroidAMD Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class BaryCoordSmoothSampleAMD: BuiltIn
        {
            public static readonly BaryCoordSmoothSampleAMD Instance = new BaryCoordSmoothSampleAMD();
            public override Enumerant Value => BuiltIn.Enumerant.BaryCoordSmoothSampleAMD;
            public new static BaryCoordSmoothSampleAMD Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class BaryCoordPullModelAMD: BuiltIn
        {
            public static readonly BaryCoordPullModelAMD Instance = new BaryCoordPullModelAMD();
            public override Enumerant Value => BuiltIn.Enumerant.BaryCoordPullModelAMD;
            public new static BaryCoordPullModelAMD Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class FragStencilRefEXT: BuiltIn
        {
            public static readonly FragStencilRefEXT Instance = new FragStencilRefEXT();
            public override Enumerant Value => BuiltIn.Enumerant.FragStencilRefEXT;
            public new static FragStencilRefEXT Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class ViewportMaskNV: BuiltIn
        {
            public static readonly ViewportMaskNV Instance = new ViewportMaskNV();
            public override Enumerant Value => BuiltIn.Enumerant.ViewportMaskNV;
            public new static ViewportMaskNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SecondaryPositionNV: BuiltIn
        {
            public static readonly SecondaryPositionNV Instance = new SecondaryPositionNV();
            public override Enumerant Value => BuiltIn.Enumerant.SecondaryPositionNV;
            public new static SecondaryPositionNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SecondaryViewportMaskNV: BuiltIn
        {
            public static readonly SecondaryViewportMaskNV Instance = new SecondaryViewportMaskNV();
            public override Enumerant Value => BuiltIn.Enumerant.SecondaryViewportMaskNV;
            public new static SecondaryViewportMaskNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class PositionPerViewNV: BuiltIn
        {
            public static readonly PositionPerViewNV Instance = new PositionPerViewNV();
            public override Enumerant Value => BuiltIn.Enumerant.PositionPerViewNV;
            public new static PositionPerViewNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class ViewportMaskPerViewNV: BuiltIn
        {
            public static readonly ViewportMaskPerViewNV Instance = new ViewportMaskPerViewNV();
            public override Enumerant Value => BuiltIn.Enumerant.ViewportMaskPerViewNV;
            public new static ViewportMaskPerViewNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class FullyCoveredEXT: BuiltIn
        {
            public static readonly FullyCoveredEXT Instance = new FullyCoveredEXT();
            public override Enumerant Value => BuiltIn.Enumerant.FullyCoveredEXT;
            public new static FullyCoveredEXT Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class TaskCountNV: BuiltIn
        {
            public static readonly TaskCountNV Instance = new TaskCountNV();
            public override Enumerant Value => BuiltIn.Enumerant.TaskCountNV;
            public new static TaskCountNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class PrimitiveCountNV: BuiltIn
        {
            public static readonly PrimitiveCountNV Instance = new PrimitiveCountNV();
            public override Enumerant Value => BuiltIn.Enumerant.PrimitiveCountNV;
            public new static PrimitiveCountNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class PrimitiveIndicesNV: BuiltIn
        {
            public static readonly PrimitiveIndicesNV Instance = new PrimitiveIndicesNV();
            public override Enumerant Value => BuiltIn.Enumerant.PrimitiveIndicesNV;
            public new static PrimitiveIndicesNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class ClipDistancePerViewNV: BuiltIn
        {
            public static readonly ClipDistancePerViewNV Instance = new ClipDistancePerViewNV();
            public override Enumerant Value => BuiltIn.Enumerant.ClipDistancePerViewNV;
            public new static ClipDistancePerViewNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class CullDistancePerViewNV: BuiltIn
        {
            public static readonly CullDistancePerViewNV Instance = new CullDistancePerViewNV();
            public override Enumerant Value => BuiltIn.Enumerant.CullDistancePerViewNV;
            public new static CullDistancePerViewNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class LayerPerViewNV: BuiltIn
        {
            public static readonly LayerPerViewNV Instance = new LayerPerViewNV();
            public override Enumerant Value => BuiltIn.Enumerant.LayerPerViewNV;
            public new static LayerPerViewNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class MeshViewCountNV: BuiltIn
        {
            public static readonly MeshViewCountNV Instance = new MeshViewCountNV();
            public override Enumerant Value => BuiltIn.Enumerant.MeshViewCountNV;
            public new static MeshViewCountNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class MeshViewIndicesNV: BuiltIn
        {
            public static readonly MeshViewIndicesNV Instance = new MeshViewIndicesNV();
            public override Enumerant Value => BuiltIn.Enumerant.MeshViewIndicesNV;
            public new static MeshViewIndicesNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class BaryCoordNV: BuiltIn
        {
            public static readonly BaryCoordNV Instance = new BaryCoordNV();
            public override Enumerant Value => BuiltIn.Enumerant.BaryCoordNV;
            public new static BaryCoordNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class BaryCoordNoPerspNV: BuiltIn
        {
            public static readonly BaryCoordNoPerspNV Instance = new BaryCoordNoPerspNV();
            public override Enumerant Value => BuiltIn.Enumerant.BaryCoordNoPerspNV;
            public new static BaryCoordNoPerspNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class FragSizeEXT: BuiltIn
        {
            public static readonly FragSizeEXT Instance = new FragSizeEXT();
            public override Enumerant Value => BuiltIn.Enumerant.FragSizeEXT;
            public new static FragSizeEXT Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class FragmentSizeNV: BuiltIn
        {
            public static readonly FragmentSizeNV Instance = new FragmentSizeNV();
            public override Enumerant Value => BuiltIn.Enumerant.FragmentSizeNV;
            public new static FragmentSizeNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class FragInvocationCountEXT: BuiltIn
        {
            public static readonly FragInvocationCountEXT Instance = new FragInvocationCountEXT();
            public override Enumerant Value => BuiltIn.Enumerant.FragInvocationCountEXT;
            public new static FragInvocationCountEXT Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class InvocationsPerPixelNV: BuiltIn
        {
            public static readonly InvocationsPerPixelNV Instance = new InvocationsPerPixelNV();
            public override Enumerant Value => BuiltIn.Enumerant.InvocationsPerPixelNV;
            public new static InvocationsPerPixelNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class LaunchIdNV: BuiltIn
        {
            public static readonly LaunchIdNV Instance = new LaunchIdNV();
            public override Enumerant Value => BuiltIn.Enumerant.LaunchIdNV;
            public new static LaunchIdNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class LaunchIdKHR: BuiltIn
        {
            public static readonly LaunchIdKHR Instance = new LaunchIdKHR();
            public override Enumerant Value => BuiltIn.Enumerant.LaunchIdKHR;
            public new static LaunchIdKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class LaunchSizeNV: BuiltIn
        {
            public static readonly LaunchSizeNV Instance = new LaunchSizeNV();
            public override Enumerant Value => BuiltIn.Enumerant.LaunchSizeNV;
            public new static LaunchSizeNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class LaunchSizeKHR: BuiltIn
        {
            public static readonly LaunchSizeKHR Instance = new LaunchSizeKHR();
            public override Enumerant Value => BuiltIn.Enumerant.LaunchSizeKHR;
            public new static LaunchSizeKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class WorldRayOriginNV: BuiltIn
        {
            public static readonly WorldRayOriginNV Instance = new WorldRayOriginNV();
            public override Enumerant Value => BuiltIn.Enumerant.WorldRayOriginNV;
            public new static WorldRayOriginNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class WorldRayOriginKHR: BuiltIn
        {
            public static readonly WorldRayOriginKHR Instance = new WorldRayOriginKHR();
            public override Enumerant Value => BuiltIn.Enumerant.WorldRayOriginKHR;
            public new static WorldRayOriginKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class WorldRayDirectionNV: BuiltIn
        {
            public static readonly WorldRayDirectionNV Instance = new WorldRayDirectionNV();
            public override Enumerant Value => BuiltIn.Enumerant.WorldRayDirectionNV;
            public new static WorldRayDirectionNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class WorldRayDirectionKHR: BuiltIn
        {
            public static readonly WorldRayDirectionKHR Instance = new WorldRayDirectionKHR();
            public override Enumerant Value => BuiltIn.Enumerant.WorldRayDirectionKHR;
            public new static WorldRayDirectionKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class ObjectRayOriginNV: BuiltIn
        {
            public static readonly ObjectRayOriginNV Instance = new ObjectRayOriginNV();
            public override Enumerant Value => BuiltIn.Enumerant.ObjectRayOriginNV;
            public new static ObjectRayOriginNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class ObjectRayOriginKHR: BuiltIn
        {
            public static readonly ObjectRayOriginKHR Instance = new ObjectRayOriginKHR();
            public override Enumerant Value => BuiltIn.Enumerant.ObjectRayOriginKHR;
            public new static ObjectRayOriginKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class ObjectRayDirectionNV: BuiltIn
        {
            public static readonly ObjectRayDirectionNV Instance = new ObjectRayDirectionNV();
            public override Enumerant Value => BuiltIn.Enumerant.ObjectRayDirectionNV;
            public new static ObjectRayDirectionNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class ObjectRayDirectionKHR: BuiltIn
        {
            public static readonly ObjectRayDirectionKHR Instance = new ObjectRayDirectionKHR();
            public override Enumerant Value => BuiltIn.Enumerant.ObjectRayDirectionKHR;
            public new static ObjectRayDirectionKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class RayTminNV: BuiltIn
        {
            public static readonly RayTminNV Instance = new RayTminNV();
            public override Enumerant Value => BuiltIn.Enumerant.RayTminNV;
            public new static RayTminNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class RayTminKHR: BuiltIn
        {
            public static readonly RayTminKHR Instance = new RayTminKHR();
            public override Enumerant Value => BuiltIn.Enumerant.RayTminKHR;
            public new static RayTminKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class RayTmaxNV: BuiltIn
        {
            public static readonly RayTmaxNV Instance = new RayTmaxNV();
            public override Enumerant Value => BuiltIn.Enumerant.RayTmaxNV;
            public new static RayTmaxNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class RayTmaxKHR: BuiltIn
        {
            public static readonly RayTmaxKHR Instance = new RayTmaxKHR();
            public override Enumerant Value => BuiltIn.Enumerant.RayTmaxKHR;
            public new static RayTmaxKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class InstanceCustomIndexNV: BuiltIn
        {
            public static readonly InstanceCustomIndexNV Instance = new InstanceCustomIndexNV();
            public override Enumerant Value => BuiltIn.Enumerant.InstanceCustomIndexNV;
            public new static InstanceCustomIndexNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class InstanceCustomIndexKHR: BuiltIn
        {
            public static readonly InstanceCustomIndexKHR Instance = new InstanceCustomIndexKHR();
            public override Enumerant Value => BuiltIn.Enumerant.InstanceCustomIndexKHR;
            public new static InstanceCustomIndexKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class ObjectToWorldNV: BuiltIn
        {
            public static readonly ObjectToWorldNV Instance = new ObjectToWorldNV();
            public override Enumerant Value => BuiltIn.Enumerant.ObjectToWorldNV;
            public new static ObjectToWorldNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class ObjectToWorldKHR: BuiltIn
        {
            public static readonly ObjectToWorldKHR Instance = new ObjectToWorldKHR();
            public override Enumerant Value => BuiltIn.Enumerant.ObjectToWorldKHR;
            public new static ObjectToWorldKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class WorldToObjectNV: BuiltIn
        {
            public static readonly WorldToObjectNV Instance = new WorldToObjectNV();
            public override Enumerant Value => BuiltIn.Enumerant.WorldToObjectNV;
            public new static WorldToObjectNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class WorldToObjectKHR: BuiltIn
        {
            public static readonly WorldToObjectKHR Instance = new WorldToObjectKHR();
            public override Enumerant Value => BuiltIn.Enumerant.WorldToObjectKHR;
            public new static WorldToObjectKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class HitTNV: BuiltIn
        {
            public static readonly HitTNV Instance = new HitTNV();
            public override Enumerant Value => BuiltIn.Enumerant.HitTNV;
            public new static HitTNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class HitTKHR: BuiltIn
        {
            public static readonly HitTKHR Instance = new HitTKHR();
            public override Enumerant Value => BuiltIn.Enumerant.HitTKHR;
            public new static HitTKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class HitKindNV: BuiltIn
        {
            public static readonly HitKindNV Instance = new HitKindNV();
            public override Enumerant Value => BuiltIn.Enumerant.HitKindNV;
            public new static HitKindNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class HitKindKHR: BuiltIn
        {
            public static readonly HitKindKHR Instance = new HitKindKHR();
            public override Enumerant Value => BuiltIn.Enumerant.HitKindKHR;
            public new static HitKindKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class IncomingRayFlagsNV: BuiltIn
        {
            public static readonly IncomingRayFlagsNV Instance = new IncomingRayFlagsNV();
            public override Enumerant Value => BuiltIn.Enumerant.IncomingRayFlagsNV;
            public new static IncomingRayFlagsNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class IncomingRayFlagsKHR: BuiltIn
        {
            public static readonly IncomingRayFlagsKHR Instance = new IncomingRayFlagsKHR();
            public override Enumerant Value => BuiltIn.Enumerant.IncomingRayFlagsKHR;
            public new static IncomingRayFlagsKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class RayGeometryIndexKHR: BuiltIn
        {
            public static readonly RayGeometryIndexKHR Instance = new RayGeometryIndexKHR();
            public override Enumerant Value => BuiltIn.Enumerant.RayGeometryIndexKHR;
            public new static RayGeometryIndexKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class WarpsPerSMNV: BuiltIn
        {
            public static readonly WarpsPerSMNV Instance = new WarpsPerSMNV();
            public override Enumerant Value => BuiltIn.Enumerant.WarpsPerSMNV;
            public new static WarpsPerSMNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SMCountNV: BuiltIn
        {
            public static readonly SMCountNV Instance = new SMCountNV();
            public override Enumerant Value => BuiltIn.Enumerant.SMCountNV;
            public new static SMCountNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class WarpIDNV: BuiltIn
        {
            public static readonly WarpIDNV Instance = new WarpIDNV();
            public override Enumerant Value => BuiltIn.Enumerant.WarpIDNV;
            public new static WarpIDNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SMIDNV: BuiltIn
        {
            public static readonly SMIDNV Instance = new SMIDNV();
            public override Enumerant Value => BuiltIn.Enumerant.SMIDNV;
            public new static SMIDNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
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
                case Enumerant.SubgroupEqMask :
                    return SubgroupEqMask.Parse(reader, wordCount - 1);
                case Enumerant.SubgroupGeMask :
                    return SubgroupGeMask.Parse(reader, wordCount - 1);
                case Enumerant.SubgroupGtMask :
                    return SubgroupGtMask.Parse(reader, wordCount - 1);
                case Enumerant.SubgroupLeMask :
                    return SubgroupLeMask.Parse(reader, wordCount - 1);
                case Enumerant.SubgroupLtMask :
                    return SubgroupLtMask.Parse(reader, wordCount - 1);
                //SubgroupEqMaskKHR has the same id as another value in enum.
                //case Enumerant.SubgroupEqMaskKHR :
                //    return SubgroupEqMaskKHR.Parse(reader, wordCount - 1);
                //SubgroupGeMaskKHR has the same id as another value in enum.
                //case Enumerant.SubgroupGeMaskKHR :
                //    return SubgroupGeMaskKHR.Parse(reader, wordCount - 1);
                //SubgroupGtMaskKHR has the same id as another value in enum.
                //case Enumerant.SubgroupGtMaskKHR :
                //    return SubgroupGtMaskKHR.Parse(reader, wordCount - 1);
                //SubgroupLeMaskKHR has the same id as another value in enum.
                //case Enumerant.SubgroupLeMaskKHR :
                //    return SubgroupLeMaskKHR.Parse(reader, wordCount - 1);
                //SubgroupLtMaskKHR has the same id as another value in enum.
                //case Enumerant.SubgroupLtMaskKHR :
                //    return SubgroupLtMaskKHR.Parse(reader, wordCount - 1);
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
                case Enumerant.FullyCoveredEXT :
                    return FullyCoveredEXT.Parse(reader, wordCount - 1);
                case Enumerant.TaskCountNV :
                    return TaskCountNV.Parse(reader, wordCount - 1);
                case Enumerant.PrimitiveCountNV :
                    return PrimitiveCountNV.Parse(reader, wordCount - 1);
                case Enumerant.PrimitiveIndicesNV :
                    return PrimitiveIndicesNV.Parse(reader, wordCount - 1);
                case Enumerant.ClipDistancePerViewNV :
                    return ClipDistancePerViewNV.Parse(reader, wordCount - 1);
                case Enumerant.CullDistancePerViewNV :
                    return CullDistancePerViewNV.Parse(reader, wordCount - 1);
                case Enumerant.LayerPerViewNV :
                    return LayerPerViewNV.Parse(reader, wordCount - 1);
                case Enumerant.MeshViewCountNV :
                    return MeshViewCountNV.Parse(reader, wordCount - 1);
                case Enumerant.MeshViewIndicesNV :
                    return MeshViewIndicesNV.Parse(reader, wordCount - 1);
                case Enumerant.BaryCoordNV :
                    return BaryCoordNV.Parse(reader, wordCount - 1);
                case Enumerant.BaryCoordNoPerspNV :
                    return BaryCoordNoPerspNV.Parse(reader, wordCount - 1);
                case Enumerant.FragSizeEXT :
                    return FragSizeEXT.Parse(reader, wordCount - 1);
                //FragmentSizeNV has the same id as another value in enum.
                //case Enumerant.FragmentSizeNV :
                //    return FragmentSizeNV.Parse(reader, wordCount - 1);
                case Enumerant.FragInvocationCountEXT :
                    return FragInvocationCountEXT.Parse(reader, wordCount - 1);
                //InvocationsPerPixelNV has the same id as another value in enum.
                //case Enumerant.InvocationsPerPixelNV :
                //    return InvocationsPerPixelNV.Parse(reader, wordCount - 1);
                case Enumerant.LaunchIdNV :
                    return LaunchIdNV.Parse(reader, wordCount - 1);
                //LaunchIdKHR has the same id as another value in enum.
                //case Enumerant.LaunchIdKHR :
                //    return LaunchIdKHR.Parse(reader, wordCount - 1);
                case Enumerant.LaunchSizeNV :
                    return LaunchSizeNV.Parse(reader, wordCount - 1);
                //LaunchSizeKHR has the same id as another value in enum.
                //case Enumerant.LaunchSizeKHR :
                //    return LaunchSizeKHR.Parse(reader, wordCount - 1);
                case Enumerant.WorldRayOriginNV :
                    return WorldRayOriginNV.Parse(reader, wordCount - 1);
                //WorldRayOriginKHR has the same id as another value in enum.
                //case Enumerant.WorldRayOriginKHR :
                //    return WorldRayOriginKHR.Parse(reader, wordCount - 1);
                case Enumerant.WorldRayDirectionNV :
                    return WorldRayDirectionNV.Parse(reader, wordCount - 1);
                //WorldRayDirectionKHR has the same id as another value in enum.
                //case Enumerant.WorldRayDirectionKHR :
                //    return WorldRayDirectionKHR.Parse(reader, wordCount - 1);
                case Enumerant.ObjectRayOriginNV :
                    return ObjectRayOriginNV.Parse(reader, wordCount - 1);
                //ObjectRayOriginKHR has the same id as another value in enum.
                //case Enumerant.ObjectRayOriginKHR :
                //    return ObjectRayOriginKHR.Parse(reader, wordCount - 1);
                case Enumerant.ObjectRayDirectionNV :
                    return ObjectRayDirectionNV.Parse(reader, wordCount - 1);
                //ObjectRayDirectionKHR has the same id as another value in enum.
                //case Enumerant.ObjectRayDirectionKHR :
                //    return ObjectRayDirectionKHR.Parse(reader, wordCount - 1);
                case Enumerant.RayTminNV :
                    return RayTminNV.Parse(reader, wordCount - 1);
                //RayTminKHR has the same id as another value in enum.
                //case Enumerant.RayTminKHR :
                //    return RayTminKHR.Parse(reader, wordCount - 1);
                case Enumerant.RayTmaxNV :
                    return RayTmaxNV.Parse(reader, wordCount - 1);
                //RayTmaxKHR has the same id as another value in enum.
                //case Enumerant.RayTmaxKHR :
                //    return RayTmaxKHR.Parse(reader, wordCount - 1);
                case Enumerant.InstanceCustomIndexNV :
                    return InstanceCustomIndexNV.Parse(reader, wordCount - 1);
                //InstanceCustomIndexKHR has the same id as another value in enum.
                //case Enumerant.InstanceCustomIndexKHR :
                //    return InstanceCustomIndexKHR.Parse(reader, wordCount - 1);
                case Enumerant.ObjectToWorldNV :
                    return ObjectToWorldNV.Parse(reader, wordCount - 1);
                //ObjectToWorldKHR has the same id as another value in enum.
                //case Enumerant.ObjectToWorldKHR :
                //    return ObjectToWorldKHR.Parse(reader, wordCount - 1);
                case Enumerant.WorldToObjectNV :
                    return WorldToObjectNV.Parse(reader, wordCount - 1);
                //WorldToObjectKHR has the same id as another value in enum.
                //case Enumerant.WorldToObjectKHR :
                //    return WorldToObjectKHR.Parse(reader, wordCount - 1);
                case Enumerant.HitTNV :
                    return HitTNV.Parse(reader, wordCount - 1);
                //HitTKHR has the same id as another value in enum.
                //case Enumerant.HitTKHR :
                //    return HitTKHR.Parse(reader, wordCount - 1);
                case Enumerant.HitKindNV :
                    return HitKindNV.Parse(reader, wordCount - 1);
                //HitKindKHR has the same id as another value in enum.
                //case Enumerant.HitKindKHR :
                //    return HitKindKHR.Parse(reader, wordCount - 1);
                case Enumerant.IncomingRayFlagsNV :
                    return IncomingRayFlagsNV.Parse(reader, wordCount - 1);
                //IncomingRayFlagsKHR has the same id as another value in enum.
                //case Enumerant.IncomingRayFlagsKHR :
                //    return IncomingRayFlagsKHR.Parse(reader, wordCount - 1);
                case Enumerant.RayGeometryIndexKHR :
                    return RayGeometryIndexKHR.Parse(reader, wordCount - 1);
                case Enumerant.WarpsPerSMNV :
                    return WarpsPerSMNV.Parse(reader, wordCount - 1);
                case Enumerant.SMCountNV :
                    return SMCountNV.Parse(reader, wordCount - 1);
                case Enumerant.WarpIDNV :
                    return WarpIDNV.Parse(reader, wordCount - 1);
                case Enumerant.SMIDNV :
                    return SMIDNV.Parse(reader, wordCount - 1);
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