using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using NUnit.Framework;
using Toe.SPIRV.Reflection;
using Veldrid;
using Veldrid.SPIRV;

namespace Toe.SPIRV.UnitTests
{
    [TestFixture]
    public class TestFieldOffsets : VeldridUnitTestBase
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
            var intArrayField = new SpirvStructureField(new SpirvArray(SpirvTypeBase.Int, 2), "intArrayField");
            marker = new SpirvStructureField(SpirvTypeBase.Float, "marker");

            WellKnownTypes = new[]
            {
                floatField, doubleField, intField, uintField, vec2Field, vec3Field, vec4Field, dvec2Field, dvec3Field,
                dvec4Field, mat2Field, mat3Field, mat4Field, intArrayField
            };
        }

        private static readonly SpirvStructureField marker;
        public static SpirvStructureField[] WellKnownTypes { get; }

        public static IEnumerable<SpirvStructure> FieldPermutations
        {
            get
            {
                for (var index0 = 0; index0 < WellKnownTypes.Length; index0++)
                {
                    yield return BuildStructure(index0);
                    for (var index1 = 0; index1 < WellKnownTypes.Length; index1++)
                        if (index0 != index1)
                        {
                            yield return BuildStructure(index0, index1);
                            for (var index2 = 0; index2 < WellKnownTypes.Length; index2++)
                                if (index0 != index2 && index1 != index2)
                                    yield return BuildStructure(index0, index1, index2);
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

        private static SpirvStructure BuildStructure(params int[] indices)
        {
            var fields = indices.Select(index => new SpirvStructureField(WellKnownTypes[index].Type,
                WellKnownTypes[index].Name)).ToArray();
            var structure = new SpirvStructure("testStruct", fields);
            var spirvStructureField = new SpirvStructureField(structure,
                string.Join("_", structure.Fields.Select(_ => _.Name)));
            var endMarker = new SpirvStructureField(SpirvTypeBase.Float, "endMarker");
            var modelStruct = new SpirvStructure("test_" + spirvStructureField.Name, marker,
                spirvStructureField, endMarker);
            return modelStruct;
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
                    CompareStructureLayout((SpirvStructure) expectedField.Type, (SpirvStructure) actualField.Type);
            }
        }

        private (Shader, Veldrid.Shader[]) CompileShaderForFieldSet(SpirvStructure fieldSet)
        {
            var vertexShaderText = new VertexShaderTemplate(fieldSet).TransformText();
            var (vertexBytes, shaderInstructions) = CompileToBytecode(vertexShaderText);
            var fragmentShaderText = new FragmentShaderTemplate().TransformText();
            var fragment = SpirvCompilation.CompileGlslToSpirv(fragmentShaderText, "fragment.glsl",
                ShaderStages.Fragment, new GlslCompileOptions {Debug = true});
            var shaders = ResourceFactory.CreateFromSpirv(
                new ShaderDescription(ShaderStages.Vertex, vertexBytes, "main"),
                new ShaderDescription(ShaderStages.Fragment, fragment.SpirvBytes, "main"));
            foreach (var shader in shaders) Disposables.Add(shader);
            return (shaderInstructions, shaders);
        }

        private static (byte[], Shader) CompileToBytecode(string vertexShaderText)
        {
            var vertex = SpirvCompilation.CompileGlslToSpirv(vertexShaderText, "vertex.glsl", ShaderStages.Vertex,
                new GlslCompileOptions {Debug = true});
            return (vertex.SpirvBytes, Shader.Parse(vertex.SpirvBytes));
        }

        private void PopulateBuffer(byte[] bytes, uint offset, SpirvTypeBase type, ref int counter, ref int hash)
        {
            if (type is SpirvStructure spirvStruct)
            {
                foreach (var field in spirvStruct.Fields)
                    PopulateBuffer(bytes, offset + field.ByteOffset.Value, field.Type, ref counter, ref hash);
                return;
            }

            if (type is SpirvVector spirvVector)
            {
                for (uint i = 0; i < spirvVector.ComponentCount; ++i)
                    PopulateBuffer(bytes, offset + spirvVector.ComponentType.SizeInBytes * i, spirvVector.ComponentType,
                        ref counter, ref hash);
                return;
            }

            if (type is SpirvArrayBase spirvArray)
            {
                for (uint i = 0; i < spirvArray.Length; ++i)
                    PopulateBuffer(bytes, offset + spirvArray.ArrayStride * i, spirvArray.ElementType, ref counter,
                        ref hash);
                return;
            }

            if (type is SpirvMatrixBase spirvMatrix)
            {
                var columnType = spirvMatrix.ColumnType;
                var elementType = columnType.ComponentType;
                var columnStride = elementType.SizeInBytes * 4;
                for (uint i = 0; i < spirvMatrix.ColumnCount; ++i)
                    PopulateBuffer(bytes, offset + columnStride * i, columnType, ref counter, ref hash);
                return;
            }

            switch (type.TypeCategory)
            {
                case SpirvTypeCategory.Void:
                    return;
                case SpirvTypeCategory.Int:
                    var intType = (SpirvInt) type;
                    switch (intType.IntType)
                    {
                        case IntType.Int:
                            ++counter;
                            MemoryMarshal.Cast<byte, int>(bytes.AsSpan((int)offset, (int)type.SizeInBytes))[0] = counter;
                            AppendHash(counter, ref hash);
                            return;
                        case IntType.UInt:
                            ++counter;
                            MemoryMarshal.Cast<byte, uint>(bytes.AsSpan((int)offset, (int)type.SizeInBytes))[0] = (uint)counter;
                            AppendHash(counter, ref hash);
                            return;
                    }
                    break;
                case SpirvTypeCategory.Float:
                    var floatType = (SpirvFloat)type;
                    switch (floatType.FloatType)
                    {
                        case FloatType.Float:
                            ++counter;
                            MemoryMarshal.Cast<byte, float>(bytes.AsSpan((int)offset, (int)type.SizeInBytes))[0] = counter;
                            AppendHash(counter, ref hash);
                            return;
                        case FloatType.Double:
                            ++counter;
                            MemoryMarshal.Cast<byte, double>(bytes.AsSpan((int)offset, (int)type.SizeInBytes))[0] = counter;
                            AppendHash(counter, ref hash);
                            return;
                    }
                    return;
            }
            throw new NotImplementedException();
        }

        private static void AppendHash(int counter, ref int hash)
        {
            hash = (hash * 397) ^ counter;
        }

        [Test]
        [TestCaseSource(nameof(WellKnownTypes))]
        public void TestAlignment(SpirvStructureField field)
        {
            var (shaderInstructions, shaders) =
                CompileShaderForFieldSet(new SpirvStructure("ModelBuffer", marker, field));
            var shaderReflection = new ShaderReflection(shaderInstructions);
            var structure = shaderReflection.Structures[0];
            Assert.AreEqual(structure.Fields[1].ByteOffset, structure.Fields[1].Type.Alignment);
        }

        [Test]
        [TestCaseSource(nameof(WellKnownTypes))]
        public void TestArrayAlignment(SpirvStructureField field)
        {
            var originalArrayType = new SpirvArray(field.Type, 2);
            var (shaderInstructions, shaders) = CompileShaderForFieldSet(new SpirvStructure("ModelBuffer", marker,
                new SpirvStructureField(originalArrayType, "testArray")));
            var shaderReflection = new ShaderReflection(shaderInstructions);
            var structure = shaderReflection.Structures[0];
            var spirvStructureField = structure.Fields[1];
            var arrayType = (SpirvArrayBase) spirvStructureField.Type;
            Assert.AreEqual(spirvStructureField.ByteOffset, spirvStructureField.Type.Alignment);
            Assert.AreEqual(arrayType.ArrayStride, originalArrayType.ArrayStride);
        }

        [Test]
        [Explicit("Only to be ran manually due to high number of permulations")]
        [TestCaseSource(nameof(FieldPermutations))]
        public void TestPermutation(SpirvStructure fieldSet)
        {
            var (shaderInstructions, shaders) = CompileShaderForFieldSet(fieldSet);
            var shaderReflection = new ShaderReflection(shaderInstructions);
            var structure = shaderReflection.Structures.Where(_ => _.Name == fieldSet.Name).First();

            CompareStructureLayout(structure, fieldSet);

            var bufferSize = structure.SizeInBytes;
            bufferSize = SpirvUtils.RoundUp(bufferSize, 16);
            var buffer = ResourceFactory.CreateBuffer(new BufferDescription(bufferSize, BufferUsage.UniformBuffer));
            Disposables.Add(buffer);

            var bytes = new byte[bufferSize];
            var counter = 1;
            var hash = 0;
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

            var pd = new GraphicsPipelineDescription(
                BlendStateDescription.SingleOverrideBlend,
                DepthStencilStateDescription.Disabled,
                RasterizerStateDescription.Default,
                PrimitiveTopology.PointList,
                new ShaderSetDescription(new[] {new VertexLayoutDescription(new VertexElementDescription[] { })},
                    shaders),
                new[] {layout},
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

            var expected = new RgbaByte((byte) (hash % 256), (byte) (hash / 256 % 256), (byte) (hash / 65536 % 256),
                (byte) (hash / 16777216 % 256));
            var actual = ReadRenderTargetPixel();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UnsizedArray()
        {
            var (vertexBytes, shaderInstructions) = CompileToBytecode(@"#version 450
layout(set = 0, binding = 0) uniform ModelBuffer
{
    int unsizedArray[];
};

void main()
{
    gl_Position = vec4(unsizedArray[0],0,0.5,1);
}");
            var shaderReflection = new ShaderReflection(shaderInstructions);
            var structure = shaderReflection.Structures[0];
        }
    }
}