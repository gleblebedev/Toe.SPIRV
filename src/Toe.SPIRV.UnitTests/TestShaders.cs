using System.Collections.Generic;

namespace Toe.SPIRV.UnitTests
{
    public class TestShaders
    {
        public static IEnumerable<object[]> EnumerateShaders()
        {
            var emptyFragmentShader = @"
#version 450
layout(location = 0) out vec4 fsout_color;

void main()
{
}";
            // ----------------------------------------
            // Simple empty shader
            yield return new[]
            {
                @"
#version 450
void main()
{
}",
                emptyFragmentShader
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
            // Simple shader with full if statement
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
                emptyFragmentShader,
            };

            // ----------------------------------------
            // Simple shader with half if statement
            yield return new[]
            {
                @"
#version 450
layout(location = 0) in vec4 position;

void main()
{
    gl_Position = position;
    if (position.x>0)
        gl_Position = position+vec4(1,1,1,1);
}",
                emptyFragmentShader,
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
                emptyFragmentShader
            };

            // ----------------------------------------
            // Simple shader that calculates value twice
            yield return new[]
            {
                @"
#version 450
layout(location = 0) in int Attr;
void main()
{
    float x = Attr+0.1;
    gl_Position = vec4(x, Attr+0.1,0,0);
}",
                emptyFragmentShader
            };

            // ----------------------------------------
            // Simple shader with loop that breakes on condition
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
        if (x > 10)
            break;
        x *= x;
        continue;
    }
    gl_Position = vec4(x);
}",
                emptyFragmentShader
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
                emptyFragmentShader,
            };

            // ----------------------------------------
            // Function call
            yield return new[]
            {
                @"
#version 450
layout(location = 0) in int Attr;
vec4 MakeVec4(int x)
{
    return vec4(x);
}
void main()
{
    gl_Position = MakeVec4(Attr);
}",
                emptyFragmentShader,
            };
            // ----------------------------------------
            // Push constant
            yield return new[]
            {
                @"
#version 450
layout(push_constant) uniform Data
{
    int Attr;
} push_const;

vec4 MakeVec4(int x)
{
    return vec4(x);
}
void main()
{
    gl_Position = MakeVec4(push_const.Attr);
}",
                emptyFragmentShader,
            };
            // ----------------------------------------
            // Constant
            yield return new[]
            {
                @"
#version 450
layout(constant_id = 100) const bool Attr = true;

vec4 MakeVec4(int x)
{
    return vec4(x);
}
void main()
{
    gl_Position = MakeVec4(Attr?1:-1);
}",
                emptyFragmentShader,
            };
        }
    }
}