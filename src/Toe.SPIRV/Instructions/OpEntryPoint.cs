using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpEntryPoint : Instruction
    {
        public override Op OpCode => Op.OpEntryPoint;

        public ExecutionModel ExecutionModel { get; set; }
        public IdRef EntryPoint { get; set; }
        public string Name { get; set; }
        public IList<IdRef> Interface { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("EntryPoint", EntryPoint);
            for (var i = 0; i < Interface.Count; ++i)
                yield return new ReferenceProperty("Interface" + i, Interface[i]);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            ExecutionModel = ExecutionModel.Parse(reader, end - reader.Position);
            EntryPoint = IdRef.Parse(reader, end - reader.Position);
            Name = LiteralString.Parse(reader, end - reader.Position);
            Interface = IdRef.ParseCollection(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {ExecutionModel} {EntryPoint} {Name} {Interface}";
        }
    }
}