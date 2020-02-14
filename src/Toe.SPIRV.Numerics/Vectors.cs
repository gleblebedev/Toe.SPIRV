namespace Toe.SPIRV.Numerics
{
    public partial struct BVec2
    {
        public bool X;
        public bool Y;
        public bool Equals(BVec2 other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            return obj is BVec2 other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(BVec2 left, BVec2 right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(BVec2 left, BVec2 right)
        {
            return !left.Equals(right);
        }
    };
    public partial struct BVec3
    {
        public bool X;
        public bool Y;
        public bool Z;
        public bool Equals(BVec3 other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        public override bool Equals(object obj)
        {
            return obj is BVec3 other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(BVec3 left, BVec3 right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(BVec3 left, BVec3 right)
        {
            return !left.Equals(right);
        }
    };
    public partial struct BVec4
    {
        public bool X;
        public bool Y;
        public bool Z;
        public bool W;
        public bool Equals(BVec4 other)
        {
            return X == other.X && Y == other.Y && Z == other.Z && W == other.W;
        }

        public override bool Equals(object obj)
        {
            return obj is BVec4 other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                hashCode = (hashCode * 397) ^ W.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(BVec4 left, BVec4 right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(BVec4 left, BVec4 right)
        {
            return !left.Equals(right);
        }
    };
    public partial struct IVec2
    {
        public int X;
        public int Y;
        public bool Equals(IVec2 other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            return obj is IVec2 other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(IVec2 left, IVec2 right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(IVec2 left, IVec2 right)
        {
            return !left.Equals(right);
        }
    };
    public partial struct IVec3
    {
        public int X;
        public int Y;
        public int Z;
        public bool Equals(IVec3 other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        public override bool Equals(object obj)
        {
            return obj is IVec3 other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(IVec3 left, IVec3 right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(IVec3 left, IVec3 right)
        {
            return !left.Equals(right);
        }
    };
    public partial struct IVec4
    {
        public int X;
        public int Y;
        public int Z;
        public int W;
        public bool Equals(IVec4 other)
        {
            return X == other.X && Y == other.Y && Z == other.Z && W == other.W;
        }

        public override bool Equals(object obj)
        {
            return obj is IVec4 other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                hashCode = (hashCode * 397) ^ W.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(IVec4 left, IVec4 right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(IVec4 left, IVec4 right)
        {
            return !left.Equals(right);
        }
    };
    public partial struct DVec2
    {
        public double X;
        public double Y;
        public bool Equals(DVec2 other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            return obj is DVec2 other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(DVec2 left, DVec2 right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DVec2 left, DVec2 right)
        {
            return !left.Equals(right);
        }
    };
    public partial struct DVec3
    {
        public double X;
        public double Y;
        public double Z;
        public bool Equals(DVec3 other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        public override bool Equals(object obj)
        {
            return obj is DVec3 other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(DVec3 left, DVec3 right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DVec3 left, DVec3 right)
        {
            return !left.Equals(right);
        }
    };
    public partial struct DVec4
    {
        public double X;
        public double Y;
        public double Z;
        public double W;
        public bool Equals(DVec4 other)
        {
            return X == other.X && Y == other.Y && Z == other.Z && W == other.W;
        }

        public override bool Equals(object obj)
        {
            return obj is DVec4 other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                hashCode = (hashCode * 397) ^ W.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(DVec4 left, DVec4 right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DVec4 left, DVec4 right)
        {
            return !left.Equals(right);
        }
    };
    public partial struct UVec2
    {
        public uint X;
        public uint Y;
        public bool Equals(UVec2 other)
        {
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            return obj is UVec2 other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(UVec2 left, UVec2 right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(UVec2 left, UVec2 right)
        {
            return !left.Equals(right);
        }
    };
    public partial struct UVec3
    {
        public uint X;
        public uint Y;
        public uint Z;
        public bool Equals(UVec3 other)
        {
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        public override bool Equals(object obj)
        {
            return obj is UVec3 other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(UVec3 left, UVec3 right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(UVec3 left, UVec3 right)
        {
            return !left.Equals(right);
        }
    };
    public partial struct UVec4
    {
        public uint X;
        public uint Y;
        public uint Z;
        public uint W;
        public bool Equals(UVec4 other)
        {
            return X == other.X && Y == other.Y && Z == other.Z && W == other.W;
        }

        public override bool Equals(object obj)
        {
            return obj is UVec4 other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                hashCode = (hashCode * 397) ^ W.GetHashCode();
                return hashCode;
            }
        }

        public static bool operator ==(UVec4 left, UVec4 right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(UVec4 left, UVec4 right)
        {
            return !left.Equals(right);
        }
    };
}