using System.Collections.Generic;
using UnityEngine;

public class TimerRowGrid : TimerRowBase
{
    [SerializeField] private Transform _timerGridParent;
    [SerializeField] private GridElement _timerGridElementPrefab;

    private List<GridElement> _gridElements = new();

    protected override void AfterInit(Timer timer)
    {
        SpawnGrid(_timer.TimerValue);
    }

    protected override void OnElapsedTimeChanged(float elapsedTime)
    {
        UpdateGrid(elapsedTime);
    }

    private void SpawnGrid(float timerValue)
    {
        int secondsCount = (int)timerValue;
        GridElement gridElement;

        for (int i = 0; i < secondsCount; i++)
        {
            gridElement = Instantiate(_timerGridElementPrefab, _timerGridParent);
            _gridElements.Add(gridElement);
        }
    }

    private void UpdateGrid(float elapsedTime)
    {
        int countOfSeconds = (int)elapsedTime;
        int tempCounter = 0;

        foreach (GridElement gridElement in _gridElements)
        {
            tempCounter++;

            if (tempCounter <= countOfSeconds)
                gridElement.gameObject.SetActive(true);
            else
                gridElement.gameObject.SetActive(false);
        }

    }
}
