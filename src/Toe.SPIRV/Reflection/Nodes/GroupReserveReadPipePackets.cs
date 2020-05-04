using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GroupReserveReadPipePackets : Node
    {
        public GroupReserveReadPipePackets()
        {
        }

        public GroupReserveReadPipePackets(SpirvTypeBase resultType, uint execution, Node pipe, Node numPackets, Node packetSize, Node packetAlignment, string debugName = null)
        {
            this.ResultType = resultType;
            this.Execution = execution;
            this.Pipe = pipe;
            this.NumPackets = numPackets;
            this.PacketSize = packetSize;
            this.PacketAlignment = packetAlignment;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpGroupReserveReadPipePackets;

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

        public GroupReserveReadPipePackets WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpGroupReserveReadPipePackets)op, treeBuilder);
        }

        public GroupReserveReadPipePackets SetUp(Action<GroupReserveReadPipePackets> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpGroupReserveReadPipePackets op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Execution = op.Execution;
            Pipe = treeBuilder.GetNode(op.Pipe);
            NumPackets = treeBuilder.GetNode(op.NumPackets);
            PacketSize = treeBuilder.GetNode(op.PacketSize);
            PacketAlignment = treeBuilder.GetNode(op.PacketAlignment);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the GroupReserveReadPipePackets object.</summary>
        /// <returns>A string that represents the GroupReserveReadPipePackets object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"GroupReserveReadPipePackets({ResultType}, {Execution}, {Pipe}, {NumPackets}, {PacketSize}, {PacketAlignment}, {DebugName})";
        }
    }
}