using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Toe.SPIRV.CustomTool.Generators;

namespace Toe.SPIRV.CustomTool
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("CountLines", "Generate data for the shader", "0.1")]
    [Guid("682B6F03-A1DC-44D6-A96D-0FCED56656D4")]
    [ComVisible(true)]
    [ProvideObject(typeof(ToeSPIRVReflection))]
    [CodeGeneratorRegistration(typeof(ToeSPIRVReflection), nameof(ToeSPIRVReflection),
        "{FAE04EC1-301F-11D3-BF4B-00C04F79EFBC}", GeneratesDesignTimeSource = true)]
    public class ToeSPIRVReflection : AbstractSPIRVReflection, IVsSingleFileGenerator
    {
        protected override string GenerateText(Shader shader, string inputFilePath)
        {
            return new ToeGenerator(shader, inputFilePath).GenerateText();
        }
    }
}