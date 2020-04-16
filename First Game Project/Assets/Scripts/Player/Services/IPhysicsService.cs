using UnityEngine;

public interface IPhysicsService
{
    bool SphereCast(Ray ray, float radius, float maxDistance);
}
