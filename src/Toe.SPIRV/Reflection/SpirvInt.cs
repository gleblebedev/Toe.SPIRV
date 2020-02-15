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

        public static SpirvTypeCategory GetType(uint width, bool signed)
        {
            switch (width)
            {
                case 8:
                    return signed ? SpirvTypeCategory.SByte : SpirvTypeCategory.Byte;
                case 16:
                    return signed ? SpirvTypeCategory.Short : SpirvTypeCategory.UShort;
                case 32:
                    return signed ? SpirvTypeCategory.Int : SpirvTypeCategory.UInt;
                default:
                    return SpirvTypeCategory.CustomInt;
            }
        }

        public override string ToString()
        {
            switch (TypeCategory)
            {
                case SpirvTypeCategory.SByte:
                    return "sbyte";
                case SpirvTypeCategory.Byte:
                    return "byte";
                case SpirvTypeCategory.Short:
                    return "short";
                case SpirvTypeCategory.UShort:
                    return "ushort";
                case SpirvTypeCategory.Int:
                    return "int";
                case SpirvTypeCategory.UInt:
                    return "uint";
                default:
                    return (_signed ?"u":"")+"int"+_width;
            }
        }
    }
}