namespace Toe.SPIRV.Reflection
{
    public class SpirvFloat: SpirvTypeBase
    {
        private readonly uint _width;

        internal SpirvFloat(uint width):base(GetType(width))
        {
            _width = width;
        }

        public override uint SizeInBytes => _width / 8;

        public static SpirvType GetType(uint width)
        {
            switch (width)
            {
                case 16:
                    return SpirvType.Half;
                case 32:
                    return SpirvType.Float;
                case 64:
                    return SpirvType.Double;
                default:
                    return SpirvType.CustomFloat;
            }
        }

        public override string ToString()
        {
            switch (_width)
            {
                case 32:
                    return "float";
                case 64:
                    return "double";
                default:
                    return "float"+_width;
            }
        }
    }
}