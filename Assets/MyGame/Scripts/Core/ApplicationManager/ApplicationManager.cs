using UnityEngine;

public class ApplicationManager : MonoBehaviour
{
    public static ApplicationManager Instance { get; private set; }


    [Header("Settings")]
    public bool debugInfos = false;
    public bool isMobile = true;


    [Header("Componemts"), Space(5)]
    public GameDataInfo gameDataInfo;
    public LoadingSceneController loadingSceneController;
    public SaveSystem saveSystem;



    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }


        Instance = this;
        DontDestroyOnLoad(this.gameObject);

        Initialized();
    }

    private void Initialized()
    {
        gameDataInfo.Initialized();
        saveSystem.Inialization();
    }


}
