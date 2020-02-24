using NUnit.Framework;
using Toe.SPIRV.Reflection;
using Veldrid;
using Veldrid.SPIRV;

namespace Toe.SPIRV.UnitTests
{
    [TestFixture]
    public class SpirvGenerationTests
    {
        private static byte[] CompileToBytecode(string vertexShaderText)
        {
            var vertex = SpirvCompilation.CompileGlslToSpirv(vertexShaderText, "vertex.glsl", ShaderStages.Vertex,
                new GlslCompileOptions { Debug = true });
            return vertex.SpirvBytes;
        }


        [Test]
        public void SimpleShader()
        {
            var shaderBytes = CompileToBytecode(@"#version 450
void main()
{
    gl_Position = vec4(0,1,2,3);
}");
            var instructions = Shader.Parse(shaderBytes);
            var reflection = new ShaderReflection(instructions);

            //var txt = new ReflectionGenerator(instructions).GenerateText();

            var generatedInstructions = reflection.Build();
            var generatedBytecode = generatedInstructions.Build();

            //Assert.AreEqual(shaderBytes.Length, generatedBytecode.Length);
            for (var index = 16; index < shaderBytes.Length; index++)
            {
                Assert.AreEqual(shaderBytes[index], generatedBytecode[index]);
            }
        }
    }
}
