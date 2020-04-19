using System;
using System.Runtime.InteropServices;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Reflection.Operands
{
    [StructLayout(LayoutKind.Explicit)]
    public struct LiteralContextDependentNumber : IEquatable<LiteralContextDependentNumber>
    {
        public bool Equals(LiteralContextDependentNumber other)
        {
            return _type == other._type && _doubleValue.Equals(other._doubleValue);
        }

        public override bool Equals(object obj)
        {
            return obj is LiteralContextDependentNumber other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) _type * 397) ^ _doubleValue.GetHashCode();
            }
        }

        public static bool operator ==(LiteralContextDependentNumber left, LiteralContextDependentNumber right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(LiteralContextDependentNumber left, LiteralContextDependentNumber right)
        {
            return !left.Equals(right);
        }

        public static readonly LiteralContextDependentNumber Undef;

        private const int DataOffset = 0;
        private const int TypeOffset = sizeof(double);

        private enum ValueType
        {
            Zero,
            Float,
            Double,
            Int,
            UInt
        }

        [FieldOffset(TypeOffset)] private ValueType _type;
        [FieldOffset(DataOffset)] private double _doubleValue;
        [FieldOffset(DataOffset)] private float _floatValue;
        [FieldOffset(DataOffset)] private int _intValue;
        [FieldOffset(DataOffset)] private uint _uintValue;

        public override string ToString()
        {
            switch (_type)
            {
                case ValueType.Zero:
                    return "0";
                case ValueType.Float:
                    return $"(float){_floatValue}";
                case ValueType.Double:
                    return $"(double){_doubleValue}";
                case ValueType.Int:
                    return $"(int){_intValue}";
                case ValueType.UInt:
                    return $"(uint){_uintValue}";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static implicit operator LiteralContextDependentNumber(double value)
        {
            var res = new LiteralContextDependentNumber();
            res._type = ValueType.Double;
            res._doubleValue = value;
            return res;
        }

        public static implicit operator LiteralContextDependentNumber(float value)
        {
            var res = new LiteralContextDependentNumber();
            res._type = ValueType.Float;
            res._floatValue = value;
            return res;
        }

        public static implicit operator LiteralContextDependentNumber(int value)
        {
            var res = new LiteralContextDependentNumber();
            res._type = ValueType.Int;
            res._intValue = value;
            return res;
        }

        public static implicit operator LiteralContextDependentNumber(uint value)
        {
            var res = new LiteralContextDependentNumber();
            res._type = ValueType.UInt;
            res._uintValue = value;
            return res;
        }

        public static implicit operator LiteralContextDependentNumber(Spv.LiteralContextDependentNumber value)
        {
            var val = value?.Value;
            if (val?.Type == null) return LiteralContextDependentNumber.Undef;
            var type = val.Type;
            switch (type.OpCode)
            {
                case Op.OpTypeInt:
                    var opTypeInt = (OpTypeInt) type;
                    if (opTypeInt.Signedness == 0)
                    {
                        switch (opTypeInt.Width)
                        {
                            case 32: return val.ToInt32();
                        }
                    }
                    else
                    {
                        switch (opTypeInt.Width)
                        {
                            case 32: return val.ToUInt32();
                        }
                    }
                    throw new NotImplementedException(type+" not implemented yet.");
                case Op.OpTypeFloat:
                    var opTypeFloat = (OpTypeFloat)type;
                    switch (opTypeFloat.Width)
                    {
                        case 32: return val.ToFloat();
                        case 64: return val.ToDouble();
                    }
                    throw new NotImplementedException(type + " not implemented yet.");
                default:
                    throw new NotImplementedException(type + " not implemented yet.");
            }
        }

        public static implicit operator double(LiteralContextDependentNumber value)
        {
            switch (value._type)
            {
                case ValueType.Zero:
                    return 0;
                case ValueType.Float:
                    return value._floatValue;
                case ValueType.Double:
                    return value._doubleValue;
                case ValueType.Int:
                    return value._intValue;
                case ValueType.UInt:
                    return value._uintValue;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static implicit operator float(LiteralContextDependentNumber value)
        {
            switch (value._type)
            {
                case ValueType.Zero:
                    return 0;
                case ValueType.Float:
                    return value._floatValue;
                case ValueType.Double:
                    return (float) value._doubleValue;
                case ValueType.Int:
                    return value._intValue;
                case ValueType.UInt:
                    return value._uintValue;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static implicit operator int(LiteralContextDependentNumber value)
        {
            switch (value._type)
            {
                case ValueType.Zero:
                    return 0;
                case ValueType.Float:
                    return (int) value._floatValue;
                case ValueType.Double:
                    return (int) value._doubleValue;
                case ValueType.Int:
                    return value._intValue;
                case ValueType.UInt:
                    return (int) value._uintValue;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static implicit operator uint(LiteralContextDependentNumber value)
        {
            switch (value._type)
            {
                case ValueType.Zero:
                    return 0;
                case ValueType.Float:
                    return (uint) value._floatValue;
                case ValueType.Double:
                    return (uint) value._doubleValue;
                case ValueType.Int:
                    return (uint) value._intValue;
                case ValueType.UInt:
                    return value._uintValue;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}