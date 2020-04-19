using NUnit.Framework;
using Toe.SPIRV.Reflection;
using Veldrid;

namespace Toe.SPIRV.UnitTests
{
    [TestFixture]
    public class SpirvReflectionTests: ShaderTestBase
    {

        [Test]
        [TestCaseSource(typeof(SampleShaders), nameof(SampleShaders.EnumerateShaders))]
        public void SampleShader(string resourceName)
        {
            (var shaderSource, var stage) = SampleShaders.LoadShader(resourceName, typeof(SampleShaders).Assembly);
            var shaderBytes = CompileToBytecode(shaderSource, stage);
            var generatedBytecode = TranslateShaderViaReflection(shaderBytes);

            //Assert.AreEqual(shaderBytes.Length, generatedBytecode.Length);
            //for (var index = 16; index < shaderBytes.Length; index++)
            //{
            //    Assert.AreEqual(shaderBytes[index], generatedBytecode[index]);
            //}
        }

        [Test]
        [TestCaseSource(typeof(TestShaders), nameof(TestShaders.EnumerateShaders))]
        public void SimpleShader(string vertexShaderCode, string fragmentShaderCode)
        {
            var vertexShader = CompileToBytecode(vertexShaderCode, ShaderStages.Vertex, debug:true, throwOnError:true);
            var fragmentShader = CompileToBytecode(fragmentShaderCode, ShaderStages.Fragment, debug: true, throwOnError: true);
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
