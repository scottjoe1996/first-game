using UnityEngine;
using Zenject;

public class PlayerControl : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public PlayerRotation PlayerRotation;
    public IUnityService _unityService;

    [Inject]
    public void Construct(IUnityService unityService)
    {
        _unityService = unityService;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        PlayerRotation = new PlayerRotation(mouseSensitivity);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(PlayerRotation.CalculateYRotation(_unityService.GetAxis("Mouse X"), _unityService.GetDeltaTime()));
    }
}
