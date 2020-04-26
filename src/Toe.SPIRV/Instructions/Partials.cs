using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Toe.SPIRV.Reflection;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public partial class OpSpecConstantOp
    {
    }

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