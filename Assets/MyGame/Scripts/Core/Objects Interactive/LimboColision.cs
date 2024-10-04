using System.Collections;
using UnityEngine;

public class LimboColision : InteractiveObjectBase
{

    [SerializeField] private bool canTakeDamage = false;
    [SerializeField] private Srl_ObjectDamege srl_ObjectDamege;
    [SerializeField] private float delayTimeReapwn = 0.5f;

    Coroutine coroutine = null;


    public override void ActionOnTriggerEnter2D(Collider2D collision)
    {
        base.ActionOnTriggerEnter2D(collision);

        St_StageAction.currentStageController.playerCharacter.CanMove = false;

        if (canTakeDamage)
        {
            St_StageAction.currentStageController.playerCharacter.TakeDamage(srl_ObjectDamege);
            if (St_StageAction.currentStageController.playerCharacter.IsLive)
            {
                coroutine = StartCoroutine(Respawn());
            }
        }
        else
        {
            coroutine = StartCoroutine(Respawn());
        }
    }
     IEnumerator Respawn()
    {
        yield return new WaitForSeconds(delayTimeReapwn);
        St_StageAction.RespawnCheckPoint();
    }
}
