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
            // Simple shader with if statement
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
            // ----------------------------------------
            // Simple shader with loop
            yield return new[]
            {
                @"
#version 450
layout(location = 0) in int Attr;
void main()
{
    float x = 1.1;
    for (int i=0; i<Attr;++i)
    {
        x *= x;
    }
    gl_Position = vec4(x);
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
            // Simple shader with switch
            yield return new[]
            {
                @"
#version 450
layout(location = 0) in int Attr;
void main()
{
    gl_Position = vec4(0,0,0,0);
    switch (Attr)
    {
        case 2:
            gl_Position = vec4(2,2,2,2);
            break;
        case 15:
            gl_Position = vec4(0,2,0,2);
            break;
        default:
            break;
    }
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