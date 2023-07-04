using UnityEngine;

namespace Views
{
    public class ConnectionPipeView : MonoBehaviour
    {
        [SerializeField] private Valve _valve;
        [SerializeField] private Material _onValveOpenMaterial;
        [SerializeField] private Material _onValveClosedMaterial;
        [SerializeField] private MeshRenderer _visual;

        private void Start()
        {
            _valve.OnOpen += OnValveOpen;
            _valve.OnClose += OnValveClose;
        }

        private void OnValveOpen()
        {
            _visual.material = _onValveOpenMaterial;
        }private void OnValveClose()
        {
            _visual.material = _onValveClosedMaterial;
        }

       
    }
}
