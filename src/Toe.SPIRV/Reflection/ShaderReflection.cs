using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Nodes;
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
            ExecutionModel = context.ExecutionModel;
        }

        public IReadOnlyList<SpirvStructure> Structures { get; private set; }

        public Function EntryFunction { get; set; }

        public ExecutionModel ExecutionModel { get; set; }

        public Shader Build()
        {
            var context = new SpirvInstructionsBuilder();
            return context.Build(this);
        }
    }
}