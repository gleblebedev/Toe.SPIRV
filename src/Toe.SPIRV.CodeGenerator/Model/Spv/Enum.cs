using System.Collections.Generic;

namespace Toe.SPIRV.CodeGenerator.Model.Spv
{
    public partial class Enum
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Dictionary<string, int> Values { get; set; }
    }
}