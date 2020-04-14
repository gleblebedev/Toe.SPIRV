using System.Collections.Generic;
using System.Linq;
using Toe.Scripting;
using Toe.SPIRV.Reflection;
using Toe.SPIRV.Reflection.Nodes;

namespace Toe.SPIRV.NodeEditor
{
    internal class ShaderToScriptConverter
    {
        Dictionary<Node, ScriptNode> _nodeMap = new Dictionary<Node, ScriptNode>();
        Script _script = new Script();
        public Script Convert(ShaderReflection reflection)
        {
            VisitNode(reflection.EntryFunction);
            return _script;
        }

        private ScriptNode VisitNode(Node node)
        {
            if (node == null)
                return null;
            if (_nodeMap.TryGetValue(node, out var scriptNode))
                return scriptNode;
            scriptNode = new ScriptNode() {Name = node.GetType().Name};
            _script.Nodes.Add(scriptNode);
            _nodeMap.Add(node, scriptNode);

            foreach (var pin in node.InputPins)
            {
                scriptNode.InputPins.Add(new PinWithConnection(pin.Name, pin.Type?.ToString()));
            }
            foreach (var pin in node.OutputPins)
            {
                scriptNode.OutputPins.Add(new Pin(pin.Name, pin.Type?.ToString()));
            }
            foreach (var pin in node.ExitPins)
            {
                scriptNode.ExitPins.Add(new PinWithConnection(pin.Name, pin.Type?.ToString()));
            }
            foreach (var pin in node.EnterPins)
            {
                scriptNode.EnterPins.Add(new Pin(pin.Name, pin.Type?.ToString()));
            }

            int index;
            index = 0;
            foreach (var inputPin in node.InputPins)
            {
                var connectedPin = inputPin.ConnectedPin;
                if (connectedPin.HasValue)
                {
                    var connectedNode = connectedPin?.Node;
                    if (connectedNode != null)
                    {
                        var script = VisitNode(connectedNode);
                        scriptNode.InputPins[index].Connection = new Connection(script, connectedPin.Value.Name);
                    }
                }
                ++index;
            }
            index = 0;
            foreach (var exitPin in node.ExitPins)
            {
                var connectedPin = exitPin.ConnectedPin;
                if (connectedPin.HasValue)
                {
                    var connectedNode = connectedPin?.Node;
                    if (connectedNode != null)
                    {
                        var script = VisitNode(connectedNode);
                        scriptNode.ExitPins[index].Connection = new Connection(script, connectedPin.Value.Name);
                    }
                }

                ++index;
            }

            return scriptNode;
        }
    }
}