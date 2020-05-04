using Toe.Scripting;
using Toe.SPIRV.Reflection;

namespace Toe.SPIRV
{
    public class ShaderScriptConverter
    {
        public static Script Convert(ShaderReflection vertexShader, ShaderReflection fragmentShader)
        {
            return new ShaderToScriptConverter().Convert(vertexShader, fragmentShader);
        }
    }
}