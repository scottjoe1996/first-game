using UnityEngine;

public class PlayerMovementInput : IPlayerMovementInput 
{
    public float GetDeltaTime() 
    {
        return Time.deltaTime;
    }

    public float GetAxis(string axisName) 
    {
        return Input.GetAxis(axisName);
    }

}