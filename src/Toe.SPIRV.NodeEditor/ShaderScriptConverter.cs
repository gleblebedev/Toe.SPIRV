using Toe.Scripting;
using Toe.SPIRV.Reflection;

namespace Toe.SPIRV.NodeEditor
{
    public class ShaderScriptConverter
    {
        public static Script Convert(ShaderReflection reflection)
        {
            return new ShaderToScriptConverter().Convert(reflection);
        }
    }
}
