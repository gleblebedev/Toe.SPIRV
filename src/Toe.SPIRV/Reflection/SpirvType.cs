namespace Toe.SPIRV.Reflection
{
    public enum SpirvType
    {
        Void,

        Bool,

        Half,
        Float,
        Double,
        CustomFloat,

        SByte,
        Byte,
        Short,
        UShort,
        Int,
        UInt,
        CustomInt,

        Vec2,
        Vec3,
        Vec4,
        Ivec2,
        Ivec3,
        Ivec4,
        Uvec2,
        Uvec3,
        Uvec4,
        Dvec2,
        Dvec3,
        Dvec4,
        Bvec2,
        Bvec3,
        Bvec4,
        CustomVector,

        Mat2,
        Mat3,
        Mat4,
        CustomMatrix,

        CustomArray,

        CustomStruct,
    }
}