using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class RayQueryConfirmIntersectionKHR : ExecutableNode, INodeWithNext
    {
        public RayQueryConfirmIntersectionKHR()
        {
        }

        public RayQueryConfirmIntersectionKHR(Node rayQuery, string debugName = null)
        {
            this.RayQuery = rayQuery;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpRayQueryConfirmIntersectionKHR;

        /// <summary>
        /// Next operation in sequence
        /// </summary>
        public ExecutableNode Next { get; set; }

        public override ExecutableNode GetNext()
        {
            return Next;
        }

        public T Then<T>(T node) where T: ExecutableNode
        {
            Next = node;
            return node;
        }

        public Node RayQuery { get; set; }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(RayQuery), RayQuery);
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

        public RayQueryConfirmIntersectionKHR WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpRayQueryConfirmIntersectionKHR)op, treeBuilder);
        }

        public RayQueryConfirmIntersectionKHR SetUp(Action<RayQueryConfirmIntersectionKHR> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpRayQueryConfirmIntersectionKHR op, SpirvInstructionTreeBuilder treeBuilder)
        {
            RayQuery = treeBuilder.GetNode(op.RayQuery);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the RayQueryConfirmIntersectionKHR object.</summary>
        /// <returns>A string that represents the RayQueryConfirmIntersectionKHR object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"RayQueryConfirmIntersectionKHR({RayQuery}, {DebugName})";
        }
    }

    public static partial class INodeWithNextExtensionMethods
    {
        public static RayQueryConfirmIntersectionKHR ThenRayQueryConfirmIntersectionKHR(this INodeWithNext node, Node rayQuery, string debugName = null)
        {
            return node.Then(new RayQueryConfirmIntersectionKHR(rayQuery, debugName));
        }
    }
}