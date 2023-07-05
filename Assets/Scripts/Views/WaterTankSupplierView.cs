using UnityEngine;
using Views.Common;

namespace Views
{
    public class WaterTankSupplierView : MonoBehaviour
    {
        [SerializeField] private WaterTankSupplier _supplier;
        [SerializeField] private HeldButton _levelUpButton;
        [SerializeField] private HeldButton _levelDownButton;
        private void Start()
        {
            _levelUpButton.OnButtonDown += _supplier.StartSupplying;
            _levelUpButton.OnButtonUp += _supplier.StopSupplying;
            
            _levelDownButton.OnButtonDown += _supplier.StartDraining;
            _levelDownButton.OnButtonUp += _supplier.StopDraining;
        }
    }
}
