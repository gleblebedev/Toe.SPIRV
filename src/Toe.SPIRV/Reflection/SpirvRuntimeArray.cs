using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public partial class SpirvRuntimeArray : SpirvTypeBase
    {
        public SpirvRuntimeArray(): base(SpirvTypeCategory.Array)
        {
        }

        public override Op OpCode => Op.OpTypeRuntimeArray;


        public Node ElementType { get; set; }
        

        public void SetUp(OpTypeRuntimeArray op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ElementType = treeBuilder.GetNode(op.ElementType);
        }
    }
    public partial class SpirvEvent : SpirvTypeBase
    {
        public SpirvEvent():base(SpirvTypeCategory.Event)
        {
        }

        public override Op OpCode => Op.OpTypeEvent;


        public void SetUp(OpTypeEvent op, SpirvInstructionTreeBuilder treeBuilder)
        {
        }
    }
}