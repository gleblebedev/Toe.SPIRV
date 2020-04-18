using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Line : Node
    {
        public Line()
        {
        }

        public override Op OpCode => Op.OpLine;


        public Node File { get; set; }
        public uint Value { get; set; }
        public uint Column { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(File), File);
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
            SetUp((OpLine)op, treeBuilder);
        }

        public void SetUp(OpLine op, SpirvInstructionTreeBuilder treeBuilder)
        {
            File = treeBuilder.GetNode(op.File);
            Value = op.Value;
            Column = op.Column;
            SetUpDecorations(op, treeBuilder);
        }
    }
}