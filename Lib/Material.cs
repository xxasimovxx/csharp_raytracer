using HittableObjects;
namespace Rays
{
    public interface IMaterial
    {
        bool Scatter(ref Ray ray, ref HitRecord hitRecord, ref Ray scatter);
    }

}
