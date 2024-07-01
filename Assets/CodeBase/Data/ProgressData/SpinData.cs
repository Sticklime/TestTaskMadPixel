using System;

namespace Data.ProgressData
{
    public class SpinData
    {
        public int CountSpin;
        public int MaxCountSpin;

        public Action IsChanged;

        public SpinData(int countSpin, int maxCountSpin)
        {
            CountSpin = countSpin;
            MaxCountSpin = maxCountSpin;
        }
    }
}