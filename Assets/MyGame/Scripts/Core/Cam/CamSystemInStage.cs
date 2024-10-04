using Cinemachine;
using UnityEngine;

public class CamSystemInStage : MonoBehaviour
{

    public CinemachineVirtualCamera virtualCamera;
    private void Awake()
    {
        St_StageAction.SetTagerCamInStageAction = SetPlayerLookCam;
    }
    private void OnDisable()
    {
        St_StageAction.SetTagerCamInStageAction -= SetPlayerLookCam;
    }

    void SetPlayerLookCam(Transform target)
    {
        virtualCamera.Follow = target;  
        virtualCamera.LookAt = target;
    }
   
}
