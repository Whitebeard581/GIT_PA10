﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script manages the behavior of individual obstacle
public class Obstacle : MonoBehaviour
{
    [SerializeField] private float Speed = 3;

    private bool Flag = false;

    void Update()
    {
        if (transform.position.x <= -8)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * -Speed);
        }

        if (transform.position.x <= -0.95f && Flag == false)
        {
            Flag = true;
            GameManager.thisManager.UpdateScore();
        }
    }
}
