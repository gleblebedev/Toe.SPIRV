using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ExecuteCallableNV : ExecutableNode, INodeWithNext
    {
        public ExecuteCallableNV()
        {
        }

        public override Op OpCode => Op.OpExecuteCallableNV;

        /// <summary>
        /// Next operation in sequence
        /// </summary>
        public ExecutableNode Next { get; set; }

        public override ExecutableNode GetNext()
        {
            return Next;
        }

        public Node SBTIndex { get; set; }
        public Node CallableDataId { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(SBTIndex), SBTIndex);
                yield return CreateInputPin(nameof(CallableDataId), CallableDataId);
                yield break;
            }
        }

        public override IEnumerable<NodePin> OutputPins
        {
            get
            {
                yield break;
            }
        }

        public override IEnumerable<NodePin> EnterPins
        {
            get
            {
                yield return new NodePin(this, "", null);
            }
        }

        public override IEnumerable<NodePinWithConnection> ExitPins
        {
            get
            {
                yield return CreateExitPin("", GetNext());
                yield break;
            }
        }
        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpExecuteCallableNV)op, treeBuilder);
        }

        public void SetUp(OpExecuteCallableNV op, SpirvInstructionTreeBuilder treeBuilder)
        {
            SBTIndex = treeBuilder.GetNode(op.SBTIndex);
            CallableDataId = treeBuilder.GetNode(op.CallableDataId);
            SetUpDecorations(op, treeBuilder);
        }
    }
}