using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpSubgroupBlockWriteINTEL : Instruction
    {
        public override Op OpCode => Op.OpSubgroupBlockWriteINTEL;

        public IdRef Ptr { get; set; }
        public IdRef Data { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Ptr", Ptr);
            yield return new ReferenceProperty("Data", Data);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            Ptr = IdRef.Parse(reader, end - reader.Position);
            Data = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{OpCode} {Ptr} {Data}";
        }
    }
}