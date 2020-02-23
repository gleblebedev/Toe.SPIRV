using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSwitch: Instruction
    {
        public OpSwitch()
        {
        }

        public override Op OpCode { get { return Op.OpSwitch; } }

        public Spv.IdRef Selector { get; set; }
        public Spv.IdRef Default { get; set; }
        public IList<Spv.PairLiteralIntegerIdRef> Target { get; set; }
        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Selector", Selector);
            yield return new ReferenceProperty("Default", Default);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            Selector = Spv.IdRef.Parse(reader, end-reader.Position);
            Default = Spv.IdRef.Parse(reader, end-reader.Position);
            Target = Spv.PairLiteralIntegerIdRef.ParseCollection(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += Selector.GetWordCount();
            wordCount += Default.GetWordCount();
            wordCount += Target.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            Selector.Write(writer);
            Default.Write(writer);
            Target.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {Selector} {Default} {Target}";
        }
    }
}
