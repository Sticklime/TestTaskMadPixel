using TMPro;

namespace Data.ProgressData
{
    public class PlayerProgress
    {
        public PlayerStats PlayerStats;
        public SpinData SpinData;

        public PlayerProgress(PlayerStats playerStats, SpinData spinData)
        {
            PlayerStats = playerStats;
            SpinData = spinData;
        }
    }
}