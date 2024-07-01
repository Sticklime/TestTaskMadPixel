using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "ItemConfig", fileName = "NewItemConfig")]
    public class ItemConfigs : ScriptableObject
    {
        [field: SerializeField] public Sprite IconItem { get; private set; }
        [field: SerializeField] public ItemType ItemType { get; private set; }
        [field: SerializeField] public int RewardValue { get; private set; }
    }

    public enum ItemType
    {
        Default = 0,
        Gold = 1,
        Gems = 2,
    }
}