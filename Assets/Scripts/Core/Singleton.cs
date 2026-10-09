using UnityEngine;

namespace CampusTour.Core
{
    /// <summary>
    /// 씬 전환과 무관하게 하나만 존재해야 하는 서비스용 베이스 클래스.
    /// 남용을 막기 위해 ApiClient, ImageLoader, ScreenNavigator에만 사용한다.
    /// </summary>
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;
        private static bool isQuitting;

        public static T Instance
        {
            get
            {
                if (instance == null && !isQuitting)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        GameObject go = new GameObject(typeof(T).Name);
                        instance = go.AddComponent<T>();
                    }
                }
                return instance;
            }
        }

        public static bool HasInstance
        {
            get { return instance != null; }
        }

        protected virtual void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }

        protected virtual void OnApplicationQuit()
        {
            isQuitting = true;
        }
    }
}
