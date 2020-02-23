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
            HlslSemanticGOOGLE = 5635,
        }

        public class RelaxedPrecision: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.RelaxedPrecision;
            public new static RelaxedPrecision Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new RelaxedPrecision();
                return res;
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
            public override Enumerant Value => Decoration.Enumerant.Block;
            public new static Block Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Block();
                return res;
            }
        }
        public class BufferBlock: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.BufferBlock;
            public new static BufferBlock Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new BufferBlock();
                return res;
            }
        }
        public class RowMajor: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.RowMajor;
            public new static RowMajor Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new RowMajor();
                return res;
            }
        }
        public class ColMajor: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.ColMajor;
            public new static ColMajor Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ColMajor();
                return res;
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
            public override Enumerant Value => Decoration.Enumerant.GLSLShared;
            public new static GLSLShared Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new GLSLShared();
                return res;
            }
        }
        public class GLSLPacked: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.GLSLPacked;
            public new static GLSLPacked Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new GLSLPacked();
                return res;
            }
        }
        public class CPacked: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.CPacked;
            public new static CPacked Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new CPacked();
                return res;
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
            public override Enumerant Value => Decoration.Enumerant.NoPerspective;
            public new static NoPerspective Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new NoPerspective();
                return res;
            }
        }
        public class Flat: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.Flat;
            public new static Flat Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Flat();
                return res;
            }
        }
        public class Patch: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.Patch;
            public new static Patch Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Patch();
                return res;
            }
        }
        public class Centroid: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.Centroid;
            public new static Centroid Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Centroid();
                return res;
            }
        }
        public class Sample: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.Sample;
            public new static Sample Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Sample();
                return res;
            }
        }
        public class Invariant: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.Invariant;
            public new static Invariant Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Invariant();
                return res;
            }
        }
        public class Restrict: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.Restrict;
            public new static Restrict Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Restrict();
                return res;
            }
        }
        public class Aliased: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.Aliased;
            public new static Aliased Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Aliased();
                return res;
            }
        }
        public class Volatile: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.Volatile;
            public new static Volatile Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Volatile();
                return res;
            }
        }
        public class Constant: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.Constant;
            public new static Constant Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Constant();
                return res;
            }
        }
        public class Coherent: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.Coherent;
            public new static Coherent Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Coherent();
                return res;
            }
        }
        public class NonWritable: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.NonWritable;
            public new static NonWritable Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new NonWritable();
                return res;
            }
        }
        public class NonReadable: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.NonReadable;
            public new static NonReadable Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new NonReadable();
                return res;
            }
        }
        public class Uniform: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.Uniform;
            public new static Uniform Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Uniform();
                return res;
            }
        }
        public class SaturatedConversion: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.SaturatedConversion;
            public new static SaturatedConversion Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new SaturatedConversion();
                return res;
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
            public override Enumerant Value => Decoration.Enumerant.NoContraction;
            public new static NoContraction Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new NoContraction();
                return res;
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
        public class ExplicitInterpAMD: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.ExplicitInterpAMD;
            public new static ExplicitInterpAMD Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ExplicitInterpAMD();
                return res;
            }
        }
        public class OverrideCoverageNV: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.OverrideCoverageNV;
            public new static OverrideCoverageNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new OverrideCoverageNV();
                return res;
            }
        }
        public class PassthroughNV: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.PassthroughNV;
            public new static PassthroughNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new PassthroughNV();
                return res;
            }
        }
        public class ViewportRelativeNV: Decoration
        {
            public override Enumerant Value => Decoration.Enumerant.ViewportRelativeNV;
            public new static ViewportRelativeNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ViewportRelativeNV();
                return res;
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
                case Enumerant.HlslCounterBufferGOOGLE :
                    return HlslCounterBufferGOOGLE.Parse(reader, wordCount - 1);
                case Enumerant.HlslSemanticGOOGLE :
                    return HlslSemanticGOOGLE.Parse(reader, wordCount - 1);
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