using CommandLine;

namespace Toe.SPIRV.CodeGenerator
{
    [Verb("genreflectionvisitor")]
    public class ReflectionVisiorOptions
    {
        [Option('g', "grammar", Required = false, HelpText = "Path to toe.spirv.grammar.json file")]
        public string Grammar { get; set; } = "toe.spirv.grammar.json";

    }
}