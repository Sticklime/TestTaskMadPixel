using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Logic.WheelFortune
{
    public class SpinButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private SpinWheel _spinWheel;

        private IProgressProvider _progressProvider;
        private bool _isEndAnimation = true;

        public void Construct(IProgressProvider progressProvider)
        {
            _progressProvider = progressProvider;
        }

        private void Start()
        {
            _button.onClick.AddListener(OnClickSpin);
            _progressProvider.PlayerProgress.SpinData.IsChanged += RefreshButtonState;
            RefreshButtonState();
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnClickSpin);
            _progressProvider.PlayerProgress.SpinData.IsChanged -= RefreshButtonState;
        }

        private void OnClickSpin()
        {
            _button.interactable = false;
            _isEndAnimation = false;

            _spinWheel.StartSpinning()
                .OnComplete(OnCompleteAnimation);
        }

        private void OnCompleteAnimation()
        {
            _isEndAnimation = true;
            RefreshButtonState();
            _progressProvider.PlayerProgress.PlayerStats.IsChanged?.Invoke();
        }

        private void RefreshButtonState() =>
            _button.interactable = _spinWheel.IsCanSpin() && _isEndAnimation;
    }
}