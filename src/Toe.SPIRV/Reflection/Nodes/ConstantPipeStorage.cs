using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class ConstantPipeStorage : Node
    {
        public ConstantPipeStorage()
        {
        }

        public override Op OpCode => Op.OpConstantPipeStorage;


        public uint PacketSize { get; set; }
        public uint PacketAlignment { get; set; }
        public uint Capacity { get; set; }
        public SpirvTypeBase ResultType { get; set; }

        public bool RelaxedPrecision { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
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
        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpConstantPipeStorage)op, treeBuilder);
        }

        public void SetUp(OpConstantPipeStorage op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            PacketSize = op.PacketSize;
            PacketAlignment = op.PacketAlignment;
            Capacity = op.Capacity;
            SetUpDecorations(op, treeBuilder);
        }
    }
}