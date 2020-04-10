using UnityEngine;
using Zenject;

public class CameraControl : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    // public Transform player;
    public CameraRotation CameraRotation;
    public IUnityService _unityService;

    [Inject]
    public void Construct(IUnityService unityService)
    {
        _unityService = unityService;
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        CameraRotation = new CameraRotation(mouseSensitivity);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = CameraRotation.CalculateXRotation(_unityService.GetAxis("Mouse Y"), _unityService.GetDeltaTime());
    }
}