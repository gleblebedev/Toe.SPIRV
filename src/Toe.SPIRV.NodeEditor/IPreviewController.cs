using Veldrid;

namespace Toe.SPIRV.NodeEditor
{
    public interface IPreviewController
    {
        void DeviceDestroyed();
        void DeviceCreated(GraphicsDevice device);
        void Render(float elapsedTotalSeconds);
        void Resized(uint width, uint height);
    }
}