public class GemsStatsView : StatsView
{
    protected override void RefreshData() => 
        _valueText.text = _progressProvider.PlayerProgress.PlayerStats.GemsCount.ToString();
}