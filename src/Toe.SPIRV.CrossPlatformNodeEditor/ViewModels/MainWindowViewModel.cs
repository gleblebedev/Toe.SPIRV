using System;
using System.Collections.Generic;
using System.Text;
using Toe.Scripting;
using Toe.Scripting.Avalonia.ViewModels;
using Toe.SPIRV.NodeEditor;
using Toe.SPIRV.Reflection;
using Veldrid;
using Veldrid.SPIRV;

namespace Toe.SPIRV.CrossPlatformNodeEditor.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Script = new ScriptViewModel();

            SetGLSL(@"
#version 450
layout(location = 0) in int Attr;
void main()
{
    float x = 1.1;
    for (int i=0; i<Attr;++i)
    {
        //x *= x;
    }
    gl_Position = vec4(x);
}", ShaderStages.Vertex, true);
        }


        public void SetGLSL(string sourceText, ShaderStages stage, bool debug = true)
        {
            var bytes = Veldrid.SPIRV.SpirvCompilation.CompileGlslToSpirv(sourceText, "shader.spv", stage,
                new GlslCompileOptions(debug));
            Script.Script = ShaderScriptConverter.Convert(new ShaderReflection(Shader.Parse(bytes.SpirvBytes)));
        }

        public ScriptViewModel Script { get; set; }
    }
}
