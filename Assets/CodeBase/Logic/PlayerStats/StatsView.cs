using TMPro;
using UnityEngine;

public abstract class StatsView : MonoBehaviour
{
    [SerializeField] protected TMP_Text _valueText;

    protected IProgressProvider _progressProvider;

    public void Construct(IProgressProvider progressProvider)
    {
        _progressProvider = progressProvider;
    }

    private void Start()
    {
        _progressProvider.PlayerProgress.PlayerStats.IsChanged += RefreshData;
        RefreshData();
    }

    private void OnDisable() =>
        _progressProvider.PlayerProgress.PlayerStats.IsChanged -= RefreshData;

    protected virtual void RefreshData()
    {
    }
}