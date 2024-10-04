using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignCheckPoint : InteractiveObjectBase
{

    [SerializeField] private bool canCheckPosition = true;
    [SerializeField] private Transform position;
    [SerializeField] private ParticleSystem vfx_CheccPoint;
    public override void ActionOnTriggerEnter2D(Collider2D collision)
    {
        base.ActionOnTriggerEnter2D(collision);

        if (canCheckPosition)
        {
            canCheckPosition = false;
            St_StageAction.CheckPositon = position;
            vfx_CheccPoint.Play();
        }
    }
}
