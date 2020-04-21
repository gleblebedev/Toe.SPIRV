using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ReservedWritePipe : Node
    {
        public ReservedWritePipe()
        {
        }

        public ReservedWritePipe(SpirvTypeBase resultType, Node pipe, Node reserveId, Node index, Node pointer, Node packetSize, Node packetAlignment, string debugName = null)
        {
            this.ResultType = resultType;
            this.Pipe = pipe;
            this.ReserveId = reserveId;
            this.Index = index;
            this.Pointer = pointer;
            this.PacketSize = packetSize;
            this.PacketAlignment = packetAlignment;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpReservedWritePipe;

        public Node Pipe { get; set; }

        public Node ReserveId { get; set; }

        public Node Index { get; set; }

        public Node Pointer { get; set; }

        public Node PacketSize { get; set; }

        public Node PacketAlignment { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Pipe), Pipe);
                yield return CreateInputPin(nameof(ReserveId), ReserveId);
                yield return CreateInputPin(nameof(Index), Index);
                yield return CreateInputPin(nameof(Pointer), Pointer);
                yield return CreateInputPin(nameof(PacketSize), PacketSize);
                yield return CreateInputPin(nameof(PacketAlignment), PacketAlignment);
                yield break;
            }
        }

        public override IEnumerable<NodePin> OutputPins
        {
            get
            {
                yield return new NodePin(this, "", ResultType);
                yield break;
            }
        }


        public override IEnumerable<NodePinWithConnection> ExitPins
        {
            get
            {
                yield break;
            }
        }

        public ReservedWritePipe WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpReservedWritePipe)op, treeBuilder);
        }

        public ReservedWritePipe SetUp(Action<ReservedWritePipe> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpReservedWritePipe op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Pipe = treeBuilder.GetNode(op.Pipe);
            ReserveId = treeBuilder.GetNode(op.ReserveId);
            Index = treeBuilder.GetNode(op.Index);
            Pointer = treeBuilder.GetNode(op.Pointer);
            PacketSize = treeBuilder.GetNode(op.PacketSize);
            PacketAlignment = treeBuilder.GetNode(op.PacketAlignment);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the ReservedWritePipe object.</summary>
        /// <returns>A string that represents the ReservedWritePipe object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"ReservedWritePipe({ResultType}, {Pipe}, {ReserveId}, {Index}, {Pointer}, {PacketSize}, {PacketAlignment}, {DebugName})";
        }
    }
}