public class GoldStatsView : StatsView
{
    protected override void RefreshData() =>
        _valueText.text = _progressProvider.PlayerProgress.PlayerStats.GoldCount.ToString();
}