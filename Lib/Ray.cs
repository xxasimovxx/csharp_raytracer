using VecMath;
namespace Rays
{
    public class Ray
    {
        public Vec3 Origin
        {

            get;
            private set;

        }

        public Vec3 Direction
        {

            get;
            private set;

        }

        public Ray(Vec3 origin, Vec3 direction)
        {

            this.Origin = origin;
            this.Direction = direction;

        }

        public Vec3 At(double t)
        {

            return Origin + Direction * t;

        }

    }

}
