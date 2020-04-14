using System.IO;
using CommandLine;

namespace Toe.SPIRV.CodeGenerator
{
    [Verb("genreflectionnodes")]
    public class GenerateReflectionNodesOptions
    {
        [Option('g', "grammar", Required = false, HelpText = "Path to toe.spirv.grammar.json file")]
        public string Grammar { get; set; } = "toe.spirv.grammar.json";


        [Option('o', "output", Required = false, HelpText = "Path to the output folder")]
        public string Output { get; set; } = Path.Combine(Directory.GetCurrentDirectory(),"Nodes");
    }
    
}