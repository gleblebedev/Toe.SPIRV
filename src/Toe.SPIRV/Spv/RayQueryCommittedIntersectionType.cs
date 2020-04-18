using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public abstract partial class RayQueryCommittedIntersectionType : ValueEnum
    {
        public enum Enumerant
        {
            [Capability(Capability.Enumerant.RayQueryProvisionalKHR)]
            RayQueryCommittedIntersectionNoneKHR = 0,
            [Capability(Capability.Enumerant.RayQueryProvisionalKHR)]
            RayQueryCommittedIntersectionTriangleKHR = 1,
            [Capability(Capability.Enumerant.RayQueryProvisionalKHR)]
            RayQueryCommittedIntersectionGeneratedKHR = 2,
        }

        public class RayQueryCommittedIntersectionNoneKHR: RayQueryCommittedIntersectionType
        {
            public static readonly RayQueryCommittedIntersectionNoneKHR Instance = new RayQueryCommittedIntersectionNoneKHR();
            public override Enumerant Value => RayQueryCommittedIntersectionType.Enumerant.RayQueryCommittedIntersectionNoneKHR;
            public new static RayQueryCommittedIntersectionNoneKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class RayQueryCommittedIntersectionTriangleKHR: RayQueryCommittedIntersectionType
        {
            public static readonly RayQueryCommittedIntersectionTriangleKHR Instance = new RayQueryCommittedIntersectionTriangleKHR();
            public override Enumerant Value => RayQueryCommittedIntersectionType.Enumerant.RayQueryCommittedIntersectionTriangleKHR;
            public new static RayQueryCommittedIntersectionTriangleKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class RayQueryCommittedIntersectionGeneratedKHR: RayQueryCommittedIntersectionType
        {
            public static readonly RayQueryCommittedIntersectionGeneratedKHR Instance = new RayQueryCommittedIntersectionGeneratedKHR();
            public override Enumerant Value => RayQueryCommittedIntersectionType.Enumerant.RayQueryCommittedIntersectionGeneratedKHR;
            public new static RayQueryCommittedIntersectionGeneratedKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }

        public abstract Enumerant Value { get; }

        public static RayQueryCommittedIntersectionType Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                case Enumerant.RayQueryCommittedIntersectionNoneKHR :
                    return RayQueryCommittedIntersectionNoneKHR.Parse(reader, wordCount - 1);
                case Enumerant.RayQueryCommittedIntersectionTriangleKHR :
                    return RayQueryCommittedIntersectionTriangleKHR.Parse(reader, wordCount - 1);
                case Enumerant.RayQueryCommittedIntersectionGeneratedKHR :
                    return RayQueryCommittedIntersectionGeneratedKHR.Parse(reader, wordCount - 1);
                default:
                    throw new IndexOutOfRangeException("Unknown RayQueryCommittedIntersectionType "+id);
            }
        }
        
        public static RayQueryCommittedIntersectionType ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<RayQueryCommittedIntersectionType> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<RayQueryCommittedIntersectionType>();
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