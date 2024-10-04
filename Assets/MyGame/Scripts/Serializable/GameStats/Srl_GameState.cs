using System;
using System.Collections.Generic;

[Serializable]
public class Srl_GameState
{
    public string namePlayer = "Player 1";
    public List<Srl_StatusStage> StatusStages = new List<Srl_StatusStage>();
}
[Serializable]
public class Srl_StatusStage
{
    public string nameStage = string.Empty;
    public int idStage = 0;
    public float time = 0;
    public int boxes = 0;
    public int internshipAttempts = 0;
}
