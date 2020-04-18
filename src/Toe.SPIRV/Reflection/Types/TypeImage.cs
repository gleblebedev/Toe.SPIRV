using System.Collections.Generic;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Types
{
    public partial class TypeImage : SpirvTypeBase
    {
        public TypeImage()
        {
        }

        public Node SampledType { get; set; }
        public Spv.Dim Dim { get; set; }
        public uint Depth { get; set; }
        public uint Arrayed { get; set; }
        public uint MS { get; set; }
        public uint Sampled { get; set; }
        public Spv.ImageFormat ImageFormat { get; set; }
        public Spv.AccessQualifier AccessQualifier { get; set; }
      
        partial void SetUp(OpTypeImage op, SpirvInstructionTreeBuilder treeBuilder)
        {
            SampledType = treeBuilder.GetNode(op.SampledType);
            Dim = op.Dim;
            Depth = op.Depth;
            Arrayed = op.Arrayed;
            MS = op.MS;
            Sampled = op.Sampled;
            ImageFormat = op.ImageFormat;
            AccessQualifier = op.AccessQualifier;
        }
    }
}