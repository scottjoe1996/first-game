using UnityEngine;

public class Weapon
{
    public Camera Camera;
    public ICheckWeaponHit _checkWeaponHit;

    readonly ParticleSystem AttackEffect;
    readonly float Range;
    readonly float Damage;

    public Weapon(Camera camera, float range, float damage, ParticleSystem attackEffect)
    {
        Camera = camera;
        _checkWeaponHit = new CheckWeaponHit();
        Range = range;
        Damage = damage;
        AttackEffect = attackEffect;
    }

    public void Attack()
    {
        AttackEffect.Play();
        if (_checkWeaponHit.RayCast(Camera.transform.position, Camera.transform.forward, out RaycastHit target, Range))
        {
            ApplyDamageToTarget(target);
        }
    }

    private void ApplyDamageToTarget(RaycastHit target)
    {
        Target targetHit = target.transform.GetComponent<Target>();
        if (targetHit != null)
        {
            targetHit.TakeDamage(Damage);
        }
    }
}
