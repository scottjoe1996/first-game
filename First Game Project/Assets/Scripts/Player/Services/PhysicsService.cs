using UnityEngine;

public class PhysicsService : IPhysicsService
{
    public bool SphereCast(Ray ray, float radius, float maxDistance)
    {
        return Physics.SphereCast(ray, radius, maxDistance);
    }
}
