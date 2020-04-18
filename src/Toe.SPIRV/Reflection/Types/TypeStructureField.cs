using System;
using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Nodes;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Types
{
    public class TypeStructureField : IComparable<TypeStructureField>
    {
        public TypeStructureField()
        {
        }

        public TypeStructureField(SpirvTypeBase type, string name = null)
        {
            Type = type;
            Name = name;
        }

        public BuiltIn BuiltIn { get; set; }

        public SpirvTypeBase Type { get; set; }

        public string Name { get; set; }

        public uint? ByteOffset { get; set; }

        public override string ToString()
        {
            return $"{Type} {Name}";
        }

        public int CompareTo(TypeStructureField other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Nullable.Compare(ByteOffset, other.ByteOffset);
        }

        public void SetUpDecoration(Decoration decoration, SpirvInstructionTreeBuilder treeBuilder)
        {
            switch (decoration.Value)
            {
                case Decoration.Enumerant.BuiltIn:
                    BuiltIn = ((Decoration.BuiltIn)decoration).BuiltInValue;
                    break;
                case Decoration.Enumerant.Offset:
                    ByteOffset = ((Decoration.Offset)decoration).ByteOffset;
                    break;
                case Decoration.Enumerant.RowMajor:
                    RowMajor = true;
                    break;
                case Decoration.Enumerant.ColMajor:
                    ColMajor = true;
                    break;
                case Decoration.Enumerant.MatrixStride:
                    MatrixStride = ((Decoration.MatrixStride)decoration).MatrixStrideValue;
                    break;
                //case Decoration.Enumerant.NoPerspective:
                //    NoPerspective = true;
                //    break;
                //case Decoration.Enumerant.Flat:
                //    Flat = true;
                //    break;
                //case Decoration.Enumerant.Patch:
                //    Patch = true;
                //    break;
                //case Decoration.Enumerant.Centroid:
                //    Centroid = true;
                //    break;
                //case Decoration.Enumerant.Sample:
                //    Sample = true;
                //    break;
                //case Decoration.Enumerant.Volatile:
                //    Volatile = true;
                //    break;
                //case Decoration.Enumerant.Coherent:
                //    Coherent = true;
                //    break;
                //case Decoration.Enumerant.NonWritable:
                //    NonWritable = true;
                //    break;
                //case Decoration.Enumerant.NonReadable:
                //    NonReadable = true;
                //    break;
                //case Decoration.Enumerant.Uniform:
                //    Uniform = true;
                //    break;
                //case Decoration.Enumerant.Stream:
                //    Stream = ((Decoration.Stream)decoration).StreamNumber;
                //    break;
                //case Decoration.Enumerant.Component:
                //    Component = ((Decoration.Component)decoration).ComponentValue;
                //    break;
                //case Decoration.Enumerant.XfbBuffer:
                //    XfbBuffer = ((Decoration.XfbBuffer)decoration).XFBBufferNumber;
                //    break;
                default:
                    throw new NotImplementedException("Member decoration instruction " + decoration.Value + " not yet implemented by " + this.GetType().Name + " class.");
            }
        }

        public uint? MatrixStride { get; set; }

        public bool ColMajor { get; set; }

        public bool RowMajor { get; set; }

        public IEnumerable<Node> BuildDecorations(TypeStruct typeStruct, uint index)
        {
            if (Name != null) yield return new MemberName() {Type = typeStruct, Member = index, Name = Name};
            if (BuiltIn != null) yield return new MemberDecorate() {StructureType = typeStruct, Member = index, Decoration = new Decoration.BuiltIn(){ BuiltInValue = BuiltIn}};
            if (ByteOffset != null) yield return new MemberDecorate() { StructureType = typeStruct, Member = index, Decoration = new Decoration.Offset() { ByteOffset = ByteOffset.Value } };
            if (RowMajor) yield return new MemberDecorate() { StructureType = typeStruct, Member = index, Decoration = Decoration.RowMajor.Instance };
            if (ColMajor) yield return new MemberDecorate() { StructureType = typeStruct, Member = index, Decoration = Decoration.ColMajor.Instance };
            if (MatrixStride != null) yield return new MemberDecorate() { StructureType = typeStruct, Member = index, Decoration = new Decoration.MatrixStride() { MatrixStrideValue = MatrixStride.Value } };
        }
    }
}