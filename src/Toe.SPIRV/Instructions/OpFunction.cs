using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpFunction : InstructionWithId
    {
        public override Op OpCode => Op.OpFunction;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public FunctionControl FunctionControl { get; set; }
        public IdRef FunctionType { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("FunctionType", FunctionType);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            FunctionControl = FunctionControl.Parse(reader, end - reader.Position);
            FunctionType = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {FunctionControl} {FunctionType}";
        }
    }
}