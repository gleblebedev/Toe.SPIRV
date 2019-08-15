using System.Numerics;
using System.Runtime.InteropServices;

namespace Toe.SPIRV.CustomTool
{
    [StructLayout(LayoutKind.Explicit)]
    public struct SampleStructure
    {
        [FieldOffset(12)]
        public Vector4 val;
    }
}