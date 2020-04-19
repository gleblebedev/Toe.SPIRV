using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
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
        public IList<Operands.PairLiteralIntegerNode> Target { get; } = new List<Operands.PairLiteralIntegerNode>();
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Selector), Selector);
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
                yield return CreateExitPin(nameof(Default), Default);
                yield break;
            }
        }
        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpSwitch)op, treeBuilder);
        }

        public void SetUp(OpSwitch op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Selector = treeBuilder.GetNode(op.Selector);
            Default = treeBuilder.GetNode(op.Default);
            foreach (var item in op.Target) { Target.Add(treeBuilder.Parse(item)); }
            SetUpDecorations(op, treeBuilder);
        }
    }
}