using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public abstract class ReflectedInstruction
    {
        public abstract Op OpCode { get; }

        public string Name { get; set; }
    }
}