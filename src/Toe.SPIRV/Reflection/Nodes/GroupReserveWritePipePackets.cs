using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GroupReserveWritePipePackets : Node
    {
        public GroupReserveWritePipePackets()
        {
        }

        public GroupReserveWritePipePackets(SpirvTypeBase resultType, uint execution, Node pipe, Node numPackets, Node packetSize, Node packetAlignment, string debugName = null)
        {
            this.ResultType = resultType;
            this.Execution = execution;
            this.Pipe = pipe;
            this.NumPackets = numPackets;
            this.PacketSize = packetSize;
            this.PacketAlignment = packetAlignment;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpGroupReserveWritePipePackets;

        public uint Execution { get; set; }

        public Node Pipe { get; set; }

        public Node NumPackets { get; set; }

        public Node PacketSize { get; set; }

        public Node PacketAlignment { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<Node> GetInputNodes()
        {
                yield return Pipe;
                yield return NumPackets;
                yield return PacketSize;
                yield return PacketAlignment;
        }

        public GroupReserveWritePipePackets WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpGroupReserveWritePipePackets)op, treeBuilder);
        }

        public GroupReserveWritePipePackets SetUp(Action<GroupReserveWritePipePackets> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpGroupReserveWritePipePackets op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Execution = op.Execution;
            Pipe = treeBuilder.GetNode(op.Pipe);
            NumPackets = treeBuilder.GetNode(op.NumPackets);
            PacketSize = treeBuilder.GetNode(op.PacketSize);
            PacketAlignment = treeBuilder.GetNode(op.PacketAlignment);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the GroupReserveWritePipePackets object.</summary>
        /// <returns>A string that represents the GroupReserveWritePipePackets object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"GroupReserveWritePipePackets({ResultType}, {Execution}, {Pipe}, {NumPackets}, {PacketSize}, {PacketAlignment}, {DebugName})";
        }
    }
}