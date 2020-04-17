using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public abstract partial class RayQueryCandidateIntersectionType : ValueEnum
    {
        public enum Enumerant
        {
            [Capability(Capability.Enumerant.RayQueryProvisionalKHR)]
            RayQueryCandidateIntersectionTriangleKHR = 0,
            [Capability(Capability.Enumerant.RayQueryProvisionalKHR)]
            RayQueryCandidateIntersectionAABBKHR = 1,
        }

        public class RayQueryCandidateIntersectionTriangleKHR: RayQueryCandidateIntersectionType
        {
            public override Enumerant Value => RayQueryCandidateIntersectionType.Enumerant.RayQueryCandidateIntersectionTriangleKHR;
            public new static RayQueryCandidateIntersectionTriangleKHR Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new RayQueryCandidateIntersectionTriangleKHR();
                return res;
            }
        }
        public class RayQueryCandidateIntersectionAABBKHR: RayQueryCandidateIntersectionType
        {
            public override Enumerant Value => RayQueryCandidateIntersectionType.Enumerant.RayQueryCandidateIntersectionAABBKHR;
            public new static RayQueryCandidateIntersectionAABBKHR Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new RayQueryCandidateIntersectionAABBKHR();
                return res;
            }
        }

        public abstract Enumerant Value { get; }

        public static RayQueryCandidateIntersectionType Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                case Enumerant.RayQueryCandidateIntersectionTriangleKHR :
                    return RayQueryCandidateIntersectionTriangleKHR.Parse(reader, wordCount - 1);
                case Enumerant.RayQueryCandidateIntersectionAABBKHR :
                    return RayQueryCandidateIntersectionAABBKHR.Parse(reader, wordCount - 1);
                default:
                    throw new IndexOutOfRangeException("Unknown RayQueryCandidateIntersectionType "+id);
            }
        }
        
        public static RayQueryCandidateIntersectionType ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<RayQueryCandidateIntersectionType> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<RayQueryCandidateIntersectionType>();
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