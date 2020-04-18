using UnityEngine;

public class GroundChecker
{
    public CharacterController CharacterController;

    public ICheckGround _checkGround;

    public GroundChecker(CharacterController characterController)
    {
        CharacterController = characterController;
        _checkGround = new CheckGround();
    }

    public bool IsGrounded()
    {
        Ray testRay = new Ray(CharacterController.bounds.center, Vector3.down);
        return _checkGround.SphereCast(testRay, CharacterController.radius + 0.05f, CharacterController.height / 2);
    }
}
