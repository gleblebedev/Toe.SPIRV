using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public partial class Dim : ValueEnum
    {
        public Dim(Enumerant value)
        {
            Value = value;
        }

        public enum Enumerant
        {
            [Capability(Capability.Enumerant.Sampled1D)]
            Dim1D = 0,
            Dim2D = 1,
            Dim3D = 2,
            [Capability(Capability.Enumerant.Shader)]
            Cube = 3,
            [Capability(Capability.Enumerant.SampledRect)]
            Rect = 4,
            [Capability(Capability.Enumerant.SampledBuffer)]
            Buffer = 5,
            [Capability(Capability.Enumerant.InputAttachment)]
            SubpassData = 6,
        }


        public Enumerant Value { get; }

        public static Dim Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                default:
                    return new Dim(id);
            }
        }
        
        public static Dim ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<Dim> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<Dim>();
            while (reader.Position < end)
            {
                res.Add(Parse(reader, end-reader.Position));
            }
            return res;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public virtual uint GetWordCount()
        {
            return 1;
        }

        public virtual void Write(WordWriter writer)
        {
            writer.WriteWord((uint)Value);
        }
    }
}