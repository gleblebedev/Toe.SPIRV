using System;

namespace Toe.SPIRV.Reflection
{
    public abstract class SpirvTypeBase
    {
        private readonly SpirvType _type;

        public static readonly SpirvVoid Void;
        public static readonly SpirvFloat Half;
        public static readonly SpirvFloat Float;
        public static readonly SpirvFloat Double;
        public static readonly SpirvBool Bool;
        public static readonly SpirvInt SByte;
        public static readonly SpirvInt Byte;
        public static readonly SpirvInt Short;
        public static readonly SpirvInt UShort;
        public static readonly SpirvInt Int;
        public static readonly SpirvInt UInt;
        public static readonly SpirvVector Vec2;
        public static readonly SpirvVector Vec3;
        public static readonly SpirvVector Vec4;
        public static readonly SpirvVector Ivec2;
        public static readonly SpirvVector Ivec3;
        public static readonly SpirvVector Ivec4;
        public static readonly SpirvVector Uvec2;
        public static readonly SpirvVector Uvec3;
        public static readonly SpirvVector Uvec4;
        public static readonly SpirvVector Dvec2;
        public static readonly SpirvVector Dvec3;
        public static readonly SpirvVector Dvec4;
        public static readonly SpirvVector Bvec2;
        public static readonly SpirvVector Bvec3;
        public static readonly SpirvVector Bvec4;
        public static readonly SpirvMatrix Mat2Base;
        public static readonly SpirvMatrix Mat3Base;
        public static readonly SpirvMatrix Mat4Base;
        public static readonly SpirvMatrixLayout Mat2;
        public static readonly SpirvMatrixLayout Mat3;
        public static readonly SpirvMatrixLayout Mat4;

        static SpirvTypeBase()
        {
            Void = new SpirvVoid();
            Half = new SpirvFloat(16);
            Float = new SpirvFloat(32);
            Double = new SpirvFloat(64);
            Bool = new SpirvBool();
            SByte = new SpirvInt(8, true);
            Byte = new SpirvInt(8, false);
            Short = new SpirvInt(16, true);
            UShort = new SpirvInt(16, false);
            Int = new SpirvInt(32, true);
            UInt = new SpirvInt(32, false);
            Vec2 = new SpirvVector(Float, 2);
            Vec3 = new SpirvVector(Float, 3);
            Vec4 = new SpirvVector(Float, 4);
            Ivec2 = new SpirvVector(Int, 2);
            Ivec3 = new SpirvVector(Int, 3);
            Ivec4 = new SpirvVector(Int, 4);
            Uvec2 = new SpirvVector(UInt, 2);
            Uvec3 = new SpirvVector(UInt, 3);
            Uvec4 = new SpirvVector(UInt, 4);
            Bvec2 = new SpirvVector(Bool, 2);
            Bvec3 = new SpirvVector(Bool, 3);
            Bvec4 = new SpirvVector(Bool, 4);
            Dvec2 = new SpirvVector(Double, 2);
            Dvec3 = new SpirvVector(Double, 3);
            Dvec4 = new SpirvVector(Double, 4);
            Mat2Base = new SpirvMatrix(Vec2, 2);
            Mat3Base = new SpirvMatrix(Vec3, 3);
            Mat4Base = new SpirvMatrix(Vec4, 4);
            Mat2 = new SpirvMatrixLayout(Mat2Base, MatrixOrientation.ColMajor, 4);
            Mat3 = new SpirvMatrixLayout(Mat3Base, MatrixOrientation.ColMajor, 4);
            Mat4 = new SpirvMatrixLayout(Mat4Base, MatrixOrientation.ColMajor, 4);
        }

        protected SpirvTypeBase(SpirvType type)
        {
            _type = type;
        }

        public SpirvType Type => _type;

        public virtual uint SizeInBytes { get { throw new NotImplementedException(); } }

        public virtual uint Alignment => SizeInBytes;

        public static SpirvVector ResolveVector(SpirvTypeBase componentType, uint componentCount)
        {
            switch (componentType.Type)
            {
                case SpirvType.Float:
                {
                    switch (componentCount)
                    {
                            case 2: return Vec2;
                            case 3: return Vec3;
                            case 4: return Vec4;
                    }
                    break;
                }
                case SpirvType.Int:
                {
                    switch (componentCount)
                    {
                        case 2: return Ivec2;
                        case 3: return Ivec3;
                        case 4: return Ivec4;
                    }
                    break;
                }
                case SpirvType.UInt:
                {
                    switch (componentCount)
                    {
                        case 2: return Uvec2;
                        case 3: return Uvec3;
                        case 4: return Uvec4;
                    }
                    break;
                }
                case SpirvType.Bool:
                {
                    switch (componentCount)
                    {
                        case 2: return Bvec2;
                        case 3: return Bvec3;
                        case 4: return Bvec4;
                    }
                    break;
                }
                case SpirvType.Double:
                {
                    switch (componentCount)
                    {
                        case 2: return Dvec2;
                        case 3: return Dvec3;
                        case 4: return Dvec4;
                    }
                    break;
                }
            }
            return new SpirvVector(componentType, componentCount);
        }

        public static SpirvTypeBase ResolveMatrix(SpirvTypeBase columnType, uint columnCount)
        {
            switch (columnType.Type)
            {
                case SpirvType.Vec2:
                    if (columnCount == 2) return Mat2;
                    break;
                case SpirvType.Vec3:
                    if (columnCount == 3) return Mat3;
                    break;
                case SpirvType.Vec4:
                    if (columnCount == 4) return Mat4;
                    break;
            }

            return new SpirvMatrix((SpirvVector)columnType, columnCount);
        }
    }
}