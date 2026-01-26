using System;
using UnityEngine;

public class TimerView : MonoBehaviour
{
    [SerializeField] private TimerRowControl _timerRowPrefab;
    [SerializeField] private Transform _timerObjectsParent;

    private Timer _timer;

    public void InitTimer(Timer timer)
    {
        _timer = timer;
        SpawnUI();
    }

    private void SpawnUI()
    {
        TimerRowControl _timerRowControl = Instantiate(_timerRowPrefab, _timerObjectsParent);
        _timerRowControl.Init(_timer);

        if (_timerRowControl.TryGetComponent<TimerRowGrid>(out TimerRowGrid _timerRowGrid))
            _timerRowGrid.Init(_timer);

        if (_timerRowControl.TryGetComponent<TimerRowSlider>(out TimerRowSlider _timerRowSlider))
            _timerRowSlider.Init(_timer);
    }
}
