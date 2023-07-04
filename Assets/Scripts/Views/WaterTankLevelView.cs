using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class WaterTankLevelView : MonoBehaviour
    {
        [SerializeField] private WaterTank _waterTank;
        [SerializeField] private Image _waterLevelFillBar;
        private void Start()
        {
            _waterTank.OnWaterLevelChangedNormalized += OnWaterLevelChangedNormalized;
        }

        private void OnWaterLevelChangedNormalized(float waterLevelNormalized)
        {
            _waterLevelFillBar.fillAmount = waterLevelNormalized;
        }
    }
}
