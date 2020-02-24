using System;
using System.Linq.Expressions;
using System.Numerics;
using NUnit.Framework;
using Toe.SPIRV.Reflection;

namespace Toe.SPIRV.UnitTests
{
    [TestFixture]
    public class ExpressionConverterTests
    {
        [Test]
        public void T()
        {
            var converter = new ExpressionConverter();
            Expression<Func<Vector4>> expression = () => new Vector4(0, 1, 2, 3);
            converter.Convert(expression);
        }
    }
}