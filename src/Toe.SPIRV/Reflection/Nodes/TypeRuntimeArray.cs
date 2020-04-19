using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Types
{
    public partial class TypeRuntimeArray : SpirvTypeBase
    {
        public override Op OpCode => Op.OpTypeRuntimeArray;

        public override SpirvTypeCategory TypeCategory => SpirvTypeCategory.RuntimeArray;

        /// <summary>
        /// TypeRuntimeArray is last field in a structure and it's size is defined in runtime. Let's take 1 as a size value for the array.
        /// </summary>
        public override uint SizeInBytes => Alignment * 1;

        public override uint Alignment => SpirvUtils.RoundUp(ElementType.Alignment, 16);

        public SpirvTypeBase ElementType { get; set; }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpTypeRuntimeArray)op, treeBuilder);
        }


        public void SetUp(OpTypeRuntimeArray op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ElementType = treeBuilder.ResolveType(op.ElementType);
            SetUpDecorations(op, treeBuilder);
        }

    }
}