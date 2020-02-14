using System.Collections.Generic;

namespace Toe.SPIRV.Reflection
{
    public class SpirvStructure: SpirvTypeBase
    {
        private uint? _sizeInBytes;
        public SpirvStructure():base(SpirvType.CustomStruct)
        {
        }

        public IList<SpirvStructureField> Fields { get; } = new List<SpirvStructureField>();

        public void EvaluateLayout()
        {
            if (Fields.Count == 0)
            {
                _sizeInBytes = 0;
                return;
            }

            var last = Fields[Fields.Count-1];
            _sizeInBytes = last.ByteOffset + last.Type.SizeInBytes;
        }

        public override uint SizeInBytes
        {
            get
            {
                if (!_sizeInBytes.HasValue)
                    EvaluateLayout();
                return _sizeInBytes.Value;
            }
        }
    }
}