using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class FragmentFetchAMD : Node
    {
        public FragmentFetchAMD()
        {
        }

        public FragmentFetchAMD(SpirvTypeBase resultType, Node image, Node coordinate, Node fragmentIndex, string debugName = null)
        {
            this.ResultType = resultType;
            this.Image = image;
            this.Coordinate = coordinate;
            this.FragmentIndex = fragmentIndex;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpFragmentFetchAMD;

        public Node Image { get; set; }

        public Node Coordinate { get; set; }

        public Node FragmentIndex { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(Image), Image);
                yield return CreateInputPin(nameof(Coordinate), Coordinate);
                yield return CreateInputPin(nameof(FragmentIndex), FragmentIndex);
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

        public FragmentFetchAMD WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpFragmentFetchAMD)op, treeBuilder);
        }

        public FragmentFetchAMD SetUp(Action<FragmentFetchAMD> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpFragmentFetchAMD op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            Image = treeBuilder.GetNode(op.Image);
            Coordinate = treeBuilder.GetNode(op.Coordinate);
            FragmentIndex = treeBuilder.GetNode(op.FragmentIndex);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the FragmentFetchAMD object.</summary>
        /// <returns>A string that represents the FragmentFetchAMD object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"FragmentFetchAMD({ResultType}, {Image}, {Coordinate}, {FragmentIndex}, {DebugName})";
        }
    }
}