using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public abstract partial class FunctionParameterAttribute : ValueEnum
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
            NoReadWrite = 7,
        }

        public class Zext: FunctionParameterAttribute
        {
            public override Enumerant Value => FunctionParameterAttribute.Enumerant.Zext;
            public new static Zext Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Zext();
                return res;
            }
        }
        public class Sext: FunctionParameterAttribute
        {
            public override Enumerant Value => FunctionParameterAttribute.Enumerant.Sext;
            public new static Sext Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Sext();
                return res;
            }
        }
        public class ByVal: FunctionParameterAttribute
        {
            public override Enumerant Value => FunctionParameterAttribute.Enumerant.ByVal;
            public new static ByVal Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ByVal();
                return res;
            }
        }
        public class Sret: FunctionParameterAttribute
        {
            public override Enumerant Value => FunctionParameterAttribute.Enumerant.Sret;
            public new static Sret Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Sret();
                return res;
            }
        }
        public class NoAlias: FunctionParameterAttribute
        {
            public override Enumerant Value => FunctionParameterAttribute.Enumerant.NoAlias;
            public new static NoAlias Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new NoAlias();
                return res;
            }
        }
        public class NoCapture: FunctionParameterAttribute
        {
            public override Enumerant Value => FunctionParameterAttribute.Enumerant.NoCapture;
            public new static NoCapture Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new NoCapture();
                return res;
            }
        }
        public class NoWrite: FunctionParameterAttribute
        {
            public override Enumerant Value => FunctionParameterAttribute.Enumerant.NoWrite;
            public new static NoWrite Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new NoWrite();
                return res;
            }
        }
        public class NoReadWrite: FunctionParameterAttribute
        {
            public override Enumerant Value => FunctionParameterAttribute.Enumerant.NoReadWrite;
            public new static NoReadWrite Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new NoReadWrite();
                return res;
            }
        }

        public abstract Enumerant Value { get; }

        public static FunctionParameterAttribute Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                case Enumerant.Zext :
                    return Zext.Parse(reader, wordCount - 1);
                case Enumerant.Sext :
                    return Sext.Parse(reader, wordCount - 1);
                case Enumerant.ByVal :
                    return ByVal.Parse(reader, wordCount - 1);
                case Enumerant.Sret :
                    return Sret.Parse(reader, wordCount - 1);
                case Enumerant.NoAlias :
                    return NoAlias.Parse(reader, wordCount - 1);
                case Enumerant.NoCapture :
                    return NoCapture.Parse(reader, wordCount - 1);
                case Enumerant.NoWrite :
                    return NoWrite.Parse(reader, wordCount - 1);
                case Enumerant.NoReadWrite :
                    return NoReadWrite.Parse(reader, wordCount - 1);
                default:
                    throw new IndexOutOfRangeException("Unknown FunctionParameterAttribute "+id);
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