using UnityEngine;
using Zenject;

public class PlayerControl : MonoBehaviour
{
    public PlayerRotation PlayerRotation;
    public PlayerMovement PlayerMovement;

    public IUnityService _unityService;

    public CharacterController characterController;

    public float mouseSensitivity = 100f;
    public float speed = 12f;

    [Inject]
    public void Construct(IUnityService unityService)
    {
        _unityService = unityService;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerRotation = new PlayerRotation(mouseSensitivity);
        PlayerMovement = new PlayerMovement(transform, speed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(PlayerRotation.CalculateYRotation(_unityService.GetAxis("Mouse X"), _unityService.GetDeltaTime()));
        characterController.Move(PlayerMovement.Calculate(_unityService.GetAxis("Horizontal"), _unityService.GetAxis("Vertical"), _unityService.GetDeltaTime()));
    }
}
