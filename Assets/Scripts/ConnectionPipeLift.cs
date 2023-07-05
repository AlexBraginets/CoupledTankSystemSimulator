using System;
using UnityEngine;

public class ConnectionPipeLift : MonoBehaviour
{
    [SerializeField] private ConnectionPipe _connectionPipe;
    [SerializeField] private Vector2 _yLocalLimits;
    [SerializeField] private float _liftRate;
    private float _currentLiftRate;
    private bool _isOperating;
    private Transform PipeTransform => _connectionPipe.transform;

    private void Start()
    {
        SetLevel(_connectionPipe.Level);
    }

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
        float y = PipeTransform.localPosition.y;
        y += _currentLiftRate * Time.deltaTime;
        y = Mathf.Clamp(y, _yLocalLimits.x, _yLocalLimits.y);
       SetLevel(y);
    }

    private void SetLevel(float level)
    {
        Vector3 pipeLocalPosition = PipeTransform.localPosition;
        pipeLocalPosition.y = level;
        PipeTransform.localPosition = pipeLocalPosition;
        _connectionPipe.SetLevel(level);
    }
}