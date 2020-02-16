using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public class Scope : ValueEnum
    {
        public Scope(Enumerant value)
        {
            Value = value;
        }

        public enum Enumerant
        {
            CrossDevice = 0,
            Device = 1,
            Workgroup = 2,
            Subgroup = 3,
            Invocation = 4
        }

        public Enumerant Value { get; }

        public static Scope Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                default:
                    return new Scope(id);
            }
        }

        public static Scope ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<Scope> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<Scope>();
            while (reader.Position < end) res.Add(Parse(reader, end - reader.Position));
            return res;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}