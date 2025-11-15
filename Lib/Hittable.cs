using VecMath;
using Rays;
namespace HittableObjects
{
    public class HitRecord
    {
        public Vec3? point { get; set; }
        public Vec3? normal { get; set; }
        public double t;
    }

    public abstract class Hittable
    {
        public abstract bool Hit(in Ray ry, double rayTmin, double rayTmax, out HitRecord rec);
    }


}
