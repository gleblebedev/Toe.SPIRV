using System.Linq;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public partial class OpTypeArray
    {
        public override uint SizeInWords => ((TypeInstruction) ElementType.Instruction).SizeInWords *
                                            ((OpConstant) ElementType.Instruction).Value.Value.ToUInt32();
    }

    public partial class OpTypeVector
    {
        public override uint SizeInWords => ((TypeInstruction) ComponentType.Instruction).SizeInWords * ComponentCount;
    }

    public partial class OpTypeMatrix
    {
        public override uint SizeInWords => ((TypeInstruction) ColumnType.Instruction).SizeInWords * ColumnCount;
    }

    public partial class OpTypeFloat
    {
        public override uint SizeInWords => (Width + 31) / 32;
    }

    public partial class OpTypeInt
    {
        public override uint SizeInWords => (Width + 31) / 32;
    }

    public partial class OpTypeVoid
    {
        public override uint SizeInWords => 0;
    }


    public partial class OpTypeStruct
    {
        public T FindMemberDecoration<T>(uint member) where T : Decoration
        {
            return MemberDecorations.Where(_=>_.Member == member).Select(_=>_.Decoration).OfType<T>().FirstOrDefault();
        }
        public override uint SizeInWords
        {
            get
            {
                uint size = 0;
                foreach (var member in MemberTypes) size += ((TypeInstruction) member.Instruction).SizeInWords;

                return size;
            }
        }
    }
}