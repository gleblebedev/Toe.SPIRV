using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpBranchConditional : Instruction
    {
        public override Op OpCode => Op.OpBranchConditional;

        public IdRef Condition { get; set; }
        public IdRef TrueLabel { get; set; }
        public IdRef FalseLabel { get; set; }
        public IList<uint> Branchweights { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Condition", Condition);
            yield return new ReferenceProperty("TrueLabel", TrueLabel);
            yield return new ReferenceProperty("FalseLabel", FalseLabel);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            Condition = IdRef.Parse(reader, end - reader.Position);
            TrueLabel = IdRef.Parse(reader, end - reader.Position);
            FalseLabel = IdRef.Parse(reader, end - reader.Position);
            Branchweights = LiteralInteger.ParseCollection(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {Condition} {TrueLabel} {FalseLabel} {Branchweights}";
        }
    }
}