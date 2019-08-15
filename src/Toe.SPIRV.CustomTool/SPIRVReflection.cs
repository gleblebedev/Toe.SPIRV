using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Toe.SPIRV.CustomTool.Generators;

namespace Toe.SPIRV.CustomTool
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("CountLines", "Generate data for the shader", "0.1")]
    [Guid("FDB76F02-016B-4BD8-B287-11F5981240D3")]
    [ComVisible(true)]
    [ProvideObject(typeof(SPIRVReflection))]
    [CodeGeneratorRegistration(typeof(SPIRVReflection), nameof(SPIRVReflection),
        "{FAE04EC1-301F-11D3-BF4B-00C04F79EFBC}", GeneratesDesignTimeSource = true)]
    public class SPIRVReflection : AbstractSPIRVReflection, IVsSingleFileGenerator
    {
        protected override string GenerateText(Shader shader, string inputFilePath)
        {
            return new FixedArrayGenerator(shader, inputFilePath).GenerateText();
        }
    }
}