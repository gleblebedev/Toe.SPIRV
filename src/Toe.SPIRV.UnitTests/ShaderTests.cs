using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using NUnit.Framework;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;
using Veldrid;
using Veldrid.SPIRV;

namespace Toe.SPIRV.UnitTests
{
    [TestFixture]
    public class ShaderTests: ShaderTestBase
    {

        [Test]
        public void FindAllDecorations()
        {
            var map = new Dictionary<Op, HashSet<Decoration.Enumerant>>();
            foreach (var shader in SampleShaders.EnumerateShaders())
            {
                SpirvCompilationResult shaderBytes;
                try
                {
                    (var shaderSource, var stage) = SampleShaders.LoadShader(shader, typeof(SampleShaders).Assembly);
                    shaderBytes = SpirvCompilation.CompileGlslToSpirv(shaderSource, "shader.vk", stage,
                        new GlslCompileOptions { Debug = true });
                }
                catch (SpirvCompilationException exception)
                {
                    continue;
                }
                var instructions = Shader.Parse(shaderBytes.SpirvBytes);


                //var decorates = instructions.Instructions
                //    .Where(_ => _.OpCode == Op.OpDecorate)
                //    .Select(_ => (OpDecorate) _);
                //foreach (var opDecorate in decorates)
                //{
                //    if (!map.TryGetValue(opDecorate.Target.Instruction.OpCode, out var set))
                //    {
                //        set = new HashSet<Decoration.Enumerant>();
                //        map.Add(opDecorate.Target.Instruction.OpCode, set);
                //    }

                //    set.Add(opDecorate.Decoration.Value);
                //}
                var decorates = instructions.Instructions
                    .Where(_ => _.OpCode == Op.OpMemberDecorate)
                    .Select(_ => (OpMemberDecorate)_);

                foreach (var opDecorate in decorates)
                {
                    if (!map.TryGetValue(opDecorate.StructureType.Instruction.OpCode, out var set))
                    {
                        set = new HashSet<Decoration.Enumerant>();
                        map.Add(opDecorate.StructureType.Instruction.OpCode, set);
                    }

                    set.Add(opDecorate.Decoration.Value);
                }
            }
            foreach (var decorate in map)
            {
                Console.WriteLine($"{decorate.Key}:");
                foreach (var enumerant in decorate.Value)
                {
                    Console.WriteLine($"  {enumerant}");
                }
            }
        }

        [Test]
        [TestCaseSource(typeof(SampleShaders), nameof(SampleShaders.EnumerateShaders))]
        public void SampleShader(string resourceName)
        {
            (var shaderSource, var stage) = SampleShaders.LoadShader(resourceName, typeof(SampleShaders).Assembly);
            var shaderBytes = CompileToBytecode(shaderSource, stage);
            var instructions = Shader.Parse(shaderBytes);
            var generatedBytecode = instructions.Build();

            //Assert.AreEqual(shaderBytes.Length, generatedBytecode.Length);
            for (var index = 16; index < shaderBytes.Length; index++)
            {
                Assert.AreEqual(shaderBytes[index], generatedBytecode[index]);
            }
        }

        [Test]
        [TestCaseSource(typeof(TestShaders), nameof(TestShaders.EnumerateShaders))]
        public void SimpleShader(string vertexShaderCode, string fragmentShaderCode)
        {
            {
                var shaderBytes = CompileToBytecode(vertexShaderCode, ShaderStages.Vertex);
                var instructions = Shader.Parse(shaderBytes);
                var generatedBytecode = instructions.Build();

                //Assert.AreEqual(shaderBytes.Length, generatedBytecode.Length);
                for (var index = 16; index < shaderBytes.Length; index++)
                {
                    Assert.AreEqual(shaderBytes[index], generatedBytecode[index]);
                }
            }
            {
                var shaderBytes = CompileToBytecode(fragmentShaderCode, ShaderStages.Fragment);
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
}