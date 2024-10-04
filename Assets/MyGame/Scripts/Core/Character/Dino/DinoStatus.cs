using UnityEngine;

public class DinoStatus : StatusCharacterBase
{
    [Header("Health Settings  ")]
    [SerializeField] private int healtMaxSet = 3;

    private void Awake()
    {
        SetHealthMax(healtMaxSet);
    }
    public override void Did()
    {
        base.Did();

    }
}
