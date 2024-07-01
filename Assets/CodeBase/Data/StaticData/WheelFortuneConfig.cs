using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "WheelFortuneConfig", fileName = "WheelFortune")]
    public class WheelFortuneConfig : ScriptableObject
    {
        [field: SerializeField] public List<ItemConfigs> Items { get; private set; }
    }
}