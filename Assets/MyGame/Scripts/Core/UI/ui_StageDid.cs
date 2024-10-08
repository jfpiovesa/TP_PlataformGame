using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ui_StageDid : MonoBehaviour
{
    [SerializeField] private GameObject content;
    [Header("text")]
    [SerializeField] private TMP_Text text_NameStage;
    [SerializeField] private TMP_Text text_boxes;
    [SerializeField] private TMP_Text text_time;

    [Header("buttons")]
    [SerializeField] private Button btn_replayAgain;
    [SerializeField] private Button btn_menu;

    [Header("Scene")]
    [SerializeField] private string sceneMenu;

    private void OnEnable()
    {
        Initialized();
    }
    private void Initialized()
    {
        btn_replayAgain.onClick.RemoveAllListeners();
        btn_menu.onClick.RemoveAllListeners();

        btn_replayAgain.onClick.AddListener(ReplayAgain);
        btn_menu.onClick.AddListener(Menu);
        content.SetActive(false);

    }
    public void SetUpStageDid()
    {
        SaveGame();

        St_StageAction.MobileCanvas?.gameObject.SetActive(false);      

        text_NameStage.text = St_StageAction.currentStageController.stageData.nameStage;
        text_boxes.text = St_StageAction.TextBoxesCurrentStage.text + "/" + St_StageAction.currentStageController.stageData.totalBoxes.ToString();
        text_time.text = St_StageAction.TextTimeCurrentStage.text;

        content.SetActive(true);
    }
    public void ReplayAgain()
    {
        ApplicationManager.Instance.loadingSceneController.LoadScene(St_StageAction.currentStageController.stageData.sceneStage, E_TypeAnimLoading.fade);
        content.SetActive(false);

    }
    public void Menu()
    {
        ApplicationManager.Instance.loadingSceneController.LoadScene(sceneMenu, E_TypeAnimLoading.fade);
    }

    void SaveGame()
    {

        Srl_StatusStage stagestatus = ApplicationManager.Instance.saveSystem.GameState.StatusStages.Find(x => x.idStage.Equals(St_StageAction.currentStageController.stageData.id));

        Srl_StatusStage newStagestatus = new Srl_StatusStage()
        {
            nameStage = St_StageAction.currentStageController.statusStage.nameStage,
            internshipAttempts = St_StageAction.currentStageController.statusStage.internshipAttempts,

        };

        if (stagestatus != null)
        {
            newStagestatus.boxes = stagestatus.boxes;

            int index = ApplicationManager.Instance.saveSystem.GameState.StatusStages
                .FindIndex(x => x.idStage.Equals(St_StageAction.currentStageController.stageData.id));

            if (index != -1)
            {
                ApplicationManager.Instance.saveSystem.GameState.StatusStages[index] = newStagestatus;
            }
        }
        else
        {

            ApplicationManager.Instance.saveSystem.GameState.StatusStages.Add(newStagestatus);
        }



        ApplicationManager.Instance.saveSystem.SaveGame();
    }
}
