using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public class SpirvPointerType : SpirvTypeBase
    {
        public SpirvPointerType() : base(SpirvTypeCategory.Pointer)
        {
            
        }

        public string Name { get; set; }
        public SpirvTypeBase Type { get; set; }
        public StorageClass.Enumerant StorageClass { get; set; }

        public override string ToString()
        {
            if (Name != null)
                return Name;
            if (Type != null)
                return $"{Type}*";
            return base.ToString();
        }
    }
}