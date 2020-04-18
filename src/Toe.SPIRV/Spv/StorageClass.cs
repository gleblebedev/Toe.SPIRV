using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public abstract partial class StorageClass : ValueEnum
    {
        public enum Enumerant
        {
            UniformConstant = 0,
            Input = 1,
            [Capability(Capability.Enumerant.Shader)]
            Uniform = 2,
            [Capability(Capability.Enumerant.Shader)]
            Output = 3,
            Workgroup = 4,
            CrossWorkgroup = 5,
            [Capability(Capability.Enumerant.Shader)]
            Private = 6,
            Function = 7,
            [Capability(Capability.Enumerant.GenericPointer)]
            Generic = 8,
            [Capability(Capability.Enumerant.Shader)]
            PushConstant = 9,
            [Capability(Capability.Enumerant.AtomicStorage)]
            AtomicCounter = 10,
            Image = 11,
            [Capability(Capability.Enumerant.Shader)]
            StorageBuffer = 12,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            CallableDataNV = 5328,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            CallableDataKHR = 5328,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            IncomingCallableDataNV = 5329,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            IncomingCallableDataKHR = 5329,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            RayPayloadNV = 5338,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            RayPayloadKHR = 5338,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            HitAttributeNV = 5339,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            HitAttributeKHR = 5339,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            IncomingRayPayloadNV = 5342,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            IncomingRayPayloadKHR = 5342,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            ShaderRecordBufferNV = 5343,
            [Capability(Capability.Enumerant.RayTracingNV)]
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            ShaderRecordBufferKHR = 5343,
            [Capability(Capability.Enumerant.PhysicalStorageBufferAddresses)]
            PhysicalStorageBuffer = 5349,
            [Capability(Capability.Enumerant.PhysicalStorageBufferAddresses)]
            PhysicalStorageBufferEXT = 5349,
        }

        public class UniformConstant: StorageClass
        {
            public static readonly UniformConstant Instance = new UniformConstant();
            public override Enumerant Value => StorageClass.Enumerant.UniformConstant;
            public new static UniformConstant Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Input: StorageClass
        {
            public static readonly Input Instance = new Input();
            public override Enumerant Value => StorageClass.Enumerant.Input;
            public new static Input Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Uniform: StorageClass
        {
            public static readonly Uniform Instance = new Uniform();
            public override Enumerant Value => StorageClass.Enumerant.Uniform;
            public new static Uniform Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Output: StorageClass
        {
            public static readonly Output Instance = new Output();
            public override Enumerant Value => StorageClass.Enumerant.Output;
            public new static Output Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Workgroup: StorageClass
        {
            public static readonly Workgroup Instance = new Workgroup();
            public override Enumerant Value => StorageClass.Enumerant.Workgroup;
            public new static Workgroup Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class CrossWorkgroup: StorageClass
        {
            public static readonly CrossWorkgroup Instance = new CrossWorkgroup();
            public override Enumerant Value => StorageClass.Enumerant.CrossWorkgroup;
            public new static CrossWorkgroup Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Private: StorageClass
        {
            public static readonly Private Instance = new Private();
            public override Enumerant Value => StorageClass.Enumerant.Private;
            public new static Private Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Function: StorageClass
        {
            public static readonly Function Instance = new Function();
            public override Enumerant Value => StorageClass.Enumerant.Function;
            public new static Function Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Generic: StorageClass
        {
            public static readonly Generic Instance = new Generic();
            public override Enumerant Value => StorageClass.Enumerant.Generic;
            public new static Generic Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class PushConstant: StorageClass
        {
            public static readonly PushConstant Instance = new PushConstant();
            public override Enumerant Value => StorageClass.Enumerant.PushConstant;
            public new static PushConstant Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class AtomicCounter: StorageClass
        {
            public static readonly AtomicCounter Instance = new AtomicCounter();
            public override Enumerant Value => StorageClass.Enumerant.AtomicCounter;
            public new static AtomicCounter Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Image: StorageClass
        {
            public static readonly Image Instance = new Image();
            public override Enumerant Value => StorageClass.Enumerant.Image;
            public new static Image Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class StorageBuffer: StorageClass
        {
            public static readonly StorageBuffer Instance = new StorageBuffer();
            public override Enumerant Value => StorageClass.Enumerant.StorageBuffer;
            public new static StorageBuffer Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class CallableDataNV: StorageClass
        {
            public static readonly CallableDataNV Instance = new CallableDataNV();
            public override Enumerant Value => StorageClass.Enumerant.CallableDataNV;
            public new static CallableDataNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class CallableDataKHR: StorageClass
        {
            public static readonly CallableDataKHR Instance = new CallableDataKHR();
            public override Enumerant Value => StorageClass.Enumerant.CallableDataKHR;
            public new static CallableDataKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class IncomingCallableDataNV: StorageClass
        {
            public static readonly IncomingCallableDataNV Instance = new IncomingCallableDataNV();
            public override Enumerant Value => StorageClass.Enumerant.IncomingCallableDataNV;
            public new static IncomingCallableDataNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class IncomingCallableDataKHR: StorageClass
        {
            public static readonly IncomingCallableDataKHR Instance = new IncomingCallableDataKHR();
            public override Enumerant Value => StorageClass.Enumerant.IncomingCallableDataKHR;
            public new static IncomingCallableDataKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class RayPayloadNV: StorageClass
        {
            public static readonly RayPayloadNV Instance = new RayPayloadNV();
            public override Enumerant Value => StorageClass.Enumerant.RayPayloadNV;
            public new static RayPayloadNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class RayPayloadKHR: StorageClass
        {
            public static readonly RayPayloadKHR Instance = new RayPayloadKHR();
            public override Enumerant Value => StorageClass.Enumerant.RayPayloadKHR;
            public new static RayPayloadKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class HitAttributeNV: StorageClass
        {
            public static readonly HitAttributeNV Instance = new HitAttributeNV();
            public override Enumerant Value => StorageClass.Enumerant.HitAttributeNV;
            public new static HitAttributeNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class HitAttributeKHR: StorageClass
        {
            public static readonly HitAttributeKHR Instance = new HitAttributeKHR();
            public override Enumerant Value => StorageClass.Enumerant.HitAttributeKHR;
            public new static HitAttributeKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class IncomingRayPayloadNV: StorageClass
        {
            public static readonly IncomingRayPayloadNV Instance = new IncomingRayPayloadNV();
            public override Enumerant Value => StorageClass.Enumerant.IncomingRayPayloadNV;
            public new static IncomingRayPayloadNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class IncomingRayPayloadKHR: StorageClass
        {
            public static readonly IncomingRayPayloadKHR Instance = new IncomingRayPayloadKHR();
            public override Enumerant Value => StorageClass.Enumerant.IncomingRayPayloadKHR;
            public new static IncomingRayPayloadKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class ShaderRecordBufferNV: StorageClass
        {
            public static readonly ShaderRecordBufferNV Instance = new ShaderRecordBufferNV();
            public override Enumerant Value => StorageClass.Enumerant.ShaderRecordBufferNV;
            public new static ShaderRecordBufferNV Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class ShaderRecordBufferKHR: StorageClass
        {
            public static readonly ShaderRecordBufferKHR Instance = new ShaderRecordBufferKHR();
            public override Enumerant Value => StorageClass.Enumerant.ShaderRecordBufferKHR;
            public new static ShaderRecordBufferKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class PhysicalStorageBuffer: StorageClass
        {
            public static readonly PhysicalStorageBuffer Instance = new PhysicalStorageBuffer();
            public override Enumerant Value => StorageClass.Enumerant.PhysicalStorageBuffer;
            public new static PhysicalStorageBuffer Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class PhysicalStorageBufferEXT: StorageClass
        {
            public static readonly PhysicalStorageBufferEXT Instance = new PhysicalStorageBufferEXT();
            public override Enumerant Value => StorageClass.Enumerant.PhysicalStorageBufferEXT;
            public new static PhysicalStorageBufferEXT Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }

        public abstract Enumerant Value { get; }

        public static StorageClass Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                case Enumerant.UniformConstant :
                    return UniformConstant.Parse(reader, wordCount - 1);
                case Enumerant.Input :
                    return Input.Parse(reader, wordCount - 1);
                case Enumerant.Uniform :
                    return Uniform.Parse(reader, wordCount - 1);
                case Enumerant.Output :
                    return Output.Parse(reader, wordCount - 1);
                case Enumerant.Workgroup :
                    return Workgroup.Parse(reader, wordCount - 1);
                case Enumerant.CrossWorkgroup :
                    return CrossWorkgroup.Parse(reader, wordCount - 1);
                case Enumerant.Private :
                    return Private.Parse(reader, wordCount - 1);
                case Enumerant.Function :
                    return Function.Parse(reader, wordCount - 1);
                case Enumerant.Generic :
                    return Generic.Parse(reader, wordCount - 1);
                case Enumerant.PushConstant :
                    return PushConstant.Parse(reader, wordCount - 1);
                case Enumerant.AtomicCounter :
                    return AtomicCounter.Parse(reader, wordCount - 1);
                case Enumerant.Image :
                    return Image.Parse(reader, wordCount - 1);
                case Enumerant.StorageBuffer :
                    return StorageBuffer.Parse(reader, wordCount - 1);
                case Enumerant.CallableDataNV :
                    return CallableDataNV.Parse(reader, wordCount - 1);
                //CallableDataKHR has the same id as another value in enum.
                //case Enumerant.CallableDataKHR :
                //    return CallableDataKHR.Parse(reader, wordCount - 1);
                case Enumerant.IncomingCallableDataNV :
                    return IncomingCallableDataNV.Parse(reader, wordCount - 1);
                //IncomingCallableDataKHR has the same id as another value in enum.
                //case Enumerant.IncomingCallableDataKHR :
                //    return IncomingCallableDataKHR.Parse(reader, wordCount - 1);
                case Enumerant.RayPayloadNV :
                    return RayPayloadNV.Parse(reader, wordCount - 1);
                //RayPayloadKHR has the same id as another value in enum.
                //case Enumerant.RayPayloadKHR :
                //    return RayPayloadKHR.Parse(reader, wordCount - 1);
                case Enumerant.HitAttributeNV :
                    return HitAttributeNV.Parse(reader, wordCount - 1);
                //HitAttributeKHR has the same id as another value in enum.
                //case Enumerant.HitAttributeKHR :
                //    return HitAttributeKHR.Parse(reader, wordCount - 1);
                case Enumerant.IncomingRayPayloadNV :
                    return IncomingRayPayloadNV.Parse(reader, wordCount - 1);
                //IncomingRayPayloadKHR has the same id as another value in enum.
                //case Enumerant.IncomingRayPayloadKHR :
                //    return IncomingRayPayloadKHR.Parse(reader, wordCount - 1);
                case Enumerant.ShaderRecordBufferNV :
                    return ShaderRecordBufferNV.Parse(reader, wordCount - 1);
                //ShaderRecordBufferKHR has the same id as another value in enum.
                //case Enumerant.ShaderRecordBufferKHR :
                //    return ShaderRecordBufferKHR.Parse(reader, wordCount - 1);
                case Enumerant.PhysicalStorageBuffer :
                    return PhysicalStorageBuffer.Parse(reader, wordCount - 1);
                //PhysicalStorageBufferEXT has the same id as another value in enum.
                //case Enumerant.PhysicalStorageBufferEXT :
                //    return PhysicalStorageBufferEXT.Parse(reader, wordCount - 1);
                default:
                    throw new IndexOutOfRangeException("Unknown StorageClass "+id);
            }
        }
        
        public static StorageClass ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<StorageClass> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<StorageClass>();
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