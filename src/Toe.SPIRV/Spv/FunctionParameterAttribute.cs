using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public class FunctionParameterAttribute : ValueEnum
    {
        public enum Enumerant
        {
            [Capability(Capability.Enumerant.Kernel)]
            Zext = 0,

            [Capability(Capability.Enumerant.Kernel)]
            Sext = 1,

            [Capability(Capability.Enumerant.Kernel)]
            ByVal = 2,

            [Capability(Capability.Enumerant.Kernel)]
            Sret = 3,

            [Capability(Capability.Enumerant.Kernel)]
            NoAlias = 4,

            [Capability(Capability.Enumerant.Kernel)]
            NoCapture = 5,

            [Capability(Capability.Enumerant.Kernel)]
            NoWrite = 6,

            [Capability(Capability.Enumerant.Kernel)]
            NoReadWrite = 7
        }


        public FunctionParameterAttribute(Enumerant value)
        {
            Value = value;
        }

        public Enumerant Value { get; }

        public static FunctionParameterAttribute Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                default:
                    return new FunctionParameterAttribute(id);
            }
        }

        public static FunctionParameterAttribute ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<FunctionParameterAttribute> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<FunctionParameterAttribute>();
            while (reader.Position < end) res.Add(Parse(reader, end - reader.Position));
            return res;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}