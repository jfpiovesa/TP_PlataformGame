using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithTime : MonoBehaviour
{
    public float tempoAntesDeDestruir = 5f;
    public bool canTimeDestroy = true;
    void Start()
    {
        if (canTimeDestroy)
        {
            StartCoroutine(AguardarDestruicao());
        }
    }
    private IEnumerator AguardarDestruicao()
    {
        yield return new WaitForSeconds(tempoAntesDeDestruir);
        Destroy();
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }

}
