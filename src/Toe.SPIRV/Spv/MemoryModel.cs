using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public abstract partial class MemoryModel : ValueEnum
    {
        public enum Enumerant
        {
            [Capability(Capability.Enumerant.Shader)]
            Simple = 0,
            [Capability(Capability.Enumerant.Shader)]
            GLSL450 = 1,
            [Capability(Capability.Enumerant.Kernel)]
            OpenCL = 2,
            [Capability(Capability.Enumerant.VulkanMemoryModel)]
            Vulkan = 3,
            [Capability(Capability.Enumerant.VulkanMemoryModel)]
            VulkanKHR = 3,
        }

        public class Simple: MemoryModel
        {
            public static readonly Simple Instance = new Simple();
            public override Enumerant Value => MemoryModel.Enumerant.Simple;
            public new static Simple Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class GLSL450: MemoryModel
        {
            public static readonly GLSL450 Instance = new GLSL450();
            public override Enumerant Value => MemoryModel.Enumerant.GLSL450;
            public new static GLSL450 Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class OpenCL: MemoryModel
        {
            public static readonly OpenCL Instance = new OpenCL();
            public override Enumerant Value => MemoryModel.Enumerant.OpenCL;
            public new static OpenCL Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class Vulkan: MemoryModel
        {
            public static readonly Vulkan Instance = new Vulkan();
            public override Enumerant Value => MemoryModel.Enumerant.Vulkan;
            public new static Vulkan Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }
        public class VulkanKHR: MemoryModel
        {
            public static readonly VulkanKHR Instance = new VulkanKHR();
            public override Enumerant Value => MemoryModel.Enumerant.VulkanKHR;
            public new static VulkanKHR Parse(WordReader reader, uint wordCount)
            {
                return Instance;
            }
        }

        public abstract Enumerant Value { get; }

        public static MemoryModel Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                case Enumerant.Simple :
                    return Simple.Parse(reader, wordCount - 1);
                case Enumerant.GLSL450 :
                    return GLSL450.Parse(reader, wordCount - 1);
                case Enumerant.OpenCL :
                    return OpenCL.Parse(reader, wordCount - 1);
                case Enumerant.Vulkan :
                    return Vulkan.Parse(reader, wordCount - 1);
                //VulkanKHR has the same id as another value in enum.
                //case Enumerant.VulkanKHR :
                //    return VulkanKHR.Parse(reader, wordCount - 1);
                default:
                    throw new IndexOutOfRangeException("Unknown MemoryModel "+id);
            }
        }
        
        public static MemoryModel ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<MemoryModel> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<MemoryModel>();
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