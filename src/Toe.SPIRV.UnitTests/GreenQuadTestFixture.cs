using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Toe.SPIRV.Reflection;
using Toe.SPIRV.Reflection.Nodes;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;
using Veldrid;
using Veldrid.SPIRV;
using Capability = Toe.SPIRV.Spv.Capability;
using ExecutionMode = Toe.SPIRV.Spv.ExecutionMode;
using MemoryModel = Toe.SPIRV.Spv.MemoryModel;

namespace Toe.SPIRV.UnitTests
{
    [TestFixture]
    public class GreenQuadTestFixture : VeldridUnitTestBase
    {
        [Test]
        public void EmptyShaderReflectionTest()
        {
            byte[] vertexByteCode;
            byte[] framentByteCode;
            {
                var vertexShaderMain = new Function(Spv.FunctionControl.CreateNone(), new TypeFunction() { ReturnType = SpirvTypeBase.Void }, "main")
                    .SetUp(_ => _
                        .ThenLabel()
                        .ThenReturn()
                    );
                var shader = new ShaderReflection()
                    .WithCapability(Capability.Shader())
                    .WithExtInstImport("GLSL.std.450")
                    .WithMemoryModel(AddressingModel.Logical(), MemoryModel.GLSL450())
                    .WithEntryPoint(ExecutionModel.Vertex(), vertexShaderMain)
                    .BuildShader();

                vertexByteCode = shader.Build();
            }
            {
                var fragmentShaderMain = new Function(Spv.FunctionControl.CreateNone(), new TypeFunction() { ReturnType = SpirvTypeBase.Void }, "main")
                        .SetUp(_ => _
                        .ThenLabel()
                        .ThenReturn()
                        );

                var shader = new ShaderReflection()
                    .WithCapability(Capability.Shader())
                    .WithExtInstImport("GLSL.std.450")
                    .WithMemoryModel(AddressingModel.Logical(), MemoryModel.GLSL450())
                    .WithEntryPoint(ExecutionModel.Fragment(), fragmentShaderMain)
                    .BuildShader();

                framentByteCode = shader
                    .Build();
            }

            var shaders = ResourceFactory.CreateFromSpirv(
                new ShaderDescription(ShaderStages.Vertex, vertexByteCode, "main"),
                new ShaderDescription(ShaderStages.Fragment, framentByteCode, "main"));

            var readRenderTargetPixel = RenderQuad(shaders);

            Assert.AreEqual(new RgbaByte(0, 0, 0, 255), readRenderTargetPixel);
        }
        [Test]
        public void GreenQuadReflectionTest()
        {
            byte[] vertexByteCode;
            byte[] framentByteCode;
            {
                var const_1f = new Constant(-1.0f);
                var const1f = new Constant(1.0f);
                var const0f = new Constant(0.0f);
                var const0i = new Constant(0);

                var arrayType = new TypeArray(SpirvTypeBase.Vec4, 4);
                var a = new ConstantComposite(SpirvTypeBase.Vec4, const_1f, const1f, const0f, const1f);
                var b = new ConstantComposite(SpirvTypeBase.Vec4, const1f, const1f, const1f, const1f);
                var c = new ConstantComposite(SpirvTypeBase.Vec4, const_1f, const_1f, const0f, const1f);
                var d = new ConstantComposite(SpirvTypeBase.Vec4, const1f, const_1f, const1f, const1f);
                var positions = new ConstantComposite(arrayType, a, b, c, d);

                var clipArrayType = new TypeArray(SpirvTypeBase.Float, 1);
                var gl_PerVertex = new TypeStruct("gl_PerVertex",
                    new TypeStructureField(SpirvTypeBase.Vec4, "gl_Position")
                        .WithDecoration(Decoration.BuiltIn(BuiltIn.Position())),
                    new TypeStructureField(SpirvTypeBase.Float, "gl_PointSize")
                        .WithDecoration(Decoration.BuiltIn(BuiltIn.PointSize())),
                    new TypeStructureField(clipArrayType, "gl_ClipDistance")
                        .WithDecoration(Decoration.BuiltIn(BuiltIn.ClipDistance())),
                    new TypeStructureField(clipArrayType, "gl_CullDistance")
                        .WithDecoration(Decoration.BuiltIn(BuiltIn.CullDistance()))
                ).WithDecoration(Decoration.Block());
                var outputVar = new Variable(gl_PerVertex.MakePointer(StorageClass.Output()), StorageClass.Output(), null, "");

                var localVar = new Variable(
                    arrayType.MakePointer(StorageClass.Function()),
                    StorageClass.Function(), null, "indexable");
                Node positionPointer = new AccessChain(SpirvTypeBase.Vec4.MakePointer(StorageClass.Output()), outputVar, new[] { const0i });
                var glVertexIndex = Variable.gl_VertexIndex();
                Node position = new Load(SpirvTypeBase.Vec4,
                                    new AccessChain(SpirvTypeBase.Vec4.MakePointer(StorageClass.Function()), localVar, new Node[]
                                    {
                                        new Load(SpirvTypeBase.Int, glVertexIndex, null)
                                    }), null);
                var vertexShaderMain = new Function(Spv.FunctionControl.Enumerant.None, new TypeFunction() { ReturnType = SpirvTypeBase.Void }, "main")
                    .SetUp(_ => _
                        .ThenLabel()
                        .ThenStore(localVar, positions, null)
                        .ThenStore(positionPointer, position, null)
                        .ThenReturn()
                    );
                var reflection = new ShaderReflection()
                    .WithCapability(Capability.Shader())
                    .WithExtInstImport("GLSL.std.450")
                    .WithMemoryModel(AddressingModel.Logical(), MemoryModel.GLSL450())
                    .WithEntryPoint(ExecutionModel.Vertex(), vertexShaderMain, "main");
                var shader = reflection
                    .BuildShader();

                vertexByteCode = shader.Build();

                Console.WriteLine("-----------------------");
                Node node = reflection.EntryPointInstructions.First().Value;
                while (node != null)
                {
                    Console.WriteLine($".Then(new {node})");
                    node = node.GetNext();
                }
                //var vertexSource = @"#version 450
                //#extension GL_KHR_vulkan_glsl : enable

                //const vec4 QuadInfos[4] = 
                //{
                //    vec4(-1, 1, 0, 1),
                //    vec4(1, 1, 1, 1),
                //    vec4(-1, -1, 0, 1),
                //    vec4(1, -1, 1, 1),
                //};

                //void main()
                //{
                //    gl_Position = QuadInfos[gl_VertexIndex];
                //}";
                //vertexByteCode = ShaderTestBase.CompileToBytecode(vertexSource, ShaderStages.Vertex, true, true);
            }
            {
                var const0f = new Constant(0.0f);
                var const1f = new Constant(1.0f);
                var redColor = new ConstantComposite(SpirvTypeBase.Vec4, const0f, const1f, const0f, const1f);
                var v = new Variable(SpirvTypeBase.Vec4.MakePointer(StorageClass.Output()), StorageClass.Output(), null, "fsout_Color0")
                {
                    Location = 0
                };
                var fragmentShaderMain = new Function(Spv.FunctionControl.Enumerant.None, new TypeFunction(SpirvTypeBase.Void), "main")
                        .SetUp(_ => _
                        .ThenLabel()
                        .ThenStore(v, redColor, null)
                        .ThenReturn()
                        );

                var reflection = new ShaderReflection()
                    .WithCapability(Capability.Shader())
                    .WithExtInstImport("GLSL.std.450")
                    .WithMemoryModel(AddressingModel.Logical(), MemoryModel.GLSL450())
                    .WithEntryPoint(ExecutionModel.Fragment(), fragmentShaderMain, "main")
                    .WithExecutionMode(fragmentShaderMain, ExecutionMode.OriginUpperLeft());

                var shader = reflection
                    .BuildShader();

                framentByteCode = shader
                    .Build();

                Console.WriteLine("-----------------------");
                Node node = reflection.EntryPointInstructions.First().Value;
                while (node != null)
                {
                    Console.WriteLine($".Then(new {node})");
                    node = node.GetNext();
                }

            //    var fragmentSource = @"#version 450

            //layout(location = 0) out vec4 fsout_Color0;

            //void main()
            //{
            //    fsout_Color0 = vec4(0,1,0,1);
            //}";
            //    framentByteCode = ShaderTestBase.CompileToBytecode(fragmentSource, ShaderStages.Fragment, true, true);
            }

            {
                var glsl = Veldrid.SPIRV.SpirvCompilation.CompileVertexFragment(vertexByteCode, framentByteCode,
                    CrossCompileTarget.GLSL);
                Console.WriteLine(glsl.VertexShader);
                Console.WriteLine(glsl.FragmentShader);
            }

            var shaders = ResourceFactory.CreateFromSpirv(
                new ShaderDescription(ShaderStages.Vertex, vertexByteCode, "main"),
                new ShaderDescription(ShaderStages.Fragment, framentByteCode, "main"));

            var readRenderTargetPixel = RenderQuad(shaders);

            Assert.AreEqual(new RgbaByte(0, 255, 0, 255), readRenderTargetPixel);
        }

