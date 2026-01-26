using System.Collections.Generic;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private List<CurrencyConfigEntry> _currencyConfigs;
    [SerializeField] private WalletRowView _walletRowViewPrefab;
    [SerializeField] private Transform _UIObjectsParent;

    private Wallet _wallet;
    private Dictionary<CurrencyType, int> _configuredCurrency;
    private Dictionary<CurrencyType, CurrencyConfig> _currencyConfigsByType;

    private int _walletStartingValue;

    public void InitWallet(Wallet wallet, Dictionary<CurrencyType, int> configuredCurrency, int walletStartingValue)
    {
        _currencyConfigsByType = new Dictionary<CurrencyType, CurrencyConfig>();

        foreach (CurrencyConfigEntry currencyConfigEntry in _currencyConfigs)
            _currencyConfigsByType[currencyConfigEntry.type] = currencyConfigEntry.config;

        _wallet = wallet;
        _configuredCurrency = new Dictionary<CurrencyType, int>(configuredCurrency);
        _walletStartingValue = walletStartingValue;

        SpawnUI();
    }

    private void SpawnUI()
    {
        foreach (KeyValuePair<CurrencyType, int> currencyData in _configuredCurrency)
        {
            WalletRowView _walletRowView = Instantiate(_walletRowViewPrefab, _UIObjectsParent);

            if (_walletRowView.TryGetComponent<WalletRowControl>(out WalletRowControl _walletRowControl))
            {
                CurrencyConfig currencyConfig = _currencyConfigsByType[currencyData.Key];

                _walletRowView.InitRow(
                    currencyConfig.sprite,
                    _walletStartingValue,
                    _wallet,
                    currencyData.Key);

                _walletRowControl.InitRow(
                    currencyConfig.increment,
                    currencyConfig.decrement,
                    _wallet,
                    currencyData.Key);
            }
        }
    }
}
