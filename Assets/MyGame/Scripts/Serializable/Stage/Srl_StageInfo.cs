using System;
using UnityEngine;

[Serializable]
public class Srl_StageInfo
{
    [Header("Settings ")]

    [Header("Id Stage "), Space(4)]
    public int idStage = 0;

    [Header("Time"), Space(4)]
    public float timeStage = 0;

    [Header("Score"), Space(4)]
    public int boxes = 0;

    [Header("attempts"), Space(4)]
    public int attempts = 0;

}
