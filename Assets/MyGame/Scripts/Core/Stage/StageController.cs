using Unity.VisualScripting;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public Srl_StatusStage statusStage;
    public SO_StageData stageData;
    public CharacterBase playerCharacter;

    [SerializeField] private bool isStartingStage = false;


    private void OnEnable()
    {
        Initialized();
    }
    private void Update()
    {
        if (!isStartingStage) return;
        TimeStage();

    }
    private void OnDisable()
    {
        St_StageAction.currentStageController = null;
    }
    private void Initialized()
    {
        Srl_StatusStage stagestatus = ApplicationManager.Instance.saveSystem.GameState.StatusStages.Find(x => x.idStage.Equals(stageData.id));


        if (stagestatus != null)
        {
            statusStage.internshipAttempts = stagestatus.internshipAttempts;

        }

        statusStage.idStage = stageData.id;
        statusStage.nameStage = stageData.nameStage;
        statusStage.internshipAttempts += 1;

        St_StageAction.currentStageController = this;
        SpawnCharacter();
    }
    void SpawnCharacter()
    {
        Transform startingPosition = GameObject.Find("startingPosition").transform;
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            SO_PlayerData playerData = ApplicationManager.Instance.gameDataInfo.GetCharacterSelected();
            St_StageAction.IconeCurrentStage.sprite = playerData.iconeCharacter;

            Instantiate(playerData.prefabCharacter, transform.position, Quaternion.identity);
        }
        else
        {
            player.transform.position = startingPosition.position;
        }

    }
    public void AddScore(int value)
    {
        statusStage.boxes += value;
        St_StageAction.TextBoxesCurrentStage.text = statusStage.boxes.ToString().PadLeft(2,'0');
    }
    public void StartingStage()
    {
        isStartingStage = true;
    }
    public void StopStage()
    {
        isStartingStage = false;
    }
    void TimeStage()
    {
        statusStage.time += Time.deltaTime;
        St_StageAction.TextTimeCurrentStage.text = ConvertTime(statusStage.time);
    }

    string ConvertTime(float seconds)
    {
        string time = string.Empty;

        float hours = seconds / 3600;
        seconds %= 3600;

        float minutes = seconds / 60;
        float remainingSeconds = seconds % 60;

        if (seconds >= 3600)
        {
            time = string.Format("{0:D2}:{1:D2}:{2:D2} ", (int)hours, (int)minutes, (int)remainingSeconds);
        }
        else
        {
            time = string.Format("{0:D2}:{1:D2} ", (int)minutes, (int)remainingSeconds);

        }
        return time;
    }



}
