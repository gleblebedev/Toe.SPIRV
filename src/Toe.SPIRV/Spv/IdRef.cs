using System;
using System.Collections.Generic;
using Toe.SPIRV.Instructions;

namespace Toe.SPIRV.Spv
{
    public class IdRef
    {
        private readonly InstructionRegistry _registry;
        private readonly uint _id;
        private InstructionWithId _instruction;

        public IdRef(uint id, InstructionRegistry registry)
        {
            _id = id;
            _registry = registry;
        }

        public IdRef(InstructionWithId instruction)
        {
            _id = instruction.IdResult;
            if (_id == 0)
                throw new ArgumentException("Instruction IdResult should not be zeo.");
            _instruction = instruction;
        }

        public static implicit operator IdRef(InstructionWithId instruction)
        {
            if (instruction == null)
                return null;
            return new IdRef(instruction);
        }

        public static implicit operator IdRef(Instruction instruction)
        {
            if (instruction == null)
                return null;
            return new IdRef((InstructionWithId)instruction);
        }

        public static implicit operator InstructionWithId(IdRef idRef)
        {
            return idRef.Instruction;
        }

        public IdRef(InstructionWithId instruction, InstructionRegistry registry)
        {
            _id = instruction.IdResult;
            _instruction = instruction;
            _registry = registry;
        }

        public InstructionWithId Instruction
        {
            get
            {
                if (_instruction != null)
                    return _instruction;
                return _instruction = _registry[_id];
            }
        }

        public uint Id
        {
            get
            {
                if (_id != 0)
                    return _id;
                if (_instruction == null)
                    return _id;
                throw new NotImplementedException();
            }
        }

        public static IdRef Parse(WordReader reader, uint wordCount)
        {
            var id = reader.ReadWord();
            return new IdRef(id, reader.Instructions);
        }

        public static IdRef ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<IdRef> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<IdRef>();
            while (reader.Position < end) res.Add(Parse(reader, end - reader.Position));
            return res;
        }

        public override string ToString()
        {
            if (_id != 0)
            {
                if (_instruction != null) return $"#{_id}({_instruction.OpName?.Value ?? _instruction.ToString()})";
                return $"#{_id}";
            }

            if (_instruction != null && !string.IsNullOrWhiteSpace(_instruction.OpName?.Value))
                return $"{_instruction.OpName.Value}";
            if (_instruction != null)
                return _instruction.ToString();
            return "<null>";
        }

        public virtual uint GetWordCount()
        {
            return 1;
        }
        public virtual void Write(WordWriter writer)
        {
            writer.WriteWord(_id);
        }
    }
}