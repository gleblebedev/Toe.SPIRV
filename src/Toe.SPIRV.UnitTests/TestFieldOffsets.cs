using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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

            public override string ToString()
            {
                return string.Join(", ", _fields.Select(_=>_.ToString()));
            }
        }
        public static IEnumerable<FieldSet> FieldPermutations
        {
            get
            {
                var floatField = new SpirvStructureField(SpirvTypeBase.Float, "floatField");
                var doubleField = new SpirvStructureField(SpirvTypeBase.Double, "doubleField");
                var intField = new SpirvStructureField(SpirvTypeBase.Int, "intField");
                var uintField = new SpirvStructureField(SpirvTypeBase.UInt, "uintField");
                var vec2Field = new SpirvStructureField(SpirvTypeBase.Vec2, "vec2Field");
                var vec3Field = new SpirvStructureField(SpirvTypeBase.Vec3, "vec3Field");
                var vec4Field = new SpirvStructureField(SpirvTypeBase.Vec4, "vec4Field");
                var mat2Field = new SpirvStructureField(SpirvTypeBase.Mat2, "mat2Field");
                var mat3Field = new SpirvStructureField(SpirvTypeBase.Mat3, "mat3Field");
                var mat4Field = new SpirvStructureField(SpirvTypeBase.Mat4, "mat4Field");
                var endMarker = new SpirvStructureField(SpirvTypeBase.Float, "endMarker");

                var allFields = new[] { floatField, doubleField, intField, uintField, vec2Field, vec3Field, vec4Field, mat2Field, mat3Field, mat4Field };
                foreach (var field in allFields)
                {
                    yield return new FieldSet(field, endMarker);
                }
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

            var structure = shaderReflection.Structures[0];
            structure.EvaluateLayout();
            foreach (var field in structure.Fields)
            {
                Console.WriteLine($"{field.Type} {field.Name} at {field.ByteOffset}");
            }

            var bufferSize = structure.SizeInBytes;
            bufferSize = ((bufferSize + 15) / 16) * 16;
            var buffer = ResourceFactory.CreateBuffer(new BufferDescription(bufferSize, BufferUsage.UniformBuffer));
            Disposables.Add(buffer);

            var bytes = new byte[bufferSize];
            int counter = 1;
            int hash = 0;
            foreach (var field in structure.Fields)
            {
                PopulateBuffer(bytes, field, ref counter, ref hash);
            }
            GraphicsDevice.UpdateBuffer(buffer, 0, bytes);

            //structure.EvaluateLayout();

            //var hlsl = SpirvCompilation.CompileVertexFragment(vertex.SpirvBytes, fragment.SpirvBytes, CrossCompileTarget.HLSL, new CrossCompileOptions());
            //var glsl = SpirvCompilation.CompileVertexFragment(vertex.SpirvBytes, fragment.SpirvBytes, CrossCompileTarget.GLSL, new CrossCompileOptions());
            //var msl = SpirvCompilation.CompileVertexFragment(vertex.SpirvBytes, fragment.SpirvBytes, CrossCompileTarget.MSL, new CrossCompileOptions());
            //var essl = SpirvCompilation.CompileVertexFragment(vertex.SpirvBytes, fragment.SpirvBytes, CrossCompileTarget.ESSL, new CrossCompileOptions());

            var shaders = ResourceFactory.CreateFromSpirv(new ShaderDescription(ShaderStages.Vertex, vertex.SpirvBytes, "main"),
                new ShaderDescription(ShaderStages.Fragment, fragment.SpirvBytes, "main"));
            foreach (var shader in shaders)
            {
                Disposables.Add(shader);
            }

            var layout = ResourceFactory.CreateResourceLayout(new ResourceLayoutDescription(
                new ResourceLayoutElementDescription("ModelBuffer", ResourceKind.UniformBuffer, ShaderStages.Vertex)));
            Disposables.Add(layout);

            var resourceSet = ResourceFactory.CreateResourceSet(new ResourceSetDescription(layout, buffer));
            Disposables.Add(resourceSet);

            GraphicsPipelineDescription pd = new GraphicsPipelineDescription(
                BlendStateDescription.SingleOverrideBlend,
                DepthStencilStateDescription.Disabled,
                RasterizerStateDescription.Default,
                PrimitiveTopology.PointList,
                new ShaderSetDescription(new VertexLayoutDescription[]{new VertexLayoutDescription(new VertexElementDescription[]{}), }, shaders), 
                new ResourceLayout[]{ layout }, 
                Framebuffer.OutputDescription);
            var pipeline = ResourceFactory.CreateGraphicsPipeline(pd);
            Disposables.Add(pipeline);

            CommandList.Begin();
            CommandList.SetFramebuffer(Framebuffer);
            CommandList.SetPipeline(pipeline);
            CommandList.SetGraphicsResourceSet(0, resourceSet);
            CommandList.Draw(1);
            CommandList.End();

            GraphicsDevice.SubmitCommands(CommandList);
            GraphicsDevice.WaitForIdle();

            var expected = new RgbaByte((byte) (hash % 256), (byte) ((hash / 256) % 256), (byte) ((hash / 65536) % 256),
                (byte) ((hash / 16777216) % 256));
            Assert.AreEqual(expected, ReadRenderTargetPixel());
        }

        private void PopulateBuffer(byte[] bytes, uint offset, SpirvTypeBase type, ref int counter, ref int hash)
        {
            if (type is SpirvVector spirvVector)
            {
                for (uint i = 0; i < spirvVector.ComponentCount; ++i)
                {
                    PopulateBuffer(bytes, offset+spirvVector.ComponentType.SizeInBytes*i, spirvVector.ComponentType, ref counter, ref hash);
                }
                return;
            }
            if (type is SpirvMatrix spirvMatrix)
            {
                for (uint i = 0; i < spirvMatrix.ColumnCount; ++i)
                {
                    PopulateBuffer(bytes, offset + spirvMatrix.ColumnType.SizeInBytes * i, spirvMatrix.ColumnType, ref counter, ref hash);
                }
                return;
            }
            switch (type.Type)
            {
                case SpirvType.Void:
                    return;
                case SpirvType.Int:
                    ++counter;
                    MemoryMarshal.Cast<byte, int>(bytes.AsSpan((int)offset, (int)type.SizeInBytes))[0] = counter;
                    hash = hash * 397 + counter;
                    return;
                case SpirvType.UInt:
                    ++counter;
                    MemoryMarshal.Cast<byte, uint>(bytes.AsSpan((int)offset, (int)type.SizeInBytes))[0] = (uint)counter;
                    hash = hash * 397 + counter;
                    return;
                case SpirvType.Float:
                    ++counter;
                    MemoryMarshal.Cast<byte, float>(bytes.AsSpan((int)offset, (int)type.SizeInBytes))[0] = counter;
                    hash = hash * 397 + counter;
                    return;
                case SpirvType.Double:
                    ++counter;
                    MemoryMarshal.Cast<byte, double>(bytes.AsSpan((int)offset, (int)type.SizeInBytes))[0] = counter;
                    hash = hash * 397 + counter;
                    return;
            }
        }
        private void PopulateBuffer(byte[] bytes, SpirvStructureField field, ref int counter, ref int hash)
        {
            PopulateBuffer(bytes, field.ByteOffset.Value, field.Type, ref counter, ref hash);
        }
    }
}