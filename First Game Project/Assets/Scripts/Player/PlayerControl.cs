using UnityEngine;
using Zenject;

public class PlayerControl : MonoBehaviour
{
    public CharacterController characterController;

    public PlayerRotation PlayerRotation;
    public PlayerGroundMovement PlayerGroundMovement;
    public PlayerVerticalMovement PlayerVerticalMovement;

    public IUnityService _unityService;

    public float mouseSensitivity = 100f;
    public float speed = 12f;
    public float gravity = -14f;

    [Inject]
    public void Construct(IUnityService unityService)
    {
        _unityService = unityService;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerRotation = new PlayerRotation(mouseSensitivity);
        PlayerGroundMovement = new PlayerGroundMovement(transform, speed);
        PlayerVerticalMovement = new PlayerVerticalMovement(characterController, gravity);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(PlayerRotation.CalculateYRotation(_unityService.GetAxis("Mouse X"), _unityService.GetDeltaTime()));
        characterController.Move(PlayerGroundMovement.Calculate(_unityService.GetAxis("Horizontal"), _unityService.GetAxis("Vertical"), _unityService.GetDeltaTime()));
        characterController.Move(PlayerVerticalMovement.CalculateGravitationalEffectVector(_unityService.GetDeltaTime()));
    }
}
