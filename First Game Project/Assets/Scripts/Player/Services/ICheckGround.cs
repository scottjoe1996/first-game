using UnityEngine;

public interface ICheckGround
{
    bool SphereCast(Ray ray, float radius, float maxDistance);
}
