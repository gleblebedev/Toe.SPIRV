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
        static TestFieldOffsets()
        {
            var floatField = new SpirvStructureField(SpirvTypeBase.Float, "floatField");
            var doubleField = new SpirvStructureField(SpirvTypeBase.Double, "doubleField");
            var intField = new SpirvStructureField(SpirvTypeBase.Int, "intField");
            var uintField = new SpirvStructureField(SpirvTypeBase.UInt, "uintField");
            var vec2Field = new SpirvStructureField(SpirvTypeBase.Vec2, "vec2Field");
            var vec3Field = new SpirvStructureField(SpirvTypeBase.Vec3, "vec3Field");
            var vec4Field = new SpirvStructureField(SpirvTypeBase.Vec4, "vec4Field");
            var dvec2Field = new SpirvStructureField(SpirvTypeBase.Dvec2, "dvec2Field");
            var dvec3Field = new SpirvStructureField(SpirvTypeBase.Dvec3, "dvec3Field");
            var dvec4Field = new SpirvStructureField(SpirvTypeBase.Dvec4, "dvec4Field");
            var mat2Field = new SpirvStructureField(SpirvTypeBase.Mat2, "mat2Field");
            var mat3Field = new SpirvStructureField(SpirvTypeBase.Mat3, "mat3Field");
            var mat4Field = new SpirvStructureField(SpirvTypeBase.Mat4, "mat4Field");
            marker = new SpirvStructureField(SpirvTypeBase.Float, "marker");
            
            WellKnownTypes = new[] { floatField, doubleField, intField, uintField, vec2Field, vec3Field, vec4Field, dvec2Field, dvec3Field, dvec4Field, mat2Field, mat3Field, mat4Field };
        }

        private static SpirvStructureField marker;
        public static SpirvStructureField[] WellKnownTypes { get; }

        public static IEnumerable<SpirvStructure> FieldPermutations
        {
            get
            {
                for (var index0 = 0; index0 < WellKnownTypes.Length; index0++)
                {
                    for (var index1 = 0; index1 < WellKnownTypes.Length; index1++)
                    {
                        for (var index2 = 0; index2 < WellKnownTypes.Length; index2++)
                        {
                            if (index0 != index1 && index0 != index2 && index1 != index2)
                            {
                                var structure = new SpirvStructure("testStruct",
                                    new SpirvStructureField(WellKnownTypes[index0].Type, WellKnownTypes[index0].Name),
                                    new SpirvStructureField(WellKnownTypes[index1].Type, WellKnownTypes[index1].Name),
                                    new SpirvStructureField(WellKnownTypes[index2].Type, WellKnownTypes[index2].Name));
                                var spirvStructureField = new SpirvStructureField(structure, string.Join("_", structure.Fields.Select(_ => _.Name)));
                                var endMarker = new SpirvStructureField(SpirvTypeBase.Float, "endMarker");
                                var modelStruct = new SpirvStructure("test_" + spirvStructureField.Name, marker, spirvStructureField, endMarker);
                                yield return modelStruct;
                            }
                        }
                    }
                }
                //var structure = new SpirvStructure("testStruct",
                //    new SpirvStructureField(WellKnownTypes[0].Type, WellKnownTypes[0].Name),
                //    new SpirvStructureField(WellKnownTypes[1].Type, WellKnownTypes[1].Name),
                //    new SpirvStructureField(WellKnownTypes[7].Type, WellKnownTypes[7].Name));
                //var spirvStructureField = new SpirvStructureField(structure, string.Join("_", structure.Fields.Select(_ => _.Name)));
                //var endMarker = new SpirvStructureField(SpirvTypeBase.Float, "endMarker");

                //var modelStruct = new SpirvStructure("test_" + spirvStructureField.Name, marker, spirvStructureField, endMarker);
                //yield return modelStruct;
            }
        }

        [Test]
        [TestCaseSource(nameof(WellKnownTypes))]
        public void TestAlignment(SpirvStructureField field)
        {
            (var shaderInstructions, var shaders) = CompileShaderForFieldSet(new SpirvStructure("ModelBuffer", marker, field));
            var shaderReflection = new ShaderReflection(shaderInstructions);
            var structure = shaderReflection.Structures[0];
            Assert.AreEqual(structure.Fields[1].ByteOffset, structure.Fields[1].Type.Alignment);
        }

        [Test]
        [TestCaseSource(nameof(WellKnownTypes))]
        public void TestArrayAlignment(SpirvStructureField field)
        {
            var originalArrayType = new SpirvArray(field.Type,2);
            (var shaderInstructions, var shaders) = CompileShaderForFieldSet(new SpirvStructure("ModelBuffer", marker, new SpirvStructureField(originalArrayType, "testArray")));
            var shaderReflection = new ShaderReflection(shaderInstructions);
            var structure = shaderReflection.Structures[0];
            var spirvStructureField = structure.Fields[1];
            var arrayType = (SpirvArrayBase) spirvStructureField.Type;
            Assert.AreEqual(spirvStructureField.ByteOffset, spirvStructureField.Type.Alignment);
            Assert.AreEqual(arrayType.ArrayStride, originalArrayType.ArrayStride);
        }

        [Test]
        [TestCaseSource(nameof(FieldPermutations))]
        public void TestPermutation(SpirvStructure fieldSet)
        {
            (var shaderInstructions, var shaders) = CompileShaderForFieldSet(fieldSet);
            var shaderReflection = new ShaderReflection(shaderInstructions);
            var structure = shaderReflection.Structures.Where(_=>_.Name == fieldSet.Name).First();

            CompareStructureLayout(structure, fieldSet);

            var bufferSize = structure.SizeInBytes;
            bufferSize = ((bufferSize + 15) / 16) * 16;
            var buffer = ResourceFactory.CreateBuffer(new BufferDescription(bufferSize, BufferUsage.UniformBuffer));
            Disposables.Add(buffer);

            var bytes = new byte[bufferSize];
            int counter = 1;
            int hash = 0;
            PopulateBuffer(bytes, 0, structure, ref counter, ref hash);
            GraphicsDevice.UpdateBuffer(buffer, 0, bytes);

            //structure.EvaluateLayout();

            //var hlsl = SpirvCompilation.CompileVertexFragment(vertex.SpirvBytes, fragment.SpirvBytes, CrossCompileTarget.HLSL, new CrossCompileOptions());
            //var glsl = SpirvCompilation.CompileVertexFragment(vertex.SpirvBytes, fragment.SpirvBytes, CrossCompileTarget.GLSL, new CrossCompileOptions());
            //var msl = SpirvCompilation.CompileVertexFragment(vertex.SpirvBytes, fragment.SpirvBytes, CrossCompileTarget.MSL, new CrossCompileOptions());
            //var essl = SpirvCompilation.CompileVertexFragment(vertex.SpirvBytes, fragment.SpirvBytes, CrossCompileTarget.ESSL, new CrossCompileOptions());

  

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
            var actual = ReadRenderTargetPixel();
            Assert.AreEqual(expected, actual);
        }

        private void CompareStructureLayout(SpirvStructure expected, SpirvStructure actual)
        {
            Assert.AreEqual(expected.Fields.Count, actual.Fields.Count);
            for (var index = 0; index < expected.Fields.Count; index++)
            {
                var actualField = actual.Fields[index];
                var expectedField = expected.Fields[index];
                Assert.AreEqual(expectedField.ByteOffset, actualField.ByteOffset);
                if (expectedField.Type.TypeCategory == SpirvTypeCategory.Struct)
                {
                    CompareStructureLayout((SpirvStructure)expectedField.Type, (SpirvStructure)actualField.Type);
                }
            }
        }

        private (Shader, Veldrid.Shader[]) CompileShaderForFieldSet(SpirvStructure fieldSet)
        {
            var vertexShaderText = new VertexShaderTemplate(fieldSet).TransformText();
            var vertex = Veldrid.SPIRV.SpirvCompilation.CompileGlslToSpirv(vertexShaderText, "vertex.glsl", ShaderStages.Vertex,
                new GlslCompileOptions() {Debug = true});
            var fragmentShaderText = new FragmentShaderTemplate().TransformText();
            var fragment = Veldrid.SPIRV.SpirvCompilation.CompileGlslToSpirv(fragmentShaderText, "fragment.glsl",
                ShaderStages.Fragment, new GlslCompileOptions() {Debug = true});
            var shaderInstructions = Toe.SPIRV.Shader.Parse(vertex.SpirvBytes);
            var shaders = ResourceFactory.CreateFromSpirv(new ShaderDescription(ShaderStages.Vertex, vertex.SpirvBytes, "main"),
                new ShaderDescription(ShaderStages.Fragment, fragment.SpirvBytes, "main"));
            foreach (var shader in shaders)
            {
                Disposables.Add(shader);
            }
            return (shaderInstructions, shaders);
        }

        private void PopulateBuffer(byte[] bytes, uint offset, SpirvTypeBase type, ref int counter, ref int hash)
        {
            if (type is SpirvStructure spirvStruct)
            {
                foreach (var field in spirvStruct.Fields)
                {
                    PopulateBuffer(bytes, offset + field.ByteOffset.Value, field.Type, ref counter, ref hash);
                }
                return;
            }
            if (type is SpirvVector spirvVector)
            {
                for (uint i = 0; i < spirvVector.ComponentCount; ++i)
                {
                    PopulateBuffer(bytes, offset+spirvVector.ComponentType.SizeInBytes*i, spirvVector.ComponentType, ref counter, ref hash);
                }
                return;
            }
            if (type is SpirvMatrixBase spirvMatrix)
            {
                var columnType = spirvMatrix.ColumnType;
                var elementType = columnType.ComponentType;
                var columnStride = elementType.SizeInBytes * 4;
                for (uint i = 0; i < spirvMatrix.ColumnCount; ++i)
                {
                    PopulateBuffer(bytes, offset + columnStride * i, columnType, ref counter, ref hash);
                }
                return;
            }
            switch (type.TypeCategory)
            {
                case SpirvTypeCategory.Void:
                    return;
                case SpirvTypeCategory.Int:
                    ++counter;
                    MemoryMarshal.Cast<byte, int>(bytes.AsSpan((int)offset, (int)type.SizeInBytes))[0] = counter;
                    AppendHash(counter, ref hash);
                    return;
                case SpirvTypeCategory.UInt:
                    ++counter;
                    MemoryMarshal.Cast<byte, uint>(bytes.AsSpan((int)offset, (int)type.SizeInBytes))[0] = (uint)counter;
                    AppendHash(counter, ref hash);
                    return;
                case SpirvTypeCategory.Float:
                    ++counter;
                    MemoryMarshal.Cast<byte, float>(bytes.AsSpan((int)offset, (int)type.SizeInBytes))[0] = counter;
                    AppendHash(counter, ref hash);
                    return;
                case SpirvTypeCategory.Double:
                    ++counter;
                    MemoryMarshal.Cast<byte, double>(bytes.AsSpan((int)offset, (int)type.SizeInBytes))[0] = counter;
                    AppendHash(counter, ref hash);
                    return;
                default:
                    throw new NotImplementedException();
            }
        }

        private static void AppendHash(int counter, ref int hash)
        {
            hash = (hash * 397) ^ counter;
        }
    }
}