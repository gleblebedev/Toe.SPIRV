using Toe.Scripting.WPF.ViewModels;
using Toe.SPIRV.Reflection;
using Veldrid;
using Veldrid.SPIRV;

namespace Toe.SPIRV.NodeEditor.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Script = new ScriptViewModel();

            SetGLSL(@"
#version 450
void main()
{
    gl_Position = vec4(0,0,0,1);
}",
                @"
#version 450
layout(location = 0) out vec4 fragColor;
void main()
{
    fragColor = vec4(1,0,1,1);
}");

            //            SetGLSL(@"
            //#version 450
            //layout(location = 0) in int Attr;
            //void main()
            //{
            //    float x = 1.1;
            //    for (int i=0; i<Attr;++i)
            //    {
            //        x *= x;
            //    }
            //    gl_Position = vec4(x);
            //}", ShaderStages.Vertex, true);
            //
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
