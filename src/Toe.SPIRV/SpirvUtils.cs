﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Toe.SPIRV
{
    internal class SpirvUtils
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static uint RoundUp(uint value, uint alignment)
        {
            var count = (value+alignment-1)/alignment;
            return count * alignment;
        }
    }
}
