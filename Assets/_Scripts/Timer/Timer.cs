using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    private float _timerValue;
    private ReactiveVariable<float> _elapsedTime;
    private float _cachedElapsedTime = 0f;

    private MonoBehaviour _coroutineRunner;

    private Coroutine _process;

    public Timer(MonoBehaviour coroutineRunner, float timerValue)
    {
        _coroutineRunner = coroutineRunner;
        _timerValue = timerValue;

        _elapsedTime = new ReactiveVariable<float>(timerValue);
    }

    public float TimerValue => _timerValue;

    public void Start()
    {
        if (_process == null)
            _process = _coroutineRunner.StartCoroutine(Process());   
    }

    public void Pause()
    {
        _cachedElapsedTime = _elapsedTime.Value;

        StopAndClearProcess();
    }

    public void Stop()
    {
        _elapsedTime.Value = TimerValue;
        _cachedElapsedTime = 0f;

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

    private void SetElapsedTime(float value)
    {
        _elapsedTime.Value = Mathf.Max(0f, value);
    }

    public ReactiveVariable<float> GetElapsedTime => _elapsedTime;

    private IEnumerator Process()
    {
        if (_cachedElapsedTime == 0f)
        {
            _elapsedTime.Value = TimerValue;
        }
        else
        {
            _elapsedTime.Value = _cachedElapsedTime;
            _cachedElapsedTime = 0f;
        }

        while (_elapsedTime.Value > 0)
        {
            SetElapsedTime(_elapsedTime.Value - Time.deltaTime);

            yield return null;
        }

        _process = null;
    }
}
