using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public class AccessQualifier : ValueEnum
    {
        public enum Enumerant
        {
            [Capability(Capability.Enumerant.Kernel)]
            ReadOnly = 0,

            [Capability(Capability.Enumerant.Kernel)]
            WriteOnly = 1,

            [Capability(Capability.Enumerant.Kernel)]
            ReadWrite = 2
        }


        public AccessQualifier(Enumerant value)
        {
            Value = value;
        }

        public Enumerant Value { get; }

        public static AccessQualifier Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                default:
                    return new AccessQualifier(id);
            }
        }

        public static AccessQualifier ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<AccessQualifier> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<AccessQualifier>();
            while (reader.Position < end) res.Add(Parse(reader, end - reader.Position));
            return res;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}