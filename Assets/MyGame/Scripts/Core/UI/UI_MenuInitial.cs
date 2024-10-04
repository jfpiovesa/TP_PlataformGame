using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UI_MenuInitial : MonoBehaviour
{

    UI_MainMenuManager ui_MainMenuManager;

    [Header("Buttons")]
    [SerializeField] private Button btn_StartGame;
    [SerializeField] private Button btn_DashBoard;
    [SerializeField] private Button btn_ExitGame;

    [Header("Scenes"),Space(5)]
    [SerializeField] private string sceneStageName;
    
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



        btn_StartGame.onClick.RemoveAllListeners();
        btn_DashBoard.onClick.RemoveAllListeners();
        btn_ExitGame.onClick.RemoveAllListeners();

        btn_StartGame.onClick.AddListener(StartGame);
        btn_DashBoard.onClick.AddListener(DashBoard);
        btn_ExitGame.onClick.AddListener(ExitGame);
    }
    void StartGame()
    {
        ApplicationManager.Instance.loadingSceneController.LoadScene(sceneStageName, E_TypeAnimLoading.fade);
    }
    void DashBoard()
    {
        ui_MainMenuManager.ui_DashBoard.DashboardCreator();
    }
    void ExitGame()
    {
        Application.Quit();
    }
}
