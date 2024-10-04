using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataInfo : MonoBehaviour
{
    [SerializeField] int idCharacterSelected = 0;
    [SerializeField] int idStageSelected = 0;
    [SerializeField] SO_PlayerData[] playerCharacters;
    [SerializeField] SO_StageData[] stagesDatas;

    public void Initialized()
    {
        FindCharacters();
        FindStage();
    }
    void FindCharacters()
    {
        playerCharacters = Resources.LoadAll<SO_PlayerData>("Characters");
    }
    void FindStage()
    {
        stagesDatas = Resources.LoadAll<SO_StageData>("Stages");
    }

    public SO_PlayerData GetCharacterSelected()
    {
        return playerCharacters[idCharacterSelected];
    }
    public SO_StageData GetStageSelected()
    {
        return stagesDatas[idStageSelected];
    }
}
