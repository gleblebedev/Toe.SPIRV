using NUnit.Framework;
using Toe.Scripting;
using Toe.SPIRV.Reflection;
using Veldrid;

namespace Toe.SPIRV.UnitTests
{
    [TestFixture]
    public class SpirvScriptingTests : ShaderTestBase
    {
        [Test]
        [TestCaseSource(typeof(TestShaders), nameof(TestShaders.EnumerateShaders))]
        public void SimpleShader(string vertexShaderCode, string fragmentShaderCode)
        {
            var vertexShader = CompileToBytecode(vertexShaderCode, ShaderStages.Vertex, debug: true, throwOnError: true);
            var fragmentShader = CompileToBytecode(fragmentShaderCode, ShaderStages.Fragment, debug: true, throwOnError: true);
            var originalCode = DecompileBytecode(vertexShader, fragmentShader);

            var translatedVertexShader = TranslateShaderViaReflection(vertexShader, fragmentShader);
        }

        private static Script TranslateShaderViaReflection(byte[] vertexShader, byte[] fragmentShader)
        {
            var vertexInstructions = Shader.Parse(vertexShader);
            var vertexReflection = new ShaderReflection(vertexInstructions);
            var fragmentInstructions = Shader.Parse(fragmentShader);
            var fragmentReflection = new ShaderReflection(fragmentInstructions);

            return ShaderScriptConverter.Convert(vertexReflection, fragmentReflection);
        }
    }
}