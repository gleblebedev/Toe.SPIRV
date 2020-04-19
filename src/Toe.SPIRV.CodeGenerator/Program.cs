using System;
using CommandLine;
using Toe.SPIRV.CodeGenerator.Model;

namespace Toe.SPIRV.CodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<UpdateDescription.Options, GenerateReflectionNodes.Options, 
                    InstructionBuilder.Options, 
                    GenerateInstructions.Options, 
                    Custom.Options,
                    GenerateOperands.Options,
                    GenerateNodeVisitor.Options
                >(args)
                .WithParsed<UpdateDescription.Options>(o => { new UpdateDescription().Run(o); })
                .WithParsed<GenerateReflectionNodes.Options>(o => { new GenerateReflectionNodes().Run(o); })
                .WithParsed<InstructionBuilder.Options>(o => { new InstructionBuilder().Run(o); })
                .WithParsed<GenerateInstructions.Options>(o => { new GenerateInstructions().Run(o); })
                .WithParsed<Custom.Options>(o => { new Custom().Run(o); })
                .WithParsed<GenerateOperands.Options>(o => { new GenerateOperands().Run(o); })
                .WithParsed<GenerateNodeVisitor.Options>(o => { new GenerateNodeVisitor().Run(o); })
                .WithNotParsed(errors =>
                {
                    foreach (var error in errors)
                    {
                        Console.Error.WriteLine(error);
                    }
                });
        }
    }
}
