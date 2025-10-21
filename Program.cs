namespace Raytracing
{
    class Raytracer
    {
        static void Main(string[] args)
        {
            int image_width = 256;
            int image_height = 256;

            // Render

            Console.Write("P3\n{0} {1}\n255\n", image_width, image_height);

            for (int j = 0; j < image_height; j++)
            {
                for (int i = 0; i < image_width; i++)
                {
                    var r = (double)i / (image_width - 1);
                    var g = (double)j / (image_height - 1);
                    var b = 0.0;

                    int ir = (int)(255.999 * r);
                    int ig = (int)(255.999 * g);
                    int ib = (int)(255.999 * b);

                    Console.Write("{0} {1} {2}\n", ir, ig, ib);
                }
            }

        }
    }
}
