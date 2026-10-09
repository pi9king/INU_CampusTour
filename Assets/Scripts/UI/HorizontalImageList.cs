using CampusTour.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CampusTour.UI
{
    /// <summary>
    /// 이미지 버튼을 가로로 나열하는 스크롤 목록. 맛집/미디어 화면이 공유한다.
    /// </summary>
    public class HorizontalImageList : MonoBehaviour
    {
        // 씬에 직렬화된 필드 이름을 유지한다.
        public GameObject ItemPrefab;

        private ObjectPool<Button> pool;

        public Button[] Build(int itemCount)
        {
            if (pool == null)
            {
                pool = new ObjectPool<Button>(ItemPrefab.GetComponent<Button>(), transform, true);
            }
            pool.ReleaseAll();

            RectTransform container = GetComponent<RectTransform>();
            RectTransform prefabRect = ItemPrefab.GetComponent<RectTransform>();
            float height = container.rect.height;
            float width = prefabRect.rect.width * (height / prefabRect.rect.height);
            float scrollWidth = width * itemCount;
            container.offsetMin = new Vector2(-scrollWidth / 2, container.offsetMin.y);
            container.offsetMax = new Vector2(scrollWidth / 2, container.offsetMax.y);

            Button[] items = new Button[itemCount];
            for (int i = 0; i < itemCount; i++)
            {
                Button item = pool.Get();
                item.name = "image" + (i + 1);
                item.onClick.RemoveAllListeners();

                RectTransform rect = item.GetComponent<RectTransform>();
                float x = -container.rect.width / 2 + width * i;
                float y = container.rect.height / 2 - height;
                rect.offsetMin = new Vector2(x, y);
                rect.offsetMax = new Vector2(x + width, y + height);
                items[i] = item;
            }
            return items;
        }
    }
}
