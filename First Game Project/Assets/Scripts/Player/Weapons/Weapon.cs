using UnityEngine;
using Zenject;

public class Weapon : MonoBehaviour
{
    public ParticleSystem AttackEffect;
    public GameObject HitEffect;
    public LayerMask HitableTargets;
    public float Range;
    public float Damage;

    public ICheckWeaponHit _checkWeaponHit;

    [Inject]
    public void Construct(ICheckWeaponHit checkWeaponHit)
    {
        _checkWeaponHit = checkWeaponHit;
    }

    public void Attack(Camera camera)
    {
        AttackEffect.Play();
        if (_checkWeaponHit.RayCast(camera.transform.position, camera.transform.forward, out RaycastHit target, Range, HitableTargets))
        {
            CreateHitEffectAtTarget(target);
            ApplyDamageToTarget(target);
        }
    }

    private void CreateHitEffectAtTarget(RaycastHit target)
    {
        GameObject hitEffectGO = Instantiate<GameObject>(HitEffect, target.point, Quaternion.LookRotation(target.normal));
        Destroy(hitEffectGO, 2f);
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
