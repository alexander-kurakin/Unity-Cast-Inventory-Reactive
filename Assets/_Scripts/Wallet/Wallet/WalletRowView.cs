using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WalletRowView : MonoBehaviour
{
    [SerializeField] private Image _iconImage;
    [SerializeField] private TMP_Text _currencyText;

    private Wallet _wallet;
    private CurrencyType _currencyType;

    public void InitRow(
    Sprite spriteToSet,
    int valueToSet,
    Wallet wallet,
    CurrencyType currencyType)
    {
        _iconImage.sprite = spriteToSet;
        _currencyText.text = valueToSet.ToString();

        _currencyType = currencyType;
        _wallet = wallet;

        _wallet.Changed += OnChanged;

    }

    private void OnDestroy()
    {
        _wallet.Changed -= OnChanged;
    }

    private void OnChanged(CurrencyType currencyTypeOnChanged, int valueToSet)
    {
        if (currencyTypeOnChanged == _currencyType)
            _currencyText.text = valueToSet.ToString();
    }
}
