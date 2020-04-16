using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpDecorateId: Instruction
    {
        public OpDecorateId()
        {
        }

        public override Op OpCode { get { return Op.OpDecorateId; } }

        public Spv.IdRef Target { get; set; }

        public Spv.Decoration Decoration { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Target", Target);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            Target = Spv.IdRef.Parse(reader, end-reader.Position);
            Decoration = Spv.Decoration.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += Target.GetWordCount();
            wordCount += Decoration.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            Target.Write(writer);
            Decoration.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {Target} {Decoration}";
        }
    }
}
