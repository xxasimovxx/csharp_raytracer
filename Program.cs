using VecMath;
using HittableObjects;
namespace Raytracing
{
    public class Raytracer
    {
        static void Main(string[] args)
        {
            HittableList world = new HittableList();
            world.Add(new Sphere(new Vec3(0,-100.5,-1), 100));
            world.Add(new Sphere(new Vec3(0,0,-1), 0.5));
            Camera camera = new Camera();

            camera.Render(world);
        }
    }
}
