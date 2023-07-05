using UnityEngine;
using Views.Common;

namespace Views
{
    public class ConnectionPipeLiftView : MonoBehaviour
    {
        [SerializeField] private ConnectionPipeLift _pipeLift;
        [SerializeField] private HeldButton _upButton;
        [SerializeField] private HeldButton _downButton;

        private void Start()
        {
            _upButton.OnButtonDown += _pipeLift.StartLiftingUp;
            _upButton.OnButtonUp += _pipeLift.StopOperating;
            
            _downButton.OnButtonDown += _pipeLift.StartLiftingDown;
            _downButton.OnButtonUp += _pipeLift.StopOperating;
        }
    }
}
