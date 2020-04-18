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
            public static readonly Reduce Instance = new Reduce();
            public override Enumerant Value => GroupOperation.Enumerant.Reduce;
            public new static Reduce Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class InclusiveScan: GroupOperation
        {
            public static readonly InclusiveScan Instance = new InclusiveScan();
            public override Enumerant Value => GroupOperation.Enumerant.InclusiveScan;
            public new static InclusiveScan Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class ExclusiveScan: GroupOperation
        {
            public static readonly ExclusiveScan Instance = new ExclusiveScan();
            public override Enumerant Value => GroupOperation.Enumerant.ExclusiveScan;
            public new static ExclusiveScan Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class ClusteredReduce: GroupOperation
        {
            public static readonly ClusteredReduce Instance = new ClusteredReduce();
            public override Enumerant Value => GroupOperation.Enumerant.ClusteredReduce;
            public new static ClusteredReduce Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class PartitionedReduceNV: GroupOperation
        {
            public static readonly PartitionedReduceNV Instance = new PartitionedReduceNV();
            public override Enumerant Value => GroupOperation.Enumerant.PartitionedReduceNV;
            public new static PartitionedReduceNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class PartitionedInclusiveScanNV: GroupOperation
        {
            public static readonly PartitionedInclusiveScanNV Instance = new PartitionedInclusiveScanNV();
            public override Enumerant Value => GroupOperation.Enumerant.PartitionedInclusiveScanNV;
            public new static PartitionedInclusiveScanNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class PartitionedExclusiveScanNV: GroupOperation
        {
            public static readonly PartitionedExclusiveScanNV Instance = new PartitionedExclusiveScanNV();
            public override Enumerant Value => GroupOperation.Enumerant.PartitionedExclusiveScanNV;
            public new static PartitionedExclusiveScanNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
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