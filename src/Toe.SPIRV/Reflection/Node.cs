using System;
using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Nodes;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public abstract class Node
    {
        private List<Decoration> _decorations;

        public abstract Op OpCode { get; }

        public string DebugName { get; set; }


        public virtual SpirvTypeBase GetResultType()
        {
            return null;
        }

        public virtual ExecutableNode GetNext()
        {
            return null;
        }

        public virtual IEnumerable<NodePin> EnterPins
        {
            get { return Enumerable.Empty<NodePin>(); }
        }

        public virtual IEnumerable<NodePinWithConnection> ExitPins
        {
            get { return Enumerable.Empty<NodePinWithConnection>(); }
        }

        public virtual IEnumerable<NodePinWithConnection> InputPins
        {
            get { return Enumerable.Empty<NodePinWithConnection>(); }
        }

        public virtual IEnumerable<NodePin> OutputPins
        {
            get { return Enumerable.Empty<NodePin>(); }
        }

        protected NodePinWithConnection CreateInputPin(string name, Node node)
        {
            if (node == null)
                return new NodePinWithConnection(this, name, null, null);
            var output = node.OutputPins.First();
            return new NodePinWithConnection(this, name, output.Type, output);
        }
        protected NodePinWithConnection CreateExitPin(string name, Node node)
        {
            if (node == null)
                return new NodePinWithConnection(this, name, null, null);
            var input = node.EnterPins.First();
            return new NodePinWithConnection(this, name, input.Type, input);
        }

        public virtual void SetUp(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
        }

        public virtual void SetUpDecorations(Instruction op, SpirvInstructionTreeBuilder treeBuilder)
        {
            DebugName = treeBuilder.GetDebugName(op);
            foreach (var instruction in treeBuilder.GetDecorations(op))
            {
                switch (instruction.OpCode)
                {
                    case Op.OpDecorate:
                        SetUpDecoration(((OpDecorate)instruction).Decoration, treeBuilder);
                        break;
                    case Op.OpMemberDecorate:
                        SetUpDecoration(((OpMemberDecorate)instruction).Decoration, treeBuilder);
                        break;
                    default:
                        throw new NotImplementedException("Decoration instruction " + instruction.OpCode + " not yet implemented by "+this.GetType().Name+" class.");
                }
            }
        }

        protected virtual void SetUpDecoration(Decoration decoration, SpirvInstructionTreeBuilder treeBuilder)
        {
            AddDecoration(decoration);
        }

        protected virtual void AddDecoration(Decoration decoration)
        {
            if (_decorations == null)
            {
                _decorations = new List<Decoration>();
            }

            _decorations.Add(decoration);
        }

        public virtual bool RemoveDecoration(Decoration.Enumerant decoration)
        {
            if (_decorations == null)
            {
                return false;
            }

            for (var index = 0; index < _decorations.Count; index++)
            {
                if (_decorations[index].Value == decoration)
                {
                    _decorations.RemoveAt(index);
                    return true;
                }
            }

            return false;
        }


        public virtual IEnumerable<Node> BuildDecorations()
        {
            if (DebugName != null)
            {
                yield return new Name() {Value = DebugName, Target = this};
            }

            if (_decorations != null)
            {
                foreach (var decoration in _decorations)
                {
                    yield return new Decorate() {Target = this, Decoration = decoration};
                }
            }
        }
    }
}
