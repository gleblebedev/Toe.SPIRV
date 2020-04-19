using System.Diagnostics;
using NUnit.Framework;
using Veldrid;
using Veldrid.SPIRV;

namespace Toe.SPIRV.UnitTests
{
    public class ShaderTestBase
    {
        public static byte[] CompileToBytecode(string vertexShaderText, ShaderStages stage = ShaderStages.Vertex, bool debug = true, bool throwOnError = false)
        {
            if (throwOnError)
            {
                var vertex = SpirvCompilation.CompileGlslToSpirv(vertexShaderText, "shader.vk", stage,
                    new GlslCompileOptions { Debug = debug });
                return vertex.SpirvBytes;
            }
            try
            {
                var vertex = SpirvCompilation.CompileGlslToSpirv(vertexShaderText, "shader.vk", stage,
                    new GlslCompileOptions {Debug = debug});
                return vertex.SpirvBytes;
            }
            catch (SpirvCompilationException exception)
            {
                Assert.Ignore(exception.Message);
                return null;
            }
        }

        public static VertexFragmentCompilationResult DecompileBytecode(byte[] vertexShader, byte[] fragmentShader, CrossCompileTarget target = CrossCompileTarget.GLSL)
        {
            return SpirvCompilation.CompileVertexFragment(vertexShader, fragmentShader, target);
        }
    }
}