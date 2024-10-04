using UnityEngine;

public class FinishStage : InteractiveObjectBase
{

    public override void ActionOnTriggerEnter2D(Collider2D collision)
    {
        base.ActionOnTriggerEnter2D(collision);

        St_StageAction.currentStageController.playerCharacter.CanMove = false;
        St_StageAction.FinishAction?.Invoke();
    }

}
