﻿using System;
using System.Collections.Generic;
using System.Text;
using Toe.SPIRV.Reflection;

namespace Toe.SPIRV.UnitTests
{
    partial class VertexShaderTemplate
    {
        protected readonly SpirvStructure _fields;

        public VertexShaderTemplate(SpirvStructure fields)
        {
            _fields = fields;
        }
    }
}
