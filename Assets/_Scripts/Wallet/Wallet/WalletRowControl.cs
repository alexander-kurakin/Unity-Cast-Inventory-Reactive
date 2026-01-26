using UnityEngine;
using UnityEngine.UI;

public class WalletRowControl : MonoBehaviour
{
    [SerializeField] private Button _addButton;
    [SerializeField] private Button _removeButton;

    private int _currencyIncrement;
    private int _currencyDecrement;
    private Wallet _wallet;
    private CurrencyType _currencyType;

    private void OnDestroy()
    {
        _addButton.onClick.RemoveListener(OnAddClick);
        _removeButton.onClick.RemoveListener(OnRemoveClick);
    }

    public void InitRow(
    int currencyIncrement,
    int currencyDecrement,
    Wallet wallet,
    CurrencyType currencyType)
    {
        _currencyType = currencyType;
        _wallet = wallet;

        _currencyIncrement = currencyIncrement;
        _currencyDecrement = currencyDecrement;

        _addButton.onClick.AddListener(OnAddClick);
        _removeButton.onClick.AddListener(OnRemoveClick);
    }

    private void OnRemoveClick()
    {
        _wallet.Remove(_currencyType, _currencyDecrement);
    }

    private void OnAddClick()
    {
        _wallet.Add(_currencyType, _currencyIncrement);
    }
    
}
