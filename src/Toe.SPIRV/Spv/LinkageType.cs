using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public abstract partial class LinkageType : ValueEnum
    {
        public enum Enumerant
        {
            [Capability(Capability.Enumerant.Linkage)]
            Export = 0,
            [Capability(Capability.Enumerant.Linkage)]
            Import = 1,
        }

        public class Export: LinkageType
        {
            public static readonly Export Instance = new Export();
            public override Enumerant Value => LinkageType.Enumerant.Export;
            public new static Export Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Import: LinkageType
        {
            public static readonly Import Instance = new Import();
            public override Enumerant Value => LinkageType.Enumerant.Import;
            public new static Import Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }

        public abstract Enumerant Value { get; }

        public static LinkageType Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                case Enumerant.Export :
                    return Export.Parse(reader, wordCount - 1);
                case Enumerant.Import :
                    return Import.Parse(reader, wordCount - 1);
                default:
                    throw new IndexOutOfRangeException("Unknown LinkageType "+id);
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