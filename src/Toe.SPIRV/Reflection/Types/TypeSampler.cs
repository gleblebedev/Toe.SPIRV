﻿using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Types
{
    public partial class TypeSampler : SpirvTypeBase
    {
        public TypeSampler()
        {
            
        }

        partial void SetUp(OpTypeSampler op, SpirvInstructionTreeBuilder treeBuilder)
        {
        }
    }
}