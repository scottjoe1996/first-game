using UnityEngine;

public class GroundChecker
{
    public CharacterController CharacterController;

    public IPhysicsService _physicsService;

    public GroundChecker(CharacterController characterController)
    {
        CharacterController = characterController;
        _physicsService = new PhysicsService();
    }

    public bool IsGrounded()
    {
        Ray testRay = new Ray(CharacterController.bounds.center, Vector3.down);
        return _physicsService.SphereCast(testRay, CharacterController.radius + 0.05f, CharacterController.height / 2);
    }
}
