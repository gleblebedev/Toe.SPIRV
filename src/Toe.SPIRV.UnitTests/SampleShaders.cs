using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Veldrid;

namespace Toe.SPIRV.UnitTests
{
    public class SampleShaders
    {
        public static IEnumerable<string> EnumerateShaders()
        {
            var assembly = typeof(SampleShaders).Assembly;
            foreach (var manifestResourceName in assembly.GetManifestResourceNames())
            {
                if (manifestResourceName.IndexOf(".asm.") < 0 && manifestResourceName.IndexOf(".legacy.") < 0)
                {
                    yield return manifestResourceName;
                }
            }
        }

        public static (string source, ShaderStages stage) LoadShader(string manifestResourceName, Assembly assembly)
        {
            if (manifestResourceName.EndsWith(".vert"))
            {
                return (ReadText(assembly, manifestResourceName), ShaderStages.Vertex);
            }
            if (manifestResourceName.EndsWith(".frag"))
            {
                return (ReadText(assembly, manifestResourceName), ShaderStages.Fragment);
            }
            throw new NotImplementedException("Can't detect shader stage");
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