using System.Collections.Generic;

namespace Toe.SPIRV.UnitTests
{
    public class TestShaders
    {
        public static IEnumerable<object[]> EnumerateShaders()
        {
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
        }
    }
}