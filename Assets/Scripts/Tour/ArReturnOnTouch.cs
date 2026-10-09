using CampusTour.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CampusTour.Tour
{
    /// <summary>
    /// AR 오브젝트를 터치하면 진행 중이던 투어 씬으로 돌아간다. (rayTracer가 SendMessage("touchBegan")로 호출)
    /// </summary>
    public class ArReturnOnTouch : MonoBehaviour
    {
        void touchBegan()
        {
            SceneManager.LoadScene(TourSession.IsActive ? TourSession.Definition.sceneName : ScreenRegistry.MainSceneName);
        }
    }
}
