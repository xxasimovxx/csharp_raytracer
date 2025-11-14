using VecMath;
namespace Rays
{
    public class Ray
    {
        public Vec3 origin
        {

            get;
            private set;

        }

        public Vec3 direction
        {

            get;
            private set;

        }

        public Ray(Vec3 origin, Vec3 direction)
        {

            this.origin = origin;
            this.direction = direction;

        }

        public Vec3 At(double t)
        {

            return origin + direction * t;

        }

    }

}
