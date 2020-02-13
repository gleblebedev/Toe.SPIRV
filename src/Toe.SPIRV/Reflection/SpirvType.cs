namespace Toe.SPIRV.Reflection
{
    public abstract class SpirvType
    {
        public static readonly SpirvVoid Void = new SpirvVoid();
        public static readonly SpirvHalf Half = new SpirvHalf();
        public static readonly SpirvFloat Float = new SpirvFloat();
        public static readonly SpirvDouble Double = new SpirvDouble();
        public static readonly SpirvBool Bool = new SpirvBool();
        public static readonly SpirvInt Int = new SpirvInt();
        public static readonly SpirvUInt UInt = new SpirvUInt();
    }
    public class SpirvFloat: SpirvType
    {
        internal SpirvFloat()
        {
        }

        public override string ToString()
        {
            return "float";
        }
    }
    public class SpirvHalf : SpirvType
    {
        internal SpirvHalf()
        {
        }
        public override string ToString()
        {
            return "half float";
        }
    }
    public class SpirvDouble : SpirvType
    {
        internal SpirvDouble()
        {
        }
        public override string ToString()
        {
            return "double";
        }
    }
    public class SpirvVoid : SpirvType
    {
        internal SpirvVoid()
        {
        }
        public override string ToString()
        {
            return "void";
        }
    }
    public class SpirvBool : SpirvType
    {
        internal SpirvBool()
        {
        }
        public override string ToString()
        {
            return "bool";
        }

    }
    public class SpirvInt : SpirvType
    {
        internal SpirvInt()
        {
        }
        public override string ToString()
        {
            return "int";
        }

    }
    public class SpirvUInt : SpirvType
    {
        internal SpirvUInt()
        {
        }
        public override string ToString()
        {
            return "uint";
        }

    }
}