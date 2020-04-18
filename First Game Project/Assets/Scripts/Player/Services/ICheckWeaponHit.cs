using UnityEngine;

public interface ICheckWeaponHit
{
    bool RayCast(Vector3 origin, Vector3 direction, out RaycastHit targetInfo, float weaponRange);
}
