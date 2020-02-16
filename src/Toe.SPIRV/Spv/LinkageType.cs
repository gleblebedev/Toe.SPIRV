using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public class LinkageType : ValueEnum
    {
        public LinkageType(Enumerant value)
        {
            Value = value;
        }

        public enum Enumerant
        {
            [Capability(Capability.Enumerant.Linkage)]
            Export = 0,

            [Capability(Capability.Enumerant.Linkage)]
            Import = 1
        }

        public Enumerant Value { get; }

        public static LinkageType Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                default:
                    return new LinkageType(id);
            }
        }

        public static LinkageType ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<LinkageType> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<LinkageType>();
            while (reader.Position < end) res.Add(Parse(reader, end - reader.Position));
            return res;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}