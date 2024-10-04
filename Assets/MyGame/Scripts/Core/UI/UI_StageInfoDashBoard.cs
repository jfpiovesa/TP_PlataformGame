using UnityEngine;
using TMPro;

public class UI_StageInfoDashBoard : MonoBehaviour
{
    [Header("Info")]
    [SerializeField] private Srl_StatusStage statusStage;

    [Header("Text"), Space(5)]
    [SerializeField] private TMP_Text nameStage;
    [SerializeField] private TMP_Text boxesStage;
    [SerializeField] private TMP_Text timeStage;
    [SerializeField] private TMP_Text attemptsStage;

    public void SetUpInfoStage(Srl_StatusStage valueStage)
    {
        statusStage = valueStage;
        UpdateInfo();
    }
     void UpdateInfo()
    {
        if (statusStage != null)
        {
            nameStage.text = statusStage.nameStage;
            boxesStage.text = statusStage.boxes.ToString();
            attemptsStage.text = statusStage.internshipAttempts.ToString();    
            timeStage.text = ConvertTime(statusStage.time);   
        }
        else
        {
            if(ApplicationManager.Instance.debugInfos)
            {
                Debug.Log("stage is null");
            }
        }
    }
     string ConvertTime(float seconds)
    {
        float hours = seconds / 3600; 
        seconds %= 3600;

        float minutes = seconds / 60;
        float remainingSeconds = seconds % 60;

        if (ApplicationManager.Instance.debugInfos)
        {
            Debug.Log("hours : " + hours + ", minutes: " + minutes + ", seconds : " + remainingSeconds);
        }

        return string.Format("{0:D2}:{1:D2}:{2:D2} ", (int)hours, (int)minutes, (int)remainingSeconds);

    }

}
