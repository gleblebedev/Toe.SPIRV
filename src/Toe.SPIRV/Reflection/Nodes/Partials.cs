using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Nodes
{
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
        partial void SetUpDecorations(IList<OpDecorate> decorates)
        {
            foreach (var decorate in decorates)
            {
                switch (decorate.Decoration.Value)
                {
                    case Decoration.Enumerant.Location:
                        Location = ((Decoration.Location) decorate.Decoration).LocationValue;
                        break;
                    case Decoration.Enumerant.DescriptorSet:
                        DescriptorSet = ((Decoration.DescriptorSet)decorate.Decoration).DescriptorSetValue;
                        break;
                    case Decoration.Enumerant.Binding:
                        BindingPoint = ((Decoration.Binding)decorate.Decoration).BindingPoint;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }
        public uint? DescriptorSet { get; set; }

        public uint? BindingPoint { get; set; }

        public uint? Location { get; set; }

        public override IEnumerable<Decoration> GetDecorations()
        {
            if (Location != null)
            {
                yield return new Decoration.Location() {LocationValue = Location.Value};
            }
            if (DescriptorSet != null)
            {
                yield return new Decoration.DescriptorSet() { DescriptorSetValue = DescriptorSet.Value };
            }
            if (BindingPoint != null)
            {
                yield return new Decoration.Binding() { BindingPoint = BindingPoint.Value };
            }
        }
    }
}
