using UnityEngine;

public class Weapon
{
    public Camera Camera;
    public ICheckWeaponHit _checkWeaponHit;

    readonly float WeaponRange;
    readonly float WeaponDamage;

    public Weapon(Camera camera, float weaponRange, float weaponDamage)
    {
        Camera = camera;
        _checkWeaponHit = new CheckWeaponHit();
        WeaponRange = weaponRange;
        WeaponDamage = weaponDamage;
    }

    public void Attack()
    {
        if (_checkWeaponHit.RayCast(Camera.transform.position, Camera.transform.forward, out RaycastHit target, WeaponRange))
        {
            ApplyDamageToTarget(target);
        }
    }

    private void ApplyDamageToTarget(RaycastHit target)
    {
        Target targetHit = target.transform.GetComponent<Target>();
        if (targetHit != null)
        {
            targetHit.TakeDamage(WeaponDamage);
        }
    }
}
