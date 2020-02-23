using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Internal;
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
                new GlslCompileOptions { Debug = false });
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
            var bytes = instructions.Build();
            Shader.Parse(bytes);

            Assert.AreEqual(shaderBytes.Length, bytes.Length);
            for (var index = 0; index < shaderBytes.Length; index++)
            {
                Assert.AreEqual(shaderBytes[index], bytes[index]);
            }
        }

    }
}
