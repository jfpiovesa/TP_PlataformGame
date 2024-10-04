using System.Collections;
using UnityEditor;
using UnityEngine;

public class ManagerLoadingScene : MonoBehaviour
{
    [Header("Settings")]
    public string sceneName;
    public bool delayLoadingScene = false;
    public float timeDelay = 10;

    void Start()
    {
        if (delayLoadingScene)
            StartCoroutine(Delay());
        else
            ApplicationManager.Instance.loadingSceneController.LoadScene(sceneName, E_TypeAnimLoading.fade);
    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(timeDelay);
        ApplicationManager.Instance.loadingSceneController.LoadScene(sceneName, E_TypeAnimLoading.fade);
    }

}
