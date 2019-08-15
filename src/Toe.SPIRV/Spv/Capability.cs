using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public class Capability : ValueEnum
    {
        public enum Enumerant
        {
            Matrix = 0,
            [Capability(Matrix)] Shader = 1,
            [Capability(Shader)] Geometry = 2,
            [Capability(Shader)] Tessellation = 3,
            Addresses = 4,
            Linkage = 5,
            Kernel = 6,
            [Capability(Kernel)] Vector16 = 7,
            [Capability(Kernel)] Float16Buffer = 8,
            Float16 = 9,
            Float64 = 10,
            Int64 = 11,
            [Capability(Int64)] Int64Atomics = 12,
            [Capability(Kernel)] ImageBasic = 13,
            [Capability(ImageBasic)] ImageReadWrite = 14,
            [Capability(ImageBasic)] ImageMipmap = 15,
            [Capability(Kernel)] Pipes = 17,
            Groups = 18,
            [Capability(Kernel)] DeviceEnqueue = 19,
            [Capability(Kernel)] LiteralSampler = 20,
            [Capability(Shader)] AtomicStorage = 21,
            Int16 = 22,
            [Capability(Tessellation)] TessellationPointSize = 23,
            [Capability(Geometry)] GeometryPointSize = 24,
            [Capability(Shader)] ImageGatherExtended = 25,
            [Capability(Shader)] StorageImageMultisample = 27,
            [Capability(Shader)] UniformBufferArrayDynamicIndexing = 28,
            [Capability(Shader)] SampledImageArrayDynamicIndexing = 29,
            [Capability(Shader)] StorageBufferArrayDynamicIndexing = 30,
            [Capability(Shader)] StorageImageArrayDynamicIndexing = 31,
            [Capability(Shader)] ClipDistance = 32,
            [Capability(Shader)] CullDistance = 33,
            [Capability(SampledCubeArray)] ImageCubeArray = 34,
            [Capability(Shader)] SampleRateShading = 35,
            [Capability(SampledRect)] ImageRect = 36,
            [Capability(Shader)] SampledRect = 37,
            [Capability(Addresses)] GenericPointer = 38,
            [Capability(Kernel)] Int8 = 39,
            [Capability(Shader)] InputAttachment = 40,
            [Capability(Shader)] SparseResidency = 41,
            [Capability(Shader)] MinLod = 42,
            Sampled1D = 43,
            [Capability(Sampled1D)] Image1D = 44,
            [Capability(Shader)] SampledCubeArray = 45,
            SampledBuffer = 46,
            [Capability(SampledBuffer)] ImageBuffer = 47,
            [Capability(Shader)] ImageMSArray = 48,
            [Capability(Shader)] StorageImageExtendedFormats = 49,
            [Capability(Shader)] ImageQuery = 50,
            [Capability(Shader)] DerivativeControl = 51,
            [Capability(Shader)] InterpolationFunction = 52,
            [Capability(Shader)] TransformFeedback = 53,
            [Capability(Geometry)] GeometryStreams = 54,
            [Capability(Shader)] StorageImageReadWithoutFormat = 55,
            [Capability(Shader)] StorageImageWriteWithoutFormat = 56,
            [Capability(Geometry)] MultiViewport = 57,
            SubgroupBallotKHR = 4423,
            DrawParameters = 4427,
            SubgroupVoteKHR = 4431,
            StorageBuffer16BitAccess = 4433,
            StorageUniformBufferBlock16 = 4433,

            [Capability(StorageBuffer16BitAccess)] [Capability(StorageUniformBufferBlock16)]
            UniformAndStorageBuffer16BitAccess = 4434,

            [Capability(StorageBuffer16BitAccess)] [Capability(StorageUniformBufferBlock16)]
            StorageUniform16 = 4434,
            StoragePushConstant16 = 4435,
            StorageInputOutput16 = 4436,
            DeviceGroup = 4437,
            [Capability(Shader)] MultiView = 4439,
            [Capability(Shader)] VariablePointersStorageBuffer = 4441,

            [Capability(VariablePointersStorageBuffer)]
            VariablePointers = 4442,
            AtomicStorageOps = 4445,
            SampleMaskPostDepthCoverage = 4447,
            [Capability(Shader)] ImageGatherBiasLodAMD = 5009,
            [Capability(Shader)] FragmentMaskAMD = 5010,
            [Capability(Shader)] StencilExportEXT = 5013,
            [Capability(Shader)] ImageReadWriteLodAMD = 5015,
            [Capability(SampleRateShading)] SampleMaskOverrideCoverageNV = 5249,
            [Capability(Geometry)] GeometryShaderPassthroughNV = 5251,
            [Capability(MultiViewport)] ShaderViewportIndexLayerEXT = 5254,
            [Capability(MultiViewport)] ShaderViewportIndexLayerNV = 5254,

            [Capability(ShaderViewportIndexLayerNV)]
            ShaderViewportMaskNV = 5255,
            [Capability(ShaderViewportMaskNV)] ShaderStereoViewNV = 5259,
            [Capability(MultiView)] PerViewAttributesNV = 5260,
            SubgroupShuffleINTEL = 5568,
            SubgroupBufferBlockIOINTEL = 5569,
            SubgroupImageBlockIOINTEL = 5570
        }


        public Capability(Enumerant value)
        {
            Value = value;
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
            while (reader.Position < end) res.Add(Parse(reader, end - reader.Position));
            return res;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}