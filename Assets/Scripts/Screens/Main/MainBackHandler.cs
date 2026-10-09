using CampusTour.UI;
using UnityEngine;

/// <summary>
/// 메인 지도 화면에서 열린 화면이 없을 때 뒤로가기를 누르면 종료 팝업을 띄운다.
/// </summary>
public class MainBackHandler : MonoBehaviour
{
    [SerializeField] private GameObject endpop;

    private void OnEnable()
    {
        ScreenNavigator.Instance.SetRootBackHandler(EndPop);
    }

    private void OnDisable()
    {
        if (ScreenNavigator.HasInstance)
        {
            ScreenNavigator.Instance.ClearRootBackHandler(EndPop);
        }
    }

    public void EndPop()
    {
        endpop.SetActive(true);
    }
}
