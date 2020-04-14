using System;
using System.IO;
using Toe.SPIRV.CodeGenerator.Model.Grammar;
using Toe.SPIRV.CodeGenerator.Views;

namespace Toe.SPIRV.CodeGenerator
{
    public class GenerateReflectionNodes
    {
        private SpirvInstructions _grammar;

        public void Run(GenerateReflectionNodesOptions options)
        {
            _grammar = Utils.LoadGrammar(options.Grammar);
            Directory.CreateDirectory(options.Output);
            foreach (var instruction in _grammar.Instructions)
            {
                var spirvInstruction = instruction.Value;
                if (spirvInstruction.Kind == InstructionKind.Function ||
                    spirvInstruction.Kind == InstructionKind.Executable)
                {
                    var text = new NodeTemplate(spirvInstruction).TransformText();
                    Utils.SaveText(Path.Combine(options.Output, spirvInstruction.Name.Substring(2)+".cs"), text);
                    Console.WriteLine($"                case Op.{spirvInstruction.Name}: return new {spirvInstruction.Name.Substring(2)}();");
                }
            }
        }
    }
}