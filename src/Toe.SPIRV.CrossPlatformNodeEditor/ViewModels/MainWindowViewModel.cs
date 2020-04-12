using System;
using System.Collections.Generic;
using System.Text;
using Toe.Scripting;
using Toe.Scripting.Avalonia.ViewModels;

namespace Toe.SPIRV.CrossPlatformNodeEditor.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Script = new ScriptViewModel();
            var scriptScript = new Script();
            var a = new ScriptNode() { Name = "A" };
            a.OutputPins.Add(new Pin("output", "float"));
            a.EnterPins.Add(new Pin("enter", "float"));
            a.ExitPins.Add(new PinWithConnection("exit", "float"));
            a.InputPins.Add(new PinWithConnection("input", "float"));
            scriptScript.Nodes.Add(a);
            var b = new ScriptNode() { Name = "B" };
            b.InputPins.Add(new PinWithConnection("input", "float", new Connection(a, a.OutputPins[0])));
            scriptScript.Nodes.Add(b);
            var c = new ScriptNode() { Name = "C" };
            c.InputPins.Add(new PinWithConnection("input", "float", new Connection(a, a.OutputPins[0])));
            scriptScript.Nodes.Add(c);

            Script.Script = scriptScript;
        }
        public ScriptViewModel Script { get; set; }
    }
}
