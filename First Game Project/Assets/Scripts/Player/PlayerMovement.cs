﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement
{
    readonly Transform PlayerTransform;
    readonly float Speed;

    public PlayerMovement(Transform playerTransform, float speed)
    {
        PlayerTransform = playerTransform;
        Speed = speed;
    }

    public Vector3 Calculate(float xMovement, float zMovement, float deltaTime)
    {
        Vector3 movement = (PlayerTransform.right * xMovement + PlayerTransform.forward * zMovement) * deltaTime * Speed;

        return movement;
    }
}
