using UnityEngine;

public class Player
{
    public float MouseSensitivity;

    public Player(float mouseSensitivity)
    {
        MouseSensitivity = mouseSensitivity;
    }

    public Vector3 CalculateYRotation(float mouseX, float deltaTime)
    {
        float rotationAmount = mouseX * MouseSensitivity * deltaTime;

        return Vector3.up * rotationAmount;
    }
}