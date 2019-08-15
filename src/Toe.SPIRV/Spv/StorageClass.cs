using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public class StorageClass : ValueEnum
    {
        public enum Enumerant
        {
            UniformConstant = 0,
            Input = 1,

            [Capability(Capability.Enumerant.Shader)]
            Uniform = 2,

            [Capability(Capability.Enumerant.Shader)]
            Output = 3,
            Workgroup = 4,
            CrossWorkgroup = 5,

            [Capability(Capability.Enumerant.Shader)]
            Private = 6,
            Function = 7,

            [Capability(Capability.Enumerant.GenericPointer)]
            Generic = 8,

            [Capability(Capability.Enumerant.Shader)]
            PushConstant = 9,

            [Capability(Capability.Enumerant.AtomicStorage)]
            AtomicCounter = 10,
            Image = 11,

            [Capability(Capability.Enumerant.Shader)]
            StorageBuffer = 12
        }


        public StorageClass(Enumerant value)
        {
            Value = value;
        }

        public Enumerant Value { get; }

        public static StorageClass Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                default:
                    return new StorageClass(id);
            }
        }

        public static StorageClass ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<StorageClass> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<StorageClass>();
            while (reader.Position < end) res.Add(Parse(reader, end - reader.Position));
            return res;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}