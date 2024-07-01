using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WheelContentView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _textValue;

    public void Refresh(Sprite icon, int value)
    {
        _icon.sprite = icon;
        _textValue.text = value.ToString();
    }
}