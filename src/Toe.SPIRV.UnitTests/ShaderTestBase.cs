using Veldrid;
using Veldrid.SPIRV;

namespace Toe.SPIRV.UnitTests
{
    public class ShaderTestBase
    {
        public static byte[] CompileToBytecode(string vertexShaderText, ShaderStages stage = ShaderStages.Vertex, bool debug = true)
        {
            var vertex = SpirvCompilation.CompileGlslToSpirv(vertexShaderText, "shader.vk", stage, new GlslCompileOptions { Debug = debug });
            return vertex.SpirvBytes;
        }

        public static VertexFragmentCompilationResult DecompileBytecode(byte[] vertexShader, byte[] fragmentShader, CrossCompileTarget target = CrossCompileTarget.GLSL)
        {
            return SpirvCompilation.CompileVertexFragment(vertexShader, fragmentShader, target);
        }
    }
}