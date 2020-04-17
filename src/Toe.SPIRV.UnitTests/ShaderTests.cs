using NUnit.Framework;
using Veldrid;

namespace Toe.SPIRV.UnitTests
{
    [TestFixture]
    public class ShaderTests: ShaderTestBase
    {


        [Test]
        [TestCaseSource(typeof(TestShaders), nameof(TestShaders.EnumerateTestShaders))]
        public void SimpleShader(string vertexShaderCode, string fragmentShaderCode)
        {
            {
                var shaderBytes = CompileToBytecode(vertexShaderCode, ShaderStages.Vertex);
                var instructions = Shader.Parse(shaderBytes);
                var generatedBytecode = instructions.Build();

                //Assert.AreEqual(shaderBytes.Length, generatedBytecode.Length);
                for (var index = 16; index < shaderBytes.Length; index++)
                {
                    Assert.AreEqual(shaderBytes[index], generatedBytecode[index]);
                }
            }
            {
                var shaderBytes = CompileToBytecode(fragmentShaderCode, ShaderStages.Fragment);
                var instructions = Shader.Parse(shaderBytes);
                var generatedBytecode = instructions.Build();

                //Assert.AreEqual(shaderBytes.Length, generatedBytecode.Length);
                for (var index = 16; index < shaderBytes.Length; index++)
                {
                    Assert.AreEqual(shaderBytes[index], generatedBytecode[index]);
                }
            }
        }
    }
}