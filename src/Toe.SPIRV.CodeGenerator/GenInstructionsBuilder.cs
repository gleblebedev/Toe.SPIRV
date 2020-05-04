using System;
using CommandLine;
using Toe.SPIRV.CodeGenerator.Model.Grammar;
using Toe.SPIRV.CodeGenerator.Views;

namespace Toe.SPIRV.CodeGenerator
{
    public class GenInstructionsBuilder
    {
        [Verb("geninstructionbuilder")]
        public class Options
        {
            [Option('g', "grammar", Required = false, HelpText = "Path to toe.spirv.grammar.json file")]
            public string Grammar { get; set; } = "toe.spirv.grammar.json";

            [Option('o', "output", Required = false, HelpText = "SpirvInstructionsBuilderBase.cs full file path and name")]
            public string Output { get; set; }
        }

        private SpirvInstructions _grammar;

        public void Run(Options options)
        {
            _grammar = Utils.LoadGrammar(options.Grammar);


            var text = new SpirvInstructionsBuilderTemplate(_grammar).TransformText();
            if (!string.IsNullOrWhiteSpace(options.Output))
                Utils.SaveText(options.Output, text);
            else
                Console.WriteLine(text);
        }
    }
}