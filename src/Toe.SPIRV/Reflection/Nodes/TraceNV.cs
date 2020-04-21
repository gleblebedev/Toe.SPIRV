using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class TraceNV : ExecutableNode, INodeWithNext
    {
        public TraceNV()
        {
        }

        public TraceNV(Node accel, Node rayFlags, Node cullMask, Node sBTOffset, Node sBTStride, Node missIndex, Node rayOrigin, Node rayTmin, Node rayDirection, Node rayTmax, Node payloadId, string debugName = null)
        {
            this.Accel = accel;
            this.RayFlags = rayFlags;
            this.CullMask = cullMask;
            this.SBTOffset = sBTOffset;
            this.SBTStride = sBTStride;
            this.MissIndex = missIndex;
            this.RayOrigin = rayOrigin;
            this.RayTmin = rayTmin;
            this.RayDirection = rayDirection;
            this.RayTmax = rayTmax;
            this.PayloadId = payloadId;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpTraceNV;

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

        public Node Accel { get; set; }

        public Node RayFlags { get; set; }

        public Node CullMask { get; set; }

        public Node SBTOffset { get; set; }

        public Node SBTStride { get; set; }

        public Node MissIndex { get; set; }

        public Node RayOrigin { get; set; }

        public Node RayTmin { get; set; }

        public Node RayDirection { get; set; }

        public Node RayTmax { get; set; }

        public Node PayloadId { get; set; }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Accel), Accel);
                yield return CreateInputPin(nameof(RayFlags), RayFlags);
                yield return CreateInputPin(nameof(CullMask), CullMask);
                yield return CreateInputPin(nameof(SBTOffset), SBTOffset);
                yield return CreateInputPin(nameof(SBTStride), SBTStride);
                yield return CreateInputPin(nameof(MissIndex), MissIndex);
                yield return CreateInputPin(nameof(RayOrigin), RayOrigin);
                yield return CreateInputPin(nameof(RayTmin), RayTmin);
                yield return CreateInputPin(nameof(RayDirection), RayDirection);
                yield return CreateInputPin(nameof(RayTmax), RayTmax);
                yield return CreateInputPin(nameof(PayloadId), PayloadId);
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

        public TraceNV WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpTraceNV)op, treeBuilder);
        }

        public TraceNV SetUp(Action<TraceNV> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpTraceNV op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Accel = treeBuilder.GetNode(op.Accel);
            RayFlags = treeBuilder.GetNode(op.RayFlags);
            CullMask = treeBuilder.GetNode(op.CullMask);
            SBTOffset = treeBuilder.GetNode(op.SBTOffset);
            SBTStride = treeBuilder.GetNode(op.SBTStride);
            MissIndex = treeBuilder.GetNode(op.MissIndex);
            RayOrigin = treeBuilder.GetNode(op.RayOrigin);
            RayTmin = treeBuilder.GetNode(op.RayTmin);
            RayDirection = treeBuilder.GetNode(op.RayDirection);
            RayTmax = treeBuilder.GetNode(op.RayTmax);
            PayloadId = treeBuilder.GetNode(op.PayloadId);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the TraceNV object.</summary>
        /// <returns>A string that represents the TraceNV object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"TraceNV({Accel}, {RayFlags}, {CullMask}, {SBTOffset}, {SBTStride}, {MissIndex}, {RayOrigin}, {RayTmin}, {RayDirection}, {RayTmax}, {PayloadId}, {DebugName})";
        }
    }

    public static partial class INodeWithNextExtensionMethods
    {
        public static TraceNV ThenTraceNV(this INodeWithNext node, Node accel, Node rayFlags, Node cullMask, Node sBTOffset, Node sBTStride, Node missIndex, Node rayOrigin, Node rayTmin, Node rayDirection, Node rayTmax, Node payloadId, string debugName = null)
        {
            return node.Then(new TraceNV(accel, rayFlags, cullMask, sBTOffset, sBTStride, missIndex, rayOrigin, rayTmin, rayDirection, rayTmax, payloadId, debugName));
        }
    }
}