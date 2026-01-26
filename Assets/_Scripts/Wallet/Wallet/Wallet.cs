using System;
using System.Collections.Generic;
using UnityEngine;

public class Wallet
{
    public event Action<CurrencyType, int> Changed;

    private Dictionary<CurrencyType, int> _currencyData;

    public Wallet(int maxValue, Dictionary<CurrencyType, int> currencyData)
    {
        if (maxValue < 0)
        {
            Debug.LogError(nameof(maxValue));
            return;
        }

        MaxValue = maxValue;

        _currencyData = new Dictionary<CurrencyType, int>(currencyData);
    }

    public int MaxValue { get; private set; }

    public bool IsEnoughCapacity(CurrencyType type, int value) => _currencyData[type] + value <= MaxValue;
    public bool IsWalletEmpty(CurrencyType type, int value) => _currencyData[type] - value <= 0;

    public void Add(CurrencyType type, int value) 
    {
        if (value < 0)
        {
            Debug.LogError(nameof(value));
            return;
        }

        if (IsEnoughCapacity(type, value) == false)
        {
            if (_currencyData[type] != MaxValue)
            {
                _currencyData[type] = MaxValue;
                Changed?.Invoke(type, _currencyData[type]);
            }

            return;
        }

        _currencyData[type] += value;
        Changed?.Invoke(type, _currencyData[type]);
    }

    public void Remove(CurrencyType type, int value)
    {
        if (value < 0)
        {
            Debug.LogError(nameof(value));
            return;
        }

        if (IsWalletEmpty(type, value) ) 
        {
            if (_currencyData[type] != 0)
            {
                _currencyData[type] = 0;
                Changed?.Invoke(type, _currencyData[type]);
            }

            return;
        }

        _currencyData[type] -= value;
        Changed?.Invoke(type, _currencyData[type]);
    }
}