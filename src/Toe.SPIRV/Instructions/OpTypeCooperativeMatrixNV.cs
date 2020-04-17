using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpTypeCooperativeMatrixNV: TypeInstruction
    {
        public OpTypeCooperativeMatrixNV()
        {
        }

        public override Op OpCode { get { return Op.OpTypeCooperativeMatrixNV; } }

        public Spv.IdRef ComponentType { get; set; }

        public uint Execution { get; set; }

        public Spv.IdRef Rows { get; set; }

        public Spv.IdRef Columns { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("ComponentType", ComponentType);
            yield return new ReferenceProperty("Rows", Rows);
            yield return new ReferenceProperty("Columns", Columns);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            ComponentType = Spv.IdRef.Parse(reader, end-reader.Position);
            Execution = Spv.IdScope.Parse(reader, end-reader.Position);
            Rows = Spv.IdRef.Parse(reader, end-reader.Position);
            Columns = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResult.GetWordCount();
            wordCount += ComponentType.GetWordCount();
            wordCount += Execution.GetWordCount();
            wordCount += Rows.GetWordCount();
            wordCount += Columns.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResult.Write(writer);
            ComponentType.Write(writer);
            Execution.Write(writer);
            Rows.Write(writer);
            Columns.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResult} = {OpCode} {ComponentType} {Execution} {Rows} {Columns}";
        }
    }
}
