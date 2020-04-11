using System;
using System.Collections.Generic;
using System.Text;
using Toe.Scripting.Avalonia.ViewModels;

namespace Toe.SPIRV.CrossPlatformNodeEditor.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Script = new ScriptViewModel();
        }
        public ScriptViewModel Script { get; set; }
    }
}
