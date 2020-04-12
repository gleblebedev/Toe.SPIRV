using CommandLine;

namespace Toe.SPIRV.CodeGenerator
{
    [Verb("updategrammar")]
    public class UpdateDescriptionOptions
    {
        [Option('i', "input", Required = false, HelpText = "Path to spirv.core.grammar.json file")]
        public string Input { get; set; } = "spirv.core.grammar.json";

        [Option('o', "output", Required = false, HelpText = "Path to toe.spirv.grammar.json file")]
        public string Output { get; set; } = "toe.spirv.grammar.json";

    }
}