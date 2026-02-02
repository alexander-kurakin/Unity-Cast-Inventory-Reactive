using UnityEngine;

public abstract class TimerRowBase : MonoBehaviour
{
    protected Timer _timer;

    public void Init(Timer timer)
    {
        _timer = timer;
        _timer.GetElapsedTime.Changed += OnElapsedTimeChanged;
        AfterInit(timer);

        //_timer.GetElapsedTime = 0f; cannot do, readonly
    }

    protected abstract void AfterInit(Timer timer);

    protected abstract void OnElapsedTimeChanged(float oldElapsedTime, float newElapsedTime);

    protected virtual void OnDestroy()
    {
        _timer.GetElapsedTime.Changed -= OnElapsedTimeChanged;
    }
}
