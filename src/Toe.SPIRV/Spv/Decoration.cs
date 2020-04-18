using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public abstract partial class Decoration : ValueEnum
    {
        public enum Enumerant
        {
            [Capability(Capability.Enumerant.Shader)]
            RelaxedPrecision = 0,
            [Capability(Capability.Enumerant.Shader)]
            [Capability(Capability.Enumerant.Kernel)]
            SpecId = 1,
            [Capability(Capability.Enumerant.Shader)]
            Block = 2,
            [Capability(Capability.Enumerant.Shader)]
            BufferBlock = 3,
            [Capability(Capability.Enumerant.Matrix)]
            RowMajor = 4,
            [Capability(Capability.Enumerant.Matrix)]
            ColMajor = 5,
            [Capability(Capability.Enumerant.Shader)]
            ArrayStride = 6,
            [Capability(Capability.Enumerant.Matrix)]
            MatrixStride = 7,
            [Capability(Capability.Enumerant.Shader)]
            GLSLShared = 8,
            [Capability(Capability.Enumerant.Shader)]
            GLSLPacked = 9,
            [Capability(Capability.Enumerant.Kernel)]
            CPacked = 10,
            BuiltIn = 11,
            [Capability(Capability.Enumerant.Shader)]
            NoPerspective = 13,
            [Capability(Capability.Enumerant.Shader)]
            Flat = 14,
            [Capability(Capability.Enumerant.Tessellation)]
            Patch = 15,
            [Capability(Capability.Enumerant.Shader)]
            Centroid = 16,
            [Capability(Capability.Enumerant.SampleRateShading)]
            Sample = 17,
            [Capability(Capability.Enumerant.Shader)]
            Invariant = 18,
            Restrict = 19,
            Aliased = 20,
            Volatile = 21,
            [Capability(Capability.Enumerant.Kernel)]
            Constant = 22,
            Coherent = 23,
            NonWritable = 24,
            NonReadable = 25,
            [Capability(Capability.Enumerant.Shader)]
            Uniform = 26,
            [Capability(Capability.Enumerant.Shader)]
            UniformId = 27,
            [Capability(Capability.Enumerant.Kernel)]
            SaturatedConversion = 28,
            [Capability(Capability.Enumerant.GeometryStreams)]
            Stream = 29,
            [Capability(Capability.Enumerant.Shader)]
            Location = 30,
            [Capability(Capability.Enumerant.Shader)]
            Component = 31,
            [Capability(Capability.Enumerant.Shader)]
            Index = 32,
            [Capability(Capability.Enumerant.Shader)]
            Binding = 33,
            [Capability(Capability.Enumerant.Shader)]
            DescriptorSet = 34,
            [Capability(Capability.Enumerant.Shader)]
            Offset = 35,
            [Capability(Capability.Enumerant.TransformFeedback)]
            XfbBuffer = 36,
            [Capability(Capability.Enumerant.TransformFeedback)]
            XfbStride = 37,
            [Capability(Capability.Enumerant.Kernel)]
            FuncParamAttr = 38,
            FPRoundingMode = 39,
            [Capability(Capability.Enumerant.Kernel)]
            FPFastMathMode = 40,
            [Capability(Capability.Enumerant.Linkage)]
            LinkageAttributes = 41,
            [Capability(Capability.Enumerant.Shader)]
            NoContraction = 42,
            [Capability(Capability.Enumerant.InputAttachment)]
            InputAttachmentIndex = 43,
            [Capability(Capability.Enumerant.Kernel)]
            Alignment = 44,
            [Capability(Capability.Enumerant.Addresses)]
            MaxByteOffset = 45,
            [Capability(Capability.Enumerant.Kernel)]
            AlignmentId = 46,
            [Capability(Capability.Enumerant.Addresses)]
            MaxByteOffsetId = 47,
            NoSignedWrap = 4469,
            NoUnsignedWrap = 4470,
            ExplicitInterpAMD = 4999,
            [Capability(Capability.Enumerant.SampleMaskOverrideCoverageNV)]
            OverrideCoverageNV = 5248,
            [Capability(Capability.Enumerant.GeometryShaderPassthroughNV)]
            PassthroughNV = 5250,
            [Capability(Capability.Enumerant.ShaderViewportMaskNV)]
            ViewportRelativeNV = 5252,
            [Capability(Capability.Enumerant.ShaderStereoViewNV)]
            SecondaryViewportRelativeNV = 5256,
            [Capability(Capability.Enumerant.MeshShadingNV)]
            PerPrimitiveNV = 5271,
            [Capability(Capability.Enumerant.MeshShadingNV)]
            PerViewNV = 5272,
            [Capability(Capability.Enumerant.MeshShadingNV)]
            PerTaskNV = 5273,
            [Capability(Capability.Enumerant.FragmentBarycentricNV)]
            PerVertexNV = 5285,
            [Capability(Capability.Enumerant.ShaderNonUniform)]
            NonUniform = 5300,
            [Capability(Capability.Enumerant.ShaderNonUniform)]
            NonUniformEXT = 5300,
            [Capability(Capability.Enumerant.PhysicalStorageBufferAddresses)]
            RestrictPointer = 5355,
            [Capability(Capability.Enumerant.PhysicalStorageBufferAddresses)]
            RestrictPointerEXT = 5355,
            [Capability(Capability.Enumerant.PhysicalStorageBufferAddresses)]
            AliasedPointer = 5356,
            [Capability(Capability.Enumerant.PhysicalStorageBufferAddresses)]
            AliasedPointerEXT = 5356,
            CounterBuffer = 5634,
            HlslCounterBufferGOOGLE = 5634,
            UserSemantic = 5635,
            HlslSemanticGOOGLE = 5635,
            UserTypeGOOGLE = 5636,
        }

        public class RelaxedPrecision: Decoration
        {
            public static readonly RelaxedPrecision Instance = new RelaxedPrecision();
            public override Enumerant Value => Decoration.Enumerant.RelaxedPrecision;
            public new static RelaxedPrecision Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SpecId: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.SpecId;
            public uint SpecializationConstantID { get; set; }
            public new static SpecId Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SpecId();
                res.SpecializationConstantID = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += SpecializationConstantID.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                SpecializationConstantID.Write(writer);
            }
        }
        public class Block: Decoration
        {
            public static readonly Block Instance = new Block();
            public override Enumerant Value => Decoration.Enumerant.Block;
            public new static Block Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class BufferBlock: Decoration
        {
            public static readonly BufferBlock Instance = new BufferBlock();
            public override Enumerant Value => Decoration.Enumerant.BufferBlock;
            public new static BufferBlock Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class RowMajor: Decoration
        {
            public static readonly RowMajor Instance = new RowMajor();
            public override Enumerant Value => Decoration.Enumerant.RowMajor;
            public new static RowMajor Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class ColMajor: Decoration
        {
            public static readonly ColMajor Instance = new ColMajor();
            public override Enumerant Value => Decoration.Enumerant.ColMajor;
            public new static ColMajor Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class ArrayStride: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.ArrayStride;
            public uint ArrayStrideValue { get; set; }
            public new static ArrayStride Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ArrayStride();
                res.ArrayStrideValue = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += ArrayStrideValue.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                ArrayStrideValue.Write(writer);
            }
        }
        public class MatrixStride: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.MatrixStride;
            public uint MatrixStrideValue { get; set; }
            public new static MatrixStride Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new MatrixStride();
                res.MatrixStrideValue = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += MatrixStrideValue.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                MatrixStrideValue.Write(writer);
            }
        }
        public class GLSLShared: Decoration
        {
            public static readonly GLSLShared Instance = new GLSLShared();
            public override Enumerant Value => Decoration.Enumerant.GLSLShared;
            public new static GLSLShared Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class GLSLPacked: Decoration
        {
            public static readonly GLSLPacked Instance = new GLSLPacked();
            public override Enumerant Value => Decoration.Enumerant.GLSLPacked;
            public new static GLSLPacked Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class CPacked: Decoration
        {
            public static readonly CPacked Instance = new CPacked();
            public override Enumerant Value => Decoration.Enumerant.CPacked;
            public new static CPacked Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class BuiltIn: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.BuiltIn;
            public Spv.BuiltIn BuiltInValue { get; set; }
            public new static BuiltIn Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new BuiltIn();
                res.BuiltInValue = Spv.BuiltIn.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += BuiltInValue.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                BuiltInValue.Write(writer);
            }
        }
        public class NoPerspective: Decoration
        {
            public static readonly NoPerspective Instance = new NoPerspective();
            public override Enumerant Value => Decoration.Enumerant.NoPerspective;
            public new static NoPerspective Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Flat: Decoration
        {
            public static readonly Flat Instance = new Flat();
            public override Enumerant Value => Decoration.Enumerant.Flat;
            public new static Flat Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Patch: Decoration
        {
            public static readonly Patch Instance = new Patch();
            public override Enumerant Value => Decoration.Enumerant.Patch;
            public new static Patch Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Centroid: Decoration
        {
            public static readonly Centroid Instance = new Centroid();
            public override Enumerant Value => Decoration.Enumerant.Centroid;
            public new static Centroid Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Sample: Decoration
        {
            public static readonly Sample Instance = new Sample();
            public override Enumerant Value => Decoration.Enumerant.Sample;
            public new static Sample Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Invariant: Decoration
        {
            public static readonly Invariant Instance = new Invariant();
            public override Enumerant Value => Decoration.Enumerant.Invariant;
            public new static Invariant Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Restrict: Decoration
        {
            public static readonly Restrict Instance = new Restrict();
            public override Enumerant Value => Decoration.Enumerant.Restrict;
            public new static Restrict Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Aliased: Decoration
        {
            public static readonly Aliased Instance = new Aliased();
            public override Enumerant Value => Decoration.Enumerant.Aliased;
            public new static Aliased Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Volatile: Decoration
        {
            public static readonly Volatile Instance = new Volatile();
            public override Enumerant Value => Decoration.Enumerant.Volatile;
            public new static Volatile Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Constant: Decoration
        {
            public static readonly Constant Instance = new Constant();
            public override Enumerant Value => Decoration.Enumerant.Constant;
            public new static Constant Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Coherent: Decoration
        {
            public static readonly Coherent Instance = new Coherent();
            public override Enumerant Value => Decoration.Enumerant.Coherent;
            public new static Coherent Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class NonWritable: Decoration
        {
            public static readonly NonWritable Instance = new NonWritable();
            public override Enumerant Value => Decoration.Enumerant.NonWritable;
            public new static NonWritable Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class NonReadable: Decoration
        {
            public static readonly NonReadable Instance = new NonReadable();
            public override Enumerant Value => Decoration.Enumerant.NonReadable;
            public new static NonReadable Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Uniform: Decoration
        {
            public static readonly Uniform Instance = new Uniform();
            public override Enumerant Value => Decoration.Enumerant.Uniform;
            public new static Uniform Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class UniformId: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.UniformId;
            public uint Execution { get; set; }
            public new static UniformId Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new UniformId();
                res.Execution = Spv.IdScope.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += Execution.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                Execution.Write(writer);
            }
        }
        public class SaturatedConversion: Decoration
        {
            public static readonly SaturatedConversion Instance = new SaturatedConversion();
            public override Enumerant Value => Decoration.Enumerant.SaturatedConversion;
            public new static SaturatedConversion Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Stream: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.Stream;
            public uint StreamNumber { get; set; }
            public new static Stream Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Stream();
                res.StreamNumber = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += StreamNumber.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                StreamNumber.Write(writer);
            }
        }
        public class Location: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.Location;
            public uint LocationValue { get; set; }
            public new static Location Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Location();
                res.LocationValue = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += LocationValue.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                LocationValue.Write(writer);
            }
        }
        public class Component: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.Component;
            public uint ComponentValue { get; set; }
            public new static Component Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Component();
                res.ComponentValue = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += ComponentValue.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                ComponentValue.Write(writer);
            }
        }
        public class Index: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.Index;
            public uint IndexValue { get; set; }
            public new static Index Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Index();
                res.IndexValue = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += IndexValue.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                IndexValue.Write(writer);
            }
        }
        public class Binding: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.Binding;
            public uint BindingPoint { get; set; }
            public new static Binding Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Binding();
                res.BindingPoint = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += BindingPoint.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                BindingPoint.Write(writer);
            }
        }
        public class DescriptorSet: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.DescriptorSet;
            public uint DescriptorSetValue { get; set; }
            public new static DescriptorSet Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new DescriptorSet();
                res.DescriptorSetValue = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += DescriptorSetValue.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                DescriptorSetValue.Write(writer);
            }
        }
        public class Offset: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.Offset;
            public uint ByteOffset { get; set; }
            public new static Offset Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Offset();
                res.ByteOffset = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += ByteOffset.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                ByteOffset.Write(writer);
            }
        }
        public class XfbBuffer: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.XfbBuffer;
            public uint XFBBufferNumber { get; set; }
            public new static XfbBuffer Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new XfbBuffer();
                res.XFBBufferNumber = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += XFBBufferNumber.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                XFBBufferNumber.Write(writer);
            }
        }
        public class XfbStride: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.XfbStride;
            public uint XFBStride { get; set; }
            public new static XfbStride Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new XfbStride();
                res.XFBStride = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += XFBStride.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                XFBStride.Write(writer);
            }
        }
        public class FuncParamAttr: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.FuncParamAttr;
            public Spv.FunctionParameterAttribute FunctionParameterAttribute { get; set; }
            public new static FuncParamAttr Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new FuncParamAttr();
                res.FunctionParameterAttribute = Spv.FunctionParameterAttribute.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += FunctionParameterAttribute.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                FunctionParameterAttribute.Write(writer);
            }
        }
        public class FPRoundingMode: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.FPRoundingMode;
            public Spv.FPRoundingMode FloatingPointRoundingMode { get; set; }
            public new static FPRoundingMode Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new FPRoundingMode();
                res.FloatingPointRoundingMode = Spv.FPRoundingMode.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += FloatingPointRoundingMode.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                FloatingPointRoundingMode.Write(writer);
            }
        }
        public class FPFastMathMode: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.FPFastMathMode;
            public Spv.FPFastMathMode FastMathMode { get; set; }
            public new static FPFastMathMode Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new FPFastMathMode();
                res.FastMathMode = Spv.FPFastMathMode.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += FastMathMode.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                FastMathMode.Write(writer);
            }
        }
        public class LinkageAttributes: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.LinkageAttributes;
            public string Name { get; set; }
            public Spv.LinkageType LinkageType { get; set; }
            public new static LinkageAttributes Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new LinkageAttributes();
                res.Name = Spv.LiteralString.Parse(reader, end-reader.Position);
                res.LinkageType = Spv.LinkageType.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += Name.GetWordCount();
                wordCount += LinkageType.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                Name.Write(writer);
                LinkageType.Write(writer);
            }
        }
        public class NoContraction: Decoration
        {
            public static readonly NoContraction Instance = new NoContraction();
            public override Enumerant Value => Decoration.Enumerant.NoContraction;
            public new static NoContraction Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class InputAttachmentIndex: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.InputAttachmentIndex;
            public uint AttachmentIndex { get; set; }
            public new static InputAttachmentIndex Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new InputAttachmentIndex();
                res.AttachmentIndex = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += AttachmentIndex.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                AttachmentIndex.Write(writer);
            }
        }
        public class Alignment: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.Alignment;
            public uint AlignmentValue { get; set; }
            public new static Alignment Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Alignment();
                res.AlignmentValue = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += AlignmentValue.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                AlignmentValue.Write(writer);
            }
        }
        public class MaxByteOffset: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.MaxByteOffset;
            public uint MaxByteOffsetValue { get; set; }
            public new static MaxByteOffset Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new MaxByteOffset();
                res.MaxByteOffsetValue = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += MaxByteOffsetValue.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                MaxByteOffsetValue.Write(writer);
            }
        }
        public class AlignmentId: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.AlignmentId;
            public Spv.IdRef Alignment { get; set; }
            public new static AlignmentId Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new AlignmentId();
                res.Alignment = Spv.IdRef.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += Alignment.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                Alignment.Write(writer);
            }
        }
        public class MaxByteOffsetId: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.MaxByteOffsetId;
            public Spv.IdRef MaxByteOffset { get; set; }
            public new static MaxByteOffsetId Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new MaxByteOffsetId();
                res.MaxByteOffset = Spv.IdRef.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += MaxByteOffset.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                MaxByteOffset.Write(writer);
            }
        }
        public class NoSignedWrap: Decoration
        {
            public static readonly NoSignedWrap Instance = new NoSignedWrap();
            public override Enumerant Value => Decoration.Enumerant.NoSignedWrap;
            public new static NoSignedWrap Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class NoUnsignedWrap: Decoration
        {
            public static readonly NoUnsignedWrap Instance = new NoUnsignedWrap();
            public override Enumerant Value => Decoration.Enumerant.NoUnsignedWrap;
            public new static NoUnsignedWrap Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class ExplicitInterpAMD: Decoration
        {
            public static readonly ExplicitInterpAMD Instance = new ExplicitInterpAMD();
            public override Enumerant Value => Decoration.Enumerant.ExplicitInterpAMD;
            public new static ExplicitInterpAMD Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class OverrideCoverageNV: Decoration
        {
            public static readonly OverrideCoverageNV Instance = new OverrideCoverageNV();
            public override Enumerant Value => Decoration.Enumerant.OverrideCoverageNV;
            public new static OverrideCoverageNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class PassthroughNV: Decoration
        {
            public static readonly PassthroughNV Instance = new PassthroughNV();
            public override Enumerant Value => Decoration.Enumerant.PassthroughNV;
            public new static PassthroughNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class ViewportRelativeNV: Decoration
        {
            public static readonly ViewportRelativeNV Instance = new ViewportRelativeNV();
            public override Enumerant Value => Decoration.Enumerant.ViewportRelativeNV;
            public new static ViewportRelativeNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class SecondaryViewportRelativeNV: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.SecondaryViewportRelativeNV;
            public uint Offset { get; set; }
            public new static SecondaryViewportRelativeNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SecondaryViewportRelativeNV();
                res.Offset = Spv.LiteralInteger.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += Offset.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                Offset.Write(writer);
            }
        }
        public class PerPrimitiveNV: Decoration
        {
            public static readonly PerPrimitiveNV Instance = new PerPrimitiveNV();
            public override Enumerant Value => Decoration.Enumerant.PerPrimitiveNV;
            public new static PerPrimitiveNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class PerViewNV: Decoration
        {
            public static readonly PerViewNV Instance = new PerViewNV();
            public override Enumerant Value => Decoration.Enumerant.PerViewNV;
            public new static PerViewNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class PerTaskNV: Decoration
        {
            public static readonly PerTaskNV Instance = new PerTaskNV();
            public override Enumerant Value => Decoration.Enumerant.PerTaskNV;
            public new static PerTaskNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class PerVertexNV: Decoration
        {
            public static readonly PerVertexNV Instance = new PerVertexNV();
            public override Enumerant Value => Decoration.Enumerant.PerVertexNV;
            public new static PerVertexNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class NonUniform: Decoration
        {
            public static readonly NonUniform Instance = new NonUniform();
            public override Enumerant Value => Decoration.Enumerant.NonUniform;
            public new static NonUniform Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class NonUniformEXT: Decoration
        {
            public static readonly NonUniformEXT Instance = new NonUniformEXT();
            public override Enumerant Value => Decoration.Enumerant.NonUniformEXT;
            public new static NonUniformEXT Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class RestrictPointer: Decoration
        {
            public static readonly RestrictPointer Instance = new RestrictPointer();
            public override Enumerant Value => Decoration.Enumerant.RestrictPointer;
            public new static RestrictPointer Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class RestrictPointerEXT: Decoration
        {
            public static readonly RestrictPointerEXT Instance = new RestrictPointerEXT();
            public override Enumerant Value => Decoration.Enumerant.RestrictPointerEXT;
            public new static RestrictPointerEXT Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class AliasedPointer: Decoration
        {
            public static readonly AliasedPointer Instance = new AliasedPointer();
            public override Enumerant Value => Decoration.Enumerant.AliasedPointer;
            public new static AliasedPointer Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class AliasedPointerEXT: Decoration
        {
            public static readonly AliasedPointerEXT Instance = new AliasedPointerEXT();
            public override Enumerant Value => Decoration.Enumerant.AliasedPointerEXT;
            public new static AliasedPointerEXT Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class CounterBuffer: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.CounterBuffer;
            public Spv.IdRef CounterBufferValue { get; set; }
            public new static CounterBuffer Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new CounterBuffer();
                res.CounterBufferValue = Spv.IdRef.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += CounterBufferValue.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                CounterBufferValue.Write(writer);
            }
        }
        public class HlslCounterBufferGOOGLE: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.HlslCounterBufferGOOGLE;
            public Spv.IdRef CounterBuffer { get; set; }
            public new static HlslCounterBufferGOOGLE Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new HlslCounterBufferGOOGLE();
                res.CounterBuffer = Spv.IdRef.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += CounterBuffer.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                CounterBuffer.Write(writer);
            }
        }
        public class UserSemantic: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.UserSemantic;
            public string Semantic { get; set; }
            public new static UserSemantic Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new UserSemantic();
                res.Semantic = Spv.LiteralString.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += Semantic.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                Semantic.Write(writer);
            }
        }
        public class HlslSemanticGOOGLE: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.HlslSemanticGOOGLE;
            public string Semantic { get; set; }
            public new static HlslSemanticGOOGLE Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new HlslSemanticGOOGLE();
                res.Semantic = Spv.LiteralString.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += Semantic.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                Semantic.Write(writer);
            }
        }
        public class UserTypeGOOGLE: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.UserTypeGOOGLE;
            public string UserType { get; set; }
            public new static UserTypeGOOGLE Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new UserTypeGOOGLE();
                res.UserType = Spv.LiteralString.Parse(reader, end-reader.Position);
                return res;
            }
            public override uint GetWordCount()
            {
                uint wordCount = base.GetWordCount();
                wordCount += UserType.GetWordCount();
                return wordCount;
            }

            public override void Write(WordWriter writer)
            {
                base.Write(writer);
                UserType.Write(writer);
            }
        }

        public abstract Enumerant Value { get; }

        public static Decoration Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                case Enumerant.RelaxedPrecision :
                    return RelaxedPrecision.Parse(reader, wordCount - 1);
                case Enumerant.SpecId :
                    return SpecId.Parse(reader, wordCount - 1);
                case Enumerant.Block :
                    return Block.Parse(reader, wordCount - 1);
                case Enumerant.BufferBlock :
                    return BufferBlock.Parse(reader, wordCount - 1);
                case Enumerant.RowMajor :
                    return RowMajor.Parse(reader, wordCount - 1);
                case Enumerant.ColMajor :
                    return ColMajor.Parse(reader, wordCount - 1);
                case Enumerant.ArrayStride :
                    return ArrayStride.Parse(reader, wordCount - 1);
                case Enumerant.MatrixStride :
                    return MatrixStride.Parse(reader, wordCount - 1);
                case Enumerant.GLSLShared :
                    return GLSLShared.Parse(reader, wordCount - 1);
                case Enumerant.GLSLPacked :
                    return GLSLPacked.Parse(reader, wordCount - 1);
                case Enumerant.CPacked :
                    return CPacked.Parse(reader, wordCount - 1);
                case Enumerant.BuiltIn :
                    return BuiltIn.Parse(reader, wordCount - 1);
                case Enumerant.NoPerspective :
                    return NoPerspective.Parse(reader, wordCount - 1);
                case Enumerant.Flat :
                    return Flat.Parse(reader, wordCount - 1);
                case Enumerant.Patch :
                    return Patch.Parse(reader, wordCount - 1);
                case Enumerant.Centroid :
                    return Centroid.Parse(reader, wordCount - 1);
                case Enumerant.Sample :
                    return Sample.Parse(reader, wordCount - 1);
                case Enumerant.Invariant :
                    return Invariant.Parse(reader, wordCount - 1);
                case Enumerant.Restrict :
                    return Restrict.Parse(reader, wordCount - 1);
                case Enumerant.Aliased :
                    return Aliased.Parse(reader, wordCount - 1);
                case Enumerant.Volatile :
                    return Volatile.Parse(reader, wordCount - 1);
                case Enumerant.Constant :
                    return Constant.Parse(reader, wordCount - 1);
                case Enumerant.Coherent :
                    return Coherent.Parse(reader, wordCount - 1);
                case Enumerant.NonWritable :
                    return NonWritable.Parse(reader, wordCount - 1);
                case Enumerant.NonReadable :
                    return NonReadable.Parse(reader, wordCount - 1);
                case Enumerant.Uniform :
                    return Uniform.Parse(reader, wordCount - 1);
                case Enumerant.UniformId :
                    return UniformId.Parse(reader, wordCount - 1);
                case Enumerant.SaturatedConversion :
                    return SaturatedConversion.Parse(reader, wordCount - 1);
                case Enumerant.Stream :
                    return Stream.Parse(reader, wordCount - 1);
                case Enumerant.Location :
                    return Location.Parse(reader, wordCount - 1);
                case Enumerant.Component :
                    return Component.Parse(reader, wordCount - 1);
                case Enumerant.Index :
                    return Index.Parse(reader, wordCount - 1);
                case Enumerant.Binding :
                    return Binding.Parse(reader, wordCount - 1);
                case Enumerant.DescriptorSet :
                    return DescriptorSet.Parse(reader, wordCount - 1);
                case Enumerant.Offset :
                    return Offset.Parse(reader, wordCount - 1);
                case Enumerant.XfbBuffer :
                    return XfbBuffer.Parse(reader, wordCount - 1);
                case Enumerant.XfbStride :
                    return XfbStride.Parse(reader, wordCount - 1);
                case Enumerant.FuncParamAttr :
                    return FuncParamAttr.Parse(reader, wordCount - 1);
                case Enumerant.FPRoundingMode :
                    return FPRoundingMode.Parse(reader, wordCount - 1);
                case Enumerant.FPFastMathMode :
                    return FPFastMathMode.Parse(reader, wordCount - 1);
                case Enumerant.LinkageAttributes :
                    return LinkageAttributes.Parse(reader, wordCount - 1);
                case Enumerant.NoContraction :
                    return NoContraction.Parse(reader, wordCount - 1);
                case Enumerant.InputAttachmentIndex :
                    return InputAttachmentIndex.Parse(reader, wordCount - 1);
                case Enumerant.Alignment :
                    return Alignment.Parse(reader, wordCount - 1);
                case Enumerant.MaxByteOffset :
                    return MaxByteOffset.Parse(reader, wordCount - 1);
                case Enumerant.AlignmentId :
                    return AlignmentId.Parse(reader, wordCount - 1);
                case Enumerant.MaxByteOffsetId :
                    return MaxByteOffsetId.Parse(reader, wordCount - 1);
                case Enumerant.NoSignedWrap :
                    return NoSignedWrap.Parse(reader, wordCount - 1);
                case Enumerant.NoUnsignedWrap :
                    return NoUnsignedWrap.Parse(reader, wordCount - 1);
                case Enumerant.ExplicitInterpAMD :
                    return ExplicitInterpAMD.Parse(reader, wordCount - 1);
                case Enumerant.OverrideCoverageNV :
                    return OverrideCoverageNV.Parse(reader, wordCount - 1);
                case Enumerant.PassthroughNV :
                    return PassthroughNV.Parse(reader, wordCount - 1);
                case Enumerant.ViewportRelativeNV :
                    return ViewportRelativeNV.Parse(reader, wordCount - 1);
                case Enumerant.SecondaryViewportRelativeNV :
                    return SecondaryViewportRelativeNV.Parse(reader, wordCount - 1);
                case Enumerant.PerPrimitiveNV :
                    return PerPrimitiveNV.Parse(reader, wordCount - 1);
                case Enumerant.PerViewNV :
                    return PerViewNV.Parse(reader, wordCount - 1);
                case Enumerant.PerTaskNV :
                    return PerTaskNV.Parse(reader, wordCount - 1);
                case Enumerant.PerVertexNV :
                    return PerVertexNV.Parse(reader, wordCount - 1);
                case Enumerant.NonUniform :
                    return NonUniform.Parse(reader, wordCount - 1);
                //NonUniformEXT has the same id as another value in enum.
                //case Enumerant.NonUniformEXT :
                //    return NonUniformEXT.Parse(reader, wordCount - 1);
                case Enumerant.RestrictPointer :
                    return RestrictPointer.Parse(reader, wordCount - 1);
                //RestrictPointerEXT has the same id as another value in enum.
                //case Enumerant.RestrictPointerEXT :
                //    return RestrictPointerEXT.Parse(reader, wordCount - 1);
                case Enumerant.AliasedPointer :
                    return AliasedPointer.Parse(reader, wordCount - 1);
                //AliasedPointerEXT has the same id as another value in enum.
                //case Enumerant.AliasedPointerEXT :
                //    return AliasedPointerEXT.Parse(reader, wordCount - 1);
                case Enumerant.CounterBuffer :
                    return CounterBuffer.Parse(reader, wordCount - 1);
                //HlslCounterBufferGOOGLE has the same id as another value in enum.
                //case Enumerant.HlslCounterBufferGOOGLE :
                //    return HlslCounterBufferGOOGLE.Parse(reader, wordCount - 1);
                case Enumerant.UserSemantic :
                    return UserSemantic.Parse(reader, wordCount - 1);
                //HlslSemanticGOOGLE has the same id as another value in enum.
                //case Enumerant.HlslSemanticGOOGLE :
                //    return HlslSemanticGOOGLE.Parse(reader, wordCount - 1);
                case Enumerant.UserTypeGOOGLE :
                    return UserTypeGOOGLE.Parse(reader, wordCount - 1);
                default:
                    throw new IndexOutOfRangeException("Unknown Decoration "+id);
            }
        }
        
        public static Decoration ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<Decoration> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<Decoration>();
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