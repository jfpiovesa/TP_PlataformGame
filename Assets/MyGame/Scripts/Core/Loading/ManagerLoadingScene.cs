using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerLoadingScene : MonoBehaviour
{
    [Header("Settings")]
    public SceneAsset sceneSelected;
    public bool delayLoadingScene = false;
    public float timeDelay = 10;

    void Start()
    {
        if (delayLoadingScene)
            StartCoroutine(Delay());
        else
            ApplicationManager.Instance.loadingSceneController.LoadScene(sceneSelected, E_TypeAnimLoading.fade);
    }
    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(timeDelay);
        ApplicationManager.Instance.loadingSceneController.LoadScene(sceneSelected, E_TypeAnimLoading.fade);
    }

}
