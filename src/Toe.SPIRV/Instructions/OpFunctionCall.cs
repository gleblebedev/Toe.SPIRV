using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpFunctionCall : InstructionWithId
    {
        public override Op OpCode => Op.OpFunctionCall;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IdRef Function { get; set; }
        public IList<IdRef> Arguments { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Function", Function);
            for (var i = 0; i < Arguments.Count; ++i)
                yield return new ReferenceProperty("Arguments" + i, Arguments[i]);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Function = IdRef.Parse(reader, end - reader.Position);
            Arguments = IdRef.ParseCollection(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Function} {Arguments}";
        }
    }
}