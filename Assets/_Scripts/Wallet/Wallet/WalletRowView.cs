using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WalletRowView : MonoBehaviour
{
    [SerializeField] private Image _iconImage;
    [SerializeField] private TMP_Text _currencyText;

    private Wallet _wallet;
    private CurrencyType _currencyType;

    private ReactiveVariable<int> _currencyData;

    public void InitRow(
    Sprite spriteToSet,
    Wallet wallet,
    CurrencyType currencyType)
    {
        _iconImage.sprite = spriteToSet;
        _wallet = wallet;

        _currencyType = currencyType;
        _currencyData = _wallet.GetCurrency(currencyType);
        _currencyText.text = _currencyData.Value.ToString();

        _currencyData.Changed += OnCurrencyChanged;

    }

    private void OnDestroy()
    {
        _currencyData.Changed -= OnCurrencyChanged;
    }

    private void OnCurrencyChanged(int oldValue, int newValue)
    {
        _currencyText.text = newValue.ToString();
    }
}
