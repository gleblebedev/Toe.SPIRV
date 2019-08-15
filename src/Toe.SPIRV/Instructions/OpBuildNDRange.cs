using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpBuildNDRange : InstructionWithId
    {
        public override Op OpCode => Op.OpBuildNDRange;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IdRef GlobalWorkSize { get; set; }
        public IdRef LocalWorkSize { get; set; }
        public IdRef GlobalWorkOffset { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("GlobalWorkSize", GlobalWorkSize);
            yield return new ReferenceProperty("LocalWorkSize", LocalWorkSize);
            yield return new ReferenceProperty("GlobalWorkOffset", GlobalWorkOffset);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            GlobalWorkSize = IdRef.Parse(reader, end - reader.Position);
            LocalWorkSize = IdRef.Parse(reader, end - reader.Position);
            GlobalWorkOffset = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {GlobalWorkSize} {LocalWorkSize} {GlobalWorkOffset}";
        }
    }
}