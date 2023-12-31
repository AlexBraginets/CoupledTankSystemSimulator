using UnityEngine;

public class WaterTankSupplier : MonoBehaviour
{
    [SerializeField] private WaterTank _waterTank;
    [SerializeField] private float _waterSupplyLevelRate;
    private bool _isOperating;
    private float _currentSupplyLevelRate;

    public void StartSupplying()
    {
        _currentSupplyLevelRate = _waterSupplyLevelRate;
        _isOperating = true;
    }

    public void StartDraining()
    {
        _currentSupplyLevelRate = -_waterSupplyLevelRate;
        _isOperating = true;
    }

    public void StopOperating()
    {
        _isOperating = false;
    }

    private void Update()
    {
        if (!_isOperating) return;
        float waterLevel = _waterTank.WaterLevel;
        waterLevel += _currentSupplyLevelRate * Time.deltaTime;
        _waterTank.SetWaterLevelClamp(waterLevel);
    }
}