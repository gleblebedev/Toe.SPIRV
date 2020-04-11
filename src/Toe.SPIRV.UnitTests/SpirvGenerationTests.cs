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

vec4 GetColor(float x)
{
    //vec4 res;
    //if (x > 0.5)
    //    res = vec4(x,x-1,x,1);
    //else
    //    res = vec4(x,x+1,x,1);
    //return res;
    return (x>0.5)?vec4(x,x-1,x,1):vec4(x,x+1,x,1);
}

void main()
{
    gl_Position = GetColor(0.1);
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
