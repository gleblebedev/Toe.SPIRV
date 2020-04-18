using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CommandLine;
using Toe.SPIRV.CodeGenerator.Model.Grammar;
using Toe.SPIRV.CodeGenerator.Views;

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

            BuildNodeFactory();
            //if (instruction.Value.Name.StartsWith("OpType"))
            //    Console.WriteLine($"{instruction.Value.Name},");
            //Console.WriteLine($"_factories[(int)Op.{instruction.Value.Name}] = () => new {instruction.Value.Name}();");
        }

        private void BuildTreeBuilderTypeSegment()
        {
            foreach (var instruction in _grammar.Instructions.Where(_ => ViewUtils.IsBuildInType(_.Value.Name)))
            {
                Console.WriteLine($"case Op.{instruction.Value.Name}:");
                Console.WriteLine($"Parse{instruction.Value.Name.Substring(6)}(({instruction.Value.Name})instruction);");
                Console.WriteLine($"break;");
            }

            Console.WriteLine($"");

            foreach (var instruction in _grammar.Instructions.Where(_ => _.Value.Name.StartsWith("OpType")))
            {
                Console.WriteLine($"case Op.{instruction.Value.Name}:");
            }
            Console.WriteLine($"ParseType(instruction);");
            Console.WriteLine($"break;");

        }

        private void BuildNodeFactory()
        {
            Console.WriteLine($"_factories = new Func<Node>[{_grammar.Instructions.Keys.Max() + 1}];");
            foreach (var instruction in _grammar.Instructions)
            {
                if (ViewUtils.IsBuildInType(instruction.Value.Name))
                {
                Console.WriteLine(
                    $"_factories[(int)Op.{instruction.Value.Name}] = ()=> throw new NotImplementedException($\"Can't create instance of {instruction.Value.Name} node. Use {{nameof(SpirvTypeBase)}} to resolve type instance.\");");
                }
                else if (instruction.Value.Name.StartsWith("OpType"))
                {
                    Console.WriteLine(
                        $"_factories[(int)Op.{instruction.Value.Name}] = ()=> new Types.{instruction.Value.Name.Substring(2)}();");
                }
                else
                {
                    Console.WriteLine(
                        $"_factories[(int)Op.{instruction.Value.Name}] = ()=> new Nodes.{instruction.Value.Name.Substring(2)}();");
                }
            }
        }
    }

}
