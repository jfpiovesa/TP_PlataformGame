using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingNotificationMessager : InteractiveObjectBase
{

    public bool canActiveMessager = true;
    [TextArea] public string textMessage = "Test";
    public override void ActionOnTriggerEnter2D(Collider2D collision)
    {
        base.ActionOnTriggerEnter2D(collision);

        if (canActiveMessager)
        {
            St_StageAction.NotificationMessager.SetupMessage(textMessage, ActiveCanText);
        }
    }
    void ActiveCanText(bool value)
    {
        canActiveMessager = value;
    }

}
