using UnityEngine;
using Zenject;

public class WeaponController : MonoBehaviour
{
    public Camera Camera;

    public Weapon Weapon;

    IPlayerAttackInput _playerAttackInput;

    public float weaponDamage = 10f;
    public float weaponRange = 100f;

    [Inject]
    public void Construct(IPlayerAttackInput playerAttackInput)
    {
        _playerAttackInput = playerAttackInput;
    }

    private void Start()
    {
        Weapon = new Weapon(Camera, weaponRange, weaponDamage);
    }

    void Update()
    {
        if (_playerAttackInput.GetButtonDown("Fire1"))
        {
            Weapon.Attack();
        }
    }
}
