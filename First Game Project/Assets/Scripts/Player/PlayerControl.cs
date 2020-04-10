using UnityEngine;
using Zenject;

public class PlayerControl : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Player Player;
    public IUnityService _unityService;

    [Inject]
    public void Construct(IUnityService unityService)
    {
        _unityService = unityService;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Player = new Player(mouseSensitivity);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Player.CalculateYRotation(_unityService.GetAxis("Mouse X"), _unityService.GetDeltaTime()));
    }
}