        [Test]
        public void GreenQuadControlTest()
        {
            var vertexSource = @"#version 450
            #extension GL_KHR_vulkan_glsl : enable

            const vec4 QuadInfos[4] = 
            {
                vec4(-1, 1, 0, 1),
                vec4(1, 1, 1, 1),
                vec4(-1, -1, 0, 1),
                vec4(1, -1, 1, 1),
            };

            void main()
            {
                gl_Position = QuadInfos[gl_VertexIndex];
            }";

            var fragmentSource = @"#version 450

            layout(location = 0) out vec4 fsout_Color0;

            void main()
            {
                fsout_Color0 = vec4(0,1,0,1);
            }";

            {
                var glsl = Veldrid.SPIRV.SpirvCompilation.CompileVertexFragment(Encoding.ASCII.GetBytes(vertexSource), Encoding.ASCII.GetBytes(fragmentSource),
                    CrossCompileTarget.GLSL);
                Console.WriteLine(glsl.VertexShader);
                Console.WriteLine(glsl.FragmentShader);
            }

            {
                var bytecode = ShaderTestBase.CompileToBytecode(vertexSource, ShaderStages.Vertex, true, true);
                var instructions = Shader.Parse(bytecode);
                var reflection = new ShaderReflection(instructions);
                Console.WriteLine("-----------------------");
                Node node = reflection.EntryPointInstructions.First().Value;
                while (node!=null)
                {
                    Console.WriteLine($".Then(new {node})");
                    node = node.GetNext();
                }
            }
            {
                var bytecode = ShaderTestBase.CompileToBytecode(fragmentSource, ShaderStages.Fragment, true, true);
                var instructions = Shader.Parse(bytecode);
                var reflection = new ShaderReflection(instructions);
                Console.WriteLine("-----------------------");
                Node node = reflection.EntryPointInstructions.First().Value;
                while (node != null)
                {
                    Console.WriteLine($".Then(new {node})");
                    node = node.GetNext();
                }
            }


            var enc = new UTF8Encoding(false);
            var shaders =ResourceFactory.CreateFromSpirv(
                new ShaderDescription(ShaderStages.Vertex, enc.GetBytes(vertexSource), "main"),
                new ShaderDescription(ShaderStages.Fragment, enc.GetBytes(fragmentSource), "main"));

            var readRenderTargetPixel = RenderQuad(shaders);

            Assert.AreEqual(new RgbaByte(0,255,0,255), readRenderTargetPixel);
        }

