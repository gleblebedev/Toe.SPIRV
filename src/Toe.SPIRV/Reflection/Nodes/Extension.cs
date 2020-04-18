using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Extension : Node
    {
        public Extension()
        {
        }

        public override Op OpCode => Op.OpExtension;


        public string Name { get; set; }

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
            SetUp((OpExtension)op, treeBuilder);
        }

        public void SetUp(OpExtension op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Name = op.Name;
            SetUpDecorations(op, treeBuilder);
        }
    }
}