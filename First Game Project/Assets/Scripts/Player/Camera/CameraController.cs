using UnityEngine;
using Zenject;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public CameraRotation CameraRotation;
    public IPlayerMovementInput _playerInput;

    [Inject]
    public void Construct(IPlayerMovementInput playerInput)
    {
        _playerInput = playerInput;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        CameraRotation = new CameraRotation(mouseSensitivity);
    }

    void Update()
    {
        transform.localRotation = CameraRotation.CalculateXRotation(_playerInput.GetAxis("Mouse Y"), _playerInput.GetDeltaTime());
    }
}