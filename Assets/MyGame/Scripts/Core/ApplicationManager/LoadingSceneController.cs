using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadingSceneController : MonoBehaviour
{
    [Header("Setting")]
    [SerializeField] private Animator loadingImage;
    [SerializeField] private E_TypeAnimLoading e_typeAnimLoading;

    private float timeAnimCurrenty;
    AsyncOperation operation;
    public void LoadScene(SceneAsset scene, E_TypeAnimLoading typeAnimLoading)
    {
        e_typeAnimLoading = typeAnimLoading;
        StartCoroutine(LoadAsync(scene));
    }
    private IEnumerator LoadAsync(SceneAsset scene)
    {
        LoadImageAnim(true);

        yield return new WaitForSeconds(timeAnimCurrenty);

        operation = SceneManager.LoadSceneAsync(scene.name);

        while (!operation.isDone)
        {
            yield return null;
        }


        LoadImageAnim(false);

    }
    public void LoadImageAnim(bool active)
    {

        if (active)
            ActiveImageAnim();
        else
            DesactiveImageAnim();

    }
    public void ActiveImageAnim()
    {
        switch (e_typeAnimLoading)
        {
            case E_TypeAnimLoading.fade:

                loadingImage.Play("Fad_In");

                break;
            case E_TypeAnimLoading.died:

                loadingImage.Play("Died_In");

                break;

            default:

                loadingImage.Play("Fad_In");

                break;
        }

        timeAnimCurrenty = loadingImage.GetNextAnimatorClipInfo(0).Length;

    }
    public void DesactiveImageAnim()
    {
        switch (e_typeAnimLoading)
        {
            case E_TypeAnimLoading.fade:

                loadingImage.Play("Fad_Out");

                break;
            case E_TypeAnimLoading.died:

                loadingImage.Play("Died_Out");

                break;

            default:

                loadingImage.Play("Fad_Out");

                break;
        }

        timeAnimCurrenty = loadingImage.GetNextAnimatorClipInfo(0).Length;
    }
}
