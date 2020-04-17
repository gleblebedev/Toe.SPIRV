using System;
using System.Collections.Generic;

namespace Toe.SPIRV.Spv
{
    public abstract partial class Scope : ValueEnum
    {
        public enum Enumerant
        {
            CrossDevice = 0,
            Device = 1,
            Workgroup = 2,
            Subgroup = 3,
            Invocation = 4,
            [Capability(Capability.Enumerant.VulkanMemoryModel)]
            QueueFamily = 5,
            [Capability(Capability.Enumerant.VulkanMemoryModel)]
            QueueFamilyKHR = 5,
            [Capability(Capability.Enumerant.RayTracingProvisionalKHR)]
            ShaderCallKHR = 6,
        }

        public class CrossDevice: Scope
        {
            public override Enumerant Value => Scope.Enumerant.CrossDevice;
            public new static CrossDevice Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new CrossDevice();
                return res;
            }
        }
        public class Device: Scope
        {
            public override Enumerant Value => Scope.Enumerant.Device;
            public new static Device Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Device();
                return res;
            }
        }
        public class Workgroup: Scope
        {
            public override Enumerant Value => Scope.Enumerant.Workgroup;
            public new static Workgroup Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Workgroup();
                return res;
            }
        }
        public class Subgroup: Scope
        {
            public override Enumerant Value => Scope.Enumerant.Subgroup;
            public new static Subgroup Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Subgroup();
                return res;
            }
        }
        public class Invocation: Scope
        {
            public override Enumerant Value => Scope.Enumerant.Invocation;
            public new static Invocation Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Invocation();
                return res;
            }
        }
        public class QueueFamily: Scope
        {
            public override Enumerant Value => Scope.Enumerant.QueueFamily;
            public new static QueueFamily Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new QueueFamily();
                return res;
            }
        }
        public class QueueFamilyKHR: Scope
        {
            public override Enumerant Value => Scope.Enumerant.QueueFamilyKHR;
            public new static QueueFamilyKHR Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new QueueFamilyKHR();
                return res;
            }
        }
        public class ShaderCallKHR: Scope
        {
            public override Enumerant Value => Scope.Enumerant.ShaderCallKHR;
            public new static ShaderCallKHR Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new ShaderCallKHR();
                return res;
            }
        }

        public abstract Enumerant Value { get; }

        public static Scope Parse(WordReader reader, uint wordCount)
        {
            var id = (Enumerant) reader.ReadWord();
            switch (id)
            {
                case Enumerant.CrossDevice :
                    return CrossDevice.Parse(reader, wordCount - 1);
                case Enumerant.Device :
                    return Device.Parse(reader, wordCount - 1);
                case Enumerant.Workgroup :
                    return Workgroup.Parse(reader, wordCount - 1);
                case Enumerant.Subgroup :
                    return Subgroup.Parse(reader, wordCount - 1);
                case Enumerant.Invocation :
                    return Invocation.Parse(reader, wordCount - 1);
                case Enumerant.QueueFamily :
                    return QueueFamily.Parse(reader, wordCount - 1);
                //QueueFamilyKHR has the same id as another value in enum.
                //case Enumerant.QueueFamilyKHR :
                //    return QueueFamilyKHR.Parse(reader, wordCount - 1);
                case Enumerant.ShaderCallKHR :
                    return ShaderCallKHR.Parse(reader, wordCount - 1);
                default:
                    throw new IndexOutOfRangeException("Unknown Scope "+id);
            }
        }
        
        public static Scope ParseOptional(WordReader reader, uint wordCount)
        {
            if (wordCount == 0) return null;
            return Parse(reader, wordCount);
        }

        public static IList<Scope> ParseCollection(WordReader reader, uint wordCount)
        {
            var end = reader.Position + wordCount;
            var res = new PrintableList<Scope>();
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