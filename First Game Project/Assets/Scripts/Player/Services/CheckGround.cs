using UnityEngine;

public class CheckGround : ICheckGround
{
    public bool SphereCast(Ray ray, float radius, float maxDistance)
    {
        return Physics.SphereCast(ray, radius, maxDistance);
    }
}
