using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerRowControl : TimerRowBase
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _stopButton;
    [SerializeField] private TMP_Text _timerText;

    protected override void AfterInit(Timer timer)
    {
        _startButton.onClick.AddListener(OnStartClick);
        _pauseButton.onClick.AddListener(OnPauseClick);
        _stopButton.onClick.AddListener(OnStopClick);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        _startButton.onClick.RemoveListener(OnStartClick);
        _pauseButton.onClick.RemoveListener(OnPauseClick);
        _stopButton.onClick.RemoveListener(OnStopClick);
    }

    protected override void OnElapsedTimeChanged(float oldElapsedTime, float newElapsedTime)
    {
        _timerText.text = newElapsedTime.ToString("0.00");
    }

    private void OnStartClick()
    {
        _timer.Start();
    }

    private void OnPauseClick()
    {
        _timer.Pause();
    }

    private void OnStopClick()
    {
        _timer.Stop();
    }
}
