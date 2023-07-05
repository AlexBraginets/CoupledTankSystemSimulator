using UnityEngine;

public class WaterFlowRateProvider : MonoBehaviour
{
   [SerializeField] private WaterTank _leftTank;
   [SerializeField] private WaterTank _rightTank;
   [SerializeField] private ConnectionPipe _connectionPipe;

   public float GetWaterFlowRate()
   {
      return _connectionPipe.WaterFlowRate;
   }
}
