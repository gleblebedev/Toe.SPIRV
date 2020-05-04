using Toe.Scripting.WPF.ViewModels;
using Toe.SPIRV.Reflection;
using Veldrid;
using Veldrid.SPIRV;

namespace Toe.SPIRV.NodeEditor.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
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
        public MainWindowViewModel()
        {
            Script = new ScriptViewModel();

            //            SetGLSL(@"
            //#version 450
            //void main()
            //{
            //    gl_Position = vec4(0,0,0,1);
            //}",
            //                @"
            //#version 450
            //layout(location = 0) out vec4 fragColor;
            //void main()
            //{
            //    fragColor = vec4(1,0,1,1);
            //}");

            SetGLSL(_vertexShaderSource, _fragmentShaderSource);
        }


        public void SetGLSL(string vertexSource, string fragmentSource, bool debug = true)
        {
            var vertexBytes = Veldrid.SPIRV.SpirvCompilation.CompileGlslToSpirv(vertexSource, "shader.spv", ShaderStages.Vertex, new GlslCompileOptions(debug));
            var vertexReflection = new ShaderReflection(Shader.Parse(vertexBytes.SpirvBytes));
            var fragmentBytes = Veldrid.SPIRV.SpirvCompilation.CompileGlslToSpirv(fragmentSource, "shader.spv", ShaderStages.Fragment, new GlslCompileOptions(debug));
            var fragmentReflection = new ShaderReflection(Shader.Parse(fragmentBytes.SpirvBytes));
            Script.Script = ShaderScriptConverter.Convert(vertexReflection, fragmentReflection);
        }

        public ScriptViewModel Script { get; set; }
    }
}
