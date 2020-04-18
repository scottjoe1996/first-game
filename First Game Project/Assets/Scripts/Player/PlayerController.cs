using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    public CharacterController characterController;

    public PlayerRotation PlayerRotation;
    public PlayerGroundMovement PlayerGroundMovement;
    public PlayerVerticalMovement PlayerVerticalMovement;

    public IPlayerMovementInput _playerMovementInput;

    public float mouseSensitivity = 100f;
    public float speed = 12f;
    public float gravity = -14f;

    [Inject]
    public void Construct(IPlayerMovementInput playerMovementInput)
    {
        _playerMovementInput = playerMovementInput;
    }
    
    void Start()
    {
        PlayerRotation = new PlayerRotation(mouseSensitivity);
        PlayerGroundMovement = new PlayerGroundMovement(transform, speed);
        PlayerVerticalMovement = new PlayerVerticalMovement(characterController, gravity);
    }

    void Update()
    {
        transform.Rotate(PlayerRotation.CalculateYRotation(_playerMovementInput.GetAxis("Mouse X"), _playerMovementInput.GetDeltaTime()));

        characterController.Move(PlayerGroundMovement.Calculate(_playerMovementInput.GetAxis("Horizontal"), _playerMovementInput.GetAxis("Vertical"), _playerMovementInput.GetDeltaTime()));

        characterController.Move(PlayerVerticalMovement.CalculateGravitationalEffectVector(_playerMovementInput.GetDeltaTime()));
    }
}
