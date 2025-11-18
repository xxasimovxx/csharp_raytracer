using VecMath;
using HittableObjects;
using Rays;
namespace Raytracing
{
    public class Raytracer
    {
        static void Main(string[] args)
        {
            Metal m = new Metal(new Vec3(0.8, 0.8, 0.8), 0.3);
            DiElectric de = new DiElectric(1.0 / 1.33);
            Lambertian l = new Lambertian(new Vec3(0.8, 0.8, 0.0));
            Lambertian l2 = new Lambertian(new Vec3(0.8,0.6,0.2));
            HittableList world = new HittableList();
            world.Add(new Sphere(new Vec3(0, -100.5, -1), 100, l));
            world.Add(new Sphere(new Vec3(0, 0, -1.2), 0.5, l2));
            world.Add(new Sphere(new Vec3(-1.0, 0, -1.0), 0.5, m));
            world.Add(new Sphere(new Vec3(1.0, 0, -1.2), 0.5, de));
            Camera camera = new Camera();

            camera.Render(world);
        }
    }
}
