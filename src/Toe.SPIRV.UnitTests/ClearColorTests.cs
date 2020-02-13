using NUnit.Framework;
using Veldrid;

namespace Toe.SPIRV.UnitTests
{
    [TestFixture]
    public class ClearColorTests : VeldridUnitTestBase
    {
 
        [Test]
        [TestCase(10, 20, 30, 40)]
        [TestCase(0, 0, 0, 0)]
        public void ClearColor(byte r, byte g, byte b, byte a)
        {
            var rgbaByte = new RgbaByte(r, g, b, a);
            CommandList.Begin();
            CommandList.SetFramebuffer(Framebuffer);
            CommandList.SetFullViewports();
            CommandList.ClearColorTarget(0, new RgbaFloat(rgbaByte.R / 255.0f, rgbaByte.G / 255.0f, rgbaByte.B / 255.0f, rgbaByte.A / 255.0f));
            CommandList.End();

            GraphicsDevice.SubmitCommands(CommandList);
            GraphicsDevice.WaitForIdle();

            ReadRenderTargetPixel(color =>
            {
                Assert.AreEqual(rgbaByte, color);
            });
        }
    }
}