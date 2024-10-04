using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_CanvasGroupController : MonoBehaviour
{
    public CanvasGroup[] canvasGroups;

    public void ActivateCanvasGroup(int index)
    {
        if (index >= 0 && index < canvasGroups.Length)
        {
            DeactivateAllCanvasGroups();
       
            canvasGroups[index].alpha = 1; 
            canvasGroups[index].interactable = true; 
            canvasGroups[index].blocksRaycasts = true; 
        }
        else
        {
            Debug.LogError("Índice fora do alcance!");
        }
    }
    public void DeactivateAllCanvasGroups()
    {
        foreach (CanvasGroup group in canvasGroups)
        {
            group.alpha = 0;
            group.interactable = false;
            group.blocksRaycasts = false;
        }
    }
}
