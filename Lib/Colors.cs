using VecMath;
using System;
using System.IO;

namespace Colors
{
    public static class Color
    {
        public static void WriteColor(Vec3 v, TextWriter output)
        {
            output.Write("{0} {1} {2}\n", (int)(v.X*255.999), (int)(v.Y*255.999), (int)(v.Z*255.999));

        }
    }

}
