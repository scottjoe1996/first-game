using UnityEngine;

public class PlayerVerticalMovement
{
    readonly float Gravity;
    readonly GroundChecker GroundChecker;

    private float verticalVelocity;
    public PlayerVerticalMovement(CharacterController characterController, float gravity)
    {
        GroundChecker = new GroundChecker(characterController);
        Gravity = gravity;
    }

    public Vector3 CalculateGravitationalEffectVector(float deltaTime)
    {
        SetVerticalVelocity(deltaTime);
        return new Vector3(0f, verticalVelocity * deltaTime, 0f);
    }

    private void SetVerticalVelocity(float deltaTime)
    {
        if (GroundChecker.IsGrounded())
        {
            verticalVelocity = Gravity;
        }
        else
        {
            verticalVelocity += Gravity * deltaTime;
        }
    }
}
