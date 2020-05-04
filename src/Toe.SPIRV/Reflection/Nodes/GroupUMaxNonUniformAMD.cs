using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class GroupUMaxNonUniformAMD : Node
    {
        public GroupUMaxNonUniformAMD()
        {
        }

        public GroupUMaxNonUniformAMD(SpirvTypeBase resultType, uint execution, Spv.GroupOperation operation, Node x, string debugName = null)
        {
            this.ResultType = resultType;
            this.Execution = execution;
            this.Operation = operation;
            this.X = x;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpGroupUMaxNonUniformAMD;

        public uint Execution { get; set; }

        public Spv.GroupOperation Operation { get; set; }

        public Node X { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<Node> GetInputNodes()
        {
                yield return X;
        }

        public GroupUMaxNonUniformAMD WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpGroupUMaxNonUniformAMD)op, treeBuilder);
        }

        public GroupUMaxNonUniformAMD SetUp(Action<GroupUMaxNonUniformAMD> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpGroupUMaxNonUniformAMD op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Execution = op.Execution;
            Operation = op.Operation;
            X = treeBuilder.GetNode(op.X);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the GroupUMaxNonUniformAMD object.</summary>
        /// <returns>A string that represents the GroupUMaxNonUniformAMD object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"GroupUMaxNonUniformAMD({ResultType}, {Execution}, {Operation}, {X}, {DebugName})";
        }
    }
}