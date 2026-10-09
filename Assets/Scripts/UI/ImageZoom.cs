using CampusTour.UI;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 이미지 확대 보기. 화면 스택의 오버레이라서 뒤로가기를 누르면 확대 화면만 닫힌다.
/// </summary>
public class ImageZoom : MonoBehaviour, IClosable
{
    public Button ZoomImage;
    public GameObject Zoom;

    public void ZoomIn(Button source)
    {
        if (source.image.sprite == null)
        {
            return;
        }
        Zoom.SetActive(true);
        ZoomImage.image.sprite = source.image.sprite;
        ScreenNavigator.Instance.PushOverlay(this);
    }

    public void Zoomout()
    {
        Zoom.SetActive(false);
        if (ScreenNavigator.HasInstance)
        {
            ScreenNavigator.Instance.RemoveOverlay(this);
        }
    }

    public void Close()
    {
        Zoomout();
    }

    private void OnDestroy()
    {
        if (ScreenNavigator.HasInstance)
        {
            ScreenNavigator.Instance.RemoveOverlay(this);
        }
    }
}
