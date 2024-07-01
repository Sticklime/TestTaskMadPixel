using System;
using Data.ProgressData;
using DefaultNamespace;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class SpinWheel : MonoBehaviour
{
    [SerializeField] private RectTransform _wheelTransform;
    [SerializeField] private WinReward _winReward;
    [SerializeField] private int _countSpinToTarget = 3;

    private IProgressProvider _progressProvider;
    private IConfigProvider _configProvider;

    public void Construct(IConfigProvider configProvider, IProgressProvider progressProvider)
    {
        _configProvider = configProvider;
        _progressProvider = progressProvider;
    }

    public Tween StartSpinning()
    {
        SpinData spinData = _progressProvider.PlayerProgress.SpinData;
        WheelFortuneConfig wheelData = _configProvider.GetWheelData();

        if (IsCanSpin())
            spinData.CountSpin--;

        int randomIndex = Random.Range(0, wheelData.Items.Count);
        _winReward.GetReward(randomIndex);

        float targetRotation = GetTargetPosition(randomIndex, wheelData);

        spinData.IsChanged?.Invoke();
        return SpinningAnimation(targetRotation);
    }

    public bool IsCanSpin() =>
        _progressProvider.PlayerProgress.SpinData.CountSpin > 0;

    private float GetTargetPosition(int randomIndex, WheelFortuneConfig wheelData)
    {
        float totalRotation = 360 * _countSpinToTarget - 90;
        float anglePerItem = 360 / wheelData.Items.Count;

        float finalRotation = randomIndex * anglePerItem + anglePerItem * 0.5f;
        float targetRotation = totalRotation + finalRotation;

        return targetRotation;
    }

    private Tween SpinningAnimation(float targetRotation) =>
        _wheelTransform
            .DORotate(new Vector3(0, 0, -targetRotation), 5f, RotateMode.FastBeyond360)
            .SetEase(Ease.OutQuad);
}