using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public abstract partial class SourceLanguage : ValueEnum
    {
        public enum Enumerant
        {
            Unknown = 0,
            ESSL = 1,
            GLSL = 2,
            OpenCL_C = 3,
            OpenCL_CPP = 4,
            HLSL = 5,
        }

        public class Unknown: SourceLanguage
        {
            public override Enumerant Value => SourceLanguage.Enumerant.Unknown;
            public new static Unknown Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Unknown();
                return res;
            }
        }
        public class ESSL: SourceLanguage
        {
            public override Enumerant Value => SourceLanguage.Enumerant.ESSL;
            public new static ESSL Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ESSL();
                return res;
            }
        }
        public class GLSL: SourceLanguage
        {
            public override Enumerant Value => SourceLanguage.Enumerant.GLSL;
            public new static GLSL Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new GLSL();
                return res;
            }
        }
        public class OpenCL_C: SourceLanguage
        {
            public override Enumerant Value => SourceLanguage.Enumerant.OpenCL_C;
            public new static OpenCL_C Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new OpenCL_C();
                return res;
            }
        }
        public class OpenCL_CPP: SourceLanguage
        {
            public override Enumerant Value => SourceLanguage.Enumerant.OpenCL_CPP;
            public new static OpenCL_CPP Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new OpenCL_CPP();
                return res;
            }
        }
        public class HLSL: SourceLanguage
        {
            public override Enumerant Value => SourceLanguage.Enumerant.HLSL;
            public new static HLSL Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new HLSL();
                return res;
            }
        }

        public abstract Enumerant Value { get; }

        public static SourceLanguage Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                case Enumerant.Unknown :
                    return Unknown.Parse(reader, wordCount - 1);
                case Enumerant.ESSL :
                    return ESSL.Parse(reader, wordCount - 1);
                case Enumerant.GLSL :
                    return GLSL.Parse(reader, wordCount - 1);
                case Enumerant.OpenCL_C :
                    return OpenCL_C.Parse(reader, wordCount - 1);
                case Enumerant.OpenCL_CPP :
                    return OpenCL_CPP.Parse(reader, wordCount - 1);
                case Enumerant.HLSL :
                    return HLSL.Parse(reader, wordCount - 1);
                default:
                    throw new IndexOutOfRangeException("Unknown SourceLanguage "+id);
            }
        }
        
        public static SourceLanguage ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<SourceLanguage> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<SourceLanguage>();
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