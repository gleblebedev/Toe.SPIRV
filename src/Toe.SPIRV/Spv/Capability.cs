using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public abstract partial class Capability : ValueEnum
    {
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
            [Capability(Capability.Enumerant.DeviceEnqueue)]
            SubgroupDispatch = 58,
            [Capability(Capability.Enumerant.Kernel)]
            NamedBarrier = 59,
            [Capability(Capability.Enumerant.Pipes)]
            PipeStorage = 60,
            GroupNonUniform = 61,
            [Capability(Capability.Enumerant.GroupNonUniform)]
            GroupNonUniformVote = 62,
            [Capability(Capability.Enumerant.GroupNonUniform)]
            GroupNonUniformArithmetic = 63,
            [Capability(Capability.Enumerant.GroupNonUniform)]
            GroupNonUniformBallot = 64,
            [Capability(Capability.Enumerant.GroupNonUniform)]
            GroupNonUniformShuffle = 65,
            [Capability(Capability.Enumerant.GroupNonUniform)]
            GroupNonUniformShuffleRelative = 66,
            [Capability(Capability.Enumerant.GroupNonUniform)]
            GroupNonUniformClustered = 67,
            [Capability(Capability.Enumerant.GroupNonUniform)]
            GroupNonUniformQuad = 68,
            ShaderLayer = 69,
            ShaderViewportIndex = 70,
            SubgroupBallotKHR = 4423,
            [Capability(Capability.Enumerant.Shader)]
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
            StorageBuffer8BitAccess = 4448,
            [Capability(Capability.Enumerant.StorageBuffer8BitAccess)]
            UniformAndStorageBuffer8BitAccess = 4449,
            StoragePushConstant8 = 4450,
            DenormPreserve = 4464,
            DenormFlushToZero = 4465,
            SignedZeroInfNanPreserve = 4466,
            RoundingModeRTE = 4467,
            RoundingModeRTZ = 4468,
            [Capability(Capability.Enumerant.Shader)]
            RayQueryProvisionalKHR = 4471,
            [Capability(Capability.Enumerant.RayQueryProvisionalKHR)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            RayTraversalPrimitiveCullingProvisionalKHR = 4478,
            [Capability(Capability.Enumerant.Shader)]
            Float16ImageAMD = 5008,
            [Capability(Capability.Enumerant.Shader)]
            ImageGatherBiasLodAMD = 5009,
            [Capability(Capability.Enumerant.Shader)]
            FragmentMaskAMD = 5010,
            [Capability(Capability.Enumerant.Shader)]
            StencilExportEXT = 5013,
            [Capability(Capability.Enumerant.Shader)]
            ImageReadWriteLodAMD = 5015,
            [Capability(Capability.Enumerant.Shader)]
            ShaderClockKHR = 5055,
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
            [Capability(Capability.Enumerant.Shader)]
            FragmentFullyCoveredEXT = 5265,
            [Capability(Capability.Enumerant.Shader)]
            MeshShadingNV = 5266,
            ImageFootprintNV = 5282,
            FragmentBarycentricNV = 5284,
            ComputeDerivativeGroupQuadsNV = 5288,
            [Capability(Capability.Enumerant.Shader)]
            FragmentDensityEXT = 5291,
            [Capability(Capability.Enumerant.Shader)]
            ShadingRateNV = 5291,
            GroupNonUniformPartitionedNV = 5297,
            [Capability(Capability.Enumerant.Shader)]
            ShaderNonUniform = 5301,
            [Capability(Capability.Enumerant.Shader)]
            ShaderNonUniformEXT = 5301,
            [Capability(Capability.Enumerant.Shader)]
            RuntimeDescriptorArray = 5302,
            [Capability(Capability.Enumerant.Shader)]
            RuntimeDescriptorArrayEXT = 5302,
            [Capability(Capability.Enumerant.InputAttachment)]
            InputAttachmentArrayDynamicIndexing = 5303,
            [Capability(Capability.Enumerant.InputAttachment)]
            InputAttachmentArrayDynamicIndexingEXT = 5303,
            [Capability(Capability.Enumerant.SampledBuffer)]
            UniformTexelBufferArrayDynamicIndexing = 5304,
            [Capability(Capability.Enumerant.SampledBuffer)]
            UniformTexelBufferArrayDynamicIndexingEXT = 5304,
            [Capability(Capability.Enumerant.ImageBuffer)]
            StorageTexelBufferArrayDynamicIndexing = 5305,
            [Capability(Capability.Enumerant.ImageBuffer)]
            StorageTexelBufferArrayDynamicIndexingEXT = 5305,
            [Capability(Capability.Enumerant.ShaderNonUniform)]
            UniformBufferArrayNonUniformIndexing = 5306,
            [Capability(Capability.Enumerant.ShaderNonUniform)]
            UniformBufferArrayNonUniformIndexingEXT = 5306,
            [Capability(Capability.Enumerant.ShaderNonUniform)]
            SampledImageArrayNonUniformIndexing = 5307,
            [Capability(Capability.Enumerant.ShaderNonUniform)]
            SampledImageArrayNonUniformIndexingEXT = 5307,
            [Capability(Capability.Enumerant.ShaderNonUniform)]
            StorageBufferArrayNonUniformIndexing = 5308,
            [Capability(Capability.Enumerant.ShaderNonUniform)]
            StorageBufferArrayNonUniformIndexingEXT = 5308,
            [Capability(Capability.Enumerant.ShaderNonUniform)]
            StorageImageArrayNonUniformIndexing = 5309,
            [Capability(Capability.Enumerant.ShaderNonUniform)]
            StorageImageArrayNonUniformIndexingEXT = 5309,
            [Capability(Capability.Enumerant.InputAttachment)]
            [Capability(Capability.Enumerant.ShaderNonUniform)]
            InputAttachmentArrayNonUniformIndexing = 5310,
            [Capability(Capability.Enumerant.InputAttachment)]
            [Capability(Capability.Enumerant.ShaderNonUniform)]
            InputAttachmentArrayNonUniformIndexingEXT = 5310,
            [Capability(Capability.Enumerant.SampledBuffer)]
            [Capability(Capability.Enumerant.ShaderNonUniform)]
            UniformTexelBufferArrayNonUniformIndexing = 5311,
            [Capability(Capability.Enumerant.SampledBuffer)]
            [Capability(Capability.Enumerant.ShaderNonUniform)]
            UniformTexelBufferArrayNonUniformIndexingEXT = 5311,
            [Capability(Capability.Enumerant.ImageBuffer)]
            [Capability(Capability.Enumerant.ShaderNonUniform)]
            StorageTexelBufferArrayNonUniformIndexing = 5312,
            [Capability(Capability.Enumerant.ImageBuffer)]
            [Capability(Capability.Enumerant.ShaderNonUniform)]
            StorageTexelBufferArrayNonUniformIndexingEXT = 5312,
            [Capability(Capability.Enumerant.Shader)]
            RayTracingNV = 5340,
            VulkanMemoryModel = 5345,
            VulkanMemoryModelKHR = 5345,
            VulkanMemoryModelDeviceScope = 5346,
            VulkanMemoryModelDeviceScopeKHR = 5346,
            [Capability(Capability.Enumerant.Shader)]
            PhysicalStorageBufferAddresses = 5347,
            [Capability(Capability.Enumerant.Shader)]
            PhysicalStorageBufferAddressesEXT = 5347,
            ComputeDerivativeGroupLinearNV = 5350,
            [Capability(Capability.Enumerant.Shader)]
            RayTracingProvisionalKHR = 5353,
            [Capability(Capability.Enumerant.Shader)]
            CooperativeMatrixNV = 5357,
            [Capability(Capability.Enumerant.Shader)]
            FragmentShaderSampleInterlockEXT = 5363,
            [Capability(Capability.Enumerant.Shader)]
            FragmentShaderShadingRateInterlockEXT = 5372,
            [Capability(Capability.Enumerant.Shader)]
            ShaderSMBuiltinsNV = 5373,
            [Capability(Capability.Enumerant.Shader)]
            FragmentShaderPixelInterlockEXT = 5378,
            [Capability(Capability.Enumerant.Shader)]
            DemoteToHelperInvocationEXT = 5379,
            SubgroupShuffleINTEL = 5568,
            SubgroupBufferBlockIOINTEL = 5569,
            SubgroupImageBlockIOINTEL = 5570,
            SubgroupImageMediaBlockIOINTEL = 5579,
            [Capability(Capability.Enumerant.Shader)]
            IntegerFunctions2INTEL = 5584,
            SubgroupAvcMotionEstimationINTEL = 5696,
            SubgroupAvcMotionEstimationIntraINTEL = 5697,
            SubgroupAvcMotionEstimationChromaINTEL = 5698,
        }

        public class Matrix: Capability
        {
            public override Enumerant Value => Capability.Enumerant.Matrix;
            public new static Matrix Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Matrix();
                return res;
            }
        }
        public class Shader: Capability
        {
            public override Enumerant Value => Capability.Enumerant.Shader;
            public new static Shader Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Shader();
                return res;
            }
        }
        public class Geometry: Capability
        {
            public override Enumerant Value => Capability.Enumerant.Geometry;
            public new static Geometry Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Geometry();
                return res;
            }
        }
        public class Tessellation: Capability
        {
            public override Enumerant Value => Capability.Enumerant.Tessellation;
            public new static Tessellation Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Tessellation();
                return res;
            }
        }
        public class Addresses: Capability
        {
            public override Enumerant Value => Capability.Enumerant.Addresses;
            public new static Addresses Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Addresses();
                return res;
            }
        }
        public class Linkage: Capability
        {
            public override Enumerant Value => Capability.Enumerant.Linkage;
            public new static Linkage Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Linkage();
                return res;
            }
        }
        public class Kernel: Capability
        {
            public override Enumerant Value => Capability.Enumerant.Kernel;
            public new static Kernel Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Kernel();
                return res;
            }
        }
        public class Vector16: Capability
        {
            public override Enumerant Value => Capability.Enumerant.Vector16;
            public new static Vector16 Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Vector16();
                return res;
            }
        }
        public class Float16Buffer: Capability
        {
            public override Enumerant Value => Capability.Enumerant.Float16Buffer;
            public new static Float16Buffer Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Float16Buffer();
                return res;
            }
        }
        public class Float16: Capability
        {
            public override Enumerant Value => Capability.Enumerant.Float16;
            public new static Float16 Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Float16();
                return res;
            }
        }
        public class Float64: Capability
        {
            public override Enumerant Value => Capability.Enumerant.Float64;
            public new static Float64 Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Float64();
                return res;
            }
        }
        public class Int64: Capability
        {
            public override Enumerant Value => Capability.Enumerant.Int64;
            public new static Int64 Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Int64();
                return res;
            }
        }
        public class Int64Atomics: Capability
        {
            public override Enumerant Value => Capability.Enumerant.Int64Atomics;
            public new static Int64Atomics Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Int64Atomics();
                return res;
            }
        }
        public class ImageBasic: Capability
        {
            public override Enumerant Value => Capability.Enumerant.ImageBasic;
            public new static ImageBasic Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ImageBasic();
                return res;
            }
        }
        public class ImageReadWrite: Capability
        {
            public override Enumerant Value => Capability.Enumerant.ImageReadWrite;
            public new static ImageReadWrite Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ImageReadWrite();
                return res;
            }
        }
        public class ImageMipmap: Capability
        {
            public override Enumerant Value => Capability.Enumerant.ImageMipmap;
            public new static ImageMipmap Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ImageMipmap();
                return res;
            }
        }
        public class Pipes: Capability
        {
            public override Enumerant Value => Capability.Enumerant.Pipes;
            public new static Pipes Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Pipes();
                return res;
            }
        }
        public class Groups: Capability
        {
            public override Enumerant Value => Capability.Enumerant.Groups;
            public new static Groups Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Groups();
                return res;
            }
        }
        public class DeviceEnqueue: Capability
        {
            public override Enumerant Value => Capability.Enumerant.DeviceEnqueue;
            public new static DeviceEnqueue Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new DeviceEnqueue();
                return res;
            }
        }
        public class LiteralSampler: Capability
        {
            public override Enumerant Value => Capability.Enumerant.LiteralSampler;
            public new static LiteralSampler Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new LiteralSampler();
                return res;
            }
        }
        public class AtomicStorage: Capability
        {
            public override Enumerant Value => Capability.Enumerant.AtomicStorage;
            public new static AtomicStorage Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new AtomicStorage();
                return res;
            }
        }
        public class Int16: Capability
        {
            public override Enumerant Value => Capability.Enumerant.Int16;
            public new static Int16 Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Int16();
                return res;
            }
        }
        public class TessellationPointSize: Capability
        {
            public override Enumerant Value => Capability.Enumerant.TessellationPointSize;
            public new static TessellationPointSize Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new TessellationPointSize();
                return res;
            }
        }
        public class GeometryPointSize: Capability
        {
            public override Enumerant Value => Capability.Enumerant.GeometryPointSize;
            public new static GeometryPointSize Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new GeometryPointSize();
                return res;
            }
        }
        public class ImageGatherExtended: Capability
        {
            public override Enumerant Value => Capability.Enumerant.ImageGatherExtended;
            public new static ImageGatherExtended Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ImageGatherExtended();
                return res;
            }
        }
        public class StorageImageMultisample: Capability
        {
            public override Enumerant Value => Capability.Enumerant.StorageImageMultisample;
            public new static StorageImageMultisample Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new StorageImageMultisample();
                return res;
            }
        }
        public class UniformBufferArrayDynamicIndexing: Capability
        {
            public override Enumerant Value => Capability.Enumerant.UniformBufferArrayDynamicIndexing;
            public new static UniformBufferArrayDynamicIndexing Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new UniformBufferArrayDynamicIndexing();
                return res;
            }
        }
        public class SampledImageArrayDynamicIndexing: Capability
        {
            public override Enumerant Value => Capability.Enumerant.SampledImageArrayDynamicIndexing;
            public new static SampledImageArrayDynamicIndexing Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SampledImageArrayDynamicIndexing();
                return res;
            }
        }
        public class StorageBufferArrayDynamicIndexing: Capability
        {
            public override Enumerant Value => Capability.Enumerant.StorageBufferArrayDynamicIndexing;
            public new static StorageBufferArrayDynamicIndexing Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new StorageBufferArrayDynamicIndexing();
                return res;
            }
        }
        public class StorageImageArrayDynamicIndexing: Capability
        {
            public override Enumerant Value => Capability.Enumerant.StorageImageArrayDynamicIndexing;
            public new static StorageImageArrayDynamicIndexing Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new StorageImageArrayDynamicIndexing();
                return res;
            }
        }
        public class ClipDistance: Capability
        {
            public override Enumerant Value => Capability.Enumerant.ClipDistance;
            public new static ClipDistance Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ClipDistance();
                return res;
            }
        }
        public class CullDistance: Capability
        {
            public override Enumerant Value => Capability.Enumerant.CullDistance;
            public new static CullDistance Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new CullDistance();
                return res;
            }
        }
        public class ImageCubeArray: Capability
        {
            public override Enumerant Value => Capability.Enumerant.ImageCubeArray;
            public new static ImageCubeArray Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ImageCubeArray();
                return res;
            }
        }
        public class SampleRateShading: Capability
        {
            public override Enumerant Value => Capability.Enumerant.SampleRateShading;
            public new static SampleRateShading Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SampleRateShading();
                return res;
            }
        }
        public class ImageRect: Capability
        {
            public override Enumerant Value => Capability.Enumerant.ImageRect;
            public new static ImageRect Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ImageRect();
                return res;
            }
        }
        public class SampledRect: Capability
        {
            public override Enumerant Value => Capability.Enumerant.SampledRect;
            public new static SampledRect Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SampledRect();
                return res;
            }
        }
        public class GenericPointer: Capability
        {
            public override Enumerant Value => Capability.Enumerant.GenericPointer;
            public new static GenericPointer Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new GenericPointer();
                return res;
            }
        }
        public class Int8: Capability
        {
            public override Enumerant Value => Capability.Enumerant.Int8;
            public new static Int8 Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Int8();
                return res;
            }
        }
        public class InputAttachment: Capability
        {
            public override Enumerant Value => Capability.Enumerant.InputAttachment;
            public new static InputAttachment Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new InputAttachment();
                return res;
            }
        }
        public class SparseResidency: Capability
        {
            public override Enumerant Value => Capability.Enumerant.SparseResidency;
            public new static SparseResidency Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SparseResidency();
                return res;
            }
        }
        public class MinLod: Capability
        {
            public override Enumerant Value => Capability.Enumerant.MinLod;
            public new static MinLod Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new MinLod();
                return res;
            }
        }
        public class Sampled1D: Capability
        {
            public override Enumerant Value => Capability.Enumerant.Sampled1D;
            public new static Sampled1D Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Sampled1D();
                return res;
            }
        }
        public class Image1D: Capability
        {
            public override Enumerant Value => Capability.Enumerant.Image1D;
            public new static Image1D Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Image1D();
                return res;
            }
        }
        public class SampledCubeArray: Capability
        {
            public override Enumerant Value => Capability.Enumerant.SampledCubeArray;
            public new static SampledCubeArray Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SampledCubeArray();
                return res;
            }
        }
        public class SampledBuffer: Capability
        {
            public override Enumerant Value => Capability.Enumerant.SampledBuffer;
            public new static SampledBuffer Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SampledBuffer();
                return res;
            }
        }
        public class ImageBuffer: Capability
        {
            public override Enumerant Value => Capability.Enumerant.ImageBuffer;
            public new static ImageBuffer Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ImageBuffer();
                return res;
            }
        }
        public class ImageMSArray: Capability
        {
            public override Enumerant Value => Capability.Enumerant.ImageMSArray;
            public new static ImageMSArray Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ImageMSArray();
                return res;
            }
        }
        public class StorageImageExtendedFormats: Capability
        {
            public override Enumerant Value => Capability.Enumerant.StorageImageExtendedFormats;
            public new static StorageImageExtendedFormats Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new StorageImageExtendedFormats();
                return res;
            }
        }
        public class ImageQuery: Capability
        {
            public override Enumerant Value => Capability.Enumerant.ImageQuery;
            public new static ImageQuery Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ImageQuery();
                return res;
            }
        }
        public class DerivativeControl: Capability
        {
            public override Enumerant Value => Capability.Enumerant.DerivativeControl;
            public new static DerivativeControl Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new DerivativeControl();
                return res;
            }
        }
        public class InterpolationFunction: Capability
        {
            public override Enumerant Value => Capability.Enumerant.InterpolationFunction;
            public new static InterpolationFunction Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new InterpolationFunction();
                return res;
            }
        }
        public class TransformFeedback: Capability
        {
            public override Enumerant Value => Capability.Enumerant.TransformFeedback;
            public new static TransformFeedback Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new TransformFeedback();
                return res;
            }
        }
        public class GeometryStreams: Capability
        {
            public override Enumerant Value => Capability.Enumerant.GeometryStreams;
            public new static GeometryStreams Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new GeometryStreams();
                return res;
            }
        }
        public class StorageImageReadWithoutFormat: Capability
        {
            public override Enumerant Value => Capability.Enumerant.StorageImageReadWithoutFormat;
            public new static StorageImageReadWithoutFormat Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new StorageImageReadWithoutFormat();
                return res;
            }
        }
        public class StorageImageWriteWithoutFormat: Capability
        {
            public override Enumerant Value => Capability.Enumerant.StorageImageWriteWithoutFormat;
            public new static StorageImageWriteWithoutFormat Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new StorageImageWriteWithoutFormat();
                return res;
            }
        }
        public class MultiViewport: Capability
        {
            public override Enumerant Value => Capability.Enumerant.MultiViewport;
            public new static MultiViewport Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new MultiViewport();
                return res;
            }
        }
        public class SubgroupDispatch: Capability
        {
            public override Enumerant Value => Capability.Enumerant.SubgroupDispatch;
            public new static SubgroupDispatch Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SubgroupDispatch();
                return res;
            }
        }
        public class NamedBarrier: Capability
        {
            public override Enumerant Value => Capability.Enumerant.NamedBarrier;
            public new static NamedBarrier Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new NamedBarrier();
                return res;
            }
        }
        public class PipeStorage: Capability
        {
            public override Enumerant Value => Capability.Enumerant.PipeStorage;
            public new static PipeStorage Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new PipeStorage();
                return res;
            }
        }
        public class GroupNonUniform: Capability
        {
            public override Enumerant Value => Capability.Enumerant.GroupNonUniform;
            public new static GroupNonUniform Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new GroupNonUniform();
                return res;
            }
        }
        public class GroupNonUniformVote: Capability
        {
            public override Enumerant Value => Capability.Enumerant.GroupNonUniformVote;
            public new static GroupNonUniformVote Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new GroupNonUniformVote();
                return res;
            }
        }
        public class GroupNonUniformArithmetic: Capability
        {
            public override Enumerant Value => Capability.Enumerant.GroupNonUniformArithmetic;
            public new static GroupNonUniformArithmetic Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new GroupNonUniformArithmetic();
                return res;
            }
        }
        public class GroupNonUniformBallot: Capability
        {
            public override Enumerant Value => Capability.Enumerant.GroupNonUniformBallot;
            public new static GroupNonUniformBallot Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new GroupNonUniformBallot();
                return res;
            }
        }
        public class GroupNonUniformShuffle: Capability
        {
            public override Enumerant Value => Capability.Enumerant.GroupNonUniformShuffle;
            public new static GroupNonUniformShuffle Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new GroupNonUniformShuffle();
                return res;
            }
        }
        public class GroupNonUniformShuffleRelative: Capability
        {
            public override Enumerant Value => Capability.Enumerant.GroupNonUniformShuffleRelative;
            public new static GroupNonUniformShuffleRelative Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new GroupNonUniformShuffleRelative();
                return res;
            }
        }
        public class GroupNonUniformClustered: Capability
        {
            public override Enumerant Value => Capability.Enumerant.GroupNonUniformClustered;
            public new static GroupNonUniformClustered Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new GroupNonUniformClustered();
                return res;
            }
        }
        public class GroupNonUniformQuad: Capability
        {
            public override Enumerant Value => Capability.Enumerant.GroupNonUniformQuad;
            public new static GroupNonUniformQuad Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new GroupNonUniformQuad();
                return res;
            }
        }
        public class ShaderLayer: Capability
        {
            public override Enumerant Value => Capability.Enumerant.ShaderLayer;
            public new static ShaderLayer Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ShaderLayer();
                return res;
            }
        }
        public class ShaderViewportIndex: Capability
        {
            public override Enumerant Value => Capability.Enumerant.ShaderViewportIndex;
            public new static ShaderViewportIndex Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ShaderViewportIndex();
                return res;
            }
        }
        public class SubgroupBallotKHR: Capability
        {
            public override Enumerant Value => Capability.Enumerant.SubgroupBallotKHR;
            public new static SubgroupBallotKHR Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SubgroupBallotKHR();
                return res;
            }
        }
        public class DrawParameters: Capability
        {
            public override Enumerant Value => Capability.Enumerant.DrawParameters;
            public new static DrawParameters Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new DrawParameters();
                return res;
            }
        }
        public class SubgroupVoteKHR: Capability
        {
            public override Enumerant Value => Capability.Enumerant.SubgroupVoteKHR;
            public new static SubgroupVoteKHR Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SubgroupVoteKHR();
                return res;
            }
        }
        public class StorageBuffer16BitAccess: Capability
        {
            public override Enumerant Value => Capability.Enumerant.StorageBuffer16BitAccess;
            public new static StorageBuffer16BitAccess Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new StorageBuffer16BitAccess();
                return res;
            }
        }
        public class StorageUniformBufferBlock16: Capability
        {
            public override Enumerant Value => Capability.Enumerant.StorageUniformBufferBlock16;
            public new static StorageUniformBufferBlock16 Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new StorageUniformBufferBlock16();
                return res;
            }
        }
        public class UniformAndStorageBuffer16BitAccess: Capability
        {
            public override Enumerant Value => Capability.Enumerant.UniformAndStorageBuffer16BitAccess;
            public new static UniformAndStorageBuffer16BitAccess Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new UniformAndStorageBuffer16BitAccess();
                return res;
            }
        }
        public class StorageUniform16: Capability
        {
            public override Enumerant Value => Capability.Enumerant.StorageUniform16;
            public new static StorageUniform16 Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new StorageUniform16();
                return res;
            }
        }
        public class StoragePushConstant16: Capability
        {
            public override Enumerant Value => Capability.Enumerant.StoragePushConstant16;
            public new static StoragePushConstant16 Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new StoragePushConstant16();
                return res;
            }
        }
        public class StorageInputOutput16: Capability
        {
            public override Enumerant Value => Capability.Enumerant.StorageInputOutput16;
            public new static StorageInputOutput16 Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new StorageInputOutput16();
                return res;
            }
        }
        public class DeviceGroup: Capability
        {
            public override Enumerant Value => Capability.Enumerant.DeviceGroup;
            public new static DeviceGroup Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new DeviceGroup();
                return res;
            }
        }
        public class MultiView: Capability
        {
            public override Enumerant Value => Capability.Enumerant.MultiView;
            public new static MultiView Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new MultiView();
                return res;
            }
        }
        public class VariablePointersStorageBuffer: Capability
        {
            public override Enumerant Value => Capability.Enumerant.VariablePointersStorageBuffer;
            public new static VariablePointersStorageBuffer Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new VariablePointersStorageBuffer();
                return res;
            }
        }
        public class VariablePointers: Capability
        {
            public override Enumerant Value => Capability.Enumerant.VariablePointers;
            public new static VariablePointers Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new VariablePointers();
                return res;
            }
        }
        public class AtomicStorageOps: Capability
        {
            public override Enumerant Value => Capability.Enumerant.AtomicStorageOps;
            public new static AtomicStorageOps Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new AtomicStorageOps();
                return res;
            }
        }
        public class SampleMaskPostDepthCoverage: Capability
        {
            public override Enumerant Value => Capability.Enumerant.SampleMaskPostDepthCoverage;
            public new static SampleMaskPostDepthCoverage Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SampleMaskPostDepthCoverage();
                return res;
            }
        }
        public class StorageBuffer8BitAccess: Capability
        {
            public override Enumerant Value => Capability.Enumerant.StorageBuffer8BitAccess;
            public new static StorageBuffer8BitAccess Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new StorageBuffer8BitAccess();
                return res;
            }
        }
        public class UniformAndStorageBuffer8BitAccess: Capability
        {
            public override Enumerant Value => Capability.Enumerant.UniformAndStorageBuffer8BitAccess;
            public new static UniformAndStorageBuffer8BitAccess Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new UniformAndStorageBuffer8BitAccess();
                return res;
            }
        }
        public class StoragePushConstant8: Capability
        {
            public override Enumerant Value => Capability.Enumerant.StoragePushConstant8;
            public new static StoragePushConstant8 Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new StoragePushConstant8();
                return res;
            }
        }
        public class DenormPreserve: Capability
        {
            public override Enumerant Value => Capability.Enumerant.DenormPreserve;
            public new static DenormPreserve Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new DenormPreserve();
                return res;
            }
        }
        public class DenormFlushToZero: Capability
        {
            public override Enumerant Value => Capability.Enumerant.DenormFlushToZero;
            public new static DenormFlushToZero Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new DenormFlushToZero();
                return res;
            }
        }
        public class SignedZeroInfNanPreserve: Capability
        {
            public override Enumerant Value => Capability.Enumerant.SignedZeroInfNanPreserve;
            public new static SignedZeroInfNanPreserve Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SignedZeroInfNanPreserve();
                return res;
            }
        }
        public class RoundingModeRTE: Capability
        {
            public override Enumerant Value => Capability.Enumerant.RoundingModeRTE;
            public new static RoundingModeRTE Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new RoundingModeRTE();
                return res;
            }
        }
        public class RoundingModeRTZ: Capability
        {
            public override Enumerant Value => Capability.Enumerant.RoundingModeRTZ;
            public new static RoundingModeRTZ Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new RoundingModeRTZ();
                return res;
            }
        }
        public class RayQueryProvisionalKHR: Capability
        {
            public override Enumerant Value => Capability.Enumerant.RayQueryProvisionalKHR;
            public new static RayQueryProvisionalKHR Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new RayQueryProvisionalKHR();
                return res;
            }
        }
        public class RayTraversalPrimitiveCullingProvisionalKHR: Capability
        {
            public override Enumerant Value => Capability.Enumerant.RayTraversalPrimitiveCullingProvisionalKHR;
            public new static RayTraversalPrimitiveCullingProvisionalKHR Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new RayTraversalPrimitiveCullingProvisionalKHR();
                return res;
            }
        }
        public class Float16ImageAMD: Capability
        {
            public override Enumerant Value => Capability.Enumerant.Float16ImageAMD;
            public new static Float16ImageAMD Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Float16ImageAMD();
                return res;
            }
        }
        public class ImageGatherBiasLodAMD: Capability
        {
            public override Enumerant Value => Capability.Enumerant.ImageGatherBiasLodAMD;
            public new static ImageGatherBiasLodAMD Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ImageGatherBiasLodAMD();
                return res;
            }
        }
        public class FragmentMaskAMD: Capability
        {
            public override Enumerant Value => Capability.Enumerant.FragmentMaskAMD;
            public new static FragmentMaskAMD Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new FragmentMaskAMD();
                return res;
            }
        }
        public class StencilExportEXT: Capability
        {
            public override Enumerant Value => Capability.Enumerant.StencilExportEXT;
            public new static StencilExportEXT Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new StencilExportEXT();
                return res;
            }
        }
        public class ImageReadWriteLodAMD: Capability
        {
            public override Enumerant Value => Capability.Enumerant.ImageReadWriteLodAMD;
            public new static ImageReadWriteLodAMD Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ImageReadWriteLodAMD();
                return res;
            }
        }
        public class ShaderClockKHR: Capability
        {
            public override Enumerant Value => Capability.Enumerant.ShaderClockKHR;
            public new static ShaderClockKHR Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ShaderClockKHR();
                return res;
            }
        }
        public class SampleMaskOverrideCoverageNV: Capability
        {
            public override Enumerant Value => Capability.Enumerant.SampleMaskOverrideCoverageNV;
            public new static SampleMaskOverrideCoverageNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SampleMaskOverrideCoverageNV();
                return res;
            }
        }
        public class GeometryShaderPassthroughNV: Capability
        {
            public override Enumerant Value => Capability.Enumerant.GeometryShaderPassthroughNV;
            public new static GeometryShaderPassthroughNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new GeometryShaderPassthroughNV();
                return res;
            }
        }
        public class ShaderViewportIndexLayerEXT: Capability
        {
            public override Enumerant Value => Capability.Enumerant.ShaderViewportIndexLayerEXT;
            public new static ShaderViewportIndexLayerEXT Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ShaderViewportIndexLayerEXT();
                return res;
            }
        }
        public class ShaderViewportIndexLayerNV: Capability
        {
            public override Enumerant Value => Capability.Enumerant.ShaderViewportIndexLayerNV;
            public new static ShaderViewportIndexLayerNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ShaderViewportIndexLayerNV();
                return res;
            }
        }
        public class ShaderViewportMaskNV: Capability
        {
            public override Enumerant Value => Capability.Enumerant.ShaderViewportMaskNV;
            public new static ShaderViewportMaskNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ShaderViewportMaskNV();
                return res;
            }
        }
        public class ShaderStereoViewNV: Capability
        {
            public override Enumerant Value => Capability.Enumerant.ShaderStereoViewNV;
            public new static ShaderStereoViewNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ShaderStereoViewNV();
                return res;
            }
        }
        public class PerViewAttributesNV: Capability
        {
            public override Enumerant Value => Capability.Enumerant.PerViewAttributesNV;
            public new static PerViewAttributesNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new PerViewAttributesNV();
                return res;
            }
        }
        public class FragmentFullyCoveredEXT: Capability
        {
            public override Enumerant Value => Capability.Enumerant.FragmentFullyCoveredEXT;
            public new static FragmentFullyCoveredEXT Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new FragmentFullyCoveredEXT();
                return res;
            }
        }
        public class MeshShadingNV: Capability
        {
            public override Enumerant Value => Capability.Enumerant.MeshShadingNV;
            public new static MeshShadingNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new MeshShadingNV();
                return res;
            }
        }
        public class ImageFootprintNV: Capability
        {
            public override Enumerant Value => Capability.Enumerant.ImageFootprintNV;
            public new static ImageFootprintNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ImageFootprintNV();
                return res;
            }
        }
        public class FragmentBarycentricNV: Capability
        {
            public override Enumerant Value => Capability.Enumerant.FragmentBarycentricNV;
            public new static FragmentBarycentricNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new FragmentBarycentricNV();
                return res;
            }
        }
        public class ComputeDerivativeGroupQuadsNV: Capability
        {
            public override Enumerant Value => Capability.Enumerant.ComputeDerivativeGroupQuadsNV;
            public new static ComputeDerivativeGroupQuadsNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ComputeDerivativeGroupQuadsNV();
                return res;
            }
        }
        public class FragmentDensityEXT: Capability
        {
            public override Enumerant Value => Capability.Enumerant.FragmentDensityEXT;
            public new static FragmentDensityEXT Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new FragmentDensityEXT();
                return res;
            }
        }
        public class ShadingRateNV: Capability
        {
            public override Enumerant Value => Capability.Enumerant.ShadingRateNV;
            public new static ShadingRateNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ShadingRateNV();
                return res;
            }
        }
        public class GroupNonUniformPartitionedNV: Capability
        {
            public override Enumerant Value => Capability.Enumerant.GroupNonUniformPartitionedNV;
            public new static GroupNonUniformPartitionedNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new GroupNonUniformPartitionedNV();
                return res;
            }
        }
        public class ShaderNonUniform: Capability
        {
            public override Enumerant Value => Capability.Enumerant.ShaderNonUniform;
            public new static ShaderNonUniform Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ShaderNonUniform();
                return res;
            }
        }
        public class ShaderNonUniformEXT: Capability
        {
            public override Enumerant Value => Capability.Enumerant.ShaderNonUniformEXT;
            public new static ShaderNonUniformEXT Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ShaderNonUniformEXT();
                return res;
            }
        }
        public class RuntimeDescriptorArray: Capability
        {
            public override Enumerant Value => Capability.Enumerant.RuntimeDescriptorArray;
            public new static RuntimeDescriptorArray Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new RuntimeDescriptorArray();
                return res;
            }
        }
        public class RuntimeDescriptorArrayEXT: Capability
        {
            public override Enumerant Value => Capability.Enumerant.RuntimeDescriptorArrayEXT;
            public new static RuntimeDescriptorArrayEXT Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new RuntimeDescriptorArrayEXT();
                return res;
            }
        }
        public class InputAttachmentArrayDynamicIndexing: Capability
        {
            public override Enumerant Value => Capability.Enumerant.InputAttachmentArrayDynamicIndexing;
            public new static InputAttachmentArrayDynamicIndexing Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new InputAttachmentArrayDynamicIndexing();
                return res;
            }
        }
        public class InputAttachmentArrayDynamicIndexingEXT: Capability
        {
            public override Enumerant Value => Capability.Enumerant.InputAttachmentArrayDynamicIndexingEXT;
            public new static InputAttachmentArrayDynamicIndexingEXT Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new InputAttachmentArrayDynamicIndexingEXT();
                return res;
            }
        }
        public class UniformTexelBufferArrayDynamicIndexing: Capability
        {
            public override Enumerant Value => Capability.Enumerant.UniformTexelBufferArrayDynamicIndexing;
            public new static UniformTexelBufferArrayDynamicIndexing Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new UniformTexelBufferArrayDynamicIndexing();
                return res;
            }
        }
        public class UniformTexelBufferArrayDynamicIndexingEXT: Capability
        {
            public override Enumerant Value => Capability.Enumerant.UniformTexelBufferArrayDynamicIndexingEXT;
            public new static UniformTexelBufferArrayDynamicIndexingEXT Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new UniformTexelBufferArrayDynamicIndexingEXT();
                return res;
            }
        }
        public class StorageTexelBufferArrayDynamicIndexing: Capability
        {
            public override Enumerant Value => Capability.Enumerant.StorageTexelBufferArrayDynamicIndexing;
            public new static StorageTexelBufferArrayDynamicIndexing Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new StorageTexelBufferArrayDynamicIndexing();
                return res;
            }
        }
        public class StorageTexelBufferArrayDynamicIndexingEXT: Capability
        {
            public override Enumerant Value => Capability.Enumerant.StorageTexelBufferArrayDynamicIndexingEXT;
            public new static StorageTexelBufferArrayDynamicIndexingEXT Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new StorageTexelBufferArrayDynamicIndexingEXT();
                return res;
            }
        }
        public class UniformBufferArrayNonUniformIndexing: Capability
        {
            public override Enumerant Value => Capability.Enumerant.UniformBufferArrayNonUniformIndexing;
            public new static UniformBufferArrayNonUniformIndexing Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new UniformBufferArrayNonUniformIndexing();
                return res;
            }
        }
        public class UniformBufferArrayNonUniformIndexingEXT: Capability
        {
            public override Enumerant Value => Capability.Enumerant.UniformBufferArrayNonUniformIndexingEXT;
            public new static UniformBufferArrayNonUniformIndexingEXT Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new UniformBufferArrayNonUniformIndexingEXT();
                return res;
            }
        }
        public class SampledImageArrayNonUniformIndexing: Capability
        {
            public override Enumerant Value => Capability.Enumerant.SampledImageArrayNonUniformIndexing;
            public new static SampledImageArrayNonUniformIndexing Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SampledImageArrayNonUniformIndexing();
                return res;
            }
        }
        public class SampledImageArrayNonUniformIndexingEXT: Capability
        {
            public override Enumerant Value => Capability.Enumerant.SampledImageArrayNonUniformIndexingEXT;
            public new static SampledImageArrayNonUniformIndexingEXT Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SampledImageArrayNonUniformIndexingEXT();
                return res;
            }
        }
        public class StorageBufferArrayNonUniformIndexing: Capability
        {
            public override Enumerant Value => Capability.Enumerant.StorageBufferArrayNonUniformIndexing;
            public new static StorageBufferArrayNonUniformIndexing Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new StorageBufferArrayNonUniformIndexing();
                return res;
            }
        }
        public class StorageBufferArrayNonUniformIndexingEXT: Capability
        {
            public override Enumerant Value => Capability.Enumerant.StorageBufferArrayNonUniformIndexingEXT;
            public new static StorageBufferArrayNonUniformIndexingEXT Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new StorageBufferArrayNonUniformIndexingEXT();
                return res;
            }
        }
        public class StorageImageArrayNonUniformIndexing: Capability
        {
            public override Enumerant Value => Capability.Enumerant.StorageImageArrayNonUniformIndexing;
            public new static StorageImageArrayNonUniformIndexing Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new StorageImageArrayNonUniformIndexing();
                return res;
            }
        }
        public class StorageImageArrayNonUniformIndexingEXT: Capability
        {
            public override Enumerant Value => Capability.Enumerant.StorageImageArrayNonUniformIndexingEXT;
            public new static StorageImageArrayNonUniformIndexingEXT Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new StorageImageArrayNonUniformIndexingEXT();
                return res;
            }
        }
        public class InputAttachmentArrayNonUniformIndexing: Capability
        {
            public override Enumerant Value => Capability.Enumerant.InputAttachmentArrayNonUniformIndexing;
            public new static InputAttachmentArrayNonUniformIndexing Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new InputAttachmentArrayNonUniformIndexing();
                return res;
            }
        }
        public class InputAttachmentArrayNonUniformIndexingEXT: Capability
        {
            public override Enumerant Value => Capability.Enumerant.InputAttachmentArrayNonUniformIndexingEXT;
            public new static InputAttachmentArrayNonUniformIndexingEXT Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new InputAttachmentArrayNonUniformIndexingEXT();
                return res;
            }
        }
        public class UniformTexelBufferArrayNonUniformIndexing: Capability
        {
            public override Enumerant Value => Capability.Enumerant.UniformTexelBufferArrayNonUniformIndexing;
            public new static UniformTexelBufferArrayNonUniformIndexing Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new UniformTexelBufferArrayNonUniformIndexing();
                return res;
            }
        }
        public class UniformTexelBufferArrayNonUniformIndexingEXT: Capability
        {
            public override Enumerant Value => Capability.Enumerant.UniformTexelBufferArrayNonUniformIndexingEXT;
            public new static UniformTexelBufferArrayNonUniformIndexingEXT Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new UniformTexelBufferArrayNonUniformIndexingEXT();
                return res;
            }
        }
        public class StorageTexelBufferArrayNonUniformIndexing: Capability
        {
            public override Enumerant Value => Capability.Enumerant.StorageTexelBufferArrayNonUniformIndexing;
            public new static StorageTexelBufferArrayNonUniformIndexing Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new StorageTexelBufferArrayNonUniformIndexing();
                return res;
            }
        }
        public class StorageTexelBufferArrayNonUniformIndexingEXT: Capability
        {
            public override Enumerant Value => Capability.Enumerant.StorageTexelBufferArrayNonUniformIndexingEXT;
            public new static StorageTexelBufferArrayNonUniformIndexingEXT Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new StorageTexelBufferArrayNonUniformIndexingEXT();
                return res;
            }
        }
        public class RayTracingNV: Capability
        {
            public override Enumerant Value => Capability.Enumerant.RayTracingNV;
            public new static RayTracingNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new RayTracingNV();
                return res;
            }
        }
        public class VulkanMemoryModel: Capability
        {
            public override Enumerant Value => Capability.Enumerant.VulkanMemoryModel;
            public new static VulkanMemoryModel Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new VulkanMemoryModel();
                return res;
            }
        }
        public class VulkanMemoryModelKHR: Capability
        {
            public override Enumerant Value => Capability.Enumerant.VulkanMemoryModelKHR;
            public new static VulkanMemoryModelKHR Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new VulkanMemoryModelKHR();
                return res;
            }
        }
        public class VulkanMemoryModelDeviceScope: Capability
        {
            public override Enumerant Value => Capability.Enumerant.VulkanMemoryModelDeviceScope;
            public new static VulkanMemoryModelDeviceScope Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new VulkanMemoryModelDeviceScope();
                return res;
            }
        }
        public class VulkanMemoryModelDeviceScopeKHR: Capability
        {
            public override Enumerant Value => Capability.Enumerant.VulkanMemoryModelDeviceScopeKHR;
            public new static VulkanMemoryModelDeviceScopeKHR Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new VulkanMemoryModelDeviceScopeKHR();
                return res;
            }
        }
        public class PhysicalStorageBufferAddresses: Capability
        {
            public override Enumerant Value => Capability.Enumerant.PhysicalStorageBufferAddresses;
            public new static PhysicalStorageBufferAddresses Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new PhysicalStorageBufferAddresses();
                return res;
            }
        }
        public class PhysicalStorageBufferAddressesEXT: Capability
        {
            public override Enumerant Value => Capability.Enumerant.PhysicalStorageBufferAddressesEXT;
            public new static PhysicalStorageBufferAddressesEXT Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new PhysicalStorageBufferAddressesEXT();
                return res;
            }
        }
        public class ComputeDerivativeGroupLinearNV: Capability
        {
            public override Enumerant Value => Capability.Enumerant.ComputeDerivativeGroupLinearNV;
            public new static ComputeDerivativeGroupLinearNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ComputeDerivativeGroupLinearNV();
                return res;
            }
        }
        public class RayTracingProvisionalKHR: Capability
        {
            public override Enumerant Value => Capability.Enumerant.RayTracingProvisionalKHR;
            public new static RayTracingProvisionalKHR Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new RayTracingProvisionalKHR();
                return res;
            }
        }
        public class CooperativeMatrixNV: Capability
        {
            public override Enumerant Value => Capability.Enumerant.CooperativeMatrixNV;
            public new static CooperativeMatrixNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new CooperativeMatrixNV();
                return res;
            }
        }
        public class FragmentShaderSampleInterlockEXT: Capability
        {
            public override Enumerant Value => Capability.Enumerant.FragmentShaderSampleInterlockEXT;
            public new static FragmentShaderSampleInterlockEXT Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new FragmentShaderSampleInterlockEXT();
                return res;
            }
        }
        public class FragmentShaderShadingRateInterlockEXT: Capability
        {
            public override Enumerant Value => Capability.Enumerant.FragmentShaderShadingRateInterlockEXT;
            public new static FragmentShaderShadingRateInterlockEXT Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new FragmentShaderShadingRateInterlockEXT();
                return res;
            }
        }
        public class ShaderSMBuiltinsNV: Capability
        {
            public override Enumerant Value => Capability.Enumerant.ShaderSMBuiltinsNV;
            public new static ShaderSMBuiltinsNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ShaderSMBuiltinsNV();
                return res;
            }
        }
        public class FragmentShaderPixelInterlockEXT: Capability
        {
            public override Enumerant Value => Capability.Enumerant.FragmentShaderPixelInterlockEXT;
            public new static FragmentShaderPixelInterlockEXT Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new FragmentShaderPixelInterlockEXT();
                return res;
            }
        }
        public class DemoteToHelperInvocationEXT: Capability
        {
            public override Enumerant Value => Capability.Enumerant.DemoteToHelperInvocationEXT;
            public new static DemoteToHelperInvocationEXT Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new DemoteToHelperInvocationEXT();
                return res;
            }
        }
        public class SubgroupShuffleINTEL: Capability
        {
            public override Enumerant Value => Capability.Enumerant.SubgroupShuffleINTEL;
            public new static SubgroupShuffleINTEL Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SubgroupShuffleINTEL();
                return res;
            }
        }
        public class SubgroupBufferBlockIOINTEL: Capability
        {
            public override Enumerant Value => Capability.Enumerant.SubgroupBufferBlockIOINTEL;
            public new static SubgroupBufferBlockIOINTEL Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SubgroupBufferBlockIOINTEL();
                return res;
            }
        }
        public class SubgroupImageBlockIOINTEL: Capability
        {
            public override Enumerant Value => Capability.Enumerant.SubgroupImageBlockIOINTEL;
            public new static SubgroupImageBlockIOINTEL Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SubgroupImageBlockIOINTEL();
                return res;
            }
        }
        public class SubgroupImageMediaBlockIOINTEL: Capability
        {
            public override Enumerant Value => Capability.Enumerant.SubgroupImageMediaBlockIOINTEL;
            public new static SubgroupImageMediaBlockIOINTEL Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SubgroupImageMediaBlockIOINTEL();
                return res;
            }
        }
        public class IntegerFunctions2INTEL: Capability
        {
            public override Enumerant Value => Capability.Enumerant.IntegerFunctions2INTEL;
            public new static IntegerFunctions2INTEL Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new IntegerFunctions2INTEL();
                return res;
            }
        }
        public class SubgroupAvcMotionEstimationINTEL: Capability
        {
            public override Enumerant Value => Capability.Enumerant.SubgroupAvcMotionEstimationINTEL;
            public new static SubgroupAvcMotionEstimationINTEL Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SubgroupAvcMotionEstimationINTEL();
                return res;
            }
        }
        public class SubgroupAvcMotionEstimationIntraINTEL: Capability
        {
            public override Enumerant Value => Capability.Enumerant.SubgroupAvcMotionEstimationIntraINTEL;
            public new static SubgroupAvcMotionEstimationIntraINTEL Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SubgroupAvcMotionEstimationIntraINTEL();
                return res;
            }
        }
        public class SubgroupAvcMotionEstimationChromaINTEL: Capability
        {
            public override Enumerant Value => Capability.Enumerant.SubgroupAvcMotionEstimationChromaINTEL;
            public new static SubgroupAvcMotionEstimationChromaINTEL Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SubgroupAvcMotionEstimationChromaINTEL();
                return res;
            }
        }

        public abstract Enumerant Value { get; }

        public static Capability Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                case Enumerant.Matrix :
                    return Matrix.Parse(reader, wordCount - 1);
                case Enumerant.Shader :
                    return Shader.Parse(reader, wordCount - 1);
                case Enumerant.Geometry :
                    return Geometry.Parse(reader, wordCount - 1);
                case Enumerant.Tessellation :
                    return Tessellation.Parse(reader, wordCount - 1);
                case Enumerant.Addresses :
                    return Addresses.Parse(reader, wordCount - 1);
                case Enumerant.Linkage :
                    return Linkage.Parse(reader, wordCount - 1);
                case Enumerant.Kernel :
                    return Kernel.Parse(reader, wordCount - 1);
                case Enumerant.Vector16 :
                    return Vector16.Parse(reader, wordCount - 1);
                case Enumerant.Float16Buffer :
                    return Float16Buffer.Parse(reader, wordCount - 1);
                case Enumerant.Float16 :
                    return Float16.Parse(reader, wordCount - 1);
                case Enumerant.Float64 :
                    return Float64.Parse(reader, wordCount - 1);
                case Enumerant.Int64 :
                    return Int64.Parse(reader, wordCount - 1);
                case Enumerant.Int64Atomics :
                    return Int64Atomics.Parse(reader, wordCount - 1);
                case Enumerant.ImageBasic :
                    return ImageBasic.Parse(reader, wordCount - 1);
                case Enumerant.ImageReadWrite :
                    return ImageReadWrite.Parse(reader, wordCount - 1);
                case Enumerant.ImageMipmap :
                    return ImageMipmap.Parse(reader, wordCount - 1);
                case Enumerant.Pipes :
                    return Pipes.Parse(reader, wordCount - 1);
                case Enumerant.Groups :
                    return Groups.Parse(reader, wordCount - 1);
                case Enumerant.DeviceEnqueue :
                    return DeviceEnqueue.Parse(reader, wordCount - 1);
                case Enumerant.LiteralSampler :
                    return LiteralSampler.Parse(reader, wordCount - 1);
                case Enumerant.AtomicStorage :
                    return AtomicStorage.Parse(reader, wordCount - 1);
                case Enumerant.Int16 :
                    return Int16.Parse(reader, wordCount - 1);
                case Enumerant.TessellationPointSize :
                    return TessellationPointSize.Parse(reader, wordCount - 1);
                case Enumerant.GeometryPointSize :
                    return GeometryPointSize.Parse(reader, wordCount - 1);
                case Enumerant.ImageGatherExtended :
                    return ImageGatherExtended.Parse(reader, wordCount - 1);
                case Enumerant.StorageImageMultisample :
                    return StorageImageMultisample.Parse(reader, wordCount - 1);
                case Enumerant.UniformBufferArrayDynamicIndexing :
                    return UniformBufferArrayDynamicIndexing.Parse(reader, wordCount - 1);
                case Enumerant.SampledImageArrayDynamicIndexing :
                    return SampledImageArrayDynamicIndexing.Parse(reader, wordCount - 1);
                case Enumerant.StorageBufferArrayDynamicIndexing :
                    return StorageBufferArrayDynamicIndexing.Parse(reader, wordCount - 1);
                case Enumerant.StorageImageArrayDynamicIndexing :
                    return StorageImageArrayDynamicIndexing.Parse(reader, wordCount - 1);
                case Enumerant.ClipDistance :
                    return ClipDistance.Parse(reader, wordCount - 1);
                case Enumerant.CullDistance :
                    return CullDistance.Parse(reader, wordCount - 1);
                case Enumerant.ImageCubeArray :
                    return ImageCubeArray.Parse(reader, wordCount - 1);
                case Enumerant.SampleRateShading :
                    return SampleRateShading.Parse(reader, wordCount - 1);
                case Enumerant.ImageRect :
                    return ImageRect.Parse(reader, wordCount - 1);
                case Enumerant.SampledRect :
                    return SampledRect.Parse(reader, wordCount - 1);
                case Enumerant.GenericPointer :
                    return GenericPointer.Parse(reader, wordCount - 1);
                case Enumerant.Int8 :
                    return Int8.Parse(reader, wordCount - 1);
                case Enumerant.InputAttachment :
                    return InputAttachment.Parse(reader, wordCount - 1);
                case Enumerant.SparseResidency :
                    return SparseResidency.Parse(reader, wordCount - 1);
                case Enumerant.MinLod :
                    return MinLod.Parse(reader, wordCount - 1);
                case Enumerant.Sampled1D :
                    return Sampled1D.Parse(reader, wordCount - 1);
                case Enumerant.Image1D :
                    return Image1D.Parse(reader, wordCount - 1);
                case Enumerant.SampledCubeArray :
                    return SampledCubeArray.Parse(reader, wordCount - 1);
                case Enumerant.SampledBuffer :
                    return SampledBuffer.Parse(reader, wordCount - 1);
                case Enumerant.ImageBuffer :
                    return ImageBuffer.Parse(reader, wordCount - 1);
                case Enumerant.ImageMSArray :
                    return ImageMSArray.Parse(reader, wordCount - 1);
                case Enumerant.StorageImageExtendedFormats :
                    return StorageImageExtendedFormats.Parse(reader, wordCount - 1);
                case Enumerant.ImageQuery :
                    return ImageQuery.Parse(reader, wordCount - 1);
                case Enumerant.DerivativeControl :
                    return DerivativeControl.Parse(reader, wordCount - 1);
                case Enumerant.InterpolationFunction :
                    return InterpolationFunction.Parse(reader, wordCount - 1);
                case Enumerant.TransformFeedback :
                    return TransformFeedback.Parse(reader, wordCount - 1);
                case Enumerant.GeometryStreams :
                    return GeometryStreams.Parse(reader, wordCount - 1);
                case Enumerant.StorageImageReadWithoutFormat :
                    return StorageImageReadWithoutFormat.Parse(reader, wordCount - 1);
                case Enumerant.StorageImageWriteWithoutFormat :
                    return StorageImageWriteWithoutFormat.Parse(reader, wordCount - 1);
                case Enumerant.MultiViewport :
                    return MultiViewport.Parse(reader, wordCount - 1);
                case Enumerant.SubgroupDispatch :
                    return SubgroupDispatch.Parse(reader, wordCount - 1);
                case Enumerant.NamedBarrier :
                    return NamedBarrier.Parse(reader, wordCount - 1);
                case Enumerant.PipeStorage :
                    return PipeStorage.Parse(reader, wordCount - 1);
                case Enumerant.GroupNonUniform :
                    return GroupNonUniform.Parse(reader, wordCount - 1);
                case Enumerant.GroupNonUniformVote :
                    return GroupNonUniformVote.Parse(reader, wordCount - 1);
                case Enumerant.GroupNonUniformArithmetic :
                    return GroupNonUniformArithmetic.Parse(reader, wordCount - 1);
                case Enumerant.GroupNonUniformBallot :
                    return GroupNonUniformBallot.Parse(reader, wordCount - 1);
                case Enumerant.GroupNonUniformShuffle :
                    return GroupNonUniformShuffle.Parse(reader, wordCount - 1);
                case Enumerant.GroupNonUniformShuffleRelative :
                    return GroupNonUniformShuffleRelative.Parse(reader, wordCount - 1);
                case Enumerant.GroupNonUniformClustered :
                    return GroupNonUniformClustered.Parse(reader, wordCount - 1);
                case Enumerant.GroupNonUniformQuad :
                    return GroupNonUniformQuad.Parse(reader, wordCount - 1);
                case Enumerant.ShaderLayer :
                    return ShaderLayer.Parse(reader, wordCount - 1);
                case Enumerant.ShaderViewportIndex :
                    return ShaderViewportIndex.Parse(reader, wordCount - 1);
                case Enumerant.SubgroupBallotKHR :
                    return SubgroupBallotKHR.Parse(reader, wordCount - 1);
                case Enumerant.DrawParameters :
                    return DrawParameters.Parse(reader, wordCount - 1);
                case Enumerant.SubgroupVoteKHR :
                    return SubgroupVoteKHR.Parse(reader, wordCount - 1);
                case Enumerant.StorageBuffer16BitAccess :
                    return StorageBuffer16BitAccess.Parse(reader, wordCount - 1);
                //StorageUniformBufferBlock16 has the same id as another value in enum.
                //case Enumerant.StorageUniformBufferBlock16 :
                //    return StorageUniformBufferBlock16.Parse(reader, wordCount - 1);
                case Enumerant.UniformAndStorageBuffer16BitAccess :
                    return UniformAndStorageBuffer16BitAccess.Parse(reader, wordCount - 1);
                //StorageUniform16 has the same id as another value in enum.
                //case Enumerant.StorageUniform16 :
                //    return StorageUniform16.Parse(reader, wordCount - 1);
                case Enumerant.StoragePushConstant16 :
                    return StoragePushConstant16.Parse(reader, wordCount - 1);
                case Enumerant.StorageInputOutput16 :
                    return StorageInputOutput16.Parse(reader, wordCount - 1);
                case Enumerant.DeviceGroup :
                    return DeviceGroup.Parse(reader, wordCount - 1);
                case Enumerant.MultiView :
                    return MultiView.Parse(reader, wordCount - 1);
                case Enumerant.VariablePointersStorageBuffer :
                    return VariablePointersStorageBuffer.Parse(reader, wordCount - 1);
                case Enumerant.VariablePointers :
                    return VariablePointers.Parse(reader, wordCount - 1);
                case Enumerant.AtomicStorageOps :
                    return AtomicStorageOps.Parse(reader, wordCount - 1);
                case Enumerant.SampleMaskPostDepthCoverage :
                    return SampleMaskPostDepthCoverage.Parse(reader, wordCount - 1);
                case Enumerant.StorageBuffer8BitAccess :
                    return StorageBuffer8BitAccess.Parse(reader, wordCount - 1);
                case Enumerant.UniformAndStorageBuffer8BitAccess :
                    return UniformAndStorageBuffer8BitAccess.Parse(reader, wordCount - 1);
                case Enumerant.StoragePushConstant8 :
                    return StoragePushConstant8.Parse(reader, wordCount - 1);
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
                case Enumerant.RayQueryProvisionalKHR :
                    return RayQueryProvisionalKHR.Parse(reader, wordCount - 1);
                case Enumerant.RayTraversalPrimitiveCullingProvisionalKHR :
                    return RayTraversalPrimitiveCullingProvisionalKHR.Parse(reader, wordCount - 1);
                case Enumerant.Float16ImageAMD :
                    return Float16ImageAMD.Parse(reader, wordCount - 1);
                case Enumerant.ImageGatherBiasLodAMD :
                    return ImageGatherBiasLodAMD.Parse(reader, wordCount - 1);
                case Enumerant.FragmentMaskAMD :
                    return FragmentMaskAMD.Parse(reader, wordCount - 1);
                case Enumerant.StencilExportEXT :
                    return StencilExportEXT.Parse(reader, wordCount - 1);
                case Enumerant.ImageReadWriteLodAMD :
                    return ImageReadWriteLodAMD.Parse(reader, wordCount - 1);
                case Enumerant.ShaderClockKHR :
                    return ShaderClockKHR.Parse(reader, wordCount - 1);
                case Enumerant.SampleMaskOverrideCoverageNV :
                    return SampleMaskOverrideCoverageNV.Parse(reader, wordCount - 1);
                case Enumerant.GeometryShaderPassthroughNV :
                    return GeometryShaderPassthroughNV.Parse(reader, wordCount - 1);
                case Enumerant.ShaderViewportIndexLayerEXT :
                    return ShaderViewportIndexLayerEXT.Parse(reader, wordCount - 1);
                //ShaderViewportIndexLayerNV has the same id as another value in enum.
                //case Enumerant.ShaderViewportIndexLayerNV :
                //    return ShaderViewportIndexLayerNV.Parse(reader, wordCount - 1);
                case Enumerant.ShaderViewportMaskNV :
                    return ShaderViewportMaskNV.Parse(reader, wordCount - 1);
                case Enumerant.ShaderStereoViewNV :
                    return ShaderStereoViewNV.Parse(reader, wordCount - 1);
                case Enumerant.PerViewAttributesNV :
                    return PerViewAttributesNV.Parse(reader, wordCount - 1);
                case Enumerant.FragmentFullyCoveredEXT :
                    return FragmentFullyCoveredEXT.Parse(reader, wordCount - 1);
                case Enumerant.MeshShadingNV :
                    return MeshShadingNV.Parse(reader, wordCount - 1);
                case Enumerant.ImageFootprintNV :
                    return ImageFootprintNV.Parse(reader, wordCount - 1);
                case Enumerant.FragmentBarycentricNV :
                    return FragmentBarycentricNV.Parse(reader, wordCount - 1);
                case Enumerant.ComputeDerivativeGroupQuadsNV :
                    return ComputeDerivativeGroupQuadsNV.Parse(reader, wordCount - 1);
                case Enumerant.FragmentDensityEXT :
                    return FragmentDensityEXT.Parse(reader, wordCount - 1);
                //ShadingRateNV has the same id as another value in enum.
                //case Enumerant.ShadingRateNV :
                //    return ShadingRateNV.Parse(reader, wordCount - 1);
                case Enumerant.GroupNonUniformPartitionedNV :
                    return GroupNonUniformPartitionedNV.Parse(reader, wordCount - 1);
                case Enumerant.ShaderNonUniform :
                    return ShaderNonUniform.Parse(reader, wordCount - 1);
                //ShaderNonUniformEXT has the same id as another value in enum.
                //case Enumerant.ShaderNonUniformEXT :
                //    return ShaderNonUniformEXT.Parse(reader, wordCount - 1);
                case Enumerant.RuntimeDescriptorArray :
                    return RuntimeDescriptorArray.Parse(reader, wordCount - 1);
                //RuntimeDescriptorArrayEXT has the same id as another value in enum.
                //case Enumerant.RuntimeDescriptorArrayEXT :
                //    return RuntimeDescriptorArrayEXT.Parse(reader, wordCount - 1);
                case Enumerant.InputAttachmentArrayDynamicIndexing :
                    return InputAttachmentArrayDynamicIndexing.Parse(reader, wordCount - 1);
                //InputAttachmentArrayDynamicIndexingEXT has the same id as another value in enum.
                //case Enumerant.InputAttachmentArrayDynamicIndexingEXT :
                //    return InputAttachmentArrayDynamicIndexingEXT.Parse(reader, wordCount - 1);
                case Enumerant.UniformTexelBufferArrayDynamicIndexing :
                    return UniformTexelBufferArrayDynamicIndexing.Parse(reader, wordCount - 1);
                //UniformTexelBufferArrayDynamicIndexingEXT has the same id as another value in enum.
                //case Enumerant.UniformTexelBufferArrayDynamicIndexingEXT :
                //    return UniformTexelBufferArrayDynamicIndexingEXT.Parse(reader, wordCount - 1);
                case Enumerant.StorageTexelBufferArrayDynamicIndexing :
                    return StorageTexelBufferArrayDynamicIndexing.Parse(reader, wordCount - 1);
                //StorageTexelBufferArrayDynamicIndexingEXT has the same id as another value in enum.
                //case Enumerant.StorageTexelBufferArrayDynamicIndexingEXT :
                //    return StorageTexelBufferArrayDynamicIndexingEXT.Parse(reader, wordCount - 1);
                case Enumerant.UniformBufferArrayNonUniformIndexing :
                    return UniformBufferArrayNonUniformIndexing.Parse(reader, wordCount - 1);
                //UniformBufferArrayNonUniformIndexingEXT has the same id as another value in enum.
                //case Enumerant.UniformBufferArrayNonUniformIndexingEXT :
                //    return UniformBufferArrayNonUniformIndexingEXT.Parse(reader, wordCount - 1);
                case Enumerant.SampledImageArrayNonUniformIndexing :
                    return SampledImageArrayNonUniformIndexing.Parse(reader, wordCount - 1);
                //SampledImageArrayNonUniformIndexingEXT has the same id as another value in enum.
                //case Enumerant.SampledImageArrayNonUniformIndexingEXT :
                //    return SampledImageArrayNonUniformIndexingEXT.Parse(reader, wordCount - 1);
                case Enumerant.StorageBufferArrayNonUniformIndexing :
                    return StorageBufferArrayNonUniformIndexing.Parse(reader, wordCount - 1);
                //StorageBufferArrayNonUniformIndexingEXT has the same id as another value in enum.
                //case Enumerant.StorageBufferArrayNonUniformIndexingEXT :
                //    return StorageBufferArrayNonUniformIndexingEXT.Parse(reader, wordCount - 1);
                case Enumerant.StorageImageArrayNonUniformIndexing :
                    return StorageImageArrayNonUniformIndexing.Parse(reader, wordCount - 1);
                //StorageImageArrayNonUniformIndexingEXT has the same id as another value in enum.
                //case Enumerant.StorageImageArrayNonUniformIndexingEXT :
                //    return StorageImageArrayNonUniformIndexingEXT.Parse(reader, wordCount - 1);
                case Enumerant.InputAttachmentArrayNonUniformIndexing :
                    return InputAttachmentArrayNonUniformIndexing.Parse(reader, wordCount - 1);
                //InputAttachmentArrayNonUniformIndexingEXT has the same id as another value in enum.
                //case Enumerant.InputAttachmentArrayNonUniformIndexingEXT :
                //    return InputAttachmentArrayNonUniformIndexingEXT.Parse(reader, wordCount - 1);
                case Enumerant.UniformTexelBufferArrayNonUniformIndexing :
                    return UniformTexelBufferArrayNonUniformIndexing.Parse(reader, wordCount - 1);
                //UniformTexelBufferArrayNonUniformIndexingEXT has the same id as another value in enum.
                //case Enumerant.UniformTexelBufferArrayNonUniformIndexingEXT :
                //    return UniformTexelBufferArrayNonUniformIndexingEXT.Parse(reader, wordCount - 1);
                case Enumerant.StorageTexelBufferArrayNonUniformIndexing :
                    return StorageTexelBufferArrayNonUniformIndexing.Parse(reader, wordCount - 1);
                //StorageTexelBufferArrayNonUniformIndexingEXT has the same id as another value in enum.
                //case Enumerant.StorageTexelBufferArrayNonUniformIndexingEXT :
                //    return StorageTexelBufferArrayNonUniformIndexingEXT.Parse(reader, wordCount - 1);
                case Enumerant.RayTracingNV :
                    return RayTracingNV.Parse(reader, wordCount - 1);
                case Enumerant.VulkanMemoryModel :
                    return VulkanMemoryModel.Parse(reader, wordCount - 1);
                //VulkanMemoryModelKHR has the same id as another value in enum.
                //case Enumerant.VulkanMemoryModelKHR :
                //    return VulkanMemoryModelKHR.Parse(reader, wordCount - 1);
                case Enumerant.VulkanMemoryModelDeviceScope :
                    return VulkanMemoryModelDeviceScope.Parse(reader, wordCount - 1);
                //VulkanMemoryModelDeviceScopeKHR has the same id as another value in enum.
                //case Enumerant.VulkanMemoryModelDeviceScopeKHR :
                //    return VulkanMemoryModelDeviceScopeKHR.Parse(reader, wordCount - 1);
                case Enumerant.PhysicalStorageBufferAddresses :
                    return PhysicalStorageBufferAddresses.Parse(reader, wordCount - 1);
                //PhysicalStorageBufferAddressesEXT has the same id as another value in enum.
                //case Enumerant.PhysicalStorageBufferAddressesEXT :
                //    return PhysicalStorageBufferAddressesEXT.Parse(reader, wordCount - 1);
                case Enumerant.ComputeDerivativeGroupLinearNV :
                    return ComputeDerivativeGroupLinearNV.Parse(reader, wordCount - 1);
                case Enumerant.RayTracingProvisionalKHR :
                    return RayTracingProvisionalKHR.Parse(reader, wordCount - 1);
                case Enumerant.CooperativeMatrixNV :
                    return CooperativeMatrixNV.Parse(reader, wordCount - 1);
                case Enumerant.FragmentShaderSampleInterlockEXT :
                    return FragmentShaderSampleInterlockEXT.Parse(reader, wordCount - 1);
                case Enumerant.FragmentShaderShadingRateInterlockEXT :
                    return FragmentShaderShadingRateInterlockEXT.Parse(reader, wordCount - 1);
                case Enumerant.ShaderSMBuiltinsNV :
                    return ShaderSMBuiltinsNV.Parse(reader, wordCount - 1);
                case Enumerant.FragmentShaderPixelInterlockEXT :
                    return FragmentShaderPixelInterlockEXT.Parse(reader, wordCount - 1);
                case Enumerant.DemoteToHelperInvocationEXT :
                    return DemoteToHelperInvocationEXT.Parse(reader, wordCount - 1);
                case Enumerant.SubgroupShuffleINTEL :
                    return SubgroupShuffleINTEL.Parse(reader, wordCount - 1);
                case Enumerant.SubgroupBufferBlockIOINTEL :
                    return SubgroupBufferBlockIOINTEL.Parse(reader, wordCount - 1);
                case Enumerant.SubgroupImageBlockIOINTEL :
                    return SubgroupImageBlockIOINTEL.Parse(reader, wordCount - 1);
                case Enumerant.SubgroupImageMediaBlockIOINTEL :
                    return SubgroupImageMediaBlockIOINTEL.Parse(reader, wordCount - 1);
                case Enumerant.IntegerFunctions2INTEL :
                    return IntegerFunctions2INTEL.Parse(reader, wordCount - 1);
                case Enumerant.SubgroupAvcMotionEstimationINTEL :
                    return SubgroupAvcMotionEstimationINTEL.Parse(reader, wordCount - 1);
                case Enumerant.SubgroupAvcMotionEstimationIntraINTEL :
                    return SubgroupAvcMotionEstimationIntraINTEL.Parse(reader, wordCount - 1);
                case Enumerant.SubgroupAvcMotionEstimationChromaINTEL :
                    return SubgroupAvcMotionEstimationChromaINTEL.Parse(reader, wordCount - 1);
                default:
                    throw new IndexOutOfRangeException("Unknown Capability "+id);
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