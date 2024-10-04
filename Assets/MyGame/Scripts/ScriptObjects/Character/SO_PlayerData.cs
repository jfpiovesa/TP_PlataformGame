using UnityEngine;


[CreateAssetMenu(fileName = "NewPlayerData", menuName = "Game Data / Player ", order = 51)]
public class SO_PlayerData : ScriptableObject
{
    public string playerName;
    public Sprite iconeCharacter;
    public GameObject prefabCharacter;

}
