using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpTypeFunction : TypeInstruction
    {
        public override Op OpCode => Op.OpTypeFunction;

        public IdRef ReturnType { get; set; }
        public IList<IdRef> ParameterTypes { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("ReturnType", ReturnType);
            for (var i = 0; i < ParameterTypes.Count; ++i)
                yield return new ReferenceProperty("ParameterTypes" + i, ParameterTypes[i]);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            ReturnType = IdRef.Parse(reader, end - reader.Position);
            ParameterTypes = IdRef.ParseCollection(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResult} = {OpCode} {ReturnType} {ParameterTypes}";
        }
    }
}