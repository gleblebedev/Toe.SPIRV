namespace Toe.SPIRV.Reflection.Nodes
{
    public static partial class INodeWithNextExtensionMethods
    {
        public static T Then<T>(this INodeWithNext prevNode, T node) where T: ExecutableNode
        {
            prevNode.Next = node;
            return node;
        }
    }
}