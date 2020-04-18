using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public abstract partial class RayQueryIntersection : ValueEnum
    {
        public enum Enumerant
        {
            [Capability(Capability.Enumerant.RayQueryProvisionalKHR)]
            RayQueryCandidateIntersectionKHR = 0,
            [Capability(Capability.Enumerant.RayQueryProvisionalKHR)]
            RayQueryCommittedIntersectionKHR = 1,
        }

        public class RayQueryCandidateIntersectionKHR: RayQueryIntersection
        {
            public static readonly RayQueryCandidateIntersectionKHR Instance = new RayQueryCandidateIntersectionKHR();
            public override Enumerant Value => RayQueryIntersection.Enumerant.RayQueryCandidateIntersectionKHR;
            public new static RayQueryCandidateIntersectionKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class RayQueryCommittedIntersectionKHR: RayQueryIntersection
        {
            public static readonly RayQueryCommittedIntersectionKHR Instance = new RayQueryCommittedIntersectionKHR();
            public override Enumerant Value => RayQueryIntersection.Enumerant.RayQueryCommittedIntersectionKHR;
            public new static RayQueryCommittedIntersectionKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }

        public abstract Enumerant Value { get; }

        public static RayQueryIntersection Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                case Enumerant.RayQueryCandidateIntersectionKHR :
                    return RayQueryCandidateIntersectionKHR.Parse(reader, wordCount - 1);
                case Enumerant.RayQueryCommittedIntersectionKHR :
                    return RayQueryCommittedIntersectionKHR.Parse(reader, wordCount - 1);
                default:
                    throw new IndexOutOfRangeException("Unknown RayQueryIntersection "+id);
            }
        }
        
        public static RayQueryIntersection ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<RayQueryIntersection> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<RayQueryIntersection>();
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