using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "NewStageData", menuName = "Game Data / Stage", order = 51)]

public class SO_StageData : ScriptableObject
{
    public int id;
    public string nameStage;
    public int totalBoxes;
    public Sprite thumnielStage;
    public SceneAsset sceneStage;
    

}
