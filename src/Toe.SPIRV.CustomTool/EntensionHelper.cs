using System;
using System.Linq;
using Veldrid;

namespace Toe.SPIRV.CustomTool
{
    public static class EntensionHelper
    {
        private static readonly ExtensionToStage[] _stages = new[]
        {
            new ExtensionToStage(){Extension = ".vert", Stage = ShaderStages.Vertex},
            new ExtensionToStage(){Extension = ".vert.glsl", Stage = ShaderStages.Vertex},
            new ExtensionToStage(){Extension = ".frag", Stage = ShaderStages.Fragment},
            new ExtensionToStage(){Extension = ".frag.glsl", Stage = ShaderStages.Fragment},
            new ExtensionToStage(){Extension = ".geom", Stage = ShaderStages.Geometry},
            new ExtensionToStage(){Extension = ".geom.glsl", Stage = ShaderStages.Geometry},
        };

        struct ExtensionToStage
        {
            public string Extension;
            public ShaderStages Stage;
        }
        public static ShaderStages Resolve(string fileName)
        {
            foreach (var extensionToStage in _stages)
            {
                if (fileName.EndsWith(extensionToStage.Extension, StringComparison.InvariantCultureIgnoreCase))
                {
                    return extensionToStage.Stage;
                }
            }
            throw new NotImplementedException("File extension is not recognized. The following extensions supported: "+string.Join(", ", _stages.Select(_=>_.Extension)));
        }
    }
}