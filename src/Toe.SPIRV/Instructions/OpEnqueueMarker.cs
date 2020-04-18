using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpEnqueueMarker: InstructionWithId
    {
        public OpEnqueueMarker()
        {
        }

        public override Op OpCode { get { return Op.OpEnqueueMarker; } }

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef Queue { get; set; }

        public Spv.IdRef NumEvents { get; set; }

        public Spv.IdRef WaitEvents { get; set; }

        public Spv.IdRef RetEvent { get; set; }


        public override void Parse(WordReader reader, uint wordCount)
        {
            var end = reader.Position+wordCount-1;
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            Queue = Spv.IdRef.Parse(reader, end-reader.Position);
            NumEvents = Spv.IdRef.Parse(reader, end-reader.Position);
            WaitEvents = Spv.IdRef.Parse(reader, end-reader.Position);
            RetEvent = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += Queue.GetWordCount();
            wordCount += NumEvents.GetWordCount();
            wordCount += WaitEvents.GetWordCount();
            wordCount += RetEvent.GetWordCount();
            return wordCount;
        }

        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            Queue.Write(writer);
            NumEvents.Write(writer);
            WaitEvents.Write(writer);
            RetEvent.Write(writer);
        }

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {Queue} {NumEvents} {WaitEvents} {RetEvent}";
        }
    }
}
