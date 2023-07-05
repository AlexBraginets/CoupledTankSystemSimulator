using UnityEngine;

public class ConnectionPipeLift : MonoBehaviour
{
    [SerializeField] private Transform _pipe;
    [SerializeField] private Vector2 _yLocalLimits;
    [SerializeField] private float _liftRate;
    private float _currentLiftRate;
    private bool _isOperating;

    public void StartLiftingUp()
    {
        _currentLiftRate = _liftRate;
        _isOperating = true;
    }

    public void StopOperating()
    {
        _isOperating = false;
    }

    public void StartLiftingDown()
    {
        _currentLiftRate = -_liftRate;
        _isOperating = true;
    }

    private void Update()
    {
        if (!_isOperating) return;
        Vector3 pipeLocalPosition = _pipe.localPosition;
        float y = pipeLocalPosition.y;
        y += _currentLiftRate * Time.deltaTime;
        y = Mathf.Clamp(y, _yLocalLimits.x, _yLocalLimits.y);
        pipeLocalPosition.y = y;
        _pipe.localPosition = pipeLocalPosition;
    }
}