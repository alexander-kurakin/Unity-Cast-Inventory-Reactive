using UnityEngine;

public abstract class TimerRowBase : MonoBehaviour
{
    protected Timer _timer;

    public void Init(Timer timer)
    {
        _timer = timer;
        _timer.ElapsedTimeChanged += OnElapsedTimeChanged;
        AfterInit(timer);
    }

    protected abstract void AfterInit(Timer timer);

    protected abstract void OnElapsedTimeChanged(float elapsedTime);

    protected virtual void OnDestroy()
    {
        _timer.ElapsedTimeChanged -= OnElapsedTimeChanged;
    }
}
