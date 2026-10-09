using CampusTour.Tour;
using CampusTour.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// AR 화면에서 뒤로가기를 누르면 투어를 그만두고 메인 지도로 돌아간다.
/// </summary>
public class OutAR : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TourSession.End();
            SceneManager.LoadScene(ScreenRegistry.MainSceneName);
        }
    }
}
