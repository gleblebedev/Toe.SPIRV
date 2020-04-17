using System.Collections.Generic;
using Toe.SPIRV.CodeGenerator.Model.Spv;

namespace Toe.SPIRV.CodeGenerator.Model.Grammar
{
    public class SpirvOperandDescription
    {
        public string Name { get; set; }
        public SpirvOperandCategory Category { get; set; }
        public SpirvOperandKind Kind { get; set; }
        public List<Enumerant> Enumerants { get; set; }
        public string Doc { get; set; }
        public List<string> Bases { get; set; }
    }
}