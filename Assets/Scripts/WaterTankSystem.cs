using UnityEngine;

public class WaterTankSystem : MonoBehaviour
{
    [SerializeField] private WaterTank _leftWaterTank;
    [SerializeField] private WaterTank _rightWaterTank;
    [SerializeField] private ConnectionPipe _connectionPipe;
    [SerializeField] private Valve _valve;

    private void Start()
    {
        _valve.OnOpen += OnValveOpen;
        _valve.OnClose += OnValveClose;
    }

    private void OnValveClose()
    {
        
    }

    private void OnValveOpen()
    {
        
    }
}