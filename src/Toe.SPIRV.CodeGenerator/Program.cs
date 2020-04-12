using CommandLine;
using Toe.SPIRV.CodeGenerator.Model;

namespace Toe.SPIRV.CodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<UpdateDescriptionOptions>(args)
                .WithParsed<UpdateDescriptionOptions>(o =>
                {
                    new UpdateDescription().Run(o);
                });
        }
    }
}
