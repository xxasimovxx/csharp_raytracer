using VecMath;
using Rays;
using Colors;
using HittableObjects;
namespace Raytracing
{
    public class Camera
    {
        public double AspectRatio { get; } = 16.0 / 9.0;
        public int ImageWidth { get; } = 400;
        public int ImageHeight { get; }
        public Vec3 Pixel00Loc { get; }
        public Vec3 CameraCenter { get; } = new Vec3(0, 0, 0);
        public Vec3 PixelDeltaU { get; }
        public Vec3 PixelDeltaV { get; }

        public Camera()
        {
            ImageHeight = (int)(ImageWidth / AspectRatio);
            ImageHeight = (ImageHeight < 1) ? 1 : ImageHeight;

            double focal_length = 1.0;
            double viewport_height = 2.0;
            double viewport_width = viewport_height * AspectRatio;

            Vec3 viewport_u = new Vec3(viewport_width, 0, 0);
            Vec3 viewport_v = new Vec3(0, -viewport_height, 0);

            PixelDeltaU = viewport_u / ImageWidth;
            PixelDeltaV = viewport_v / ImageHeight;

            Vec3 viewport_upper_left = CameraCenter
                                     - new Vec3(0, 0, focal_length) - viewport_u / 2 - viewport_v / 2;
            Pixel00Loc = viewport_upper_left + (PixelDeltaU + PixelDeltaV) * 0.5;
        }

        public void Render(IHittable world)
        {
            using FileStream fs = File.OpenWrite("image.ppm");
            using StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine($"P3\n{ImageWidth} {ImageHeight}\n255");

            for (int i = 0; i < ImageHeight; i++)
            {
                for (int j = 0; j < ImageWidth; j++)
                {
                    Vec3 pixel_center = Pixel00Loc + (PixelDeltaU * j) + (PixelDeltaV * i);
                    Vec3 ray_direction = pixel_center - CameraCenter;
                    Ray ray = new Ray(CameraCenter, ray_direction);

                    Vec3 pixel_color = RayColor(ray, world);
                    Color.WriteColor(pixel_color, sw);

                }
            }
            Console.WriteLine("Successfully created file image.ppm!");
        }

        public Vec3 RayColor(Ray ray, IHittable world)
        {
            HitRecord rec;
            if (world.Hit(ref ray, new Interval(0, double.PositiveInfinity), out rec))
            {
                return (rec.Normal + new Vec3(1, 1, 1)) * 0.5;

            }

            Vec3 unit_direction = ray.Direction.UnitVec();
            double a = 0.5 * (unit_direction.Y + 1.0);
            Vec3 color = new Vec3(0.5, 0.7, 1.0);
            Vec3 v = new Vec3(1.0, 1.0, 1.0);
            return v * (1.0 - a) + color * a;

        }
    }
}
