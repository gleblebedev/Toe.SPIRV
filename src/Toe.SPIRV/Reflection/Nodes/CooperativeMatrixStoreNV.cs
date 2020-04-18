using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class CooperativeMatrixStoreNV : ExecutableNode, INodeWithNext
    {
        public CooperativeMatrixStoreNV()
        {
        }

        public override Op OpCode => Op.OpCooperativeMatrixStoreNV;

        /// <summary>
        /// Next operation in sequence
        /// </summary>
        public ExecutableNode Next { get; set; }

        public override ExecutableNode GetNext()
        {
            return Next;
        }

        public Node Pointer { get; set; }
        public Node Object { get; set; }
        public Node Stride { get; set; }
        public Node ColumnMajor { get; set; }
        public Spv.MemoryAccess MemoryAccess { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Pointer), Pointer);
                yield return CreateInputPin(nameof(Object), Object);
                yield return CreateInputPin(nameof(Stride), Stride);
                yield return CreateInputPin(nameof(ColumnMajor), ColumnMajor);
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
                yield return CreateExitPin("", GetNext());
                yield break;
            }
        }
        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpCooperativeMatrixStoreNV)op, treeBuilder);
        }

        public void SetUp(OpCooperativeMatrixStoreNV op, SpirvInstructionTreeBuilder treeBuilder)
        {
            Pointer = treeBuilder.GetNode(op.Pointer);
            Object = treeBuilder.GetNode(op.Object);
            Stride = treeBuilder.GetNode(op.Stride);
            ColumnMajor = treeBuilder.GetNode(op.ColumnMajor);
            MemoryAccess = op.MemoryAccess;
            SetUpDecorations(op, treeBuilder);
        }
    }
}