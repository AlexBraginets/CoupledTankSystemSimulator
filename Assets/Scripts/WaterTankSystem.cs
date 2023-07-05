using UnityEngine;

public class WaterTankSystem : MonoBehaviour
{
    [SerializeField] private WaterTank _leftWaterTank;
    [SerializeField] private WaterTank _rightWaterTank;
    [SerializeField] private ConnectionPipe _connectionPipe;
    [SerializeField] private Valve _valve;
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
        float transferVolume = GetWaterFlowRate() * Time.deltaTime;
        if (_leftWaterTank.WaterLevel > _rightWaterTank.WaterLevel)
        {
            TransferWaterClamped(_leftWaterTank, _rightWaterTank, transferVolume);
        }
        else if(_rightWaterTank.WaterLevel > _leftWaterTank.WaterLevel)
        {
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

    private float GetWaterFlowRate()
    {
        return _connectionPipe.WaterFlowRate;
    }
}