#version 450

layout (set=0, binding=0) uniform Uniforms
{
    vec3      iResolution;           // viewport resolution (in pixels)
    float     iTime;                 // shader playback time (in seconds)
    float     iTimeDelta;            // render time (in seconds)
    int       iFrame;                // shader playback frame
    float     iChannelTime[4];       // channel playback time (in seconds)
    vec3      iChannelResolution[4]; // channel resolution (in pixels)
    vec4      iMouse;                // mouse pixel coords. xy: current (if MLB down), zw: click
    vec4      iDate;                 // (year, month, day, time in seconds)
    float     iSampleRate;           // sound sample rate (i.e., 44100)
};

void main()
{
}