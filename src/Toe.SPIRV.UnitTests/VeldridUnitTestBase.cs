using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Veldrid;

namespace Toe.SPIRV.UnitTests
{
    
    public class VeldridUnitTestBase
    {
        private GraphicsDevice _graphicsDevice;
        private ResourceFactory _resourceFactory;
        private Texture _offscreenColor;
        private TextureView _offscreenView;
        private CommandList _commandList;
        private Texture _offscreenDepth;
        private Framebuffer _offscreenFB;
        private Texture _stagingTextrue;
        private IList<IDisposable> _disposables;

        public CommandList CommandList => _commandList;
        public GraphicsDevice GraphicsDevice => _graphicsDevice;
        public Framebuffer Framebuffer => _offscreenFB;
        public ResourceFactory ResourceFactory => _resourceFactory;

        public IList<IDisposable> Disposables => _disposables;
        public virtual uint Width
        {
            get { return 1; }
        }
        public virtual uint Height
        {
            get { return 1; }
        }
        [SetUp]
        public virtual void Setup()
        {
            _disposables = new List<IDisposable>();
            _graphicsDevice = GraphicsDevice.CreateVulkan(new GraphicsDeviceOptions(true));
            _resourceFactory = _graphicsDevice.ResourceFactory;
            _offscreenColor = _resourceFactory.CreateTexture(TextureDescription.Texture2D(
                Width, Height, 1, 1,
                PixelFormat.R8_G8_B8_A8_UNorm, TextureUsage.RenderTarget | TextureUsage.Sampled));
            _stagingTextrue = _resourceFactory.CreateTexture(TextureDescription.Texture2D(
                Width, Height, 1, 1,
                PixelFormat.R8_G8_B8_A8_UNorm, TextureUsage.Staging));
            _offscreenDepth = _resourceFactory.CreateTexture(TextureDescription.Texture2D(
                Width, Height, 1, 1, PixelFormat.R16_UNorm, TextureUsage.DepthStencil));
            _offscreenFB = _resourceFactory.CreateFramebuffer(new FramebufferDescription(_offscreenDepth, _offscreenColor));
            _offscreenView = _resourceFactory.CreateTextureView(_offscreenColor);
            _commandList = _resourceFactory.CreateCommandList();
        }

        protected RgbaByte ReadRenderTargetPixel()
        {
            RgbaByte pixel = RgbaByte.Black;
            ReadRenderTarget((MappedResource _) =>
            {
                unsafe
                {
                    RgbaByte* basePtr = (RgbaByte*) _.Data;
                    pixel = * basePtr;
                }
            });
            return pixel;
        }
        protected void ReadRenderTarget(Action<MappedResource> callback)
        {
            using (var cl = _resourceFactory.CreateCommandList())
            {
                cl.Begin();
                cl.CopyTexture(_offscreenColor,0,0,0,0,0,
                    _stagingTextrue,0,0,0,0,0,Width,Height,1,1);
                cl.End();
                _graphicsDevice.SubmitCommands(cl);
                _graphicsDevice.WaitForIdle();
                MappedResource map = _graphicsDevice.Map(_stagingTextrue, MapMode.Read, 0);
                try
                {
                    callback(map);
                }
                finally
                {
                    _graphicsDevice.Unmap(_stagingTextrue, 0);
                }
            }
        }

        [TearDown]
        public virtual void TearDown()
        {
            for (var index = _disposables.Count - 1; index >= 0; --index)
            {
                _disposables[index].Dispose();
            }

            _disposables = null;
            _commandList?.Dispose();
            _offscreenView?.Dispose();
            _offscreenFB?.Dispose();
            _offscreenDepth?.Dispose();
            _offscreenColor?.Dispose();
            _graphicsDevice?.Dispose();
            
        }



    }
}