        private string PrintArguments(Node node)
        {
            return "";
        }

        private RgbaByte RenderQuad(Veldrid.Shader[] shaders)
        {
            using (var pipeline = ResourceFactory.CreateGraphicsPipeline(new GraphicsPipelineDescription(
                BlendStateDescription.SingleOverrideBlend,
                DepthStencilStateDescription.DepthOnlyLessEqual,
                RasterizerStateDescription.CullNone,
                PrimitiveTopology.TriangleStrip,
                new ShaderSetDescription(new VertexLayoutDescription[0], shaders),
                new ResourceLayout[0],
                Framebuffer.OutputDescription
            )))
            {


                CommandList.Begin();
                CommandList.SetFramebuffer(Framebuffer);
                CommandList.SetFullViewports();
                CommandList.ClearColorTarget(0, RgbaFloat.Black);
                CommandList.ClearDepthStencil(1);
                CommandList.SetPipeline(pipeline);
                CommandList.Draw(4);
                CommandList.End();

                GraphicsDevice.SubmitCommands(CommandList);
                GraphicsDevice.WaitForIdle();

                var readRenderTargetPixel = ReadRenderTargetPixel();
                return readRenderTargetPixel;
            }
        }

        private CrossCompileTarget GetTarget(GraphicsBackend graphicsDeviceBackendType)
        {
            switch (graphicsDeviceBackendType)
            {
                case GraphicsBackend.Direct3D11:
                    return CrossCompileTarget.HLSL;
                case GraphicsBackend.Vulkan:
                    throw new NotImplementedException();
                case GraphicsBackend.OpenGL:
                    return CrossCompileTarget.GLSL;
                case GraphicsBackend.Metal:
                    return CrossCompileTarget.MSL;
                case GraphicsBackend.OpenGLES:
                    return CrossCompileTarget.ESSL;
                default:
                    throw new ArgumentOutOfRangeException(nameof(graphicsDeviceBackendType), graphicsDeviceBackendType, null);
            }
        }
    }
}