using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupImageBlockWriteINTEL : ExecutableNode, INodeWithNext
    {
        public SubgroupImageBlockWriteINTEL()
        {
        }

        public SubgroupImageBlockWriteINTEL(Node image, Node coordinate, Node data, string debugName = null)
        {
            this.Image = image;
            this.Coordinate = coordinate;
            this.Data = data;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpSubgroupImageBlockWriteINTEL;

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

        public Node Image { get; set; }

        public Node Coordinate { get; set; }

        public Node Data { get; set; }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Image), Image);
                yield return CreateInputPin(nameof(Coordinate), Coordinate);
                yield return CreateInputPin(nameof(Data), Data);
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

        public SubgroupImageBlockWriteINTEL WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpSubgroupImageBlockWriteINTEL)op, treeBuilder);
        }

        public SubgroupImageBlockWriteINTEL SetUp(Action<SubgroupImageBlockWriteINTEL> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpSubgroupImageBlockWriteINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Image = treeBuilder.GetNode(op.Image);
            Coordinate = treeBuilder.GetNode(op.Coordinate);
            Data = treeBuilder.GetNode(op.Data);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the SubgroupImageBlockWriteINTEL object.</summary>
        /// <returns>A string that represents the SubgroupImageBlockWriteINTEL object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"SubgroupImageBlockWriteINTEL({Image}, {Coordinate}, {Data}, {DebugName})";
        }
    }

    public static partial class INodeWithNextExtensionMethods
    {
        public static SubgroupImageBlockWriteINTEL ThenSubgroupImageBlockWriteINTEL(this INodeWithNext node, Node image, Node coordinate, Node data, string debugName = null)
        {
            return node.Then(new SubgroupImageBlockWriteINTEL(image, coordinate, data, debugName));
        }
    }
}