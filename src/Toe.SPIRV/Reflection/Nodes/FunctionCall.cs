using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class FunctionCall : FunctionNode 
    {
        public FunctionCall(OpFunctionCall op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Arguments = treeBuilder.GetNodes(op.Arguments);
        }

        public override void FixForwardReferences(Instruction instruction, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.FixForwardReferences(instruction, treeBuilder);
            Function = treeBuilder.GetNode(((OpFunctionCall)instruction).Function);
        }

        public Node Function { get; set; }

        public IList<Node> Arguments { get; set; }
    }
}