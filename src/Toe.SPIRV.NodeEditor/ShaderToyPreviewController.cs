using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using Veldrid;
using Veldrid.SPIRV;

namespace Toe.SPIRV.NodeEditor
{
    public class ShaderToyPreviewController: IPreviewController
    {
        private GraphicsDevice _device;

        private string _vertexShaderSource = @"
#version 450

layout (location = 0) out vec2 fragCoord;

const vec4 QuadInfos[4] = 
{
    vec4(-1, 1, 0, 0),
    vec4(1, 1, 1, 0),
    vec4(-1, -1, 0, 1),
    vec4(1, -1, 1, 1),
};

void main()
{
    gl_Position = vec4(QuadInfos[gl_VertexIndex].xy, 1, 1);
    fragCoord = QuadInfos[gl_VertexIndex].zw;
}";

        private string _fragmentShaderSource = @"
#version 450

// Vortex Street by dr2 - 2015
// License: Creative Commons Attribution-NonCommercial-ShareAlike 3.0 Unported License

// Motivated by implementation of van Wijk's IBFV by eiffie (lllGDl) and andregc (4llGWl) 

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


const vec4 cHashA4 = vec4(0., 1., 57., 58.);
const vec3 cHashA3 = vec3(1., 57., 113.);
const float cHashM = 43758.54;

vec4 Hashv4f(float p)
{
    return fract(sin(p + cHashA4) * cHashM);
}

float Noisefv2(vec2 p)
{
    vec2 i = floor(p);
    vec2 f = fract(p);
    f = f * f * (3. - 2. * f);
    vec4 t = Hashv4f(dot(i, cHashA3.xy));
    return mix(mix(t.x, t.y, f.x), mix(t.z, t.w, f.x), f.y);
}

float Fbm2(vec2 p)
{
    float s = 0.;
    float a = 1.;
    for (int i = 0; i < 6; i++)
    {
        s += a * Noisefv2(p);
        a *= 0.5;
        p *= 2.;
    }
    return s;
}

float tCur;

vec2 VortF(vec2 q, vec2 c)
{
    vec2 d = q - c;
    return 0.25 * vec2(d.y, -d.x) / (dot(d, d) + 0.05);
}

vec2 FlowField(vec2 q)
{
    vec2 vr, c;
    float dir = 1.;
    c = vec2(mod(tCur, 10.) - 20., 0.6 * dir);
    vr = vec2(0.);
    for (int k = 0; k < 30; k++)
    {
        vr += dir * VortF(4. * q, c);
        c = vec2(c.x + 1., -c.y);
        dir = -dir;
    }
    return vr;
}

layout (location = 0) in vec2 fragCoord;
layout (location = 0) out vec4 fragColor;


void main()
{
    vec2 uv = gl_FragCoord.xy / iResolution.xy - 0.5;
    uv.x *= iResolution.x / iResolution.y;
    tCur = iTime;
    vec2 p = uv;
    for (int i = 0; i < 10; i++) p -= FlowField(p) * 0.03;
    vec3 col = Fbm2(5. * p + vec2(-0.1 * tCur, 0.)) *
        vec3(0.5, 0.5, 1.);
    fragColor = vec4(col, 1.);
}
";

        private ResourceFactory _resources;
        private Pipeline _pipeline;
        private ResourceLayout _resourceLayout;
        private CommandList _cl;
        private DeviceBuffer _uniforms;
        private ResourceSet _resourceSet;
        private ShaderToyUniforms.Uniforms _uniformValues;

        public void DeviceDestroyed()
        {
        }

        public void DeviceCreated(GraphicsDevice device)
        {
            _device = device;
            _resources = _device.ResourceFactory;

            var vertexShaderDescription = new ShaderDescription(ShaderStages.Vertex, Encoding.ASCII.GetBytes(_vertexShaderSource), "main");
            var fragmentShaderDescription = new ShaderDescription(ShaderStages.Fragment, Encoding.ASCII.GetBytes(_fragmentShaderSource), "main");
            var shaders = _resources.CreateFromSpirv(vertexShaderDescription, fragmentShaderDescription);

            var shaderSetDescription = new ShaderSetDescription(new VertexLayoutDescription[0], shaders);

            _resourceLayout = _resources.CreateResourceLayout(new ResourceLayoutDescription(new ResourceLayoutElementDescription("Uniforms", ResourceKind.UniformBuffer, ShaderStages.Fragment)));

            var sizeOf = (uint) Marshal.SizeOf<ShaderToyUniforms.Uniforms>();
            sizeOf = ((sizeOf + 15) / 16) * 16;
            _uniforms = _resources.CreateBuffer(new BufferDescription(
                sizeOf, BufferUsage.Dynamic | BufferUsage.UniformBuffer));

            _resourceSet = _resources.CreateResourceSet(new ResourceSetDescription(_resourceLayout, _uniforms));

            _pipeline = _resources.CreateGraphicsPipeline(new GraphicsPipelineDescription(
                BlendStateDescription.SingleOverrideBlend, 
                DepthStencilStateDescription.Disabled, 
                RasterizerStateDescription.CullNone, 
                PrimitiveTopology.TriangleStrip,
                shaderSetDescription,
                new ResourceLayout[]{ _resourceLayout, },
                _device.MainSwapchain.Framebuffer.OutputDescription
                ));

            _cl = _resources.CreateCommandList();

        }

        public void Render(float elapsedTotalSeconds)
        {
            _uniformValues.iTime += elapsedTotalSeconds;
            _uniformValues.iTimeDelta = elapsedTotalSeconds;
            _uniformValues.iSampleRate = 44100;
            _cl.Begin();

            _cl.UpdateBuffer(_uniforms, 0, ref _uniformValues);

            _cl.SetFramebuffer(_device.MainSwapchain.Framebuffer);
            _cl.ClearColorTarget(0, RgbaFloat.Black);
            _cl.ClearDepthStencil(1f);
            _cl.SetPipeline(_pipeline);
            _cl.SetGraphicsResourceSet(0, _resourceSet);
            _cl.Draw(4);

            _cl.End();
            _device.SubmitCommands(_cl);
            _device.SwapBuffers(_device.MainSwapchain);
            _device.WaitForIdle();
        }

        public void Resized(uint width, uint height)
        {
            _uniformValues.iResolution = new Vector3(width, height, 1);
        }
    }


    /*
uniform vec3      iResolution;           // viewport resolution (in pixels)
uniform float     iTime;                 // shader playback time (in seconds)
uniform float     iTimeDelta;            // render time (in seconds)
uniform int       iFrame;                // shader playback frame
uniform float     iChannelTime[4];       // channel playback time (in seconds)
uniform vec3      iChannelResolution[4]; // channel resolution (in pixels)
uniform vec4      iMouse;                // mouse pixel coords. xy: current (if MLB down), zw: click
uniform samplerXX iChannel0..3;          // input channel. XX = 2D/Cube
uniform vec4      iDate;                 // (year, month, day, time in seconds)
uniform float     iSampleRate;           // sound sample rate (i.e., 44100)
     */
}