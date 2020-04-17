using System;
using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public class SpirvStructureField : IComparable<SpirvStructureField>
    {
        public SpirvStructureField(SpirvTypeBase type, string name, IEnumerable<OpMemberDecorate> decorations = null)
        {
            Type = type;
            Name = name;
            if (decorations != null)
            {
                foreach (var memberDecorate in decorations)
                {
                    switch (memberDecorate.Decoration.Value)
                    {
                        case Decoration.Enumerant.Offset:
                            ByteOffset = ((Decoration.Offset) memberDecorate.Decoration).ByteOffset;
                            break;
                        case Decoration.Enumerant.BuiltIn:
                            BuiltIn = ((Decoration.BuiltIn)memberDecorate.Decoration).BuiltInValue;
                            break;
                        case Decoration.Enumerant.ColMajor:
                        case Decoration.Enumerant.RowMajor:
                        case Decoration.Enumerant.ArrayStride:
                        case Decoration.Enumerant.MatrixStride:
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                }
            }
        }

        public BuiltIn BuiltIn { get; set; }

        public SpirvTypeBase Type { get; }

        public string Name { get; }

        public uint? ByteOffset { get; internal set; }

        public override string ToString()
        {
            return $"{Type} {Name}";
        }

        public int CompareTo(SpirvStructureField other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Nullable.Compare(ByteOffset, other.ByteOffset);
        }
    }
}