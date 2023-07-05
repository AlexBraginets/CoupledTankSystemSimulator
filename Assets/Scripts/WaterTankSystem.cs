using UnityEngine;

public class WaterTankSystem : MonoBehaviour
{
    [SerializeField] private WaterTank _leftWaterTank;
    [SerializeField] private WaterTank _rightWaterTank;
    [SerializeField] private ConnectionPipe _connectionPipe;
    [SerializeField] private Valve _valve;
    [SerializeField] private WaterFlowRateProvider _waterFlowRateProvider;
    private bool _isTanksConnected;

    private void Start()
    {
        _valve.OnOpen += OnValveOpen;
        _valve.OnClose += OnValveClose;
    }

    private void OnValveClose()
    {
        _isTanksConnected = false;
    }

    private void OnValveOpen()
    {
        _isTanksConnected = true;
    }

    private void Update()
    {
        if (!_isTanksConnected) return;
        float pipeLevel = _connectionPipe.Level;
        float maxTankLevel = Mathf.Max(_leftWaterTank.WaterLevel, _rightWaterTank.WaterLevel);
        if (pipeLevel >= maxTankLevel) return;
        float transferVolume = GetWaterFlowRate() * Time.deltaTime;
        if (_leftWaterTank.WaterLevel > _rightWaterTank.WaterLevel)
        {
            transferVolume = Mathf.Min(GetVolumeTillPipe(_leftWaterTank), transferVolume);
            TransferWaterClamped(_leftWaterTank, _rightWaterTank, transferVolume);
        }
        else if (_rightWaterTank.WaterLevel > _leftWaterTank.WaterLevel)
        {
            transferVolume = Mathf.Min(GetVolumeTillPipe(_rightWaterTank), transferVolume);
            TransferWaterClamped(_rightWaterTank, _leftWaterTank, transferVolume);
        }
    }

    private void TransferWaterClamped(WaterTank fromTank, WaterTank toTank, float volume)
    {
        var fromWaterVolume = fromTank.Volume;
        var toWaterVolume = toTank.Volume;
        var maxTransferVolume = (fromWaterVolume - toWaterVolume) / 2f;
        var clampedTransferVolume = Mathf.Min(volume, maxTransferVolume);
        // transfer water
        fromTank.AddVolume(-clampedTransferVolume);
        toTank.AddVolume(clampedTransferVolume);
    }

    private float GetVolumeTillPipe(WaterTank tank)
    {
        float tankLevel = tank.WaterLevel;
        float pipeLevel = _connectionPipe.Level;
        float dLevel = tankLevel - pipeLevel;
        float area = tank.SectionArea;
        return dLevel * area;
    }

    private float GetWaterFlowRate()
    {
        return _waterFlowRateProvider.GetWaterFlowRate();
    }
}