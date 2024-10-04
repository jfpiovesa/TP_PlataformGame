using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_DashBoard : MonoBehaviour
{
    [SerializeField] private UI_MainMenuManager ui_MainMenuManager;
    [SerializeField] private Button btn_return;


    [SerializeField] private Transform content;
    [SerializeField] private UI_StageInfoDashBoard prefabItemSategeInfo;

    private void Awake()
    {
        Initialized();
    }
    void Initialized()
    {
        if (ui_MainMenuManager == null)
        {
            ui_MainMenuManager = GetComponentInParent<UI_MainMenuManager>();
        }

        btn_return.onClick.RemoveAllListeners();

        btn_return.onClick.AddListener(Return);
    }

    public void DashboardCreator()
    {
        List<Srl_StatusStage> statusStages = ApplicationManager.Instance.saveSystem.GameState.StatusStages;

        foreach (Transform itemChild in content)
        {
            if (itemChild.gameObject != null)
            {
                Destroy(itemChild.gameObject);
            }
        }
        foreach (Srl_StatusStage item in statusStages)
        {
            if (item != null)
            {
                Instantiate<UI_StageInfoDashBoard>(prefabItemSategeInfo, content).SetUpInfoStage(item);
            }
        }

        ui_MainMenuManager.canvasGroupController.ActivateCanvasGroup(1);
    }


    void Return()
    {
        ui_MainMenuManager.canvasGroupController.ActivateCanvasGroup(0);
    }

}
