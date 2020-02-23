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
        }

        public class UniformConstant: StorageClass
        {
            public override Enumerant Value => StorageClass.Enumerant.UniformConstant;
            public new static UniformConstant Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new UniformConstant();
                return res;
            }
        }
        public class Input: StorageClass
        {
            public override Enumerant Value => StorageClass.Enumerant.Input;
            public new static Input Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Input();
                return res;
            }
        }
        public class Uniform: StorageClass
        {
            public override Enumerant Value => StorageClass.Enumerant.Uniform;
            public new static Uniform Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Uniform();
                return res;
            }
        }
        public class Output: StorageClass
        {
            public override Enumerant Value => StorageClass.Enumerant.Output;
            public new static Output Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Output();
                return res;
            }
        }
        public class Workgroup: StorageClass
        {
            public override Enumerant Value => StorageClass.Enumerant.Workgroup;
            public new static Workgroup Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Workgroup();
                return res;
            }
        }
        public class CrossWorkgroup: StorageClass
        {
            public override Enumerant Value => StorageClass.Enumerant.CrossWorkgroup;
            public new static CrossWorkgroup Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new CrossWorkgroup();
                return res;
            }
        }
        public class Private: StorageClass
        {
            public override Enumerant Value => StorageClass.Enumerant.Private;
            public new static Private Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Private();
                return res;
            }
        }
        public class Function: StorageClass
        {
            public override Enumerant Value => StorageClass.Enumerant.Function;
            public new static Function Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Function();
                return res;
            }
        }
        public class Generic: StorageClass
        {
            public override Enumerant Value => StorageClass.Enumerant.Generic;
            public new static Generic Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Generic();
                return res;
            }
        }
        public class PushConstant: StorageClass
        {
            public override Enumerant Value => StorageClass.Enumerant.PushConstant;
            public new static PushConstant Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new PushConstant();
                return res;
            }
        }
        public class AtomicCounter: StorageClass
        {
            public override Enumerant Value => StorageClass.Enumerant.AtomicCounter;
            public new static AtomicCounter Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new AtomicCounter();
                return res;
            }
        }
        public class Image: StorageClass
        {
            public override Enumerant Value => StorageClass.Enumerant.Image;
            public new static Image Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new Image();
                return res;
            }
        }
        public class StorageBuffer: StorageClass
        {
            public override Enumerant Value => StorageClass.Enumerant.StorageBuffer;
            public new static StorageBuffer Parse(WordReader reader, uint wordCount)
            {
                var end = reader.Position+wordCount;
                var res = new StorageBuffer();
                return res;
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