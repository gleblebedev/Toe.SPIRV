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
            public static readonly Vertex Instance = new Vertex();
            public override Enumerant Value => ExecutionModel.Enumerant.Vertex;
            public new static Vertex Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class TessellationControl: ExecutionModel
        {
            public static readonly TessellationControl Instance = new TessellationControl();
            public override Enumerant Value => ExecutionModel.Enumerant.TessellationControl;
            public new static TessellationControl Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class TessellationEvaluation: ExecutionModel
        {
            public static readonly TessellationEvaluation Instance = new TessellationEvaluation();
            public override Enumerant Value => ExecutionModel.Enumerant.TessellationEvaluation;
            public new static TessellationEvaluation Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Geometry: ExecutionModel
        {
            public static readonly Geometry Instance = new Geometry();
            public override Enumerant Value => ExecutionModel.Enumerant.Geometry;
            public new static Geometry Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Fragment: ExecutionModel
        {
            public static readonly Fragment Instance = new Fragment();
            public override Enumerant Value => ExecutionModel.Enumerant.Fragment;
            public new static Fragment Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class GLCompute: ExecutionModel
        {
            public static readonly GLCompute Instance = new GLCompute();
            public override Enumerant Value => ExecutionModel.Enumerant.GLCompute;
            public new static GLCompute Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Kernel: ExecutionModel
        {
            public static readonly Kernel Instance = new Kernel();
            public override Enumerant Value => ExecutionModel.Enumerant.Kernel;
            public new static Kernel Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class TaskNV: ExecutionModel
        {
            public static readonly TaskNV Instance = new TaskNV();
            public override Enumerant Value => ExecutionModel.Enumerant.TaskNV;
            public new static TaskNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class MeshNV: ExecutionModel
        {
            public static readonly MeshNV Instance = new MeshNV();
            public override Enumerant Value => ExecutionModel.Enumerant.MeshNV;
            public new static MeshNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class RayGenerationNV: ExecutionModel
        {
            public static readonly RayGenerationNV Instance = new RayGenerationNV();
            public override Enumerant Value => ExecutionModel.Enumerant.RayGenerationNV;
            public new static RayGenerationNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class RayGenerationKHR: ExecutionModel
        {
            public static readonly RayGenerationKHR Instance = new RayGenerationKHR();
            public override Enumerant Value => ExecutionModel.Enumerant.RayGenerationKHR;
            public new static RayGenerationKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class IntersectionNV: ExecutionModel
        {
            public static readonly IntersectionNV Instance = new IntersectionNV();
            public override Enumerant Value => ExecutionModel.Enumerant.IntersectionNV;
            public new static IntersectionNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class IntersectionKHR: ExecutionModel
        {
            public static readonly IntersectionKHR Instance = new IntersectionKHR();
            public override Enumerant Value => ExecutionModel.Enumerant.IntersectionKHR;
            public new static IntersectionKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class AnyHitNV: ExecutionModel
        {
            public static readonly AnyHitNV Instance = new AnyHitNV();
            public override Enumerant Value => ExecutionModel.Enumerant.AnyHitNV;
            public new static AnyHitNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class AnyHitKHR: ExecutionModel
        {
            public static readonly AnyHitKHR Instance = new AnyHitKHR();
            public override Enumerant Value => ExecutionModel.Enumerant.AnyHitKHR;
            public new static AnyHitKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class ClosestHitNV: ExecutionModel
        {
            public static readonly ClosestHitNV Instance = new ClosestHitNV();
            public override Enumerant Value => ExecutionModel.Enumerant.ClosestHitNV;
            public new static ClosestHitNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class ClosestHitKHR: ExecutionModel
        {
            public static readonly ClosestHitKHR Instance = new ClosestHitKHR();
            public override Enumerant Value => ExecutionModel.Enumerant.ClosestHitKHR;
            public new static ClosestHitKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class MissNV: ExecutionModel
        {
            public static readonly MissNV Instance = new MissNV();
            public override Enumerant Value => ExecutionModel.Enumerant.MissNV;
            public new static MissNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class MissKHR: ExecutionModel
        {
            public static readonly MissKHR Instance = new MissKHR();
            public override Enumerant Value => ExecutionModel.Enumerant.MissKHR;
            public new static MissKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class CallableNV: ExecutionModel
        {
            public static readonly CallableNV Instance = new CallableNV();
            public override Enumerant Value => ExecutionModel.Enumerant.CallableNV;
            public new static CallableNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class CallableKHR: ExecutionModel
        {
            public static readonly CallableKHR Instance = new CallableKHR();
            public override Enumerant Value => ExecutionModel.Enumerant.CallableKHR;
            public new static CallableKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
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