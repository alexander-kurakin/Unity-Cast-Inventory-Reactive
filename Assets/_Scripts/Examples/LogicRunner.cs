using System.Collections.Generic;
using UnityEngine;

public class LogicRunner : MonoBehaviour
{
    [SerializeField] private WalletView _walletView;
    [SerializeField] private TimerView _timerView;
    [SerializeField] private List<CurrencyType> _configuredCurrency;
    [SerializeField] private int _walletMaxValue = 9999;
    [SerializeField] private float _defaultTimerValue = 10f;

    private Wallet _wallet;
    private Timer _timer;
    
    private void Awake()
    {
        _wallet = new Wallet(_walletMaxValue, _configuredCurrency);
        _walletView.InitWallet(_wallet, _configuredCurrency);

        _timer = new Timer(this, _defaultTimerValue);
        _timerView.InitTimer(_timer);
    }
}