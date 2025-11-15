using Rays;
namespace VecMath
{
    public class Vec3
    {
        public double X
        {
            get;
            private set;
        }
        public double Y
        {
            get;
            private set;
        }
        public double Z
        {
            get;
            private set;
        }

        public Vec3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;

        }

        public double Length()
        {

            return System.Math.Sqrt(X * X + Y * Y + Z * Z);

        }

        public Vec3 UnitVec()
        {

            return this / this.Length();

        }

        public static Vec3 operator -(Vec3 v)
        {

            return new Vec3(-v.X, -v.Y, -v.Z);

        }

        public static Vec3 operator -(Vec3 v, Vec3 u)
        {

            return new Vec3(v.X - u.X, v.Y - u.Y, v.Z - u.Z);

        }

        public static Vec3 operator +(Vec3 v, Vec3 u)
        {

            return new Vec3(v.X + u.X, v.Y + u.Y, v.Z + u.Z);

        }

        public static Vec3 operator *(Vec3 v, Vec3 u)
        {

            return new Vec3(v.X * u.X, v.Y * u.Y, v.Z * u.Z);

        }

        public static Vec3 operator /(Vec3 v, double scalar)
        {

            return new Vec3(v.X / scalar, v.Y / scalar, v.Z / scalar);

        }

        public static Vec3 operator *(Vec3 v, double scalar)
        {

            return new Vec3(v.X * scalar, v.Y * scalar, v.Z * scalar);

        }

        public static Vec3 operator +(Vec3 v, double scalar)
        {

            return new Vec3(v.X + scalar, v.Y + scalar, v.Z + scalar);

        }

        public static Vec3 operator -(Vec3 v, double scalar)
        {

            return new Vec3(v.X - scalar, v.Y - scalar, v.Z - scalar);

        }

        public double HitSphere(double Radius, Ray ray)
        {
            Vec3 Oc = this - ray.Origin;
            var a = VecOperation.Dot(ray.Direction, ray.Direction);
            var b = -2.0 * VecOperation.Dot(ray.Direction, Oc);
            var c = VecOperation.Dot(Oc, Oc) - Radius * Radius;
            var discriminant = b * b - 4 * a * c;
            if (discriminant < 0)
                return -1.0;
            return (-b - Math.Sqrt(discriminant)) / (2.0 * a);

        }

        public override string ToString()
        {

            var sb = new System.Text.StringBuilder();
            sb.AppendFormat("{0} {1} {2}", X, Y, Z);
            return sb.ToString();

        }


    }

    public static class VecOperation
    {
        public static double Dot(Vec3 v, Vec3 u)
        {

            return v.X * u.X + v.Y * u.Y + v.Z * u.Z;

        }

        public static Vec3 Cross(Vec3 v, Vec3 u)
        {

            return new Vec3(v.Y * u.Z - v.Z * u.Y, v.Z * u.X - v.X * u.Z, v.X * u.Y - v.Y * u.X);

        }

    }
}
