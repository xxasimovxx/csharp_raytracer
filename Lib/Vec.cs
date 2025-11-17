namespace VecMath
{
    public static class VRandom
    {
        private static Random random = new Random();
        public static Vec3 Vec3()
        {
            return new Vec3(random.Next() * random.NextDouble() - random.Next() * random.NextDouble(),
                random.Next() * random.NextDouble() - random.Next() * random.NextDouble(),
                random.Next() * random.NextDouble() - random.Next() * random.NextDouble());
        }
        public static Vec3 UnitVec3()
        {
            return VRandom.Vec3().UnitVec();
        }

        public static Vec3 Vec3(double min, double max)
        {
            var mm = max - min;
            return new Vec3(
              random.NextDouble() * mm + min,
              random.NextDouble() * mm + min,
              random.NextDouble() * mm + min);

        }

    }
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

        public static double Dot(Vec3 v, Vec3 u)
        {
            return v.X * u.X + v.Y * u.Y + v.Z * u.Z;
        }

        public static Vec3 Cross(Vec3 v, Vec3 u)
        {
            return new Vec3(v.Y * u.Z - v.Z * u.Y, v.Z * u.X - v.X * u.Z, v.X * u.Y - v.Y * u.X);
        }

        public Vec3 RandomUnitVector()
        {
            while (true)
            {
                Vec3 point = VRandom.Vec3(-1.0, 1.0);
                double lenSquared = point.LengthSquared();
                if (lenSquared <= 1 && lenSquared > 1e-160)
                    return point / Math.Sqrt(lenSquared);
            }
        }

        public static Vec3 RandomOnHemisphere(Vec3 normal)
        {
            Vec3 randomUnitVec = normal.RandomUnitVector();

            if (Dot(randomUnitVec, normal) > 0.0)
                return randomUnitVec;
            else
                return -randomUnitVec;
        }

        public override string ToString()
        {
            return $"{X} {Y} {Z}";
        }
    }
}
