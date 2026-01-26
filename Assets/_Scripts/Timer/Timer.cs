using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    public event Action<float> ElapsedTimeChanged;

    private float _timerValue;
    private float _elapsedTime;
    private float _cachedElapsedTime = 0f;

    private MonoBehaviour _coroutineRunner;

    private Coroutine _process;

    public Timer(MonoBehaviour coroutineRunner, float timerValue)
    {
        _coroutineRunner = coroutineRunner;
        _timerValue = timerValue;
    }

    public float TimerValue => _timerValue;

    public void Start()
    {
        if (_process == null)
            _process = _coroutineRunner.StartCoroutine(Process());   
    }

    public void Pause()
    {
        _cachedElapsedTime = _elapsedTime;

        ElapsedTimeChanged?.Invoke(_cachedElapsedTime);
        StopAndClearProcess();
    }

    public void Stop()
    {
        _elapsedTime = TimerValue;
        _cachedElapsedTime = 0f;

        ElapsedTimeChanged?.Invoke(_elapsedTime);
        StopAndClearProcess();
    }

    private void StopAndClearProcess()
    {
        if (_process != null)
        {
            _coroutineRunner.StopCoroutine(_process);
            _process = null;
        }
    }

    private IEnumerator Process()
    {
        if (_cachedElapsedTime == 0f)
        {
            _elapsedTime = TimerValue;
        }
        else
        {
            _elapsedTime = _cachedElapsedTime;
            _cachedElapsedTime = 0f;
        }

        while (_elapsedTime > 0)
        {
            _elapsedTime -= Time.deltaTime;
            ElapsedTimeChanged?.Invoke(_elapsedTime);

            if (_elapsedTime < 0)
                _elapsedTime = 0;

            yield return null;
        }

        _process = null;
    }
}
