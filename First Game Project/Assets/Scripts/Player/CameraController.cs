using UnityEngine;
using Zenject;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public CameraRotation CameraRotation;
    public IUnityService _unityService;

    [Inject]
    public void Construct(IUnityService unityService)
    {
        _unityService = unityService;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        CameraRotation = new CameraRotation(mouseSensitivity);
    }

    void Update()
    {
        transform.localRotation = CameraRotation.CalculateXRotation(_unityService.GetAxis("Mouse Y"), _unityService.GetDeltaTime());
    }
}