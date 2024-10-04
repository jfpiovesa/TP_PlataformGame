using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusCharacterBase : MonoBehaviour
{

    public bool isAlive = true;
    private int healthCurrent { get; set; }
    private int healthMax { get; set; }
    public int Health => healthCurrent;

    public void SetHealthMax(int value)
    {
        healthMax = value;
        healthCurrent = healthMax;
    }
    public void AddHealth(int value)
    {
        healthCurrent = Mathf.Clamp(healthCurrent + value, 0, healthMax);
    }

    public void RemoveHealth(int value)
    {
        healthCurrent = Mathf.Clamp(healthCurrent - value, 0, healthMax);
        St_StageAction.LifeCharacteUpdate(healthCurrent);
        if (healthCurrent.Equals(0))
        {
            Did();
        }
    }
    public virtual void Did()
    {
        isAlive = false;
        St_StageAction.DidAction?.Invoke();
    }
}
