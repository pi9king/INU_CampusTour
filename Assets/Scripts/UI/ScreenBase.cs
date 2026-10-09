using UnityEngine;
using UnityEngine.SceneManagement;

namespace CampusTour.UI
{
    /// <summary>
    /// Additive로 여는 화면의 베이스. 자기 씬 이름으로 ScreenId를 찾아 인자를 받고, 닫을 때 내비게이터에 알린다.
    /// </summary>
    public abstract class ScreenBase : MonoBehaviour
    {
        private ScreenId screenId;
        private bool isRegistered;

        protected virtual void Start()
        {
            isRegistered = ScreenRegistry.TryGetScreenId(gameObject.scene.name, out screenId);
            OnOpen(isRegistered ? ScreenNavigator.Instance.GetArgs(screenId) : null);
        }

        /// <summary>화면이 열릴 때 한 번 호출된다. 내비게이터를 거치지 않고 열렸다면 args는 null이다.</summary>
        protected abstract void OnOpen(ScreenArgs args);

        public void Close()
        {
            if (isRegistered)
            {
                ScreenNavigator.Instance.Close(screenId);
            }
            else
            {
                SceneManager.UnloadSceneAsync(gameObject.scene);
            }
        }
    }
}
