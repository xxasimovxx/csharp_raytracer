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
        private double Fuzz { get; set; }
        public Metal(Vec3 color, double fuzz)
        {
            Albedo = color;
            Fuzz = fuzz < 1.0 ? fuzz : 1.0;
        }

        public bool Scatter(ref Ray ray, ref HitRecord rec, ref Vec3 color, ref Ray scattered)
        {
            Vec3 reflected = Vec3.Reflect(ray.Direction, rec.Normal);
            reflected = reflected.UnitVec() + (VRandom.UnitVec3() * Fuzz);
            scattered = new Ray(rec.Point, reflected);
            color = Albedo;
            return Vec3.Dot(scattered.Direction, rec.Normal) > 0;
        }
    }

    public struct DiElectric : IMaterial
    {
        private double RefractionIndex { get; set; }

        public DiElectric(double refractionIndex)
        {
            RefractionIndex = refractionIndex;
        }

        public bool Scatter(ref Ray ray, ref HitRecord rec, ref Vec3 color, ref Ray scattered)
        {
            color = new Vec3(1, 1, 1);
            double RI = rec.FrontFace ? (1.0 / RefractionIndex) : RefractionIndex;
            Vec3 unitDirection = ray.Direction.UnitVec();
            double CosTheta = Double.Min(Vec3.Dot(-unitDirection, rec.Normal), 1.0);
            double SinTheta = Math.Sqrt(1.0 - CosTheta * CosTheta);

            bool cannotRetract = RI * SinTheta > 1.0;
            Vec3 direction;

            if(cannotRetract)
              direction = Vec3.Reflect(unitDirection, rec.Normal);
            else
              direction = Vec3.Refract(unitDirection, rec.Normal, RI);
            
            scattered = new Ray(rec.Point, direction);
            return true;
        }


    }
}
