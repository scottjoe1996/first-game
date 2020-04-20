using UnityEngine;

public class CheckWeaponHit : ICheckWeaponHit
{
    public bool RayCast(Vector3 origin, Vector3 direction, out RaycastHit targetInfo, float weaponRange, LayerMask hitableTargets)
    {
        return Physics.Raycast(origin, direction, out targetInfo, weaponRange, hitableTargets);
    }
}
