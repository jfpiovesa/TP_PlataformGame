using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_MainStage : MonoBehaviour
{
    [Header("UI Componemts")]
    [SerializeField] private Button btn_menu; 
    [SerializeField] private Image IconeCharacter;
    [SerializeField] private TMP_Text text_time;
    [SerializeField] private TMP_Text text_boxes;
    [SerializeField] private GameObject[] life;

    [Header("Componemts")]
    [SerializeField] private ui_StageFinish ui_StageFinish;
    [SerializeField] private ui_StageDid ui_StageDid;
    [SerializeField] private UI_MenuGameInStage uI_MenuGameInStage;

    private void Awake()
    {
        St_StageAction.TextBoxesCurrentStage = text_boxes;
        St_StageAction.TextTimeCurrentStage = text_time;
        St_StageAction.IconeCurrentStage = IconeCharacter;
        St_StageAction.LifeChatacterEggs = life;
        St_StageAction.FinishAction = ui_StageFinish.SetUpStageFinish;
        St_StageAction.DidAction = ui_StageDid.SetUpStageDid;
        OnInitialized();
    }
    private void OnDisable()
    {
        St_StageAction.TextBoxesCurrentStage  =  null;
        St_StageAction.TextTimeCurrentStage = null;
        St_StageAction.IconeCurrentStage = null;
        St_StageAction.LifeChatacterEggs = null;
        St_StageAction.FinishAction = null;
        St_StageAction.DidAction = null;


    }
    private void OnInitialized()
    {

        btn_menu.onClick.RemoveAllListeners();
        btn_menu.onClick.AddListener(uI_MenuGameInStage.MenuOn);
    }

}
