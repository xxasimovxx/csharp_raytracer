using VecMath;
using Rays;
namespace HittableObjects
{
    public struct HitRecord
    {
        public Vec3 Point { get; set; }
        public Vec3 Normal { get; set; }
        public bool FrontFace { get; private set; }
        public double T;

        public void SetFaceNormal(in Ray ray, in Vec3 outwardNormal)
        {
            FrontFace = Vec3.Dot(ray.Direction, outwardNormal) < 0;
            Normal = FrontFace ? outwardNormal : -outwardNormal;
        }
    }

    public interface IHittable
    {
        public bool Hit(ref Ray ray, Interval interval, out HitRecord rec);
    }

    public class HittableList : IHittable
    {
        public List<IHittable> HList { get; private set; }
        public HittableList()
        {
            HList = new List<IHittable>();
        }

        public HittableList(IHittable HObject)
        {
            HList = new List<IHittable>();
            HList.Add(HObject);
        }

        public void Add(IHittable HObject)
        {
            HList.Add(HObject);
        }

        public bool Hit(ref Ray ray, Interval interval, out HitRecord rec)
        {
            rec = default;
            bool hitAnything = false;
            double closestSoFar = interval.Max;

            foreach (var HObject in HList)
            {
                if (HObject.Hit(ref ray, new Interval(interval.Min, closestSoFar), out HitRecord tempHitRecord))
                {
                    hitAnything = true;
                    closestSoFar = tempHitRecord.T;
                    rec = tempHitRecord;
                }
            }

            return hitAnything;
        }
    }

    public class Sphere : IHittable
    {
        public Vec3 Center { get; private set; }
        public double Radius { get; private set; }

        public Sphere(Vec3 center, double radius)
        {
            Center = center;
            Radius = radius;
        }

        public bool Hit(ref Ray ray, Interval interval, out HitRecord rec)
        {
            Vec3 oc = Center - ray.Origin;
            var a = ray.Direction.LengthSquared();
            var h = Vec3.Dot(ray.Direction, oc);
            var c = oc.LengthSquared() - Radius * Radius;

            var discriminant = h * h - a * c;

            if (discriminant < 0)
            {
                rec = default;
                return false;
            }

            var sqrtd = Math.Sqrt(discriminant);

            var root = (h - sqrtd) / a;
            if (root <= interval.Min || interval.Max <= root)
            {
                root = (h + sqrtd) / a;
                if (root <= interval.Min ||  interval.Max<= root)
                {
                    rec = default;
                    return false;
                }
            }

            rec = new HitRecord();

            rec.T = root;
            rec.Point = ray.At(rec.T);
            var outwardNormal = (rec.Point - Center) / Radius;
            rec.SetFaceNormal(ray, outwardNormal);

            return true;
        }
    }
}
