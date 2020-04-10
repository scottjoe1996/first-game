using UnityEngine;

public class Camera {
    public float MouseSensitivity;
    private float xRotation = 0f;

    public Camera(float mouseSensitivity) {
        MouseSensitivity = mouseSensitivity;
    }

    public Quaternion CalculateXRotation(float mouseY, float deltaTime) {
        float rotationAmount = mouseY * MouseSensitivity * deltaTime;
        xRotation -= rotationAmount;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        return Quaternion.Euler(xRotation, 0, 0);
    }
}