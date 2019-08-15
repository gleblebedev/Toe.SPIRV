﻿using Toe.SPIRV.Spv;

namespace Toe.SPIRV.Instructions
{
    public class ReferenceProperty
    {
        public ReferenceProperty(string name, IdRef reference)
        {
            Name = name;
            Reference = reference;
        }

        public string Name { get; }

        public IdRef Reference { get; }
    }
}