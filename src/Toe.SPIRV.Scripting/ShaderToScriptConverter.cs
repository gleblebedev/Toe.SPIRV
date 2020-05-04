using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Toe.Scripting;
using Toe.Scripting.Helpers;
using Toe.SPIRV.Instructions;
using Toe.SPIRV.Reflection;
using Toe.SPIRV.Reflection.Nodes;
using Toe.SPIRV.Reflection.Types;
using Toe.SPIRV.Spv;

namespace Toe.SPIRV
{
    internal class ShaderToScriptConverter: ShaderToScriptConverterBase
    {
        private readonly Dictionary<Node, ScriptNode> _nodeMap = new Dictionary<Node, ScriptNode>();

        public Script Convert(ShaderReflection vertexShader, ShaderReflection fragmentShader)
        {
            ValidateShader(vertexShader, nameof(vertexShader));
            ValidateShader(fragmentShader, nameof(fragmentShader));

            var vertex = VisitFunction(vertexShader.EntryPointInstructions[0].Value);
            var fragment = VisitFunction(fragmentShader.EntryPointInstructions[0].Value);

            var helper = new ScriptHelper(_script);
            EliminateLabels(helper);
            return helper.BuildScript();
        }

        protected override ScriptNode VisitConstant(Constant node)
        {
            var visitConstant = base.VisitConstant(node);
            visitConstant.Value = string.Format(CultureInfo.InvariantCulture, "{0}", node.Value);
            return visitConstant;
        }

        private void EliminateLabels(ScriptHelper helper)
        {
            foreach (var scriptNode in helper.Nodes)
            {
                if (scriptNode.Type == nameof(OpLabel))
                {
                    var next = scriptNode.ExitPins.ConnectedPins.FirstOrDefault();
                    if (next != null)
                    {
                        foreach (var enterPins in scriptNode.EnterPins)
                        {
                            foreach (var link in enterPins.Links.ToList())
                            {
                                helper.Link(link.From, next);
                                helper.RemoveLink(link);
                            }
                        }
                    }
                }
            }
        }

        private static void ValidateShader(ShaderReflection vertexShader, string vertexShaderName)
        {
            if (vertexShader == null)
                throw new ArgumentNullException($"{vertexShaderName} should not be null");
            if (vertexShader.EntryPointInstructions.Count != 1)
                throw new ArgumentException($"{vertexShaderName} expected to have exactly one entry point");
            if (vertexShader.EntryPointInstructions[0].Value.ResultType != SpirvTypeBase.Void)
                throw new ArgumentException($"{vertexShaderName} entry point should have void result type");
            if (vertexShader.EntryPointInstructions[0].Value.Parameters.Count != 0)
                throw new ArgumentException($"{vertexShaderName} entry point should not have arguments");
            if (((TypeFunction) vertexShader.EntryPointInstructions[0].Value.FunctionType).Arguments.Count != 0)
                throw new ArgumentException($"{vertexShaderName} entry point should not have arguments");
        }
    }
}