using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Media;
using Toe.SPIRV.NodeEditor;
using Veldrid;
using PixelFormat = Veldrid.PixelFormat;

namespace Toe.SPIRV.WPFNodeEditor.Views
{
    public class PreviewControl: Control
    {
        private GraphicsDevice _device;
        private IPreviewController _previewController;
        private Stopwatch _stopwatch;

        public PreviewControl()
        {
            _stopwatch = new Stopwatch();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, false);
            this.SetStyle(ControlStyles.Opaque, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            PreviewController = new ShaderToyPreviewController();
            CompositionTarget.Rendering += OnRendering;
        }

        private void OnRendering(object sender, EventArgs e)
        {
            var elapsedTotalSeconds = (float)_stopwatch.Elapsed.TotalSeconds;
            _stopwatch.Restart();
            if (_device != null)
            {
                _previewController?.Render(elapsedTotalSeconds);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            _device?.ResizeMainWindow((uint)Width, (uint)Height);
            _previewController?.Resized((uint) Width, (uint) Height);
            base.OnResize(e);
        }

        public IPreviewController PreviewController
        {
            get => _previewController;
            set
            {
                if (_previewController != value)
                {
                    if (_device != null)
                    {
                        _previewController?.DeviceDestroyed();
                    }

                    _previewController = value;

                    if (_device != null)
                    {
                        _previewController?.DeviceCreated(_device);
                    }
                }
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            var width = (uint)Math.Max(Width, 1);
            var height = (uint)Math.Max(Height, 1);
            _device = GraphicsDevice.CreateD3D11(new GraphicsDeviceOptions(true, PixelFormat.R32_Float, false), Handle, width, height);
            //_device = GraphicsDevice.CreateVulkan(new GraphicsDeviceOptions(false, PixelFormat.R32_Float, false) {PreferStandardClipSpaceYDirection = true}, VkSurfaceSource.CreateWin32(Handle, Handle), width, height);

            _previewController?.DeviceCreated(_device);
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            if (_device != null)
            {
                _previewController?.DeviceDestroyed();

                _device.WaitForIdle();
                _device.Dispose();
                _device = null;
            }

            base.OnHandleDestroyed(e);
        }
    }
}
