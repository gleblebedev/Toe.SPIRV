namespace Toe.SPIRV.Reflection.Operands
{
    public struct PairNodeLiteralInteger
    {
        public uint LiteralInteger { get; }
        public Node Node { get; }

        public PairNodeLiteralInteger(Node node, uint integer)
        {
            Node = node;
            LiteralInteger = integer;
        }

        public override string ToString()
        {
            return $"{Node}: {LiteralInteger}";
        }
    }
}