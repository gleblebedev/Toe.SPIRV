using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpGetKernelPreferredWorkGroupSizeMultiple: InstructionWithId
    {
        public OpGetKernelPreferredWorkGroupSizeMultiple()
        {
        }

        public override Op OpCode { get { return Op.OpGetKernelPreferredWorkGroupSizeMultiple; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef Invoke { get; set; }

        public Spv.IdRef Param { get; set; }

        public Spv.IdRef ParamSize { get; set; }

        public Spv.IdRef ParamAlign { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Invoke", Invoke);
            yield return new ReferenceProperty("Param", Param);
            yield return new ReferenceProperty("ParamSize", ParamSize);
            yield return new ReferenceProperty("ParamAlign", ParamAlign);
            yield break;
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            Invoke = Spv.IdRef.Parse(reader, end-reader.Position);
            Param = Spv.IdRef.Parse(reader, end-reader.Position);
            ParamSize = Spv.IdRef.Parse(reader, end-reader.Position);
            ParamAlign = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += Invoke.GetWordCount();
            wordCount += Param.GetWordCount();
            wordCount += ParamSize.GetWordCount();
            wordCount += ParamAlign.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            Invoke.Write(writer);
            Param.Write(writer);
            ParamSize.Write(writer);
            ParamAlign.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Invoke} {Param} {ParamSize} {ParamAlign}";
        }
    }
}
