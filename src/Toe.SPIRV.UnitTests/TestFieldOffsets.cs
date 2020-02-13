using System.Collections.Generic;
using NUnit.Framework;
using Toe.SPIRV.Reflection;
using Veldrid;
using Veldrid.SPIRV;
using ShaderDescription = Veldrid.ShaderDescription;

namespace Toe.SPIRV.UnitTests
{
    [TestFixture]
    public class TestFieldOffsets: VeldridUnitTestBase
    {
        public class FieldSet
        {
            private readonly SpirvStructureField[] _fields;

            public IReadOnlyList<SpirvStructureField> Fields => _fields;

            public FieldSet(params SpirvStructureField[] fields)
            {
                _fields = fields;
            }
        }
        public static IEnumerable<FieldSet> FieldPermutations
        {
            get
            {
                var floatField = new SpirvStructureField(SpirvType.Float, "floatField");
                yield return new FieldSet(floatField);
            }
        }

        [Test]
        [TestCaseSource(nameof(FieldPermutations))]
        public void TestPermutation(FieldSet arg)
        {
            var vertexShaderText = new VertexShaderTemplate(arg).TransformText();
            var vertex = Veldrid.SPIRV.SpirvCompilation.CompileGlslToSpirv(vertexShaderText, "vertex.glsl", ShaderStages.Vertex, new GlslCompileOptions() { Debug = true });
            var fragmentShaderText = new FragmentShaderTemplate().TransformText();
            var fragment = Veldrid.SPIRV.SpirvCompilation.CompileGlslToSpirv(fragmentShaderText, "fragment.glsl", ShaderStages.Fragment, new GlslCompileOptions() { Debug = true });

            var shaderInstructions = Toe.SPIRV.Shader.Parse(vertex.SpirvBytes);
            var shaderReflection = new ShaderReflection(shaderInstructions);
            
            var shaders = ResourceFactory.CreateFromSpirv(new ShaderDescription(ShaderStages.Vertex, vertex.SpirvBytes, "main"),
                new ShaderDescription(ShaderStages.Fragment, fragment.SpirvBytes, "main"));

            GraphicsPipelineDescription pd = new GraphicsPipelineDescription(
                BlendStateDescription.SingleOverrideBlend,
                DepthStencilStateDescription.Disabled,
                RasterizerStateDescription.Default,
                PrimitiveTopology.PointList,
                new ShaderSetDescription(new VertexLayoutDescription[]{new VertexLayoutDescription(new VertexElementDescription[]{}), }, shaders), 
                new ResourceLayout[]{}, 
                Framebuffer.OutputDescription);
            var pipeline = ResourceFactory.CreateGraphicsPipeline(pd);

            CommandList.Begin();
            CommandList.SetFramebuffer(Framebuffer);
            CommandList.SetPipeline(pipeline);
            CommandList.Draw(1);
            CommandList.End();

            GraphicsDevice.SubmitCommands(CommandList);
            GraphicsDevice.WaitForIdle();

            ReadRenderTargetPixel(color =>
            {
                Assert.AreEqual(new RgbaByte(255,127,255,255), color);
            });
        }

    }
}