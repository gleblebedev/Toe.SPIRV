using System;
using System.IO;
using CommandLine;
using Toe.SPIRV.CodeGenerator.Model.Grammar;
using Toe.SPIRV.CodeGenerator.Views;

namespace Toe.SPIRV.CodeGenerator
{
    public class GenerateReflectionNodes
    {
        [Verb("genreflectionnodes")]
        public class Options
        {
            [Option('g', "grammar", Required = false, HelpText = "Path to toe.spirv.grammar.json file")]
            public string Grammar { get; set; } = "toe.spirv.grammar.json";


            [Option('o', "output", Required = false, HelpText = "Path to the output folder")]
            public string Output { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "Nodes");
        }

        private SpirvInstructions _grammar;

        public void Run(Options options)
        {
            _grammar = Utils.LoadGrammar(options.Grammar);
            Directory.CreateDirectory(options.Output);
            foreach (var instruction in _grammar.Instructions)
            {
                var spirvInstruction = instruction.Value;
                if (spirvInstruction.Kind != InstructionKind.Type)
                {
                    var text = new NodeTemplate(spirvInstruction).TransformText();
                    Utils.SaveText(Path.Combine(options.Output, spirvInstruction.Name.Substring(2)+".cs"), text);
                    Console.WriteLine($"                case Op.{spirvInstruction.Name}: return new {spirvInstruction.Name.Substring(2)}();");
                }
                else
                {
                    var text = new TypeTemplate(spirvInstruction).TransformText();
                    Utils.SaveText(Path.Combine(options.Output, spirvInstruction.Name.Substring(2) + ".cs"), text);
                    //Console.WriteLine($"                case Op.{spirvInstruction.Name}: return new {spirvInstruction.Name.Substring(2)}();");
                }
            }
        }
    }
}