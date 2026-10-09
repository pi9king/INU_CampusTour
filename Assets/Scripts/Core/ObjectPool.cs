using System.Collections.Generic;
using UnityEngine;

namespace CampusTour.Core
{
    /// <summary>
    /// 목록 UI 항목처럼 반복 생성되는 오브젝트를 재사용하기 위한 풀.
    /// </summary>
    public class ObjectPool<T> where T : Component
    {
        private readonly T prefab;
        private readonly Transform parent;
        private readonly bool worldPositionStays;
        private readonly Stack<T> inactive = new Stack<T>();
        private readonly List<T> active = new List<T>();

        /// <param name="worldPositionStays">
        /// true면 Instantiate 후 SetParent(parent)와 같은 방식(월드 좌표 유지)으로 붙인다.
        /// </param>
        public ObjectPool(T prefab, Transform parent, bool worldPositionStays = false)
        {
            this.prefab = prefab;
            this.parent = parent;
            this.worldPositionStays = worldPositionStays;
        }

        public int ActiveCount
        {
            get { return active.Count; }
        }

        public int InactiveCount
        {
            get { return inactive.Count; }
        }

        public IList<T> ActiveItems
        {
            get { return active.AsReadOnly(); }
        }

        public T Get()
        {
            T item = inactive.Count > 0 ? inactive.Pop() : Create();
            item.gameObject.SetActive(true);
            active.Add(item);
            return item;
        }

        public void Release(T item)
        {
            if (!active.Remove(item))
            {
                return;
            }
            item.gameObject.SetActive(false);
            inactive.Push(item);
        }

        public void ReleaseAll()
        {
            for (int i = active.Count - 1; i >= 0; i--)
            {
                T item = active[i];
                item.gameObject.SetActive(false);
                inactive.Push(item);
            }
            active.Clear();
        }

        private T Create()
        {
            T item = Object.Instantiate(prefab);
            item.transform.SetParent(parent, worldPositionStays);
            return item;
        }
    }
}
