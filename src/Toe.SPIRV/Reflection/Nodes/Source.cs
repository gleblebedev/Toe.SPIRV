using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Source : Node
    {
        public Source()
        {
        }

        public override Op OpCode => Op.OpSource;


        public Spv.SourceLanguage SourceLanguage { get; set; }
        public uint Version { get; set; }
        public Node File { get; set; }
        public string Value { get; set; }
        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                yield return CreateInputPin(nameof(File), File);
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
            SetUp((OpSource)op, treeBuilder);
        }

        public void SetUp(OpSource op, SpirvInstructionTreeBuilder treeBuilder)
        {
            SourceLanguage = op.SourceLanguage;
            Version = op.Version;
            File = treeBuilder.GetNode(op.File);
            Value = op.Value;
            SetUpDecorations(op, treeBuilder);
        }
    }
}