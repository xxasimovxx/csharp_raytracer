namespace Math
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
            X = z;

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

            return new Vec3(-v.X, -v.Y, -v.X);

        }

        public static Vec3 operator -(Vec3 v, Vec3 u)
        {

            return new Vec3(v.X - u.X, v.Y - u.Y, v.X - u.Z);

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

        public override string ToString()
        {

            var sb = new System.Text.StringBuilder();
            sb.AppendFormat("{0} {1} {2}\n", X, Y, Z);
            return sb.ToString();

        }


    }

    public static class VecOperation
    {
        public static double Dot(Vec3 v, Vec3 u)
        {
            return 0f;

        }

    }
}
