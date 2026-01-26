using UnityEngine;
using UnityEngine.UI;

public class TimerRowSlider : TimerRowBase
{
    [SerializeField] private Slider _timerSlider;

    protected override void AfterInit(Timer timer)
    {
        _timerSlider.maxValue = _timer.TimerValue;
        _timerSlider.value = _timerSlider.maxValue;
    }

    protected override void OnElapsedTimeChanged(float oldElapsedTime, float newElapsedTime)
    {
        _timerSlider.value = newElapsedTime;
    }
}
