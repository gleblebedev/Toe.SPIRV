using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public partial class OpTypeStruct : TypeInstruction
    {
        public IList<OpMemberDecorate> MemberDecorations { get; } = new List<OpMemberDecorate>();

        public IList<OpMemberName> MemberNames { get; } = new List<OpMemberName>();

        public override Op OpCode => Op.OpTypeStruct;

        public IList<IdRef> MemberTypes { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            for (var i = 0; i < MemberTypes.Count; ++i)
                yield return new ReferenceProperty("MemberTypes" + i, MemberTypes[i]);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            MemberTypes = IdRef.ParseCollection(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResult} = {OpCode} {MemberTypes}";
        }
    }
}