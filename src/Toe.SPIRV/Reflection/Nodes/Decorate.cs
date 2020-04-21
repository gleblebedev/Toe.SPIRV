using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Decorate : Node
    {
        public Decorate()
        {
        }

        public Decorate(Node target, Spv.Decoration decoration, string debugName = null)
        {
            this.Target = target;
            this.Decoration = decoration;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpDecorate;

        public Node Target { get; set; }

        public Spv.Decoration Decoration { get; set; }

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
                yield return CreateExitPin(nameof(Target), Target);
                yield break;
            }
        }

        public Decorate WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpDecorate)op, treeBuilder);
        }

        public Decorate SetUp(Action<Decorate> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpDecorate op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Target = treeBuilder.GetNode(op.Target);
            Decoration = op.Decoration;
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the Decorate object.</summary>
        /// <returns>A string that represents the Decorate object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"Decorate({Target}, {Decoration}, {DebugName})";
        }
    }
}