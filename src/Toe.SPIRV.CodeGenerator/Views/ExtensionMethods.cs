using System.Collections.Generic;

namespace Toe.SPIRV.CodeGenerator.Views
{
    public static class ExtensionMethods
    {
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> items, T item)
        {
            if (items != null)
            {
                foreach (var i in items)
                {
                    yield return i;
                }
            }

            yield return item;
        }
    }
}