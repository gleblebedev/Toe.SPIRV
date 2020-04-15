using System;
using System.IO;
using Toe.SPIRV.CodeGenerator.Model.Grammar;
using Toe.SPIRV.CodeGenerator.Views;

namespace Toe.SPIRV.CodeGenerator
{
    public class ReflectionVisior
    {
        private SpirvInstructions _grammar;

        public void Run(ReflectionVisiorOptions options)
        {
            _grammar = Utils.LoadGrammar(options.Grammar);

            Console.WriteLine(new NodeVisitor(_grammar).TransformText());
        }
    }
}