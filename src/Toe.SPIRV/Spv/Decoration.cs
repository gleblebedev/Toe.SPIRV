using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public class Decoration : ValueEnum
    {
        public enum Enumerant
        {
            [Capability(Capability.Enumerant.Shader)]
            RelaxedPrecision = 0,

            [Capability(Capability.Enumerant.Shader)]
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

            [Capability(Capability.Enumerant.Kernel)]
            [Capability(Capability.Enumerant.StorageUniformBufferBlock16)]
            [Capability(Capability.Enumerant.StorageUniform16)]
            [Capability(Capability.Enumerant.StoragePushConstant16)]
            [Capability(Capability.Enumerant.StorageInputOutput16)]
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
            ExplicitInterpAMD = 4999,

            [Capability(Capability.Enumerant.SampleMaskOverrideCoverageNV)]
            OverrideCoverageNV = 5248,

            [Capability(Capability.Enumerant.GeometryShaderPassthroughNV)]
            PassthroughNV = 5250,

            [Capability(Capability.Enumerant.ShaderViewportMaskNV)]
            ViewportRelativeNV = 5252,

            [Capability(Capability.Enumerant.ShaderStereoViewNV)]
            SecondaryViewportRelativeNV = 5256,
            HlslCounterBufferGOOGLE = 5634,
            HlslSemanticGOOGLE = 5635
        }

        public Decoration(Enumerant value)
        {
            Value = value;
        }

        public Enumerant Value { get; }

        public static Decoration Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                case Enumerant.SpecId:
                    return SpecId.Parse(reader, wordCount - 1);
                case Enumerant.ArrayStride:
                    return ArrayStride.Parse(reader, wordCount - 1);
                case Enumerant.MatrixStride:
                    return MatrixStride.Parse(reader, wordCount - 1);
                case Enumerant.BuiltIn:
                    return BuiltIn.Parse(reader, wordCount - 1);
                case Enumerant.Stream:
                    return Stream.Parse(reader, wordCount - 1);
                case Enumerant.Location:
                    return Location.Parse(reader, wordCount - 1);
                case Enumerant.Component:
                    return Component.Parse(reader, wordCount - 1);
                case Enumerant.Index:
                    return Index.Parse(reader, wordCount - 1);
                case Enumerant.Binding:
                    return Binding.Parse(reader, wordCount - 1);
                case Enumerant.DescriptorSet:
                    return DescriptorSet.Parse(reader, wordCount - 1);
                case Enumerant.Offset:
                    return Offset.Parse(reader, wordCount - 1);
                case Enumerant.XfbBuffer:
                    return XfbBuffer.Parse(reader, wordCount - 1);
                case Enumerant.XfbStride:
                    return XfbStride.Parse(reader, wordCount - 1);
                case Enumerant.FuncParamAttr:
                    return FuncParamAttr.Parse(reader, wordCount - 1);
                case Enumerant.FPRoundingMode:
                    return FPRoundingMode.Parse(reader, wordCount - 1);
                case Enumerant.FPFastMathMode:
                    return FPFastMathMode.Parse(reader, wordCount - 1);
                case Enumerant.LinkageAttributes:
                    return LinkageAttributes.Parse(reader, wordCount - 1);
                case Enumerant.InputAttachmentIndex:
                    return InputAttachmentIndex.Parse(reader, wordCount - 1);
                case Enumerant.Alignment:
                    return Alignment.Parse(reader, wordCount - 1);
                case Enumerant.SecondaryViewportRelativeNV:
                    return SecondaryViewportRelativeNV.Parse(reader, wordCount - 1);
                case Enumerant.HlslCounterBufferGOOGLE:
                    return HlslCounterBufferGOOGLE.Parse(reader, wordCount - 1);
                case Enumerant.HlslSemanticGOOGLE:
                    return HlslSemanticGOOGLE.Parse(reader, wordCount - 1);
                default:
                    return new Decoration(id);
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
            while (reader.Position < end) res.Add(Parse(reader, end - reader.Position));
            return res;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public class SpecId : Decoration
        {
            public SpecId() : base(Enumerant.SpecId)
            {
            }

            public uint SpecializationConstantID { get; set; }

            public new static SpecId Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position + wordCount;
                var res = new SpecId();
                res.SpecializationConstantID = LiteralInteger.Parse(reader, end - reader.Position);
                return res;
            }
        }

        public class ArrayStride : Decoration
        {
            public ArrayStride() : base(Enumerant.ArrayStride)
            {
            }

            public uint ArrayStrideValue { get; set; }

            public new static ArrayStride Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position + wordCount;
                var res = new ArrayStride();
                res.ArrayStrideValue = LiteralInteger.Parse(reader, end - reader.Position);
                return res;
            }
        }

        public class MatrixStride : Decoration
        {
            public MatrixStride() : base(Enumerant.MatrixStride)
            {
            }

            public uint MatrixStrideValue { get; set; }

            public new static MatrixStride Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position + wordCount;
                var res = new MatrixStride();
                res.MatrixStrideValue = LiteralInteger.Parse(reader, end - reader.Position);
                return res;
            }
        }

        public class BuiltIn : Decoration
        {
            public BuiltIn() : base(Enumerant.BuiltIn)
            {
            }

            public Spv.BuiltIn BuiltInValue { get; set; }

            public new static BuiltIn Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position + wordCount;
                var res = new BuiltIn();
                res.BuiltInValue = Spv.BuiltIn.Parse(reader, end - reader.Position);
                return res;
            }
        }

        public class Stream : Decoration
        {
            public Stream() : base(Enumerant.Stream)
            {
            }

            public uint StreamNumber { get; set; }

            public new static Stream Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position + wordCount;
                var res = new Stream();
                res.StreamNumber = LiteralInteger.Parse(reader, end - reader.Position);
                return res;
            }
        }

        public class Location : Decoration
        {
            public Location() : base(Enumerant.Location)
            {
            }

            public uint LocationValue { get; set; }

            public new static Location Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position + wordCount;
                var res = new Location();
                res.LocationValue = LiteralInteger.Parse(reader, end - reader.Position);
                return res;
            }

            public override string ToString()
            {
                return $"{Value} {LocationValue}";
            }
        }

        public class Component : Decoration
        {
            public Component() : base(Enumerant.Component)
            {
            }

            public uint ComponentValue { get; set; }

            public new static Component Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position + wordCount;
                var res = new Component();
                res.ComponentValue = LiteralInteger.Parse(reader, end - reader.Position);
                return res;
            }
        }

        public class Index : Decoration
        {
            public Index() : base(Enumerant.Index)
            {
            }

            public uint IndexValue { get; set; }

            public new static Index Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position + wordCount;
                var res = new Index();
                res.IndexValue = LiteralInteger.Parse(reader, end - reader.Position);
                return res;
            }
        }

        public class Binding : Decoration
        {
            public Binding() : base(Enumerant.Binding)
            {
            }

            public uint BindingPoint { get; set; }

            public new static Binding Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position + wordCount;
                var res = new Binding();
                res.BindingPoint = LiteralInteger.Parse(reader, end - reader.Position);
                return res;
            }

            public override string ToString()
            {
                return $"{Value} {BindingPoint}";
            }
        }

        public class DescriptorSet : Decoration
        {
            public DescriptorSet() : base(Enumerant.DescriptorSet)
            {
            }

            public uint DescriptorSetValue { get; set; }

            public new static DescriptorSet Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position + wordCount;
                var res = new DescriptorSet();
                res.DescriptorSetValue = LiteralInteger.Parse(reader, end - reader.Position);
                return res;
            }

            public override string ToString()
            {
                return $"{Value} {DescriptorSetValue}";
            }
        }

        public class Offset : Decoration
        {
            public Offset() : base(Enumerant.Offset)
            {
            }

            public uint ByteOffset { get; set; }

            public new static Offset Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position + wordCount;
                var res = new Offset();
                res.ByteOffset = LiteralInteger.Parse(reader, end - reader.Position);
                return res;
            }

            public override string ToString()
            {
                return $"{Value} {ByteOffset}";
            }
        }

        public class XfbBuffer : Decoration
        {
            public XfbBuffer() : base(Enumerant.XfbBuffer)
            {
            }

            public uint XFBBufferNumber { get; set; }

            public new static XfbBuffer Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position + wordCount;
                var res = new XfbBuffer();
                res.XFBBufferNumber = LiteralInteger.Parse(reader, end - reader.Position);
                return res;
            }
        }

        public class XfbStride : Decoration
        {
            public XfbStride() : base(Enumerant.XfbStride)
            {
            }

            public uint XFBStride { get; set; }

            public new static XfbStride Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position + wordCount;
                var res = new XfbStride();
                res.XFBStride = LiteralInteger.Parse(reader, end - reader.Position);
                return res;
            }
        }

        public class FuncParamAttr : Decoration
        {
            public FuncParamAttr() : base(Enumerant.FuncParamAttr)
            {
            }

            public FunctionParameterAttribute FunctionParameterAttribute { get; set; }

            public new static FuncParamAttr Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position + wordCount;
                var res = new FuncParamAttr();
                res.FunctionParameterAttribute = FunctionParameterAttribute.Parse(reader, end - reader.Position);
                return res;
            }
        }

        public class FPRoundingMode : Decoration
        {
            public FPRoundingMode() : base(Enumerant.FPRoundingMode)
            {
            }

            public Spv.FPRoundingMode FloatingPointRoundingMode { get; set; }

            public new static FPRoundingMode Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position + wordCount;
                var res = new FPRoundingMode();
                res.FloatingPointRoundingMode = Spv.FPRoundingMode.Parse(reader, end - reader.Position);
                return res;
            }
        }

        public class FPFastMathMode : Decoration
        {
            public FPFastMathMode() : base(Enumerant.FPFastMathMode)
            {
            }

            public Spv.FPFastMathMode FastMathMode { get; set; }

            public new static FPFastMathMode Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position + wordCount;
                var res = new FPFastMathMode();
                res.FastMathMode = Spv.FPFastMathMode.Parse(reader, end - reader.Position);
                return res;
            }
        }

        public class LinkageAttributes : Decoration
        {
            public LinkageAttributes() : base(Enumerant.LinkageAttributes)
            {
            }

            public string Name { get; set; }
            public LinkageType LinkageType { get; set; }

            public new static LinkageAttributes Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position + wordCount;
                var res = new LinkageAttributes();
                res.Name = LiteralString.Parse(reader, end - reader.Position);
                res.LinkageType = LinkageType.Parse(reader, end - reader.Position);
                return res;
            }
        }

        public class InputAttachmentIndex : Decoration
        {
            public InputAttachmentIndex() : base(Enumerant.InputAttachmentIndex)
            {
            }

            public uint AttachmentIndex { get; set; }

            public new static InputAttachmentIndex Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position + wordCount;
                var res = new InputAttachmentIndex();
                res.AttachmentIndex = LiteralInteger.Parse(reader, end - reader.Position);
                return res;
            }
        }

        public class Alignment : Decoration
        {
            public Alignment() : base(Enumerant.Alignment)
            {
            }

            public uint AlignmentValue { get; set; }

            public new static Alignment Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position + wordCount;
                var res = new Alignment();
                res.AlignmentValue = LiteralInteger.Parse(reader, end - reader.Position);
                return res;
            }
        }

        public class SecondaryViewportRelativeNV : Decoration
        {
            public SecondaryViewportRelativeNV() : base(Enumerant.SecondaryViewportRelativeNV)
            {
            }

            public uint Offset { get; set; }

            public new static SecondaryViewportRelativeNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position + wordCount;
                var res = new SecondaryViewportRelativeNV();
                res.Offset = LiteralInteger.Parse(reader, end - reader.Position);
                return res;
            }
        }

        public class HlslCounterBufferGOOGLE : Decoration
        {
            public HlslCounterBufferGOOGLE() : base(Enumerant.HlslCounterBufferGOOGLE)
            {
            }

            public IdRef CounterBuffer { get; set; }

            public new static HlslCounterBufferGOOGLE Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position + wordCount;
                var res = new HlslCounterBufferGOOGLE();
                res.CounterBuffer = IdRef.Parse(reader, end - reader.Position);
                return res;
            }
        }

        public class HlslSemanticGOOGLE : Decoration
        {
            public HlslSemanticGOOGLE() : base(Enumerant.HlslSemanticGOOGLE)
            {
            }

            public string Semantic { get; set; }

            public new static HlslSemanticGOOGLE Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position + wordCount;
                var res = new HlslSemanticGOOGLE();
                res.Semantic = LiteralString.Parse(reader, end - reader.Position);
                return res;
            }
        }
    }
}