using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public class GroupOperation : ValueEnum
    {
        public GroupOperation(Enumerant value)
        {
            Value = value;
        }

        public enum Enumerant
        {
            [Capability(Capability.Enumerant.Kernel)]
            Reduce = 0,

            [Capability(Capability.Enumerant.Kernel)]
            InclusiveScan = 1,

            [Capability(Capability.Enumerant.Kernel)]
            ExclusiveScan = 2
        }

        public Enumerant Value { get; }

        public static GroupOperation Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                default:
                    return new GroupOperation(id);
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
            while (reader.Position < end) res.Add(Parse(reader, end - reader.Position));
            return res;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}