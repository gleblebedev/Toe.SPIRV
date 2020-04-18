using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Types
{
    public partial class TypeFunction:SpirvTypeBase
    {
        public TypeFunction()
        {
        }


        public SpirvTypeBase ReturnType { get; set; }

        public IList<TypeFunctionArgument> Arguments { get; } = new List<TypeFunctionArgument>();

        public override string ToString()
        {
            return DebugName ?? base.ToString();
        }

        partial void SetUp(OpTypeFunction instruction, SpirvInstructionTreeBuilder treeBuilder)
        {
            ReturnType = treeBuilder.ResolveType(instruction.ReturnType);
            foreach (var parameterType in instruction.ParameterTypes)
                Arguments.Add(new TypeFunctionArgument(treeBuilder.ResolveType(parameterType.Id)));
        }
    }
}