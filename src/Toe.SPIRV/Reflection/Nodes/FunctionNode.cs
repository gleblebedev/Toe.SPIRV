namespace Toe.SPIRV.Reflection.Nodes
{
    public abstract class FunctionNode: Node
    {
        public SpirvTypeBase ReturnType { get; set; }

        public override bool TryGetReturnType(out SpirvTypeBase type)
        {
            type = ReturnType;
            return true;
        }
    }
}