using Toe.SPIRV.Reflection;

namespace Toe.SPIRV.UnitTests
{
    partial class VertexShaderTemplate
    {
        protected readonly SpirvStruct _fields;

        public VertexShaderTemplate(SpirvStruct fields)
        {
            _fields = fields;
        }
    }
}