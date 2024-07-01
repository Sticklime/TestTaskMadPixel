using DefaultNamespace;
using UnityEngine;

public class WinReward : MonoBehaviour
{
    private IProgressProvider _progressProvider;
    private IConfigProvider _configProvider;

    public void Construct(IProgressProvider progressProvider, IConfigProvider configProvider)
    {
        _progressProvider = progressProvider;
        _configProvider = configProvider;
    }

    public void GetReward(int itemIndex)
    {
        ItemConfigs itemConfigs = _configProvider.GetWheelData().Items[itemIndex];
        var playerStats = _progressProvider.PlayerProgress.PlayerStats;

        switch (itemConfigs.ItemType)
        {
            case ItemType.Gold:
                playerStats.GoldCount += itemConfigs.RewardValue;
                break;
            case ItemType.Gems:
                playerStats.GemsCount += itemConfigs.RewardValue;
                break;
        }
    }
}