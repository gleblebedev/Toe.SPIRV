using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
}
