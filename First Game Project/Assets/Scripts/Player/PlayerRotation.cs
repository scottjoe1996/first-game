using UnityEngine;

public class PlayerRotation
{
    public float MouseSensitivity;

    public PlayerRotation(float mouseSensitivity)
    {
        MouseSensitivity = mouseSensitivity;
    }

    public Vector3 CalculateYRotation(float mouseX, float deltaTime)
    {
        float rotationAmount = mouseX * MouseSensitivity * deltaTime;

        return Vector3.up * rotationAmount;
    }
}