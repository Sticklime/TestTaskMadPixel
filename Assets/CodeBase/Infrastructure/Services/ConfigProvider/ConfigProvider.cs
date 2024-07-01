using DefaultNamespace;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.ConfigProvider
{
    public class ConfigProvider : IConfigProvider
    {
        private WheelFortuneConfig _wheelFortuneConfig;

        public void Load()
        {
            _wheelFortuneConfig = Resources.Load<WheelFortuneConfig>(PathProvider.WheelConfigPath);
        }

        public WheelFortuneConfig GetWheelData() =>
            _wheelFortuneConfig;
    }
}