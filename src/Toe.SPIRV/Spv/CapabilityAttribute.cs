using System;

namespace Toe.SPIRV.Spv
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class CapabilityAttribute : Attribute
    {
        public CapabilityAttribute(Capability.Enumerant capability)
        {
            Capability = capability;
        }

        public Capability.Enumerant Capability { get; }
    }
}