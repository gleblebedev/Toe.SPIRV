using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CommandLine;

namespace Toe.SPIRV.CodeGenerator
{
    public class Custom
    {
        [Verb("geninstructions")]
        public class Options
        {
            [Option('g', "grammar", Required = false, HelpText = "Path to toe.spirv.grammar.json file")]
            public string Grammar { get; set; } = "toe.spirv.grammar.json";
        }

        public void Run(Options options)
        {
            
        }
    }

}
