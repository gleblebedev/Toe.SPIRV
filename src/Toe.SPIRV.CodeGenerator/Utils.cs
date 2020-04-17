using System;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Toe.SPIRV.CodeGenerator.Model.Grammar;
using Toe.SPIRV.CodeGenerator.Model.Spv;

namespace Toe.SPIRV.CodeGenerator
{
    public static class Utils
    {

        public static FileStream OpenFileRead(string fileName)
        {
            return File.Open(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        }
        public static FileStream CreateFile(string fileName)
        {
            return File.Open(fileName, FileMode.Create, FileAccess.Write, FileShare.Read);
        }
        public static T LoadJsonOrDefault<T>(string fileName, Func<T> fallback = null)
        {
            if (!File.Exists(fileName))
            {
                if (fallback == null)
                    return default;
                return fallback();
            }
            using (var file = OpenFileRead(fileName))
            {
                using (var reader = new StreamReader(file))
                {
                    return JsonConvert.DeserializeObject<T>(reader.ReadToEnd(), new Newtonsoft.Json.Converters.StringEnumConverter());
                }
            }
        }
        public static void SaveJson<T>(string fileName, T instance)
        {
            using (var file = CreateFile(fileName))
            {
                using (var writer = new StreamWriter(file, new UTF8Encoding(false)))
                {
                    writer.Write(JsonConvert.SerializeObject(instance, Formatting.Indented, new Newtonsoft.Json.Converters.StringEnumConverter()));
                }
            }
        }

        public static Operands LoadOperands(string fileName)
        {
            var operands = LoadJsonOrDefault<Operands>(fileName,
                () => throw new FileNotFoundException("File " + fileName +
                                                      " not found. Expected path to spirv.core.grammar.json."));
            foreach (var instruction in operands.instructions)
            {
                if (instruction.opname == "OpCopyMemory" || instruction.opname == "OpCopyMemorySized")
                {
                    var memAssess = instruction.operands.Where(_ => _.kind == "MemoryAccess").ToList();
                    foreach (var operand in memAssess.Skip(1))
                    {
                        instruction.operands.Remove(operand);
                    }
                }
            }
            return operands;
        }

        public static SpirvInstructions LoadGrammar(string fileName)
        {
            return LoadJsonOrDefault<SpirvInstructions>(fileName,
                () => new SpirvInstructions());
        }

        public static void SaveGrammar(string fileName, SpirvInstructions instructions)
        {
            SaveJson(fileName, instructions);
        }

        public static void SaveText(string fileName, string text)
        {
            using (var file = CreateFile(fileName))
            {
                using (var writer = new StreamWriter(file, new UTF8Encoding(false)))
                {
                    writer.Write(text);
                }
            }
        }
    }
}