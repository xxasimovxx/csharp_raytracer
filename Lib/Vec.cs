using Rays;
namespace VecMath
{
    public struct Vec3
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

        public double LengthSquared()
        {
            return X * X + Y * Y + Z * Z;

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


        // temporary function just to test things out
        public double HitSphere(double radius, Ray ray)
        {
            Vec3 center = this - ray.Origin;
            double a = ray.Direction.LengthSquared();
            double h = Dot(ray.Direction, center);
            double c = center.LengthSquared() - radius * radius;
            double discriminant = h * h - a * c;
            if (discriminant < 0)
                return -1.0;
            return (h - Math.Sqrt(discriminant)) / a;

        }
        public static double Dot(Vec3 v, Vec3 u)
        {
            return v.X * u.X + v.Y * u.Y + v.Z * u.Z;
        }

        public static Vec3 Cross(Vec3 v, Vec3 u)
        {
            return new Vec3(v.Y * u.Z - v.Z * u.Y, v.Z * u.X - v.X * u.Z, v.X * u.Y - v.Y * u.X);
        }

        public override string ToString()
        {

            var sb = new System.Text.StringBuilder();
            sb.AppendFormat("{0} {1} {2}", X, Y, Z);
            return sb.ToString();

        }
    }
}
