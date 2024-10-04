using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxe : InteractiveObjectBase
{
    [SerializeField] private int valueScore = 1;

    public override void ActionOnCollisionEnter2D(Collision2D collision)
    {
        base.ActionOnCollisionEnter2D(collision);
        St_StageAction.currentStageController?.AddScore(valueScore);
        DestruirWithInstantiate();

    }
}
