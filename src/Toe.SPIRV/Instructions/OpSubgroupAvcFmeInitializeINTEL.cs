using System.Collections.Generic;
using Toe.SPIRV.Spv;


namespace Toe.SPIRV.Instructions
{
    public partial class OpSubgroupAvcFmeInitializeINTEL: InstructionWithId
    {
        public OpSubgroupAvcFmeInitializeINTEL()
        {
        }

        public override Op OpCode { get { return Op.OpSubgroupAvcFmeInitializeINTEL; } }
        
        /// <summary>
        /// Returns true if instruction has IdResult field.
        /// </summary>
        public override bool HasResultId => true;

        /// <summary>
        /// Returns true if instruction has IdResultType field.
        /// </summary>
        public override bool HasResultType => true;

        public Spv.IdRef IdResultType { get; set; }

        public Spv.IdRef SrcCoord { get; set; }

        public Spv.IdRef MotionVectors { get; set; }

        public Spv.IdRef MajorShapes { get; set; }

        public Spv.IdRef MinorShapes { get; set; }

        public Spv.IdRef Direction { get; set; }

        public Spv.IdRef PixelResolution { get; set; }

        public Spv.IdRef SadAdjustment { get; set; }

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
            SrcCoord = Spv.IdRef.Parse(reader, end-reader.Position);
            MotionVectors = Spv.IdRef.Parse(reader, end-reader.Position);
            MajorShapes = Spv.IdRef.Parse(reader, end-reader.Position);
            MinorShapes = Spv.IdRef.Parse(reader, end-reader.Position);
            Direction = Spv.IdRef.Parse(reader, end-reader.Position);
            PixelResolution = Spv.IdRef.Parse(reader, end-reader.Position);
            SadAdjustment = Spv.IdRef.Parse(reader, end-reader.Position);
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
            wordCount += SrcCoord.GetWordCount();
            wordCount += MotionVectors.GetWordCount();
            wordCount += MajorShapes.GetWordCount();
            wordCount += MinorShapes.GetWordCount();
            wordCount += Direction.GetWordCount();
            wordCount += PixelResolution.GetWordCount();
            wordCount += SadAdjustment.GetWordCount();
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
            SrcCoord.Write(writer);
            MotionVectors.Write(writer);
            MajorShapes.Write(writer);
            MinorShapes.Write(writer);
            Direction.Write(writer);
            PixelResolution.Write(writer);
            SadAdjustment.Write(writer);
        }

        partial void WriteExtras(WordWriter writer);

        public override string ToString()
        {
            return $"{IdResultType} {IdResult} = {OpCode} {SrcCoord} {MotionVectors} {MajorShapes} {MinorShapes} {Direction} {PixelResolution} {SadAdjustment}";
        }
    }
}
