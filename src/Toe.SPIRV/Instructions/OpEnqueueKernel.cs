using System.Collections.Generic;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class OpEnqueueKernel : InstructionWithId
    {
        public override Op OpCode => Op.OpEnqueueKernel;

        public IdRef<TypeInstruction> IdResultType { get; set; }
        public IdRef Queue { get; set; }
        public IdRef Flags { get; set; }
        public IdRef NDRange { get; set; }
        public IdRef NumEvents { get; set; }
        public IdRef WaitEvents { get; set; }
        public IdRef RetEvent { get; set; }
        public IdRef Invoke { get; set; }
        public IdRef Param { get; set; }
        public IdRef ParamSize { get; set; }
        public IdRef ParamAlign { get; set; }
        public IList<IdRef> LocalSize { get; set; }

        public override IEnumerable<ReferenceProperty> GetReferences()
        {
            yield return new ReferenceProperty("Queue", Queue);
            yield return new ReferenceProperty("Flags", Flags);
            yield return new ReferenceProperty("NDRange", NDRange);
            yield return new ReferenceProperty("NumEvents", NumEvents);
            yield return new ReferenceProperty("WaitEvents", WaitEvents);
            yield return new ReferenceProperty("RetEvent", RetEvent);
            yield return new ReferenceProperty("Invoke", Invoke);
            yield return new ReferenceProperty("Param", Param);
            yield return new ReferenceProperty("ParamSize", ParamSize);
            yield return new ReferenceProperty("ParamAlign", ParamAlign);
            for (var i = 0; i < LocalSize.Count; ++i)
                yield return new ReferenceProperty("LocalSize" + i, LocalSize[i]);
        }

        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount - 1;
            IdResultType = Spv.IdResultType.Parse(reader, end - reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end - reader.Position);
            reader.Instructions.Add(this);
            Queue = IdRef.Parse(reader, end - reader.Position);
            Flags = IdRef.Parse(reader, end - reader.Position);
            NDRange = IdRef.Parse(reader, end - reader.Position);
            NumEvents = IdRef.Parse(reader, end - reader.Position);
            WaitEvents = IdRef.Parse(reader, end - reader.Position);
            RetEvent = IdRef.Parse(reader, end - reader.Position);
            Invoke = IdRef.Parse(reader, end - reader.Position);
            Param = IdRef.Parse(reader, end - reader.Position);
            ParamSize = IdRef.Parse(reader, end - reader.Position);
            ParamAlign = IdRef.Parse(reader, end - reader.Position);
            LocalSize = IdRef.ParseCollection(reader, end - reader.Position);
        }

        public override string ToString()
        {
            return
                $"{IdResultType} {IdResult} = {OpCode} {Queue} {Flags} {NDRange} {NumEvents} {WaitEvents} {RetEvent} {Invoke} {Param} {ParamSize} {ParamAlign} {LocalSize}";
        }
    }
}