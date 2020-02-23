using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public abstract partial class AddressingModel : ValueEnum
    {
        public enum Enumerant
        {
            Logical = 0,
            [Capability(Capability.Enumerant.Addresses)]
            Physical32 = 1,
            [Capability(Capability.Enumerant.Addresses)]
            Physical64 = 2,
        }

        public class Logical: AddressingModel
        {
            public override Enumerant Value => AddressingModel.Enumerant.Logical;
            public new static Logical Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Logical();
                return res;
            }
        }
        public class Physical32: AddressingModel
        {
            public override Enumerant Value => AddressingModel.Enumerant.Physical32;
            public new static Physical32 Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Physical32();
                return res;
            }
        }
        public class Physical64: AddressingModel
        {
            public override Enumerant Value => AddressingModel.Enumerant.Physical64;
            public new static Physical64 Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Physical64();
                return res;
            }
        }

        public abstract Enumerant Value { get; }

        public static AddressingModel Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                case Enumerant.Logical :
                    return Logical.Parse(reader, wordCount - 1);
                case Enumerant.Physical32 :
                    return Physical32.Parse(reader, wordCount - 1);
                case Enumerant.Physical64 :
                    return Physical64.Parse(reader, wordCount - 1);
                default:
                    throw new IndexOutOfRangeException("Unknown AddressingModel "+id);
            }
        }
        
        public static AddressingModel ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<AddressingModel> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<AddressingModel>();
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