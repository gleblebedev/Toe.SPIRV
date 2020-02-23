using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public partial class Capability : ValueEnum
    {
        public Capability(Enumerant value)
        {
            Value = value;
        }

        public enum Enumerant
        {
            Matrix = 0,
            [Capability(Capability.Enumerant.Matrix)]
            Shader = 1,
            [Capability(Capability.Enumerant.Shader)]
            Geometry = 2,
            [Capability(Capability.Enumerant.Shader)]
            Tessellation = 3,
            Addresses = 4,
            Linkage = 5,
            Kernel = 6,
            [Capability(Capability.Enumerant.Kernel)]
            Vector16 = 7,
            [Capability(Capability.Enumerant.Kernel)]
            Float16Buffer = 8,
            Float16 = 9,
            Float64 = 10,
            Int64 = 11,
            [Capability(Capability.Enumerant.Int64)]
            Int64Atomics = 12,
            [Capability(Capability.Enumerant.Kernel)]
            ImageBasic = 13,
            [Capability(Capability.Enumerant.ImageBasic)]
            ImageReadWrite = 14,
            [Capability(Capability.Enumerant.ImageBasic)]
            ImageMipmap = 15,
            [Capability(Capability.Enumerant.Kernel)]
            Pipes = 17,
            Groups = 18,
            [Capability(Capability.Enumerant.Kernel)]
            DeviceEnqueue = 19,
            [Capability(Capability.Enumerant.Kernel)]
            LiteralSampler = 20,
            [Capability(Capability.Enumerant.Shader)]
            AtomicStorage = 21,
            Int16 = 22,
            [Capability(Capability.Enumerant.Tessellation)]
            TessellationPointSize = 23,
            [Capability(Capability.Enumerant.Geometry)]
            GeometryPointSize = 24,
            [Capability(Capability.Enumerant.Shader)]
            ImageGatherExtended = 25,
            [Capability(Capability.Enumerant.Shader)]
            StorageImageMultisample = 27,
            [Capability(Capability.Enumerant.Shader)]
            UniformBufferArrayDynamicIndexing = 28,
            [Capability(Capability.Enumerant.Shader)]
            SampledImageArrayDynamicIndexing = 29,
            [Capability(Capability.Enumerant.Shader)]
            StorageBufferArrayDynamicIndexing = 30,
            [Capability(Capability.Enumerant.Shader)]
            StorageImageArrayDynamicIndexing = 31,
            [Capability(Capability.Enumerant.Shader)]
            ClipDistance = 32,
            [Capability(Capability.Enumerant.Shader)]
            CullDistance = 33,
            [Capability(Capability.Enumerant.SampledCubeArray)]
            ImageCubeArray = 34,
            [Capability(Capability.Enumerant.Shader)]
            SampleRateShading = 35,
            [Capability(Capability.Enumerant.SampledRect)]
            ImageRect = 36,
            [Capability(Capability.Enumerant.Shader)]
            SampledRect = 37,
            [Capability(Capability.Enumerant.Addresses)]
            GenericPointer = 38,
            [Capability(Capability.Enumerant.Kernel)]
            Int8 = 39,
            [Capability(Capability.Enumerant.Shader)]
            InputAttachment = 40,
            [Capability(Capability.Enumerant.Shader)]
            SparseResidency = 41,
            [Capability(Capability.Enumerant.Shader)]
            MinLod = 42,
            Sampled1D = 43,
            [Capability(Capability.Enumerant.Sampled1D)]
            Image1D = 44,
            [Capability(Capability.Enumerant.Shader)]
            SampledCubeArray = 45,
            SampledBuffer = 46,
            [Capability(Capability.Enumerant.SampledBuffer)]
            ImageBuffer = 47,
            [Capability(Capability.Enumerant.Shader)]
            ImageMSArray = 48,
            [Capability(Capability.Enumerant.Shader)]
            StorageImageExtendedFormats = 49,
            [Capability(Capability.Enumerant.Shader)]
            ImageQuery = 50,
            [Capability(Capability.Enumerant.Shader)]
            DerivativeControl = 51,
            [Capability(Capability.Enumerant.Shader)]
            InterpolationFunction = 52,
            [Capability(Capability.Enumerant.Shader)]
            TransformFeedback = 53,
            [Capability(Capability.Enumerant.Geometry)]
            GeometryStreams = 54,
            [Capability(Capability.Enumerant.Shader)]
            StorageImageReadWithoutFormat = 55,
            [Capability(Capability.Enumerant.Shader)]
            StorageImageWriteWithoutFormat = 56,
            [Capability(Capability.Enumerant.Geometry)]
            MultiViewport = 57,
            SubgroupBallotKHR = 4423,
            DrawParameters = 4427,
            SubgroupVoteKHR = 4431,
            StorageBuffer16BitAccess = 4433,
            StorageUniformBufferBlock16 = 4433,
            [Capability(Capability.Enumerant.StorageBuffer16BitAccess)]
            [Capability(Capability.Enumerant.StorageUniformBufferBlock16)]
            UniformAndStorageBuffer16BitAccess = 4434,
            [Capability(Capability.Enumerant.StorageBuffer16BitAccess)]
            [Capability(Capability.Enumerant.StorageUniformBufferBlock16)]
            StorageUniform16 = 4434,
            StoragePushConstant16 = 4435,
            StorageInputOutput16 = 4436,
            DeviceGroup = 4437,
            [Capability(Capability.Enumerant.Shader)]
            MultiView = 4439,
            [Capability(Capability.Enumerant.Shader)]
            VariablePointersStorageBuffer = 4441,
            [Capability(Capability.Enumerant.VariablePointersStorageBuffer)]
            VariablePointers = 4442,
            AtomicStorageOps = 4445,
            SampleMaskPostDepthCoverage = 4447,
            [Capability(Capability.Enumerant.Shader)]
            ImageGatherBiasLodAMD = 5009,
            [Capability(Capability.Enumerant.Shader)]
            FragmentMaskAMD = 5010,
            [Capability(Capability.Enumerant.Shader)]
            StencilExportEXT = 5013,
            [Capability(Capability.Enumerant.Shader)]
            ImageReadWriteLodAMD = 5015,
            [Capability(Capability.Enumerant.SampleRateShading)]
            SampleMaskOverrideCoverageNV = 5249,
            [Capability(Capability.Enumerant.Geometry)]
            GeometryShaderPassthroughNV = 5251,
            [Capability(Capability.Enumerant.MultiViewport)]
            ShaderViewportIndexLayerEXT = 5254,
            [Capability(Capability.Enumerant.MultiViewport)]
            ShaderViewportIndexLayerNV = 5254,
            [Capability(Capability.Enumerant.ShaderViewportIndexLayerNV)]
            ShaderViewportMaskNV = 5255,
            [Capability(Capability.Enumerant.ShaderViewportMaskNV)]
            ShaderStereoViewNV = 5259,
            [Capability(Capability.Enumerant.MultiView)]
            PerViewAttributesNV = 5260,
            SubgroupShuffleINTEL = 5568,
            SubgroupBufferBlockIOINTEL = 5569,
            SubgroupImageBlockIOINTEL = 5570,
        }


        public Enumerant Value { get; }

        public static Capability Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                default:
                    return new Capability(id);
            }
        }
        
        public static Capability ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<Capability> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<Capability>();
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