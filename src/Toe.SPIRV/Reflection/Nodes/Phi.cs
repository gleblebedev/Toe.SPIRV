using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Phi : Node
    {
        public Phi()
        {
        }

        public override Op OpCode => Op.OpPhi;


        public IList<Operands.PairNodeNode> VariableParent { get; } = new List<Operands.PairNodeNode>();
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
            SetUp((OpPhi)op, treeBuilder);
        }

        public void SetUp(OpPhi op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            foreach (var item in op.VariableParent) { VariableParent.Add(treeBuilder.Parse(item)); }
            SetUpDecorations(op, treeBuilder);
        }
    }
}