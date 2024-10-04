using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UI_MenuGameInStage : MonoBehaviour
{
    [SerializeField] private GameObject content;
    [SerializeField] private string sceneMenuName;

    [Header("UI Componemts")]
    [SerializeField] private Button btn_resume;
    [SerializeField] private Button btn_replayAgain;
    [SerializeField] private Button btn_Menu;


    private void OnEnable()
    {
        OnInitialized();
    }
    private void OnInitialized()
    {
        btn_resume.onClick.RemoveAllListeners();
        btn_replayAgain.onClick.RemoveAllListeners();
        btn_Menu.onClick.RemoveAllListeners();


        btn_resume.onClick.AddListener(Resume);
        btn_replayAgain.onClick.AddListener(ReplayAgain);
        btn_Menu.onClick.AddListener(Menu);
    }
    public void MenuOn()
    {
        content.SetActive(true);
        St_StageAction.MobileCanvas.gameObject.SetActive(false);
        St_StageAction.currentStageController.StopStage();

    }
    public void Resume()
    {
        content.SetActive(false);
        St_StageAction.MobileCanvas.gameObject.SetActive(true);
        St_StageAction.currentStageController.StartingStage();
    }
    public void ReplayAgain()
    {
        SaveGame();
        ApplicationManager.Instance.loadingSceneController.LoadScene(St_StageAction.currentStageController.stageData.sceneStage, E_TypeAnimLoading.fade);
        content.SetActive(false);
    }
    public void Menu()
    {
        SaveGame();
        ApplicationManager.Instance.loadingSceneController.LoadScene(sceneMenuName, E_TypeAnimLoading.fade);
    }
    void SaveGame()
    {
        Srl_StatusStage stagestatus = ApplicationManager.Instance.saveSystem.GameState.StatusStages
            .Find(x => x.idStage.Equals(St_StageAction.currentStageController.stageData.id));

        Srl_StatusStage newStagestatus = new Srl_StatusStage()
        {
            idStage = St_StageAction.currentStageController.stageData.id,
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
