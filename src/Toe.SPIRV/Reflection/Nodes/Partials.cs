using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection.Operands;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
    public partial class Constant
    {
        public Constant(SpirvTypeBase type, NumberLiteral value)
        {
            ResultType = type;
            Value = value;
        }
    }
    public partial class Function
    {
        public IList<FunctionParameter> Parameters { get; } = new List<FunctionParameter>();

        public override IEnumerable<NodePinWithConnection> InputPins
        {
            get
            {
                int index = 0;
                foreach (var parameter in Parameters)
                {
                    yield return new NodePinWithConnection(this, "parameter"+index, parameter.ResultType, parameter.OutputPins.First());
                }
            }
        }
    }

    public partial class MemoryModel
    {
        public static readonly MemoryModel GLSL450 = new MemoryModel(){AddressingModel = new AddressingModel.Logical(), Value = new Spv.MemoryModel.GLSL450() };
    }

    public partial class Variable
    {
        public uint? DescriptorSet { get; set; }

        public uint? BindingPoint { get; set; }

        public uint? Location { get; set; }

        public override void AddDecoration(Decoration decoration)
        {
            switch (decoration.Value)
            {
                case Decoration.Enumerant.Location:
                    Location = ((Decoration.Location)decoration).LocationValue;
                    return;
                case Decoration.Enumerant.DescriptorSet:
                    DescriptorSet = ((Decoration.DescriptorSet)decoration).DescriptorSetValue;
                    return;
                case Decoration.Enumerant.Binding:
                    BindingPoint = ((Decoration.Binding)decoration).BindingPoint;
                    return;
            }
            base.AddDecoration(decoration);
        }

        public override bool RemoveDecoration(Decoration.Enumerant decoration)
        {
            switch (decoration)
            {
                case Decoration.Enumerant.Location:
                    Location = null;
                    return true;
                case Decoration.Enumerant.DescriptorSet:
                    DescriptorSet = null;
                    return true;
                case Decoration.Enumerant.Binding:
                    BindingPoint = null;
                    return true;
            }
            return base.RemoveDecoration(decoration);
        }

        public override IEnumerable<Node> BuildDecorations()
        {
            return base.BuildDecorations()
                .Concat(BuidlLocation())
                .Concat(BuildDescriptorSet())
                .Concat(Binding());
        }

        private IEnumerable<Node> Binding()
        {
            if (BindingPoint != null)
            {
                yield return new Decorate(){Target = this, Decoration = new Decoration.Binding() {BindingPoint = BindingPoint.Value}};
            }
        }

        private IEnumerable<Node> BuildDescriptorSet()
        {
            if (DescriptorSet != null)
            {
                yield return new Decorate() { Target = this, Decoration = new Decoration.DescriptorSet() {DescriptorSetValue = DescriptorSet.Value} };
            }
        }

        private IEnumerable<Node> BuidlLocation()
        {
            if (Location != null)
            {
                yield return new Decorate() { Target = this, Decoration = new Decoration.Location() {LocationValue = Location.Value} };
            }
        }
    }
}
