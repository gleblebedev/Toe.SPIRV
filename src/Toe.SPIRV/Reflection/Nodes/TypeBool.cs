using System.Collections.Generic;
using System.Linq;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection
{
    public partial class SpirvBool : SpirvTypeBase
    {
        public override Op OpCode => Op.OpTypeBool;
    }
}