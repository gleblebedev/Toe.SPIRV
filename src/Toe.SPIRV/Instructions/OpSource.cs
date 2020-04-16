using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSource: Instruction
    {
        public OpSource()
        {
        }

        public override Op OpCode { get { return Op.OpSource; } }

        public Spv.SourceLanguage SourceLanguage { get; set; }

        public uint Version { get; set; }

        public Spv.IdRef File { get; set; }

        public string Value { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("File", File);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            SourceLanguage = Spv.SourceLanguage.Parse(reader, end-reader.Position);
            Version = Spv.LiteralInteger.Parse(reader, end-reader.Position);
            File = Spv.IdRef.ParseOptional(reader, end-reader.Position);
            Value = Spv.LiteralString.ParseOptional(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += SourceLanguage.GetWordCount();
            wordCount += Version.GetWordCount();
            wordCount += File?.GetWordCount() ?? (uint)0;
            wordCount += Value?.GetWordCount() ?? (uint)0;
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            SourceLanguage.Write(writer);
            Version.Write(writer);
            if (File != null) File.Write(writer);
            if (Value != null) Value.Write(writer);
        }

        public override string ToString()
        {
            return $"{OpCode} {SourceLanguage} {Version} {File} {Value}";
        }
    }
}
