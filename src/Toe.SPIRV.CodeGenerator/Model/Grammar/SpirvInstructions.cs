using System;
using System.Collections.Generic;
using System.Text;
using Toe.SPIRV.CodeGenerator.Model.Spv;

namespace Toe.SPIRV.CodeGenerator.Model.Grammar
{
    public class SpirvInstructions
    {
        public Dictionary<int,SpirvInstruction> Instructions { get; } = new Dictionary<int, SpirvInstruction>();

        public Dictionary<SpirvOperandKind, OperandKind> OperandKinds { get; } = new Dictionary<SpirvOperandKind, OperandKind>();
    }
}
