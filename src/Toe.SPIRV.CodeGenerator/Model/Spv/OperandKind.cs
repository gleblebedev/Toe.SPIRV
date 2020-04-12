using System.Collections.Generic;

namespace Toe.SPIRV.CodeGenerator.Model.Spv
{
    public partial class OperandKind
    {
        public string category { get; set; }
        public string kind { get; set; }
        public List<Enumerant> enumerants { get; set; }
        public string doc { get; set; }
        public List<string> bases { get; set; }
    }
}