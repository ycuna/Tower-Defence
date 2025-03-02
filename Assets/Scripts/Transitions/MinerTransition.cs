﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MinerTransition : MonoBehaviour
{
    [SerializeField] private MinerState _nextState;

    public bool NeedSwitch { get; protected set; }

    public MinerState NextState
    {
        get => _nextState;
    }

    private void OnEnable()
    {
        NeedSwitch = false;
    }
}
