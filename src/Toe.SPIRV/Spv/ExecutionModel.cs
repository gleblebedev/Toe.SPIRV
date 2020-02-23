using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public abstract partial class ExecutionModel : ValueEnum
    {
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
            Kernel = 6,
        }

        public class Vertex: ExecutionModel
        {
            public override Enumerant Value => ExecutionModel.Enumerant.Vertex;
            public new static Vertex Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Vertex();
                return res;
            }
        }
        public class TessellationControl: ExecutionModel
        {
            public override Enumerant Value => ExecutionModel.Enumerant.TessellationControl;
            public new static TessellationControl Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new TessellationControl();
                return res;
            }
        }
        public class TessellationEvaluation: ExecutionModel
        {
            public override Enumerant Value => ExecutionModel.Enumerant.TessellationEvaluation;
            public new static TessellationEvaluation Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new TessellationEvaluation();
                return res;
            }
        }
        public class Geometry: ExecutionModel
        {
            public override Enumerant Value => ExecutionModel.Enumerant.Geometry;
            public new static Geometry Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Geometry();
                return res;
            }
        }
        public class Fragment: ExecutionModel
        {
            public override Enumerant Value => ExecutionModel.Enumerant.Fragment;
            public new static Fragment Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Fragment();
                return res;
            }
        }
        public class GLCompute: ExecutionModel
        {
            public override Enumerant Value => ExecutionModel.Enumerant.GLCompute;
            public new static GLCompute Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new GLCompute();
                return res;
            }
        }
        public class Kernel: ExecutionModel
        {
            public override Enumerant Value => ExecutionModel.Enumerant.Kernel;
            public new static Kernel Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Kernel();
                return res;
            }
        }

        public abstract Enumerant Value { get; }

        public static ExecutionModel Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                case Enumerant.Vertex :
                    return Vertex.Parse(reader, wordCount - 1);
                case Enumerant.TessellationControl :
                    return TessellationControl.Parse(reader, wordCount - 1);
                case Enumerant.TessellationEvaluation :
                    return TessellationEvaluation.Parse(reader, wordCount - 1);
                case Enumerant.Geometry :
                    return Geometry.Parse(reader, wordCount - 1);
                case Enumerant.Fragment :
                    return Fragment.Parse(reader, wordCount - 1);
                case Enumerant.GLCompute :
                    return GLCompute.Parse(reader, wordCount - 1);
                case Enumerant.Kernel :
                    return Kernel.Parse(reader, wordCount - 1);
                default:
                    throw new IndexOutOfRangeException("Unknown ExecutionModel "+id);
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
            while (reader.Position < end)
            {
                res.Add(Parse(reader, end-reader.Position));
            }
            return res;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public virtual uint GetWordCount()
        {
            return 1;
        }

        public virtual void Write(WordWriter writer)
        {
            writer.WriteWord((uint)Value);
        }
    }
}