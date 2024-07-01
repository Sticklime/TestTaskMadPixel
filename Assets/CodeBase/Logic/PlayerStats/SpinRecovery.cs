using Data.ProgressData;
using UnityEngine;

public class SpinRecovery : MonoBehaviour
{
    [SerializeField] private float _cooldown;

    private float _currentCooldown;

    private IProgressProvider _progressProvider;

    public void Construct(IProgressProvider progressProvider)
    {
        _progressProvider = progressProvider;
    }

    private void Start()
    {
        _currentCooldown = _cooldown;
    }

    private void Update()
    {
        var spinData = _progressProvider.PlayerProgress.SpinData;

        if (IsMaxSpin(spinData))
        {
            _currentCooldown = _cooldown;
            return;
        }

        if (_currentCooldown > 0)
            _currentCooldown -= Time.deltaTime;
        else
        {
            _currentCooldown = _cooldown;
            AddSpin();
        }
    }

    private bool IsMaxSpin(SpinData spinData) =>
        spinData.CountSpin >= spinData.MaxCountSpin;

    private void AddSpin()
    {
        _progressProvider.PlayerProgress.SpinData.CountSpin++;
        _progressProvider.PlayerProgress.SpinData.IsChanged?.Invoke();
    }
}