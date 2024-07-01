using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Logic.WheelFortune
{
    public class WheelContent : MonoBehaviour
    {
        [SerializeField] private List<WheelContentView> _wheelContents;
        [SerializeField] private RectTransform _contentContainer;
        [SerializeField] private float _radius = 200f;
        [Range(-0.1f, 0.1f)] [SerializeField] private float _offsetPosition;

        private IConfigProvider _configProvider;

        public void Construct(IConfigProvider configProvider)
        {
            _configProvider = configProvider;
        }

        private void OnValidate()
        {
            ArrangeWheelContents();
        }

        private void Start()
        {
            RefreshContent();
        }

        private void RefreshContent()
        {
            var wheelData = _configProvider.GetWheelData();

            for (int i = 0; i < wheelData.Items.Count; i++)
                _wheelContents[i].Refresh(wheelData.Items[i].IconItem, wheelData.Items[i].RewardValue);
        }

        private void ArrangeWheelContents()
        {
            int itemCount = _wheelContents.Count;
            float angleStep = 360f / itemCount;
            float halfAngleStep = angleStep * _offsetPosition * -1;

            for (int i = 0; i < itemCount; i++)
            {
                WheelContentView content = _wheelContents[i];

                float angle = (i * angleStep * Mathf.Deg2Rad) + halfAngleStep;
                Vector2 position = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * _radius;

                RectTransform rectTransform = content.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = position;

                float zRotation = Mathf.Atan2(position.y, position.x) * Mathf.Rad2Deg - 90;
                rectTransform.localRotation = Quaternion.Euler(0, 0, zRotation);
            }
        }
    }
}