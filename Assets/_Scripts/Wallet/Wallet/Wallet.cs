using System;
using System.Collections.Generic;
using UnityEngine;

public class Wallet
{
    private Dictionary<CurrencyType, ReactiveVariable<int>> _currencyData;

    public Wallet(int maxValue, List<CurrencyType> currencyData)
    {
        if (maxValue < 0)
        {
            Debug.LogError(nameof(maxValue));
            return;
        }

        MaxValue = maxValue;

        _currencyData = new Dictionary<CurrencyType, ReactiveVariable<int>>();

        foreach (CurrencyType type in currencyData)
            _currencyData[type] = new ReactiveVariable<int>();
    }

    public int MaxValue { get; private set; }
    public ReactiveVariable<int> GetCurrency(CurrencyType type) => _currencyData[type];

    public bool WillExceedMaxValue(CurrencyType type, int value) => _currencyData[type].Value + value > MaxValue;
    public bool WillGoBelowZero(CurrencyType type, int value) => _currencyData[type].Value - value <= 0;

    public void Add(CurrencyType type, int value)
    {
        if (value < 0)
        {
            Debug.LogError(nameof(value));
            return;
        }

        if (WillExceedMaxValue(type, value))
        {
            _currencyData[type].Value = MaxValue;
            return;
        }

        _currencyData[type].Value += value;
    }

    public void Remove(CurrencyType type, int value)
    {
        if (value < 0)
        {
            Debug.LogError(nameof(value));
            return;
        }

        if (WillGoBelowZero(type, value))
        {
            _currencyData[type].Value = 0;
            return;
        }

        _currencyData[type].Value -= value;
    }
}