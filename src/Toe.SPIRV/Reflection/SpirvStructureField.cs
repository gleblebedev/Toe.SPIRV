namespace Toe.SPIRV.Reflection
{
    public class SpirvStructureField
    {
        private readonly SpirvType _type;
        private readonly string _name;

        public SpirvStructureField(SpirvType type, string name)
        {
            _type = type;
            _name = name;
        }

        public SpirvType Type => _type;
        public string Name => _name;

        public override string ToString()
        {
            return $"{_type} {_name}";
        }
    }
}