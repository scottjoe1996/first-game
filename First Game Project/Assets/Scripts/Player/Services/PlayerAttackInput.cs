using UnityEngine;

public class PlayerAttackInput : IPlayerAttackInput
{
    public bool GetButtonDown(string input)
    {
        return Input.GetButtonDown(input);
    }
}
