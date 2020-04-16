using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public class SpirvPointer : SpirvTypeBase
    {
        public SpirvPointer() : base(SpirvTypeCategory.Pointer)
        {
            
        }

        public override Op OpCode => Op.OpTypePointer;

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
    }
}