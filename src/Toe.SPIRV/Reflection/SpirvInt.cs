namespace Toe.SPIRV.Reflection
{
    public class SpirvInt : SpirvTypeBase
    {
        private readonly uint _width;
        private readonly bool _signed;

        internal SpirvInt(uint width, bool signed) : base(GetType(width, signed))
        {
            _width = width;
            _signed = signed;
        }

        public override uint SizeInBytes => _width / 8;

        public static SpirvType GetType(uint width, bool signed)
        {
            switch (width)
            {
                case 8:
                    return signed ? SpirvType.SByte : SpirvType.Byte;
                case 16:
                    return signed ? SpirvType.Short : SpirvType.UShort;
                case 32:
                    return signed ? SpirvType.Int : SpirvType.UInt;
                default:
                    return SpirvType.CustomInt;
            }
        }

        public override string ToString()
        {
            switch (Type)
            {
                case SpirvType.SByte:
                    return "sbyte";
                case SpirvType.Byte:
                    return "byte";
                case SpirvType.Short:
                    return "short";
                case SpirvType.UShort:
                    return "ushort";
                case SpirvType.Int:
                    return "int";
                case SpirvType.UInt:
                    return "uint";
                default:
                    return (_signed ?"u":"")+"int"+_width;
            }
        }
    }
}