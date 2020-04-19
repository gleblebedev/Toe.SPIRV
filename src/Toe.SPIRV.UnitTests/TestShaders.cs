using System.Collections.Generic;

namespace Toe.SPIRV.UnitTests
{
    public class TestShaders
    {
        public static IEnumerable<object[]> EnumerateShaders()
        {
            // ----------------------------------------
            // Simple empty shader
            yield return new[]
            {
                @"
#version 450
void main()
{
}",
                @"
#version 450
layout(location = 0) out vec4 fsout_color;

void main()
{
}",
            };
            // ----------------------------------------
            // Simple shader
            yield return new[]
            {
                @"
#version 450
void main()
{
    gl_Position = vec4(0,0,0,0);
}",
                @"
#version 450
layout(location = 0) out vec4 fsout_color;

void main()
{
    fsout_color = vec4(0,0,0,0);
}",
            };
            // ----------------------------------------
            // Simple shader
            yield return new[]
            {
                @"
#version 450
layout(location = 0) in vec4 position;

void main()
{
    if (position.x>0)
        gl_Position = position;
    else
        gl_Position = position+vec4(1,1,1,1);
}",
                @"
#version 450
layout(location = 0) out vec4 fsout_color;

void main()
{
    fsout_color = vec4(0,0,0,0);
}",
            };
        }
    }
}