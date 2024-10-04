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
        filePathCurrenty = Path.Combine(Application.dataPath, filePath);
        LoadGame();
    }

    public void SaveGame()
    {
        string json = JsonUtility.ToJson(gameState, true);

        if (File.Exists(filePathCurrenty))
        {
            File.WriteAllText(filePathCurrenty, json);
        }
        else
        {
            File.CreateText(filePathCurrenty);
        }

        if (ApplicationManager.Instance.debugInfos)
        {
            Debug.Log("Jogo salvo em: " + filePathCurrenty);

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
