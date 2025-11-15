using Colors;
using Rays;
using VecMath;
namespace Raytracing
{
    public class Raytracer
    {
        static void Main(string[] args)
        {
            Camera camera = new Camera(16.0 / 9.0, 400);

            // Render
            using FileStream fs = File.OpenWrite("image.ppm");
            using StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine($"P3\n{camera.ImageWidth} {camera.ImageHeight}\n255");

            for (int i = 0; i < camera.ImageHeight; i++)
            {
                for (int j = 0; j < camera.ImageWidth; j++)
                {
                    Vec3 pixel_center = camera.Pixel00Loc + (camera.PixelDeltaU * j) + (camera.PixelDeltaV * i);
                    Vec3 ray_direction = pixel_center - camera.CameraCenter;
                    Ray r = new Ray(camera.CameraCenter, ray_direction);

                    Vec3 pixel_color = RayColor(r);
                    Color.WriteColor(pixel_color, sw);

                }
            }
            Console.WriteLine("Successfully created file image.ppm!");
        }

        private static Vec3 RayColor(Ray ray)
        {
            Vec3 point = new Vec3(0, 0, -1);
            double hs = point.HitSphere(0.5, ray);

            if (hs > 0.0)
            {
                Vec3 uv = (ray.At(hs) - new Vec3(0, 0, -1)).UnitVec();
                return (new Vec3(uv.X + 1, uv.Y + 1, uv.Z + 1)) * 0.5;

            }

            Vec3 unit_direction = ray.Direction.UnitVec();
            double a = 0.5 * (unit_direction.Y + 1.0);
            Vec3 color = new Vec3(0.5, 0.7, 1.0);
            Vec3 v = new Vec3(1.0, 1.0, 1.0);
            return v * (1.0 - a) + color * a;

        }
    }
}
