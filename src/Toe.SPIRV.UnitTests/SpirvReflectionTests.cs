using NUnit.Framework;
using Toe.SPIRV.Reflection;
using Veldrid;

namespace Toe.SPIRV.UnitTests
{
    [TestFixture]
    public class SpirvReflectionTests: ShaderTestBase
    {

        [Test]
        [TestCaseSource(typeof(TestShaders), nameof(TestShaders.EnumerateTestShaders))]
        public void SimpleShader(string vertexShaderCode, string fragmentShaderCode)
        {
            var vertexShader = CompileToBytecode(vertexShaderCode, ShaderStages.Vertex);
            var fragmentShader = CompileToBytecode(fragmentShaderCode, ShaderStages.Fragment);
            var originalCode = DecompileBytecode(vertexShader, fragmentShader);

            var translatedVertexShader = TranslateShaderViaReflection(vertexShader);
            var translatedFragmentShader = TranslateShaderViaReflection(fragmentShader);
            var translatedCode = DecompileBytecode(translatedVertexShader, translatedFragmentShader);

            Assert.AreEqual(originalCode.FragmentShader, translatedCode.FragmentShader);
            Assert.AreEqual(originalCode.VertexShader, translatedCode.VertexShader);
        }

        private static byte[] TranslateShaderViaReflection(byte[] vertexShader)
        {
            var instructions = Shader.Parse(vertexShader);
            var reflection = new ShaderReflection(instructions);
            var shader = reflection.Build();
            var generatedBytecode = shader.Build();
            return generatedBytecode;
        }
    }
}
