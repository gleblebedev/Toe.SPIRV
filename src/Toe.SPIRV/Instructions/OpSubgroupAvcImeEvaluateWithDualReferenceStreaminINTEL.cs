using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSubgroupAvcImeEvaluateWithDualReferenceStreaminINTEL: InstructionWithId
    {
        public OpSubgroupAvcImeEvaluateWithDualReferenceStreaminINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpSubgroupAvcImeEvaluateWithDualReferenceStreaminINTEL; } }
        
        /// <summary>
        /// Returns true if instruction has IdResult field.
        /// </summary>
        public override bool HasResultId => true;

        /// <summary>
        /// Returns true if instruction has IdResultType field.
        /// </summary>
        public override bool HasResultType => true;

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef SrcImage { get; set; }

        public Spv.IdRef FwdRefImage { get; set; }

        public Spv.IdRef BwdRefImage { get; set; }

        public Spv.IdRef Payload { get; set; }

        public Spv.IdRef StreaminComponents { get; set; }

        /// <summary>
        /// Read complete instruction from the bytecode source.
        /// </summary>
        /// <param name="reader">Bytecode source.</param>
        /// <param name="end">Index of a next word right after this instruction.</param>
        public override void Parse(WordReader reader, uint end)
        {
            IdResultType = Spv.IdResultType.Parse(reader, end-reader.Position);
            IdResult = Spv.IdResult.Parse(reader, end-reader.Position);
            reader.Instructions.Add(this);
            ParseOperands(reader, end);
            PostParse(reader, end);
        }

        /// <summary>
        /// Read instruction operands from the bytecode source.
        /// </summary>
        /// <param name="reader">Bytecode source.</param>
        /// <param name="end">Index of a next word right after this instruction.</param>
        public override void ParseOperands(WordReader reader, uint end)
        {
            SrcImage = Spv.IdRef.Parse(reader, end-reader.Position);
            FwdRefImage = Spv.IdRef.Parse(reader, end-reader.Position);
            BwdRefImage = Spv.IdRef.Parse(reader, end-reader.Position);
            Payload = Spv.IdRef.Parse(reader, end-reader.Position);
            StreaminComponents = Spv.IdRef.Parse(reader, end-reader.Position);
        }

        /// <summary>
        /// Process parsed instruction if required.
        /// </summary>
        /// <param name="reader">Bytecode source.</param>
        /// <param name="end">Index of a next word right after this instruction.</param>
        partial void PostParse(WordReader reader, uint end);

        /// <summary>
        /// Calculate number of words to fit complete instruction bytecode.
        /// </summary>
        /// <returns>Number of words in instruction bytecode.</returns>
        public override uint GetWordCount()
        {
            uint wordCount = 0;
            wordCount += IdResultType.GetWordCount();
            wordCount += IdResult.GetWordCount();
            wordCount += SrcImage.GetWordCount();
            wordCount += FwdRefImage.GetWordCount();
            wordCount += BwdRefImage.GetWordCount();
            wordCount += Payload.GetWordCount();
            wordCount += StreaminComponents.GetWordCount();
            return wordCount;
        }

        /// <summary>
        /// Write instruction into bytecode stream.
        /// </summary>
        /// <param name="writer">Bytecode writer.</param>
        public override void Write(WordWriter writer)
        {
            IdResultType.Write(writer);
            IdResult.Write(writer);
            WriteOperands(writer);
            WriteExtras(writer);
        }

        /// <summary>
        /// Write instruction operands into bytecode stream.
        /// </summary>
        /// <param name="writer">Bytecode writer.</param>
        public override void WriteOperands(WordWriter writer)
        {
            SrcImage.Write(writer);
            FwdRefImage.Write(writer);
            BwdRefImage.Write(writer);
            Payload.Write(writer);
            StreaminComponents.Write(writer);
        }

        partial void WriteExtras(WordWriter writer);

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {SrcImage} {FwdRefImage} {BwdRefImage} {Payload} {StreaminComponents}";
        }
    }
}
