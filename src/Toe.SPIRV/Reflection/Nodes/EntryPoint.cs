using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class EntryPoint : Node
    {
        public EntryPoint()
        {
        }

        public override Op OpCode => Op.OpEntryPoint;


        public Spv.ExecutionModel ExecutionModel { get; set; }
        public Node Value { get; set; }
        public string Name { get; set; }
        public IList<Node> Interface { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Value), Value);
                for (var index = 0; index < Interface.Count; index++)
                {
                    yield return CreateInputPin(nameof(Interface) + index, Interface[index]);
                }
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
            SetUp((OpEntryPoint)op, treeBuilder);
        }

        public void SetUp(OpEntryPoint op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ExecutionModel = op.ExecutionModel;
            Value = treeBuilder.GetNode(op.Value);
            Name = op.Name;
            Interface = treeBuilder.GetNodes(op.Interface);
            SetUpDecorations(op, treeBuilder);
        }
    }
}