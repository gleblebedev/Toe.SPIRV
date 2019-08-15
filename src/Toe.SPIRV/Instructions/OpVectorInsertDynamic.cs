using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpVectorInsertDynamic : InstructionWithId
    {
        public override Op OpCode => Op.OpVectorInsertDynamic;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IdRef Vector { get; set; }
        public IdRef Component { get; set; }
        public IdRef Index { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Vector", Vector);
            yield return new ReferenceProperty("Component", Component);
            yield return new ReferenceProperty("Index", Index);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Vector = IdRef.Parse(reader, end - reader.Position);
            Component = IdRef.Parse(reader, end - reader.Position);
            Index = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Vector} {Component} {Index}";
        }
    }
}