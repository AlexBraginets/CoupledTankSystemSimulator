using TMPro;
using UnityEngine;
using Utils;

namespace Views
{
    public class WaterTankPercentageLevelView : MonoBehaviour
    {
        [SerializeField] private WaterTank _waterTank;
        [SerializeField] private int _precisionDigits;
        [SerializeField] private GameObject _view;
        [SerializeField] private TMP_Text _percentageLabel;
        [SerializeField] private OnMouseDownAction _onMouseDownAction;
        private void Start()
        {
            _onMouseDownAction.Callback += Toggle;
            _waterTank.OnWaterLevelChangedNormalized += UpdateLabel;
            UpdateLabel(_waterTank.WaterLevelNormalized);
        }

        public void Show()
        {
            _view.SetActive(true);
        }

        public void Hide()
        {
            _view.SetActive(false);
        }

        public void Toggle()
        {
            _view.SetActive(!_view.activeSelf);
        }

        private void UpdateLabel(float waterLevelNormalized)
        {
            _percentageLabel.text = GetPercentage();
        }
        private string GetPercentage()
        {
            float waterLevelNormalized = _waterTank.WaterLevelNormalized;
            float percentage = waterLevelNormalized * 100f;

            return percentage.ToString($"N{_precisionDigits}") + "%";
        }
    }
}
