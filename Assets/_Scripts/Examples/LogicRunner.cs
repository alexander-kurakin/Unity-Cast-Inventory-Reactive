using System.Collections.Generic;
using UnityEngine;

public class LogicRunner : MonoBehaviour
{
    [SerializeField] private WalletView _walletView;
    [SerializeField] private TimerView _timerView;

    [SerializeField] private int _walletMaxValue = 9999;
    [SerializeField] private int _walletStartingValue = 0;
    [SerializeField] private float _defaultTimerValue = 10f;
 
    private Wallet _wallet;
    private Timer _timer;
    private Dictionary<CurrencyType, int> _configuredCurrency;

    private void Awake()
    {
        _configuredCurrency = new Dictionary<CurrencyType, int>()
        {
            {CurrencyType.Meat, _walletStartingValue },
            {CurrencyType.Money, _walletStartingValue},
            {CurrencyType.Alcohol, _walletStartingValue },
        };

        _wallet = new Wallet(_walletMaxValue, _configuredCurrency);
        _walletView.InitWallet(_wallet, _configuredCurrency, _walletStartingValue);

        _timer = new Timer(this, _defaultTimerValue);
        _timerView.InitTimer(_timer);
    }
}