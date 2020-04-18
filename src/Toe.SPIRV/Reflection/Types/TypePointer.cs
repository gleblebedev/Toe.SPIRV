using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Types
{
    public partial class TypePointer : SpirvTypeBase
    {
        public TypePointer()
        {
            
        }

        public SpirvTypeBase Type { get; set; }
        public StorageClass StorageClass { get; set; }

        public override string ToString()
        {
            if (DebugName != null)
                return DebugName;
            if (Type != null)
                return $"{Type}*";
            return base.ToString();
        }

        partial void SetUp(OpTypePointer instruction, SpirvInstructionTreeBuilder treeBuilder)
        {
            Type = treeBuilder.ResolveType(instruction.Type);
            StorageClass = instruction.StorageClass;
        }
    }
}