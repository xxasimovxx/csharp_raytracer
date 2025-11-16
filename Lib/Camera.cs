using VecMath;
namespace Raytracing
{
    public class Camera
    {
        public double AspectRatio { get; }
        public int ImageWidth { get; }
        public int ImageHeight { get; }
        public Vec3 Pixel00Loc { get; }
        public Vec3 CameraCenter { get; } = new Vec3(0, 0, 0);
        public Vec3 PixelDeltaU { get; }
        public Vec3 PixelDeltaV { get; }
        public Camera(double aspect_ratio, int width)
        {
            AspectRatio = aspect_ratio;
            ImageWidth = width;

            // Calculate the image height, and ensure that it's at least 1.
            ImageHeight = (int)(ImageWidth / aspect_ratio);
            ImageHeight = (ImageHeight < 1) ? 1 : ImageHeight;

            // Camera
            double focal_length = 1.0;
            double viewport_height = 2.0;
            double viewport_width = viewport_height * aspect_ratio;

            // Calculate the vectors across the horizontal and down the vertical viewport edges.
            Vec3 viewport_u = new Vec3(viewport_width, 0, 0);
            Vec3 viewport_v = new Vec3(0, -viewport_height, 0);

            // Calculate the horizontal and vertical delta vectors from pixel to pixel.
            PixelDeltaU = viewport_u / ImageWidth;
            PixelDeltaV = viewport_v / ImageHeight;

            // Calculate the location of the upper left pixel.
            Vec3 viewport_upper_left = CameraCenter
                                     - new Vec3(0, 0, focal_length) - viewport_u / 2 - viewport_v / 2;
            Pixel00Loc = viewport_upper_left + (PixelDeltaU + PixelDeltaV) * 0.5;
        }
    }
}
