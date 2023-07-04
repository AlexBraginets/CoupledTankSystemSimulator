using System;
using UnityEngine;

public class WaterTank : MonoBehaviour
{
    public const float MAX_WATER_LEVEL = 1f;
    public float WaterLevel { get; private set; }
    public float WaterLevelNormalized => WaterLevel / MAX_WATER_LEVEL;
    public event Action<float> OnWaterLevelChangedNormalized;

    public void SetWaterLevelNormalized(float waterLevelNormalized)
    {
        var waterLevel = waterLevelNormalized * MAX_WATER_LEVEL;
        WaterLevel = waterLevel;
        OnWaterLevelChangedNormalized?.Invoke(waterLevelNormalized);
    }

}
