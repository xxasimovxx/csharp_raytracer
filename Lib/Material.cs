using HittableObjects;
using VecMath;
namespace Rays
{
    public interface IMaterial
    {
        public bool Scatter(ref Ray ray, ref HitRecord rec, ref Vec3 color, ref Ray scattered);
    }

    public struct Lambertian : IMaterial
    {
        private Vec3 Albedo { get; set; }
        public Lambertian(Vec3 albedo)
        {
            Albedo = albedo;
        }

        public bool Scatter(ref Ray ray, ref HitRecord rec, ref Vec3 color, ref Ray scattered)
        {
            Vec3 scatterDirection = rec.Normal + VRandom.UnitVec3();
            if (scatterDirection.NearZero())
                scatterDirection = rec.Normal;

            scattered = new Ray(rec.Point, scatterDirection);
            color = Albedo;
            return true;
        }
    }

    public struct Metal : IMaterial
    {
        private Vec3 Albedo { get; set; }
        public Metal(Vec3 color)
        {
            Albedo = color;
        }

        public bool Scatter(ref Ray ray, ref HitRecord rec, ref Vec3 color, ref Ray scattered)
        {
            Vec3 reflected = Vec3.Reflect(ray.Direction, rec.Normal);
            scattered = new Ray(rec.Point, reflected);
            color = Albedo;
            return true;
        }
    }
}
