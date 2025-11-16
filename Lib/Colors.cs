using VecMath;
using Rays;
namespace Colors
{
    public static class Color
    {
        public static void WriteColor(Vec3 v, TextWriter output)
        {
          Interval intensity = new Interval(0.0, 0.999);
          double r = (int)(256 * intensity.Clamp(v.X));
          double g = (int)(256 * intensity.Clamp(v.Y));
          double b = (int)(256 * intensity.Clamp(v.Z));

            output.WriteLine($"{r} {g} {b}");

        }
    }

}
