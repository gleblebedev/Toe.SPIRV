using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public abstract partial class GroupOperation : ValueEnum
    {
        public enum Enumerant
        {
            [Capability(Capability.Enumerant.Kernel)]
            [Capability(Capability.Enumerant.GroupNonUniformArithmetic)]
            [Capability(Capability.Enumerant.GroupNonUniformBallot)]
            Reduce = 0,
            [Capability(Capability.Enumerant.Kernel)]
            [Capability(Capability.Enumerant.GroupNonUniformArithmetic)]
            [Capability(Capability.Enumerant.GroupNonUniformBallot)]
            InclusiveScan = 1,
            [Capability(Capability.Enumerant.Kernel)]
            [Capability(Capability.Enumerant.GroupNonUniformArithmetic)]
            [Capability(Capability.Enumerant.GroupNonUniformBallot)]
            ExclusiveScan = 2,
            [Capability(Capability.Enumerant.GroupNonUniformClustered)]
            ClusteredReduce = 3,
            [Capability(Capability.Enumerant.GroupNonUniformPartitionedNV)]
            PartitionedReduceNV = 6,
            [Capability(Capability.Enumerant.GroupNonUniformPartitionedNV)]
            PartitionedInclusiveScanNV = 7,
            [Capability(Capability.Enumerant.GroupNonUniformPartitionedNV)]
            PartitionedExclusiveScanNV = 8,
        }

        public class Reduce: GroupOperation
        {
            public override Enumerant Value => GroupOperation.Enumerant.Reduce;
            public new static Reduce Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Reduce();
                return res;
            }
        }
        public class InclusiveScan: GroupOperation
        {
            public override Enumerant Value => GroupOperation.Enumerant.InclusiveScan;
            public new static InclusiveScan Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new InclusiveScan();
                return res;
            }
        }
        public class ExclusiveScan: GroupOperation
        {
            public override Enumerant Value => GroupOperation.Enumerant.ExclusiveScan;
            public new static ExclusiveScan Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ExclusiveScan();
                return res;
            }
        }
        public class ClusteredReduce: GroupOperation
        {
            public override Enumerant Value => GroupOperation.Enumerant.ClusteredReduce;
            public new static ClusteredReduce Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ClusteredReduce();
                return res;
            }
        }
        public class PartitionedReduceNV: GroupOperation
        {
            public override Enumerant Value => GroupOperation.Enumerant.PartitionedReduceNV;
            public new static PartitionedReduceNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new PartitionedReduceNV();
                return res;
            }
        }
        public class PartitionedInclusiveScanNV: GroupOperation
        {
            public override Enumerant Value => GroupOperation.Enumerant.PartitionedInclusiveScanNV;
            public new static PartitionedInclusiveScanNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new PartitionedInclusiveScanNV();
                return res;
            }
        }
        public class PartitionedExclusiveScanNV: GroupOperation
        {
            public override Enumerant Value => GroupOperation.Enumerant.PartitionedExclusiveScanNV;
            public new static PartitionedExclusiveScanNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new PartitionedExclusiveScanNV();
                return res;
            }
        }

        public abstract Enumerant Value { get; }

        public static GroupOperation Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                case Enumerant.Reduce :
                    return Reduce.Parse(reader, wordCount - 1);
                case Enumerant.InclusiveScan :
                    return InclusiveScan.Parse(reader, wordCount - 1);
                case Enumerant.ExclusiveScan :
                    return ExclusiveScan.Parse(reader, wordCount - 1);
                case Enumerant.ClusteredReduce :
                    return ClusteredReduce.Parse(reader, wordCount - 1);
                case Enumerant.PartitionedReduceNV :
                    return PartitionedReduceNV.Parse(reader, wordCount - 1);
                case Enumerant.PartitionedInclusiveScanNV :
                    return PartitionedInclusiveScanNV.Parse(reader, wordCount - 1);
                case Enumerant.PartitionedExclusiveScanNV :
                    return PartitionedExclusiveScanNV.Parse(reader, wordCount - 1);
                default:
                    throw new IndexOutOfRangeException("Unknown GroupOperation "+id);
            }
        }
        
        public static GroupOperation ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<GroupOperation> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<GroupOperation>();
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