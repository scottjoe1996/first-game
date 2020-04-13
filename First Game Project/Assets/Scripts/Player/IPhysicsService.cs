using UnityEngine;

public interface IPhysicsService
{
    bool SphereCast(Ray ray, float radius, float maxDistance);
}

public class PhysicsService : IPhysicsService
{
    public bool SphereCast(Ray ray, float radius, float maxDistance)
    {
        return Physics.SphereCast(ray, radius, maxDistance);
    }
}
