using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Toe.SPIRV.CustomTool.Generators;

namespace Toe.SPIRV.CustomTool
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("CountLines", "Generate data for the shader", "0.1")]
    [Guid("BCA9538C-5582-4DC7-B3ED-3102CC6EA437")]
    [ComVisible(true)]
    [ProvideObject(typeof(SharpDXSPIRVReflection))]
    [CodeGeneratorRegistration(typeof(SharpDXSPIRVReflection), nameof(SharpDXSPIRVReflection),
        "{FAE04EC1-301F-11D3-BF4B-00C04F79EFBC}", GeneratesDesignTimeSource = true)]
    public class SharpDXSPIRVReflection : AbstractSPIRVReflection, IVsSingleFileGenerator
    {
        protected override string GenerateText(Shader shader, string inputFilePath)
        {
            return new SharpDXGenerator(shader, inputFilePath).GenerateText();
        }
    }
}