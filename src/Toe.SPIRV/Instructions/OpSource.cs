using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpSource : Instruction
    {
        public override Op OpCode => Op.OpSource;

        public SourceLanguage SourceLanguage { get; set; }
        public uint Version { get; set; }
        public IdRef File { get; set; }
        public string Source { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("File", File);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            SourceLanguage = SourceLanguage.Parse(reader, end - reader.Position);
            Version = LiteralInteger.Parse(reader, end - reader.Position);
            File = IdRef.ParseOptional(reader, end - reader.Position);
            Source = LiteralString.ParseOptional(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {SourceLanguage} {Version} {File} {Source}";
        }
    }
}