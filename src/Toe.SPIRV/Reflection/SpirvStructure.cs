using System.Collections.Generic;

namespace Toe.SPIRV.Reflection
{
    public class SpirvStructure: SpirvType
    {
        public IList<SpirvStructureField> Fields { get; } = new List<SpirvStructureField>();
    }
}