﻿using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Types
{
    public partial class TypeReserveId : SpirvTypeBase
    {
        public TypeReserveId()
        {
        }

        partial void SetUp(OpTypeReserveId op, SpirvInstructionTreeBuilder treeBuilder)
        {
        }
    }
}