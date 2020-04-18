using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Capability : Node
    {
        public Capability()
        {
        }

        public override Op OpCode => Op.OpCapability;


        public Spv.Capability Value { get; set; }

        public override IEnumerable<NodePin> OutputPins
        {
            get
            {
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
            SetUp((OpCapability)op, treeBuilder);
        }

        public void SetUp(OpCapability op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Value = op.Value;
            SetUpDecorations(op, treeBuilder);
        }
    }
}