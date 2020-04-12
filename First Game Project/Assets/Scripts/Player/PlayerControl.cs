using UnityEngine;
using Zenject;

public class PlayerControl : MonoBehaviour
{
    public CharacterController characterController;

    public PlayerRotation PlayerRotation;
    public PlayerMovement PlayerMovement;

    public IUnityService _unityService;

    public float mouseSensitivity = 100f;
    public float speed = 12f;
    public float gravity = -14f;

    private float verticalVelocity;

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

        SetVerticalVelocity();
        characterController.Move(new Vector3(0f, verticalVelocity * _unityService.GetDeltaTime(), 0f));
    }

    private void SetVerticalVelocity()
    {
        if (IsGrounded())
        {
            verticalVelocity = gravity;
        }
        else
        {
            verticalVelocity += gravity * _unityService.GetDeltaTime();
        }
    }

    private bool IsGrounded()
    {
        Ray testRay = new Ray(characterController.bounds.center, Vector3.down);
        return Physics.SphereCast(testRay, characterController.radius + 0.05f, characterController.height / 2);
    }
}
