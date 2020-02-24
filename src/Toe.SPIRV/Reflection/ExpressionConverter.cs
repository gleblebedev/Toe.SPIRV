using System;
using System.Linq.Expressions;

namespace Toe.SPIRV.Reflection
{
    public class ExpressionConverter
    {
        public ExpressionConverter()
        {
        }

        public SpirvFunction Convert(LambdaExpression expression)
        {
            return new SpirvFunction();
        }
    }
}