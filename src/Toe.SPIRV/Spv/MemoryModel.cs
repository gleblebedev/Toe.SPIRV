using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public class MemoryModel : ValueEnum
    {
        public enum Enumerant
        {
            [Capability(Capability.Enumerant.Shader)]
            Simple = 0,

            [Capability(Capability.Enumerant.Shader)]
            GLSL450 = 1,

            [Capability(Capability.Enumerant.Kernel)]
            OpenCL = 2
        }


        public MemoryModel(Enumerant value)
        {
            Value = value;
        }

        public Enumerant Value { get; }

        public static MemoryModel Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                default:
                    return new MemoryModel(id);
            }
        }

        public static MemoryModel ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<MemoryModel> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<MemoryModel>();
            while (reader.Position < end) res.Add(Parse(reader, end - reader.Position));
            return res;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}