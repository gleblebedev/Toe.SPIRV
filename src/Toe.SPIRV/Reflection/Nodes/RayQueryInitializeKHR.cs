using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class RayQueryInitializeKHR : ExecutableNode, INodeWithNext
    {
        public RayQueryInitializeKHR()
        {
        }

        public RayQueryInitializeKHR(Node rayQuery, Node accel, Node rayFlags, Node cullMask, Node rayOrigin, Node rayTMin, Node rayDirection, Node rayTMax, string debugName = null)
        {
            this.RayQuery = rayQuery;
            this.Accel = accel;
            this.RayFlags = rayFlags;
            this.CullMask = cullMask;
            this.RayOrigin = rayOrigin;
            this.RayTMin = rayTMin;
            this.RayDirection = rayDirection;
            this.RayTMax = rayTMax;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpRayQueryInitializeKHR;

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

        public Node Accel { get; set; }

        public Node RayFlags { get; set; }

        public Node CullMask { get; set; }

        public Node RayOrigin { get; set; }

        public Node RayTMin { get; set; }

        public Node RayDirection { get; set; }

        public Node RayTMax { get; set; }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(RayQuery), RayQuery);
                yield return CreateInputPin(nameof(Accel), Accel);
                yield return CreateInputPin(nameof(RayFlags), RayFlags);
                yield return CreateInputPin(nameof(CullMask), CullMask);
                yield return CreateInputPin(nameof(RayOrigin), RayOrigin);
                yield return CreateInputPin(nameof(RayTMin), RayTMin);
                yield return CreateInputPin(nameof(RayDirection), RayDirection);
                yield return CreateInputPin(nameof(RayTMax), RayTMax);
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

        public RayQueryInitializeKHR WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpRayQueryInitializeKHR)op, treeBuilder);
        }

        public RayQueryInitializeKHR SetUp(Action<RayQueryInitializeKHR> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpRayQueryInitializeKHR op, SpirvInstructionTreeBuilder treeBuilder)
        {
            RayQuery = treeBuilder.GetNode(op.RayQuery);
            Accel = treeBuilder.GetNode(op.Accel);
            RayFlags = treeBuilder.GetNode(op.RayFlags);
            CullMask = treeBuilder.GetNode(op.CullMask);
            RayOrigin = treeBuilder.GetNode(op.RayOrigin);
            RayTMin = treeBuilder.GetNode(op.RayTMin);
            RayDirection = treeBuilder.GetNode(op.RayDirection);
            RayTMax = treeBuilder.GetNode(op.RayTMax);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the RayQueryInitializeKHR object.</summary>
        /// <returns>A string that represents the RayQueryInitializeKHR object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"RayQueryInitializeKHR({RayQuery}, {Accel}, {RayFlags}, {CullMask}, {RayOrigin}, {RayTMin}, {RayDirection}, {RayTMax}, {DebugName})";
        }
    }

    public static partial class INodeWithNextExtensionMethods
    {
        public static RayQueryInitializeKHR ThenRayQueryInitializeKHR(this INodeWithNext node, Node rayQuery, Node accel, Node rayFlags, Node cullMask, Node rayOrigin, Node rayTMin, Node rayDirection, Node rayTMax, string debugName = null)
        {
            return node.Then(new RayQueryInitializeKHR(rayQuery, accel, rayFlags, cullMask, rayOrigin, rayTMin, rayDirection, rayTMax, debugName));
        }
    }
}