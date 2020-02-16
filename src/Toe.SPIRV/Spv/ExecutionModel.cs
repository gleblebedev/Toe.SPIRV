using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public class ExecutionModel : ValueEnum
    {
        public ExecutionModel(Enumerant value)
        {
            Value = value;
        }

        public enum Enumerant
        {
            [Capability(Capability.Enumerant.Shader)]
            Vertex = 0,

            [Capability(Capability.Enumerant.Tessellation)]
            TessellationControl = 1,

            [Capability(Capability.Enumerant.Tessellation)]
            TessellationEvaluation = 2,

            [Capability(Capability.Enumerant.Geometry)]
            Geometry = 3,

            [Capability(Capability.Enumerant.Shader)]
            Fragment = 4,

            [Capability(Capability.Enumerant.Shader)]
            GLCompute = 5,

            [Capability(Capability.Enumerant.Kernel)]
            Kernel = 6
        }

        public Enumerant Value { get; }

        public static ExecutionModel Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                default:
                    return new ExecutionModel(id);
            }
        }

        public static ExecutionModel ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<ExecutionModel> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<ExecutionModel>();
            while (reader.Position < end) res.Add(Parse(reader, end - reader.Position));
            return res;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}