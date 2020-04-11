using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    readonly Transform Player;
    readonly float Speed;

    public PlayerMovement(Transform player, float speed)
    {
        Player = player;
        Speed = speed;
    }

    public Vector3 Calculate(float xMovement, float zMovement, float deltaTime)
    {
        Vector3 movement = (Player.right * xMovement + Player.forward * zMovement) * deltaTime * Speed;

        return movement;
    }
}
