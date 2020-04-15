using NUnit.Framework;
using Toe.SPIRV.Reflection;
using Veldrid;

namespace Toe.SPIRV.UnitTests
{
    [TestFixture]
    public class SpirvReflectionTests: ShaderTestBase
    {

        [Test]
        public void SimpleShader()
        {
            var vertexShader = CompileToBytecode(@"#version 450
layout(location = 0) out vec4 fsout_color;

void main()
{
    fsout_color = vec4(0,0,0,0);
}", ShaderStages.Vertex);
            var fragmentShader = CompileToBytecode(@"#version 450
void main()
{
    gl_Position = vec4(0,0,0,0);
}", ShaderStages.Vertex);
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
