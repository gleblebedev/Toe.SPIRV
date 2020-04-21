using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class SubgroupAvcImeEvaluateWithSingleReferenceStreaminoutINTEL : Node
    {
        public SubgroupAvcImeEvaluateWithSingleReferenceStreaminoutINTEL()
        {
        }

        public SubgroupAvcImeEvaluateWithSingleReferenceStreaminoutINTEL(SpirvTypeBase resultType, Node srcImage, Node refImage, Node payload, Node streaminComponents, string debugName = null)
        {
            this.ResultType = resultType;
            this.SrcImage = srcImage;
            this.RefImage = refImage;
            this.Payload = payload;
            this.StreaminComponents = streaminComponents;
            DebugName = debugName;
        }

        public override Op OpCode => Op.OpSubgroupAvcImeEvaluateWithSingleReferenceStreaminoutINTEL;

        public Node SrcImage { get; set; }

        public Node RefImage { get; set; }

        public Node Payload { get; set; }

        public Node StreaminComponents { get; set; }

        public SpirvTypeBase ResultType { get; set; }

        public override SpirvTypeBase GetResultType()
        {
            return ResultType;
        }

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(SrcImage), SrcImage);
                yield return CreateInputPin(nameof(RefImage), RefImage);
                yield return CreateInputPin(nameof(Payload), Payload);
                yield return CreateInputPin(nameof(StreaminComponents), StreaminComponents);
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

        public SubgroupAvcImeEvaluateWithSingleReferenceStreaminoutINTEL WithDecoration(Spv.Decoration decoration)
        {
            AddDecoration(decoration);
            return this;
        }

        public override void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            base.SetUp(op, treeBuilder);
            SetUp((OpSubgroupAvcImeEvaluateWithSingleReferenceStreaminoutINTEL)op, treeBuilder);
        }

        public SubgroupAvcImeEvaluateWithSingleReferenceStreaminoutINTEL SetUp(Action<SubgroupAvcImeEvaluateWithSingleReferenceStreaminoutINTEL> setup)
        {
            setup(this);
            return this;
        }

        private void SetUp(OpSubgroupAvcImeEvaluateWithSingleReferenceStreaminoutINTEL op, SpirvInstructionTreeBuilder treeBuilder)
        {
            ResultType = treeBuilder.ResolveType(op.IdResultType);
            SrcImage = treeBuilder.GetNode(op.SrcImage);
            RefImage = treeBuilder.GetNode(op.RefImage);
            Payload = treeBuilder.GetNode(op.Payload);
            StreaminComponents = treeBuilder.GetNode(op.StreaminComponents);
            SetUpDecorations(op, treeBuilder);
        }

        /// <summary>Returns a string that represents the SubgroupAvcImeEvaluateWithSingleReferenceStreaminoutINTEL object.</summary>
        /// <returns>A string that represents the SubgroupAvcImeEvaluateWithSingleReferenceStreaminoutINTEL object.</returns>
        /// <filterpriority>2</filterpriority>
        public override string ToString()
        {
            return $"SubgroupAvcImeEvaluateWithSingleReferenceStreaminoutINTEL({ResultType}, {SrcImage}, {RefImage}, {Payload}, {StreaminComponents}, {DebugName})";
        }
    }
}