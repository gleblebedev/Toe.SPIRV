namespace Toe.SPIRV.Reflection
{
    public class SpirvVector : SpirvType
    {
        private readonly uint _componentCount;
        private readonly SpirvType _componentType;
        private string _name;

        public SpirvVector(uint componentCount, SpirvType componentType)
        {
            _componentCount = componentCount;
            _componentType = componentType;
            if (_componentType == SpirvType.Float)
            {
                _name = "vec" + _componentCount;
            }
            else if (_componentType == SpirvType.Bool)
            {
                _name = "bvec" + _componentCount;
            }
            else if (_componentType == SpirvType.Int)
            {
                _name = "ivec" + _componentCount;
            }
            else if (_componentType == SpirvType.UInt)
            {
                _name = "uvec" + _componentCount;
            }
            else if (_componentType == SpirvType.Double)
            {
                _name = "dvec" + _componentCount;
            }
            else
            {
                _name = _componentType.ToString() + _componentCount;
            }
        }

        public override string ToString()
        {
            return _name;
        }
    }
}