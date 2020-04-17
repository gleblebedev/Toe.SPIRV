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
            [Capability(Capability.Enumerant.MeshShadingNV)]
            TaskNV = 5267,
            [Capability(Capability.Enumerant.MeshShadingNV)]
            MeshNV = 5268,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            RayGenerationNV = 5313,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            RayGenerationKHR = 5313,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            IntersectionNV = 5314,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            IntersectionKHR = 5314,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            AnyHitNV = 5315,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            AnyHitKHR = 5315,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            ClosestHitNV = 5316,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            ClosestHitKHR = 5316,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            MissNV = 5317,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            MissKHR = 5317,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            CallableNV = 5318,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            CallableKHR = 5318,
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
        public class TaskNV: ExecutionModel
        {
            public override Enumerant Value => ExecutionModel.Enumerant.TaskNV;
            public new static TaskNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new TaskNV();
                return res;
            }
        }
        public class MeshNV: ExecutionModel
        {
            public override Enumerant Value => ExecutionModel.Enumerant.MeshNV;
            public new static MeshNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new MeshNV();
                return res;
            }
        }
        public class RayGenerationNV: ExecutionModel
        {
            public override Enumerant Value => ExecutionModel.Enumerant.RayGenerationNV;
            public new static RayGenerationNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new RayGenerationNV();
                return res;
            }
        }
        public class RayGenerationKHR: ExecutionModel
        {
            public override Enumerant Value => ExecutionModel.Enumerant.RayGenerationKHR;
            public new static RayGenerationKHR Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new RayGenerationKHR();
                return res;
            }
        }
        public class IntersectionNV: ExecutionModel
        {
            public override Enumerant Value => ExecutionModel.Enumerant.IntersectionNV;
            public new static IntersectionNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new IntersectionNV();
                return res;
            }
        }
        public class IntersectionKHR: ExecutionModel
        {
            public override Enumerant Value => ExecutionModel.Enumerant.IntersectionKHR;
            public new static IntersectionKHR Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new IntersectionKHR();
                return res;
            }
        }
        public class AnyHitNV: ExecutionModel
        {
            public override Enumerant Value => ExecutionModel.Enumerant.AnyHitNV;
            public new static AnyHitNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new AnyHitNV();
                return res;
            }
        }
        public class AnyHitKHR: ExecutionModel
        {
            public override Enumerant Value => ExecutionModel.Enumerant.AnyHitKHR;
            public new static AnyHitKHR Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new AnyHitKHR();
                return res;
            }
        }
        public class ClosestHitNV: ExecutionModel
        {
            public override Enumerant Value => ExecutionModel.Enumerant.ClosestHitNV;
            public new static ClosestHitNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ClosestHitNV();
                return res;
            }
        }
        public class ClosestHitKHR: ExecutionModel
        {
            public override Enumerant Value => ExecutionModel.Enumerant.ClosestHitKHR;
            public new static ClosestHitKHR Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ClosestHitKHR();
                return res;
            }
        }
        public class MissNV: ExecutionModel
        {
            public override Enumerant Value => ExecutionModel.Enumerant.MissNV;
            public new static MissNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new MissNV();
                return res;
            }
        }
        public class MissKHR: ExecutionModel
        {
            public override Enumerant Value => ExecutionModel.Enumerant.MissKHR;
            public new static MissKHR Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new MissKHR();
                return res;
            }
        }
        public class CallableNV: ExecutionModel
        {
            public override Enumerant Value => ExecutionModel.Enumerant.CallableNV;
            public new static CallableNV Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new CallableNV();
                return res;
            }
        }
        public class CallableKHR: ExecutionModel
        {
            public override Enumerant Value => ExecutionModel.Enumerant.CallableKHR;
            public new static CallableKHR Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new CallableKHR();
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
                case Enumerant.TaskNV :
                    return TaskNV.Parse(reader, wordCount - 1);
                case Enumerant.MeshNV :
                    return MeshNV.Parse(reader, wordCount - 1);
                case Enumerant.RayGenerationNV :
                    return RayGenerationNV.Parse(reader, wordCount - 1);
                //RayGenerationKHR has the same id as another value in enum.
                //case Enumerant.RayGenerationKHR :
                //    return RayGenerationKHR.Parse(reader, wordCount - 1);
                case Enumerant.IntersectionNV :
                    return IntersectionNV.Parse(reader, wordCount - 1);
                //IntersectionKHR has the same id as another value in enum.
                //case Enumerant.IntersectionKHR :
                //    return IntersectionKHR.Parse(reader, wordCount - 1);
                case Enumerant.AnyHitNV :
                    return AnyHitNV.Parse(reader, wordCount - 1);
                //AnyHitKHR has the same id as another value in enum.
                //case Enumerant.AnyHitKHR :
                //    return AnyHitKHR.Parse(reader, wordCount - 1);
                case Enumerant.ClosestHitNV :
                    return ClosestHitNV.Parse(reader, wordCount - 1);
                //ClosestHitKHR has the same id as another value in enum.
                //case Enumerant.ClosestHitKHR :
                //    return ClosestHitKHR.Parse(reader, wordCount - 1);
                case Enumerant.MissNV :
                    return MissNV.Parse(reader, wordCount - 1);
                //MissKHR has the same id as another value in enum.
                //case Enumerant.MissKHR :
                //    return MissKHR.Parse(reader, wordCount - 1);
                case Enumerant.CallableNV :
                    return CallableNV.Parse(reader, wordCount - 1);
                //CallableKHR has the same id as another value in enum.
                //case Enumerant.CallableKHR :
                //    return CallableKHR.Parse(reader, wordCount - 1);
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