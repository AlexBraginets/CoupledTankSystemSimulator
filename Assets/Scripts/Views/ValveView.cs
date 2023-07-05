using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class ValveView : MonoBehaviour
    {
        [SerializeField] private Valve _valve;
        [SerializeField] private Button _openValveButton;
        [SerializeField] private Button _closeValveButton;

        private void Start()
        {
            _openValveButton.onClick.AddListener(_valve.Open);
            _closeValveButton.onClick.AddListener(_valve.Close);
        }
    }
}
