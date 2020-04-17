using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Veldrid;

namespace Toe.SPIRV.UnitTests
{
    public class SampleShaders
    {
        public static IEnumerable<object[]> EnumerateShaders()
        {
            var assembly = typeof(SampleShaders).Assembly;
            foreach (var manifestResourceName in assembly.GetManifestResourceNames())
            {
                if (manifestResourceName.IndexOf(".asm.") < 0 && manifestResourceName.IndexOf(".legacy.") < 0)
                {
                    if (manifestResourceName.EndsWith(".vert"))
                    {
                        yield return new object[] {ReadText(assembly, manifestResourceName), ShaderStages.Vertex};
                    }
                    else if (manifestResourceName.EndsWith(".frag"))
                    {
                        yield return new object[] {ReadText(assembly, manifestResourceName), ShaderStages.Fragment};
                    }
                }
            }
        }

        private static string ReadText(Assembly assembly, string manifestResourceName)
        {
            using (var s = assembly.GetManifestResourceStream(manifestResourceName))
            {
                using (var reader = new StreamReader(s))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}