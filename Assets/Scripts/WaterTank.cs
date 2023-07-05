using System;
using UnityEngine;

public class WaterTank : MonoBehaviour
{
    public const float MAX_WATER_LEVEL = 6f;
    [field: SerializeField] public float WaterLevel { get; private set; }
    [SerializeField] private float _radius;
    public float SectionArea => Mathf.PI * _radius * _radius;
    public float Volume => SectionArea * WaterLevel;
    public float WaterLevelNormalized => WaterLevel / MAX_WATER_LEVEL;
    public event Action<float> OnWaterLevelChangedNormalized;

    private void SetWaterLevelNormalized(float waterLevelNormalized)
    {
        var waterLevel = waterLevelNormalized * MAX_WATER_LEVEL;
        SetWaterLevel(waterLevel);
    }

    public void SetWaterLevelClamp(float waterLevel)
    {
        waterLevel = Mathf.Clamp(waterLevel, 0, MAX_WATER_LEVEL);
        SetWaterLevel(waterLevel);
    }
    public void SetWaterLevel(float waterLevel)
    {
        WaterLevel = waterLevel;
        OnWaterLevelChangedNormalized?.Invoke(WaterLevelNormalized);
    }

    public void AddVolume(float volume)
    {
        var dh = volume / SectionArea;
        SetWaterLevel(WaterLevel + dh);
    }
}