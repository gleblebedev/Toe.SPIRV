using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CommandLine;
using Toe.SPIRV.CodeGenerator.Model.Grammar;

namespace Toe.SPIRV.CodeGenerator
{
    public class Custom
    {
        private SpirvInstructions _grammar;

        [Verb("custom")]
        public class Options
        {
            [Option('g', "grammar", Required = false, HelpText = "Path to toe.spirv.grammar.json file")]
            public string Grammar { get; set; } = "toe.spirv.grammar.json";
        }

        public void Run(Options options)
        {
            _grammar = Utils.LoadGrammar(options.Grammar);

            Console.WriteLine($"_factories = new Func<Instruction>[{_grammar.Instructions.Keys.Max()+1}];");
            foreach (var instruction in _grammar.Instructions)
            {
                if (instruction.Value.Name.StartsWith("OpType"))
                    Console.WriteLine($"{instruction.Value.Name},");
                //Console.WriteLine($"_factories[(int)Op.{instruction.Value.Name}] = () => new {instruction.Value.Name}();");
            }
        }
    }

}
