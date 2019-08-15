using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpSwitch : Instruction
    {
        public override Op OpCode => Op.OpSwitch;

        public IdRef Selector { get; set; }
        public IdRef Default { get; set; }
        public IList<PairLiteralIntegerIdRef> Target { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Selector", Selector);
            yield return new ReferenceProperty("Default", Default);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            Selector = IdRef.Parse(reader, end - reader.Position);
            Default = IdRef.Parse(reader, end - reader.Position);
            Target = PairLiteralIntegerIdRef.ParseCollection(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {Selector} {Default} {Target}";
        }
    }
}