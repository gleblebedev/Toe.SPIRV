using System;
using System.Collections.Generic;
using NUnit.Framework;
using Veldrid;

namespace Toe.SPIRV.UnitTests
{
    public class VeldridUnitTestBase
    {
        private Texture _offscreenColor;
        private TextureView _offscreenView;
        private Texture _offscreenDepth;
        private Texture _stagingTextrue;

        public virtual uint Width => 1;

        public virtual uint Height => 1;

        public CommandList CommandList { get; private set; }

        public GraphicsDevice GraphicsDevice { get; private set; }

        public Framebuffer Framebuffer { get; private set; }

        public ResourceFactory ResourceFactory { get; private set; }

        public IList<IDisposable> Disposables { get; private set; }

        [SetUp]
        public virtual void Setup()
        {
            Disposables = new List<IDisposable>();
            GraphicsDevice = GraphicsDevice.CreateVulkan(new GraphicsDeviceOptions(true));
            ResourceFactory = GraphicsDevice.ResourceFactory;
            _offscreenColor = ResourceFactory.CreateTexture(TextureDescription.Texture2D(
                Width, Height, 1, 1,
                PixelFormat.R8_G8_B8_A8_UNorm, TextureUsage.RenderTarget | TextureUsage.Sampled));
            _stagingTextrue = ResourceFactory.CreateTexture(TextureDescription.Texture2D(
                Width, Height, 1, 1,
                PixelFormat.R8_G8_B8_A8_UNorm, TextureUsage.Staging));
            _offscreenDepth = ResourceFactory.CreateTexture(TextureDescription.Texture2D(
                Width, Height, 1, 1, PixelFormat.R16_UNorm, TextureUsage.DepthStencil));
            Framebuffer =
                ResourceFactory.CreateFramebuffer(new FramebufferDescription(_offscreenDepth, _offscreenColor));
            _offscreenView = ResourceFactory.CreateTextureView(_offscreenColor);
            CommandList = ResourceFactory.CreateCommandList();
        }

        [TearDown]
        public virtual void TearDown()
        {
            for (var index = Disposables.Count - 1; index >= 0; --index) Disposables[index].Dispose();

            Disposables = null;
            CommandList?.Dispose();
            _offscreenView?.Dispose();
            Framebuffer?.Dispose();
            _offscreenDepth?.Dispose();
            _offscreenColor?.Dispose();
            GraphicsDevice?.Dispose();
        }

        protected RgbaByte ReadRenderTargetPixel()
        {
            var pixel = RgbaByte.Black;
            ReadRenderTarget(_ =>
            {
                unsafe
                {
                    var basePtr = (RgbaByte*) _.Data;
                    pixel = *basePtr;
                }
            });
            return pixel;
        }

        protected void ReadRenderTarget(Action<MappedResource> callback)
        {
            using (var cl = ResourceFactory.CreateCommandList())
            {
                cl.Begin();
                cl.CopyTexture(_offscreenColor, 0, 0, 0, 0, 0,
                    _stagingTextrue, 0, 0, 0, 0, 0, Width, Height, 1, 1);
                cl.End();
                GraphicsDevice.SubmitCommands(cl);
                GraphicsDevice.WaitForIdle();
                var map = GraphicsDevice.Map(_stagingTextrue, MapMode.Read, 0);
                try
                {
                    callback(map);
                }
                finally
                {
                    GraphicsDevice.Unmap(_stagingTextrue, 0);
                }
            }
        }
    }
}