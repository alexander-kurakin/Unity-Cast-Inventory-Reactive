using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WalletRowView : MonoBehaviour
{
    [SerializeField] private Image _iconImage;
    [SerializeField] private TMP_Text _text;

    private IReadOnlyReactiveVariable<int> _reactiveNumberToShow;
 
    public void InitRow(
    Sprite spriteToSet,
    IReadOnlyReactiveVariable<int> reactiveNumberToShow)
    {
        _iconImage.sprite = spriteToSet;
        _reactiveNumberToShow = reactiveNumberToShow;
        _text.text = _reactiveNumberToShow.Value.ToString();

        _reactiveNumberToShow.Changed += OnReactiveNumberChanged;

        //_reactiveNumberToShow.Value = 9999; cannot do, readonly variable

    }

    private void OnDestroy()
    {
        _reactiveNumberToShow.Changed -= OnReactiveNumberChanged;
    }

    private void OnReactiveNumberChanged(int oldValue, int newValue)
    {
        _text.text = newValue.ToString();
    }
}
