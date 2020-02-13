using System;
using System.Collections.Generic;
using System.Text;

namespace Toe.SPIRV.UnitTests
{
    partial class VertexShaderTemplate
    {
        protected readonly TestFieldOffsets.FieldSet _fields;

        public VertexShaderTemplate(TestFieldOffsets.FieldSet fields)
        {
            _fields = fields;
        }
    }
}
