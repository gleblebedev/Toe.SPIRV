using Toe.SPIRV.Reflection.Nodes;

namespace Toe.SPIRV.Reflection
{
    public interface INodeWithNext
    {
        ExecutableNode Next { get; set; }
    }
}