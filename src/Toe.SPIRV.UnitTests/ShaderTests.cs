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
                    shaderBytes = SpirvCompilation.CompileGlslToSpirv((string)shader[0], "shader.vk", (ShaderStages)shader[1],
                        new GlslCompileOptions { Debug = true });
                }
                catch (SpirvCompilationException exception)
                {
                    continue;
                }
                var instructions = Shader.Parse(shaderBytes.SpirvBytes);

                
                var decorates = instructions.Instructions
                    .Where(_ => _.OpCode == Op.OpDecorate)
                    .Select(_ => (OpDecorate) _);

                foreach (var opDecorate in decorates)
                {
                    if (!map.TryGetValue(opDecorate.Target.Instruction.OpCode, out var set))
                    {
                        set = new HashSet<Decoration.Enumerant>();
                        map.Add(opDecorate.Target.Instruction.OpCode, set);
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
        public void SampleShader(string vertexShaderCode, ShaderStages stage)
        {
            var shaderBytes = CompileToBytecode(vertexShaderCode, stage);
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