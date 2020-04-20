using UnityEngine;
using Zenject;

public class WeaponController : MonoBehaviour
{
    public Camera Camera;
    public Weapon Weapon;

    public IPlayerAttackInput _playerAttackInput;

    [Inject]
    public void Construct(IPlayerAttackInput playerAttackInput)
    {
        _playerAttackInput = playerAttackInput;
    }

    void Update()
    {
        if (_playerAttackInput.GetButtonDown("Fire1"))
        {
            Weapon.Attack(Camera);
        }
    }
}
