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
                case Enumerant.ImageGatherBiasLodAMD :
                    return ImageGatherBiasLodAMD.Parse(reader, wordCount - 1);
                case Enumerant.FragmentMaskAMD :
                    return FragmentMaskAMD.Parse(reader, wordCount - 1);
                case Enumerant.StencilExportEXT :
                    return StencilExportEXT.Parse(reader, wordCount - 1);
                case Enumerant.ImageReadWriteLodAMD :
                    return ImageReadWriteLodAMD.Parse(reader, wordCount - 1);
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
                case Enumerant.SubgroupShuffleINTEL :
                    return SubgroupShuffleINTEL.Parse(reader, wordCount - 1);
                case Enumerant.SubgroupBufferBlockIOINTEL :
                    return SubgroupBufferBlockIOINTEL.Parse(reader, wordCount - 1);
                case Enumerant.SubgroupImageBlockIOINTEL :
                    return SubgroupImageBlockIOINTEL.Parse(reader, wordCount - 1);
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