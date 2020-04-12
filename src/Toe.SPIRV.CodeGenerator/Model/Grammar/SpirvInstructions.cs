using System;
using System.Collections.Generic;
using System.Text;

namespace Toe.SPIRV.CodeGenerator.Model.Grammar
{
    public class SpirvInstructions
    {
        public Dictionary<int,SpirvInstruction> Instructions { get; } = new Dictionary<int, SpirvInstruction>();
    }
}
