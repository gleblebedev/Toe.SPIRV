using System;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Veldrid;
using Veldrid.SPIRV;

namespace Toe.SPIRV.CustomTool
{
    [ComVisible(true)]
    public abstract class AbstractSPIRVReflection: IVsSingleFileGenerator
    {

        public int DefaultExtension(out string pbstrDefaultExtension)
        {
            pbstrDefaultExtension = ".cs";
            return pbstrDefaultExtension.Length;
        }

        public int Generate(string wszInputFilePath, string bstrInputFileContents,
            string wszDefaultNamespace, IntPtr[] rgbOutputFileContents,
            out uint pcbOutput, IVsGeneratorProgress pGenerateProgress)
        {
            SpirvCompilationResult compilationResult;

            try
            {
                var stage = EntensionHelper.Resolve(wszInputFilePath);

                compilationResult = Veldrid.SPIRV.SpirvCompilation.CompileGlslToSpirv(bstrInputFileContents, wszInputFilePath, stage,
                    new GlslCompileOptions() { Debug = true });
            }
            catch (Exception ex)
            {
                SetOutput(rgbOutputFileContents, out pcbOutput, "Compilation error: " + ex.Message);
                return VSConstants.S_OK;
            }

            try
            {
                var text = GenerateText(Toe.SPIRV.Shader.Parse(compilationResult.SpirvBytes), wszInputFilePath);
                SetOutput(rgbOutputFileContents, out pcbOutput, text);
            }
            catch (Exception ex)
            {
                SetOutput(rgbOutputFileContents, out pcbOutput, "Generation error: " + ex);
                return VSConstants.S_OK;
            }

            return VSConstants.S_OK;
        }

        protected abstract string GenerateText(Shader shader, string inputFilePath);

        private static void SetOutput(IntPtr[] rgbOutputFileContents, out uint pcbOutput, string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            int length = bytes.Length;
            rgbOutputFileContents[0] = Marshal.AllocCoTaskMem(length);
            Marshal.Copy(bytes, 0, rgbOutputFileContents[0], length);
            pcbOutput = (uint)length;
        }
    }
}