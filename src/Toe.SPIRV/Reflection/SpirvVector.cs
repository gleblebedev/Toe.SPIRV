namespace Toe.SPIRV.Reflection
{
    public class SpirvVector : SpirvTypeBase
    {
        private readonly uint _componentCount;
        private readonly SpirvTypeBase _componentType;

        internal SpirvVector(SpirvTypeBase componentType, uint componentCount):base(GetType(componentType, componentCount))
        {
            _componentCount = componentCount;
            _componentType = componentType;
        }

        public uint ComponentCount => _componentCount;
        public SpirvTypeBase ComponentType => _componentType;

        public override uint Alignment
        {
            get
            {
                switch (_componentCount)
                {
                    case 3:
                        return _componentType.SizeInBytes * 4;
                    case 2:
                    case 4:
                    default:
                        return _componentType.SizeInBytes * _componentCount;
                }
            }
        }

        public override uint SizeInBytes => _componentType.SizeInBytes * _componentCount;

        public static SpirvType GetType(SpirvTypeBase componentType, uint componentCount)
        {
            switch (componentType.Type)
            {
                case SpirvType.Float:
                {
                    switch (componentCount)
                    {
                        case 2:
                            return SpirvType.Vec2;
                        case 3:
                            return SpirvType.Vec3;
                        case 4:
                            return SpirvType.Vec4;
                    }
                    break;
                }
                case SpirvType.Int:
                {
                    switch (componentCount)
                    {
                        case 2:
                            return SpirvType.Ivec2;
                        case 3:
                            return SpirvType.Ivec3;
                        case 4:
                            return SpirvType.Ivec4;
                    }
                    break;
                }
                case SpirvType.UInt:
                {
                    switch (componentCount)
                    {
                        case 2:
                            return SpirvType.Uvec2;
                        case 3:
                            return SpirvType.Uvec3;
                        case 4:
                            return SpirvType.Uvec4;
                    }
                    break;
                }
                case SpirvType.Double:
                {
                    switch (componentCount)
                    {
                        case 2:
                            return SpirvType.Dvec2;
                        case 3:
                            return SpirvType.Dvec3;
                        case 4:
                            return SpirvType.Dvec4;
                    }
                    break;
                }
                case SpirvType.Bool:
                {
                    switch (componentCount)
                    {
                        case 2:
                            return SpirvType.Bvec2;
                        case 3:
                            return SpirvType.Bvec3;
                        case 4:
                            return SpirvType.Bvec4;
                    }
                    break;
                }
            }

            return SpirvType.CustomVector;
        }

        public override string ToString()
        {
            switch (Type)
            {
                case SpirvType.Bvec2: return "bvec2";
                case SpirvType.Bvec3: return "bvec3";
                case SpirvType.Bvec4: return "bvec4";
                case SpirvType.Ivec2: return "ivec2";
                case SpirvType.Ivec3: return "ivec3";
                case SpirvType.Ivec4: return "ivec4";
                case SpirvType.Uvec2: return "uvec2";
                case SpirvType.Uvec3: return "uvec3";
                case SpirvType.Uvec4: return "uvec4";
                case SpirvType.Dvec2: return "dvec2";
                case SpirvType.Dvec3: return "dvec3";
                case SpirvType.Dvec4: return "dvec4";
                case SpirvType.Vec2: return "vec2";
                case SpirvType.Vec3: return "vec3";
                case SpirvType.Vec4: return "vec4";
            }

            return _componentType + "vec" + _componentCount;
        }
    }
}