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
            [Capability(Capability.Enumerant.PhysicalStorageBufferAddresses)]
            PhysicalStorageBuffer64 = 5348,
            [Capability(Capability.Enumerant.PhysicalStorageBufferAddresses)]
            PhysicalStorageBuffer64EXT = 5348,
        }

        public class Logical: AddressingModel
        {
            public static readonly Logical Instance = new Logical();
            public override Enumerant Value => AddressingModel.Enumerant.Logical;
            public new static Logical Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Physical32: AddressingModel
        {
            public static readonly Physical32 Instance = new Physical32();
            public override Enumerant Value => AddressingModel.Enumerant.Physical32;
            public new static Physical32 Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Physical64: AddressingModel
        {
            public static readonly Physical64 Instance = new Physical64();
            public override Enumerant Value => AddressingModel.Enumerant.Physical64;
            public new static Physical64 Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class PhysicalStorageBuffer64: AddressingModel
        {
            public static readonly PhysicalStorageBuffer64 Instance = new PhysicalStorageBuffer64();
            public override Enumerant Value => AddressingModel.Enumerant.PhysicalStorageBuffer64;
            public new static PhysicalStorageBuffer64 Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class PhysicalStorageBuffer64EXT: AddressingModel
        {
            public static readonly PhysicalStorageBuffer64EXT Instance = new PhysicalStorageBuffer64EXT();
            public override Enumerant Value => AddressingModel.Enumerant.PhysicalStorageBuffer64EXT;
            public new static PhysicalStorageBuffer64EXT Parse(WordReader reader, uint wordCount)
            {
                return Instance;
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
                case Enumerant.PhysicalStorageBuffer64 :
                    return PhysicalStorageBuffer64.Parse(reader, wordCount - 1);
                //PhysicalStorageBuffer64EXT has the same id as another value in enum.
                //case Enumerant.PhysicalStorageBuffer64EXT :
                //    return PhysicalStorageBuffer64EXT.Parse(reader, wordCount - 1);
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