using NUnit.Framework;

namespace Toe.SPIRV.UnitTests
{
    [TestFixture]
    public class ShaderTests: ShaderTestBase
    {


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
            var generatedBytecode = instructions.Build();

            //Assert.AreEqual(shaderBytes.Length, generatedBytecode.Length);
            for (var index = 16; index < shaderBytes.Length; index++)
            {
                Assert.AreEqual(shaderBytes[index], generatedBytecode[index]);
            }
        }
    }
}