using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public static class St_StageAction
{
    public static StageController currentStageController { get; set; }
    public static TMP_Text TextBoxesCurrentStage { get; set; }
    public static TMP_Text TextTimeCurrentStage { get; set; }
    public static Image IconeCurrentStage { get; set; }

    public static GameObject[] LifeChatacterEggs;
    public static Transform CheckPositon { get; set; }
    public static UI_MobileCanvas MobileCanvas { get; set; }
    public static UI_NotificationMessager NotificationMessager { get; set; } 
    public static Action<Transform> SetTagerCamInStageAction { get; set; }
    public static Action DidAction { get; set; }
    public static Action FinishAction { get; set; }
    public static void SetTagerCamInStage(Transform stageController)
    {
        SetTagerCamInStageAction?.Invoke(stageController);
    }
    public static void RespawnCheckPoint()
    {
        currentStageController.playerCharacter.transform.position = CheckPositon.position;
        currentStageController.playerCharacter.CanMove = true;
    }
    public static void LifeCharacteUpdate(int value)
    {
        if (currentStageController.playerCharacter == null) return;
        if (LifeChatacterEggs == null) return;

        foreach(GameObject gameObject in  LifeChatacterEggs)
        {
            gameObject.SetActive(false);
        }
        if(value > 0)
        {
            for (int i = 0; i < value ; i++)
            {
                LifeChatacterEggs[i].SetActive(true);
            }
        }
       
        
    }

}
