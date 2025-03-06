﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkingState : State
{
    [SerializeField] private float _moveSpeed;


    private void FixedUpdate()
    {
        transform.position += _moveSpeed * Vector3.left;
    }
}
