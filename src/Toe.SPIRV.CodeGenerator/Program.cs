using System;
using CommandLine;
using Toe.SPIRV.CodeGenerator.Model;

namespace Toe.SPIRV.CodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<UpdateDescriptionOptions, GenerateReflectionNodesOptions, ReflectionVisiorOptions>(args)
                .WithParsed<UpdateDescriptionOptions>(o => { new UpdateDescription().Run(o); })
                .WithParsed<GenerateReflectionNodesOptions>(o => { new GenerateReflectionNodes().Run(o); })
                .WithParsed<ReflectionVisiorOptions>(o => { new ReflectionVisior().Run(o); })
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
