using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Toe.SPIRV.NodeEditor.ShaderToyUniforms
{
    [StructLayout(LayoutKind.Explicit)]
    public partial struct Uniforms
    {
        [FieldOffset(0)]
        public Vector3 iResolution;

        [FieldOffset(12)]
        public float iTime;

        [FieldOffset(16)]
        public float iTimeDelta;

        [FieldOffset(20)]
        public int iFrame;

        [FieldOffset(32)]
        public float iChannelTime0;
        [FieldOffset(48)]
        public float iChannelTime1;
        [FieldOffset(64)]
        public float iChannelTime2;
        [FieldOffset(80)]
        public float iChannelTime3;

        [FieldOffset(96)]
        public Vector3 iChannelResolution0;
        [FieldOffset(112)]
        public Vector3 iChannelResolution1;
        [FieldOffset(128)]
        public Vector3 iChannelResolution2;
        [FieldOffset(144)]
        public Vector3 iChannelResolution3;

        [FieldOffset(160)]
        public Vector4 iMouse;

        [FieldOffset(176)]
        public Vector4 iDate;

        [FieldOffset(192)]
        public float iSampleRate;
    }
}
