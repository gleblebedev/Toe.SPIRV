using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public class BuiltIn : ValueEnum
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

            [Capability(Capability.Enumerant.Geometry)] [Capability(Capability.Enumerant.Tessellation)]
            PrimitiveId = 7,

            [Capability(Capability.Enumerant.Geometry)] [Capability(Capability.Enumerant.Tessellation)]
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

            [Capability(Capability.Enumerant.Kernel)] [Capability(Capability.Enumerant.SubgroupBallotKHR)]
            SubgroupSize = 36,

            [Capability(Capability.Enumerant.Kernel)]
            SubgroupMaxSize = 37,

            [Capability(Capability.Enumerant.Kernel)]
            NumSubgroups = 38,

            [Capability(Capability.Enumerant.Kernel)]
            NumEnqueuedSubgroups = 39,

            [Capability(Capability.Enumerant.Kernel)]
            SubgroupId = 40,

            [Capability(Capability.Enumerant.Kernel)] [Capability(Capability.Enumerant.SubgroupBallotKHR)]
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
            ViewportMaskPerViewNV = 5262
        }


        public BuiltIn(Enumerant value)
        {
            Value = value;
        }

        public Enumerant Value { get; }

        public static BuiltIn Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                default:
                    return new BuiltIn(id);
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
            while (reader.Position < end) res.Add(Parse(reader, end - reader.Position));
            return res;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}