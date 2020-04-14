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
            //var scriptScript = new Script();
            //var a = new ScriptNode() { Name = "A" };
            //a.OutputPins.Add(new Pin("output", "float"));
            //a.EnterPins.Add(new Pin("enter", "float"));
            //a.ExitPins.Add(new PinWithConnection("exit", "float"));
            //a.InputPins.Add(new PinWithConnection("input", "float"));
            //scriptScript.Nodes.Add(a);
            //var b = new ScriptNode() { Name = "B" };
            //b.InputPins.Add(new PinWithConnection("input", "float", new Connection(a, a.OutputPins[0])));
            //scriptScript.Nodes.Add(b);
            //var c = new ScriptNode() { Name = "C" };
            //c.InputPins.Add(new PinWithConnection("input", "float", new Connection(a, a.OutputPins[0])));
            //scriptScript.Nodes.Add(c);

            //Script.Script = scriptScript;

            SetGLSL(@"
#version 450
layout(location = 0) in float Attr;
float GetX(float a) { return a+1; }
void main()
{
    gl_Position = vec4(0,GetX(Attr),2,3);
}", ShaderStages.Vertex);

//            SetGLSL(@"
//#version 450
//layout(location = 0) in int Attr;
//void main()
//{
//    float x = 1.1;
//    for (int i=0; i<Attr;++i)
//        x *= x;
//    gl_Position = vec4(x);
//}", ShaderStages.Vertex, true);
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
