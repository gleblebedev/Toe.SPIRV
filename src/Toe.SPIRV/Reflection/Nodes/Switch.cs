using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Switch : ExecutableNode
    {
        public Switch()
        {
        }

        public override Op OpCode => Op.OpSwitch;


        public Node Selector { get; set; }
        public Node Default { get; set; }
        public IList<Spv.PairLiteralIntegerIdRef> Target { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Selector), Selector);
                yield return CreateInputPin(nameof(Default), Default);
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
                yield break;
            }
        }
        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            SetUp((OpSwitch)op, treeBuilder);
        }

        public void SetUp(OpSwitch op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Selector = treeBuilder.GetNode(op.Selector);
            Default = treeBuilder.GetNode(op.Default);
            Target = op.Target;
        }
        
        partial void SetUpDecorations(IList<OpDecorate> decorations);
    }
}