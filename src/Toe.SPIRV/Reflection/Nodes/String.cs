using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class String : Node
    {
        public String()
        {
        }

        public override Op OpCode => Op.OpString;


        public string Value { get; set; }

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
            SetUp((OpString)op, treeBuilder);
        }

        public void SetUp(OpString op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Value = op.Value;
            SetUpDecorations(op, treeBuilder);
        }
    }
}