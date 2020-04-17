using System.IO;
using CommandLine;
using Toe.SPIRV.CodeGenerator.Model.Grammar;
using Toe.SPIRV.CodeGenerator.Views;

namespace Toe.SPIRV.CodeGenerator
{
    public class GenerateOperands
    {
        [Verb("genoperands")]
        public class Options
        {
            [Option('g', "grammar", Required = false, HelpText = "Path to toe.spirv.grammar.json file")]
            public string Grammar { get; set; } = "toe.spirv.grammar.json";


            [Option('o', "output", Required = false, HelpText = "Path to the output folder")]
            public string Output { get; set; } = Path.Combine(Directory.GetCurrentDirectory(), "Spv");
        }
        private SpirvInstructions _grammar;

        public void Run(Options options)
        {
            _grammar = Utils.LoadGrammar(options.Grammar);
            Directory.CreateDirectory(options.Output);
            foreach (var instruction in _grammar.OperandKinds)
            {
                switch (instruction.Value.Category)
                {
                    case SpirvOperandCategory.BitEnum:
                    {
                        var text = new FlagTemplate(instruction.Value).TransformText();
                        Utils.SaveText(Path.Combine(options.Output, instruction.Value.Name + ".cs"), text);
                        break;
                    }
                    case SpirvOperandCategory.ValueEnum:
                    {
                        var text = new EnumTemplate(instruction.Value).TransformText();
                        Utils.SaveText(Path.Combine(options.Output, instruction.Value.Name + ".cs"), text);
                        break;
                    }
                }
            }
        }
    }
}