using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpGetKernelWorkGroupSize : InstructionWithId
    {
        public override Op OpCode => Op.OpGetKernelWorkGroupSize;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IdRef Invoke { get; set; }
        public IdRef Param { get; set; }
        public IdRef ParamSize { get; set; }
        public IdRef ParamAlign { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Invoke", Invoke);
            yield return new ReferenceProperty("Param", Param);
            yield return new ReferenceProperty("ParamSize", ParamSize);
            yield return new ReferenceProperty("ParamAlign", ParamAlign);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Invoke = IdRef.Parse(reader, end - reader.Position);
            Param = IdRef.Parse(reader, end - reader.Position);
            ParamSize = IdRef.Parse(reader, end - reader.Position);
            ParamAlign = IdRef.Parse(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Invoke} {Param} {ParamSize} {ParamAlign}";
        }
    }
}