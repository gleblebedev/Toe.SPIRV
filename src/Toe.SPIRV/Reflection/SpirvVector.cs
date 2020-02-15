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

        public static SpirvTypeCategory GetType(SpirvTypeBase componentType, uint componentCount)
        {
            switch (componentType.TypeCategory)
            {
                case SpirvTypeCategory.Float:
                {
                    switch (componentCount)
                    {
                        case 2:
                            return SpirvTypeCategory.Vec2;
                        case 3:
                            return SpirvTypeCategory.Vec3;
                        case 4:
                            return SpirvTypeCategory.Vec4;
                    }
                    break;
                }
                case SpirvTypeCategory.Int:
                {
                    switch (componentCount)
                    {
                        case 2:
                            return SpirvTypeCategory.Ivec2;
                        case 3:
                            return SpirvTypeCategory.Ivec3;
                        case 4:
                            return SpirvTypeCategory.Ivec4;
                    }
                    break;
                }
                case SpirvTypeCategory.UInt:
                {
                    switch (componentCount)
                    {
                        case 2:
                            return SpirvTypeCategory.Uvec2;
                        case 3:
                            return SpirvTypeCategory.Uvec3;
                        case 4:
                            return SpirvTypeCategory.Uvec4;
                    }
                    break;
                }
                case SpirvTypeCategory.Double:
                {
                    switch (componentCount)
                    {
                        case 2:
                            return SpirvTypeCategory.Dvec2;
                        case 3:
                            return SpirvTypeCategory.Dvec3;
                        case 4:
                            return SpirvTypeCategory.Dvec4;
                    }
                    break;
                }
                case SpirvTypeCategory.Bool:
                {
                    switch (componentCount)
                    {
                        case 2:
                            return SpirvTypeCategory.Bvec2;
                        case 3:
                            return SpirvTypeCategory.Bvec3;
                        case 4:
                            return SpirvTypeCategory.Bvec4;
                    }
                    break;
                }
            }

            return SpirvTypeCategory.CustomVector;
        }

        public override string ToString()
        {
            switch (TypeCategory)
            {
                case SpirvTypeCategory.Bvec2: return "bvec2";
                case SpirvTypeCategory.Bvec3: return "bvec3";
                case SpirvTypeCategory.Bvec4: return "bvec4";
                case SpirvTypeCategory.Ivec2: return "ivec2";
                case SpirvTypeCategory.Ivec3: return "ivec3";
                case SpirvTypeCategory.Ivec4: return "ivec4";
                case SpirvTypeCategory.Uvec2: return "uvec2";
                case SpirvTypeCategory.Uvec3: return "uvec3";
                case SpirvTypeCategory.Uvec4: return "uvec4";
                case SpirvTypeCategory.Dvec2: return "dvec2";
                case SpirvTypeCategory.Dvec3: return "dvec3";
                case SpirvTypeCategory.Dvec4: return "dvec4";
                case SpirvTypeCategory.Vec2: return "vec2";
                case SpirvTypeCategory.Vec3: return "vec3";
                case SpirvTypeCategory.Vec4: return "vec4";
            }

            return _componentType + "vec" + _componentCount;
        }
    }
}