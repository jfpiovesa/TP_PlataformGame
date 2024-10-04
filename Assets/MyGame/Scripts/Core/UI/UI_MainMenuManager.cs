using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MainMenuManager : MonoBehaviour
{
    [Header("Componemts")]
    public UI_CanvasGroupController canvasGroupController;
    public UI_DashBoard ui_DashBoard;
    public UI_MenuInitial ui_MenuInitial;

    private void Awake()
    {
        GetComponets();
        Initialized();
    }

    void GetComponets()
    {
        if (canvasGroupController == null)
        {
            canvasGroupController = GetComponent<UI_CanvasGroupController>();
        }
        if (ui_DashBoard == null)
        {
            ui_DashBoard = GetComponentInChildren<UI_DashBoard>();
        }
        if (ui_MenuInitial == null)
        {
            ui_MenuInitial = GetComponentInChildren<UI_MenuInitial>();
        }
    }

    private void Initialized()
    {
        canvasGroupController.ActivateCanvasGroup(0);
    }



}
