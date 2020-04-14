using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Switch : ExecutableNode 
    {
        public Switch()
        {
        }

        public Node Selector { get; set; }
        public Node Default { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Selector), Selector);
                yield return CreateInputPin(nameof(Default), Default);
                yield break;
            }
        }

        public override IEnumerable<NodePinWithConnection> ExitPins
        {
            get
            {
                if (!IsFunction) yield return CreateExitPin("", GetNext());
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
        }
    }
}