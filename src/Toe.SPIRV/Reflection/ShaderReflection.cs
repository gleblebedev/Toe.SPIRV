using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public class ShaderReflection
    {
        public ShaderReflection(Shader shader)
        {
            var context = new SpirvInstructionTreeBuilder();
            context.BuildTree(shader);
            Structures = context.Types.Where(_=>_.TypeCategory == SpirvTypeCategory.Struct).Select(_=>(SpirvStructure)_).ToList();
            EntryFunction = context.EntryFunction;
        }

        public IReadOnlyList<SpirvStructure> Structures { get; private set; }

        public SpirvFunction EntryFunction { get; set; }

        public Shader Build()
        {
            var shader = new Shader();
            shader.Instructions.Add(new OpCapability(){Capability = new Capability.Shader() });
            shader.Instructions.Add(new OpExtInstImport(){Name = "GLSL.std.450" });
            shader.Instructions.Add(new OpMemoryModel() { MemoryModel = new MemoryModel.GLSL450(), AddressingModel = new AddressingModel.Logical()});

            //shader.Instructions.Add(new OpEntryPoint() { ExecutionModel = });
            throw new NotImplementedException();
            return shader;
        }
    }
}