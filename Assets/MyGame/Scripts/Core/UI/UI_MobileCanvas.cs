using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MobileCanvas : MonoBehaviour
{
    private void Awake()
    {
        St_StageAction.MobileCanvas = this;
        this.gameObject.SetActive(ApplicationManager.Instance.isMobile);

    }
}
