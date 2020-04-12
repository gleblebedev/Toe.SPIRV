using System.Collections.Generic;

namespace Toe.SPIRV.CodeGenerator.Model.Spv
{
    public class Meta
    {
        public List<List<string>> Comment { get; set; }
        public int MagicNumber { get; set; }
        public int Version { get; set; }
        public int Revision { get; set; }
        public int OpCodeMask { get; set; }
        public int WordCountShift { get; set; }
    }
}