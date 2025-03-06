using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkingTransition : Transition
{
    public bool IsAbleToGo { get; set; }

    private void Update()
    {
        if (IsAbleToGo)
            NeedSwitch = true;
    }
}
