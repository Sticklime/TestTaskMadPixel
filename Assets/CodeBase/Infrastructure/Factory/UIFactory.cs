using System.Collections.Generic;
using System.Linq;
using CodeBase.Infrastructure;
using CodeBase.Logic.WheelFortune;
using UnityEngine;

public class UIFactory : IUIFactory
{
    private readonly IProgressProvider _progressProvider;
    private readonly IConfigProvider _configProvider;

    private SpinWheel _spinWheelPrefab;
    private GameObject _hudPrefab;

    public UIFactory(IProgressProvider progressProvider, IConfigProvider configProvider)
    {
        _progressProvider = progressProvider;
        _configProvider = configProvider;
    }

    public void Load()
    {
        _spinWheelPrefab = Resources.Load<SpinWheel>(PathProvider.WheelPrefabPath);
        _hudPrefab = Resources.Load<GameObject>(PathProvider.HudCanvas);
    }

    public SpinWheel CreateWheelFortune()
    {
        SpinWheel wheelFortune = Object.Instantiate(_spinWheelPrefab);

        WheelContent wheelContent = wheelFortune.GetComponentInChildren<WheelContent>();
        SpinButton spinButton = wheelFortune.GetComponentInChildren<SpinButton>();
        WinReward winReward = wheelFortune.GetComponent<WinReward>();

        wheelFortune.Construct(_configProvider, _progressProvider);
        winReward.Construct(_progressProvider, _configProvider);
        wheelContent.Construct(_configProvider);
        spinButton.Construct(_progressProvider);

        return wheelFortune;
    }

    public GameObject CreateHud()
    {
        GameObject hudInstance = Object.Instantiate(_hudPrefab);

        List<StatsView> stats = hudInstance.GetComponentsInChildren<StatsView>().ToList();
        SpinRecovery spinRecovery = hudInstance.GetComponentInChildren<SpinRecovery>();
        StarsBar starsBar = hudInstance.GetComponentInChildren<StarsBar>();

        starsBar.Construct(_progressProvider);
        spinRecovery.Construct(_progressProvider);

        foreach (var stat in stats)
            stat.Construct(_progressProvider);

        return hudInstance;
    }
}