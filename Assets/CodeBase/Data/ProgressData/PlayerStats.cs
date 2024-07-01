using System;

namespace Data.ProgressData
{
    public class PlayerStats
    {
        public int GoldCount;
        public int GemsCount;

        public Action IsChanged;

        public PlayerStats(int goldCount, int gemsCount)
        {
            GoldCount = goldCount;
            GemsCount = gemsCount;
        }
    }
}