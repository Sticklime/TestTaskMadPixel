using UnityEngine;
using UnityEngine.UI;

public class StarView : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Color _colorOn;
    [SerializeField] private Color _colorOff;

    public void OffStar() => 
        _image.color = _colorOff;

    public void OnStar() => 
        _image.color = _colorOn;
}