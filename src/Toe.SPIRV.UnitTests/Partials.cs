using Toe.SPIRV.Reflection;
using Toe.SPIRV.Reflection.Types;

namespace Toe.SPIRV.UnitTests
{
    partial class VertexShaderTemplate
    {
        protected readonly TypeStruct _fields;

        public VertexShaderTemplate(TypeStruct fields)
        {
            _fields = fields;
        }
    }
}