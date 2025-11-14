using Colors;
using Rays;
using VecMath;
namespace Raytracing
{
    class Raytracer
    {
        static void Main(string[] args)
        {
            // Image

            double aspect_ratio = 16.0 / 9.0;
            int image_width = 400;

            // Calculate the image height, and ensure that it's at least 1.
            int image_height = (int)(image_width / aspect_ratio);
            image_height = (image_height < 1) ? 1 : image_height;

            // Camera

            double focal_length = 1.0;
            double viewport_height = 2.0;
            double viewport_width = viewport_height * (double)(image_width / image_height);
            Vec3 camera_center = new Vec3(0, 0, 0);

            // Calculate the vectors across the horizontal and down the vertical viewport edges.
            Vec3 viewport_u = new Vec3(viewport_width, 0, 0);
            Vec3 viewport_v = new Vec3(0, -viewport_height, 0);

            // Calculate the horizontal and vertical delta vectors from pixel to pixel.
            Vec3 pixel_delta_u = viewport_u / image_width;
            Vec3 pixel_delta_v = viewport_v / image_height;

            // Calculate the location of the upper left pixel.
            Vec3 viewport_upper_left = camera_center
                                     - new Vec3(0, 0, focal_length) - viewport_u / 2 - viewport_v / 2;
            Vec3 pixel00_loc = viewport_upper_left + (pixel_delta_u + pixel_delta_v) * 0.5;

            // Render

            Console.Write("P3\n{0} {1}\n255\n", image_width, image_height);

            for (int i = 0; i < image_height; i++)
            {
                for (int j = 0; j < image_width; j++)
                {
                    Vec3 pixel_center = pixel00_loc + (pixel_delta_u * j) + (pixel_delta_v * i);
                    Vec3 ray_direction = pixel_center - camera_center;
                    Ray r = new Ray(camera_center, ray_direction);

                    Vec3 pixel_color = RayColor(r);
                    Color.WriteColor(pixel_color, Console.Out);

                }
            }
        }

        private static Vec3 RayColor(Ray ray)
        {

            Vec3 unit_direction = ray.direction.UnitVec();
            double a = 0.5 * (unit_direction.Y + 1.0);
            Vec3 color = new Vec3(0.5, 0.7, 1.0);
            Vec3 v = new Vec3(1.0, 1.0, 1.0);
            return v * (1.0 - a) + color * a;

        }
    }
}
