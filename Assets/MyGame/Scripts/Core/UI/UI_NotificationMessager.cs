using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_NotificationMessager : MonoBehaviour
{
    [SerializeField] private GameObject contet;
    [SerializeField] private TMP_Text text_message;
    [SerializeField] private float timeDelayWrite = 0.3f;
    [SerializeField] private float timeDelayClosed = 1f;

    Action<bool> actionMessager;
    private void OnEnable()
    {
        St_StageAction.NotificationMessager = this;
    }
    private void OnDisable()
    {
        St_StageAction.NotificationMessager = null;
    }
    public void SetupMessage(string value ,Action<bool> action)
    {
        actionMessager?.Invoke(true);
        actionMessager = action;
        actionMessager?.Invoke(false);
        StartCoroutine(TextWriTe(value));
    }

    private IEnumerator TextWriTe(string value)
    {
        contet.SetActive(true);
        text_message.text = string.Empty;

        foreach (char item in value)
        {
            text_message.text += item; 
            yield return new WaitForSeconds(timeDelayWrite); 
        }

        yield return new WaitForSeconds(timeDelayClosed);

        contet.SetActive(false);
        actionMessager?.Invoke(true);

    }
}
