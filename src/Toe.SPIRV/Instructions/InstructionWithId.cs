using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public abstract class InstructionWithId : Instruction
    {
        public uint IdResult { get; set; }

        public OpName OpName { get; set; }

        public IList<OpDecorate> Decorations { get; } = new List<OpDecorate>();

        public override bool TryGetResultId(out uint id)
        {
            id = IdResult;
            return true;
        }

        public T FindDecoration<T>() where T : Decoration
        {
            return Decorations.Select(_ => _.Decoration).OfType<T>().FirstOrDefault();
        }

        public Decoration FindDecoration(Decoration.Enumerant id)
        {
            return Decorations.Where(_ => _.Decoration.Value == id).Select(_ => _.Decoration).FirstOrDefault();
        }
    }
}