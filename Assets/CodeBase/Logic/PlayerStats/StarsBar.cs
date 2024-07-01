using System.Collections.Generic;
using Data.ProgressData;
using UnityEngine;

public class StarsBar : MonoBehaviour
{
    [SerializeField] private List<StarView> _starViews;

    private IProgressProvider _progressProvider;

    public void Construct(IProgressProvider progressProvider)
    {
        _progressProvider = progressProvider;
    }

    private void Start()
    {
        _progressProvider.PlayerProgress.SpinData.IsChanged += RefreshStars;
    }

    private void OnDestroy()
    {
        _progressProvider.PlayerProgress.SpinData.IsChanged -= RefreshStars;
    }

    private void RefreshStars()
    {
        SpinData spinData = _progressProvider.PlayerProgress.SpinData;

        foreach (StarView starView in _starViews)
            starView.OffStar();

        for (int i = 0; i < spinData.CountSpin; i++) 
            _starViews[i].OnStar();
    }
}