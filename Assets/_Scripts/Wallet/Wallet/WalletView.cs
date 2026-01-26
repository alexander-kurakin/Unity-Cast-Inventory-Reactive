using System.Collections.Generic;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private List<CurrencyConfigEntry> _currencyConfigs;
    [SerializeField] private WalletRowView _walletRowViewPrefab;
    [SerializeField] private Transform _UIObjectsParent;

    private Wallet _wallet;
    private List<CurrencyType> _configuredCurrency;
    private Dictionary<CurrencyType, CurrencyConfig> _currencyConfigsByType;

    public void InitWallet(Wallet wallet, List<CurrencyType> configuredCurrency)
    {
        _currencyConfigsByType = new Dictionary<CurrencyType, CurrencyConfig>();

        foreach (CurrencyConfigEntry currencyConfigEntry in _currencyConfigs)
            _currencyConfigsByType[currencyConfigEntry.type] = currencyConfigEntry.config;

        _wallet = wallet;
        _configuredCurrency = new List<CurrencyType>(configuredCurrency);

        SpawnUI();
    }

    private void SpawnUI()
    {
        foreach (CurrencyType type in _configuredCurrency)
        {
            WalletRowView _walletRowView = Instantiate(_walletRowViewPrefab, _UIObjectsParent);

            if (_walletRowView.TryGetComponent<WalletRowControl>(out WalletRowControl _walletRowControl))
            {
                CurrencyConfig currencyConfig = _currencyConfigsByType[type];

                _walletRowView.InitRow(
                    currencyConfig.sprite,
                    _wallet,
                    type);

                _walletRowControl.InitRow(
                    currencyConfig.increment,
                    currencyConfig.decrement,
                    _wallet,
                    type);
            }
        }
    }
}
