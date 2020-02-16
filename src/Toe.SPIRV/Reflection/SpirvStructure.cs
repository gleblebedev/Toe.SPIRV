﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Toe.SPIRV.Reflection
{
    public class SpirvStructure : SpirvTypeBase
    {
        private readonly List<SpirvStructureField> _fields = new List<SpirvStructureField>();
        private uint? _sizeInBytes;
        private uint? _alignment;

        public SpirvStructure(string name, params SpirvStructureField[] fields) : base(SpirvTypeCategory.Struct)
        {
            Name = name;
            _fields.AddRange(fields);
            if (_fields.Any(_ => _.ByteOffset == null)) UpdateFieldOffsets();
            EvaluateSizeAndAlignment();
        }

        public override uint Alignment
        {
            get
            {
                if (!_alignment.HasValue)
                    throw new InvalidOperationException("Please execute EvaluateLayout() to calculate property value");
                return _alignment.Value;
            }
        }
        //public void EvaluateLayout()
        //{
        //    UpdateFieldOffsets();
        //    EvaluateSizeAndAlignment();
        //}

        public override uint SizeInBytes
        {
            get
            {
                if (!_alignment.HasValue)
                    throw new InvalidOperationException("Please execute EvaluateLayout() to calculate property value");
                return _sizeInBytes.Value;
            }
        }

        public string Name { get; }

        public IReadOnlyList<SpirvStructureField> Fields => _fields;

        public override string ToString()
        {
            return Name ?? base.ToString();
        }

        private void UpdateFieldOffsets()
        {
            uint offset = 0;
            foreach (var field in _fields)
            {
                var alignment = field.Type.Alignment;
                var pos = SpirvUtils.RoundUp(offset, alignment);
                field.ByteOffset = pos;
                offset = pos + field.Type.SizeInBytes;
            }
        }

        private void EvaluateSizeAndAlignment()
        {
            if (Fields.Count == 0)
            {
                _sizeInBytes = 0;
                _alignment = 0;
                return;
            }

            uint size = 0;
            uint maxAlignment = 16;
            foreach (var field in _fields)
            {
                var alignment = field.Type.Alignment;
                if (maxAlignment < alignment)
                    maxAlignment = alignment;
                var end = field.ByteOffset.Value + field.Type.SizeInBytes;
                if (end > size)
                    size = end;
            }

            _alignment = maxAlignment;
            _sizeInBytes = SpirvUtils.RoundUp(size, maxAlignment);
        }
    }
}