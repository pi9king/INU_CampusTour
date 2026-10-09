using CampusTour.Core;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 검색 결과 연락처 목록의 레이아웃. 항목은 풀에서 재사용한다.
/// </summary>
public class CallControl : MonoBehaviour
{
    public GameObject CallPrefab;

    private ObjectPool<Image> pool;

    public Image[] initCallList(int callCount)
    {
        if (pool == null)
        {
            pool = new ObjectPool<Image>(CallPrefab.GetComponent<Image>(), transform, true);
        }
        pool.ReleaseAll();

        RectTransform container = GetComponent<RectTransform>();
        RectTransform prefabRect = CallPrefab.GetComponent<RectTransform>();
        float width = container.rect.width;
        float height = prefabRect.rect.height;
        float scrollHeight = height * callCount;
        container.offsetMin = new Vector2(scrollHeight / 2, container.offsetMin.x);
        container.offsetMax = new Vector2(-scrollHeight / 2, container.offsetMax.x);

        Image[] items = new Image[callCount];
        for (int i = 0; i < callCount; i++)
        {
            Image item = pool.Get();
            item.name = "CallList" + (i + 1);

            RectTransform rect = item.GetComponent<RectTransform>();
            float x = container.rect.width / 2 - width;
            float y = -container.rect.height / 2 - height * i;
            rect.offsetMin = new Vector2(x, y);
            rect.offsetMax = new Vector2(x + width, y + height);
            items[i] = item;
        }
        return items;
    }
}
