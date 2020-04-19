using System.Collections.Generic;
using System.Linq;
using Toe.Scripting;
using Toe.SPIRV.Reflection;
using Toe.SPIRV.Reflection.Nodes;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV.NodeEditor
{
    internal class ShaderToScriptConverter
    {
        private readonly Dictionary<Node, ScriptNode> _nodeMap = new Dictionary<Node, ScriptNode>();
        private readonly Script _script = new Script();

        public Script Convert(ShaderReflection reflection)
        {
            foreach (var node in reflection.EntryPointInstructions)
            {
                VisitNode(node.Value, null, null, null);
            }
            return _script;
        }

        private ScriptNode VisitNode(Node node, Node mergeNode, Node continueNode, Node loopNode)
        {
            if (node == null)
                return null;
            if (_nodeMap.TryGetValue(node, out var scriptNode))
                return scriptNode;

            Node childMergeNode = mergeNode;
            Node childContinueNode = continueNode;
            switch (node.OpCode)
            {
                case Op.OpSelectionMerge:
                    var selectionMerge = (SelectionMerge) node;
                    childMergeNode = selectionMerge.MergeBlock;
                    break;
                case Op.OpLoopMerge:
                    var loopMerge = (LoopMerge)node;
                    childMergeNode = loopMerge.MergeBlock;
                    childContinueNode = loopMerge.ContinueTarget;
                    break;
            }

            scriptNode = new ScriptNode {Name = node.GetType().Name};
            if (node is Constant constant)
            {
                scriptNode.Value = constant.Value.ToString();
            }
            else
            {
                scriptNode.Value = node.DebugName;
            }
            _script.Nodes.Add(scriptNode);
            _nodeMap.Add(node, scriptNode);

            foreach (var pin in node.InputPins)
                scriptNode.InputPins.Add(new PinWithConnection(pin.Name, pin.Type?.ToString()));
            foreach (var pin in node.OutputPins) scriptNode.OutputPins.Add(new Pin(pin.Name, pin.Type?.ToString()));
            foreach (var pin in node.ExitPins)
                scriptNode.ExitPins.Add(new PinWithConnection(pin.Name, pin.Type?.ToString()));
            foreach (var pin in node.EnterPins) scriptNode.EnterPins.Add(new Pin(pin.Name, pin.Type?.ToString()));

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
                        var script = VisitNode(connectedNode, childMergeNode, childContinueNode, loopNode);
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
                        if (connectedNode == mergeNode || connectedNode == continueNode || connectedNode == loopNode)
                            continue;
                        switch (connectedNode.OpCode)
                        {
                            case Op.OpBranch:
                                var branch = (Branch) connectedNode;
                                if (branch.TargetLabel == mergeNode || branch.TargetLabel == continueNode || branch.TargetLabel == loopNode)
                                    continue;
                                break;
                        }

                        // TODO: OpLoopMerge.Next should break when goes to Continue only!
                        // TODO: OpLoopMerge.Continue should break when goes back to loopNode only!
                        var script = VisitNode(connectedNode, childMergeNode, childContinueNode, (connectedNode.OpCode == Op.OpLoopMerge)?node:loopNode);
                        scriptNode.ExitPins[index].Connection = new Connection(script, connectedPin.Value.Name);
                    }
                }

                ++index;
            }

            return scriptNode;
        }
    }
}