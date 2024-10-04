using System;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] private Srl_GameState gameState = new Srl_GameState();
    [SerializeField] private string filePathCurrenty;
    [SerializeField] private string filePath = "MyGame/Resources/gameState.json";

    public Srl_GameState GameState => gameState;

    public void Inialization()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (!UnityEngine.Android.Permission.HasUserAuthorizedPermission(UnityEngine.Android.Permission.ExternalStorageWrite))
            {
                UnityEngine.Android.Permission.RequestUserPermission(UnityEngine.Android.Permission.ExternalStorageWrite);
            }
        }

        filePathCurrenty = Path.Combine(Application.dataPath, filePath);
        LoadGame();
    }

    public void SaveGame()
    {
        string json = JsonUtility.ToJson(gameState);
        try
        {

            if (File.Exists(filePathCurrenty))
            {
                File.WriteAllText(filePathCurrenty, json);
            }
            else
            {
                using (StreamWriter writer = File.CreateText(filePathCurrenty))
                {
                    writer.Write(json);
                }
            }
            if (ApplicationManager.Instance.debugInfos)
            {
                Debug.Log("Jogo salvo em: " + filePathCurrenty);

            }
        }
        catch (Exception e)
        {
            Debug.LogError("Erro ao salvar o arquivo: " + e.Message);
        }
    }

    public void LoadGame()
    {
        if (File.Exists(filePathCurrenty))
        {
            string json = File.ReadAllText(filePathCurrenty);
            gameState = JsonUtility.FromJson<Srl_GameState>(json);

            if (ApplicationManager.Instance.debugInfos)
            {
                Debug.Log("Jogo carregado: " + json);
            }
        }
        else
        {
            SaveGame();
        }
    }
}
