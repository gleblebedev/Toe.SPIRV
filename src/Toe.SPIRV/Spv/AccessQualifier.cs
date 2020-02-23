using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public abstract partial class AccessQualifier : ValueEnum
    {
        public enum Enumerant
        {
            [Capability(Capability.Enumerant.Kernel)]
            ReadOnly = 0,
            [Capability(Capability.Enumerant.Kernel)]
            WriteOnly = 1,
            [Capability(Capability.Enumerant.Kernel)]
            ReadWrite = 2,
        }

        public class ReadOnly: AccessQualifier
        {
            public override Enumerant Value => AccessQualifier.Enumerant.ReadOnly;
            public new static ReadOnly Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ReadOnly();
                return res;
            }
        }
        public class WriteOnly: AccessQualifier
        {
            public override Enumerant Value => AccessQualifier.Enumerant.WriteOnly;
            public new static WriteOnly Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new WriteOnly();
                return res;
            }
        }
        public class ReadWrite: AccessQualifier
        {
            public override Enumerant Value => AccessQualifier.Enumerant.ReadWrite;
            public new static ReadWrite Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ReadWrite();
                return res;
            }
        }

        public abstract Enumerant Value { get; }

        public static AccessQualifier Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                case Enumerant.ReadOnly :
                    return ReadOnly.Parse(reader, wordCount - 1);
                case Enumerant.WriteOnly :
                    return WriteOnly.Parse(reader, wordCount - 1);
                case Enumerant.ReadWrite :
                    return ReadWrite.Parse(reader, wordCount - 1);
                default:
                    throw new IndexOutOfRangeException("Unknown AccessQualifier "+id);
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