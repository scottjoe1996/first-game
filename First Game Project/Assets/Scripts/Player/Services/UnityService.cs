using UnityEngine;

public class UnityService : IUnityService 
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