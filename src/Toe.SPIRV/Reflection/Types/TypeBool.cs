﻿using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Types
{
    public partial class TypeBool : SpirvTypeBase
    {
        internal TypeBool()
        {
        }


        public override string ToString()
        {
            return "bool";
        }
    }
}