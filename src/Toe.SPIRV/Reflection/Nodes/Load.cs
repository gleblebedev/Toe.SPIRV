using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Load : Node
    {
        public Load()
        {
        }

        public Load(SpirvTypeBase resultType, Node pointer, Spv.MemoryAccess memoryAccess, string debugName = null)
        {
            this.ResultType = resultType;
            this.Pointer = pointer;
            this.MemoryAccess = memoryAccess;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpLoad;

        public Node Pointer { get; set; }

        public Spv.MemoryAccess MemoryAccess { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Pointer), Pointer);
                yield break;
            }
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

        public Load WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpLoad)op, treeBuilder);
        }

        public Load SetUp(Action<Load> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpLoad op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Pointer = treeBuilder.GetNode(op.Pointer);
            MemoryAccess = op.MemoryAccess;
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the Load object.</summary>
        /// <returns>A string that represents the Load object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"Load({ResultType}, {Pointer}, {MemoryAccess}, {DebugName})";
        }
    }
}