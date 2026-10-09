using CampusTour.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 메인 지도 화면의 메뉴와 버튼 처리.
/// 메뉴 패널은 화면 스택의 오버레이로 올라가므로 뒤로가기로 닫힌다.
/// </summary>
public class Buttonmanage : MonoBehaviour, IClosable
{
    private const string UniversityUrl = "http://www.inu.ac.kr";
    private const string AmbassadorBlogUrl = "http://blog.naver.com/dream_we";

    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject dramalist;
    [SerializeField] private GameObject tourlist;
    [SerializeField] private GameObject prefa;
    [SerializeField] private GameObject menuback;
    [SerializeField] private GameObject GpsWarning;
    [SerializeField] private InputField SeachField;
    [SerializeField] private GameObject CallBtn;

    // 지도 프리팹은 DontDestroyOnLoad라서 메인 화면에 다시 들어와도 한 번만 만든다.
    private static bool isMapCreated;

    private void Start()
    {
        bool isDesktop = SystemInfo.deviceType == DeviceType.Desktop;
        if (!Input.location.isEnabledByUser && !isDesktop)
        {
            GpsWarning.SetActive(true);
        }
        if (!isMapCreated)
        {
            Instantiate(prefa);
            isMapCreated = true;
        }
    }

    public void clickmenu()
    {
        SeachField.text = "";
        CallBtn.SetActive(false);
        if (!menu.activeSelf)
        {
            menu.SetActive(true);
            menuback.SetActive(true);
            dramalist.SetActive(false);
            tourlist.SetActive(false);
            ScreenNavigator.Instance.PushOverlay(this);
        }
        else
        {
            menu.SetActive(false);
            menuback.SetActive(false);
            ScreenNavigator.Instance.RemoveOverlay(this);
        }
    }

    public void Close()
    {
        Alloff();
    }

    #region 메뉴
    public void OnClickRollBack()
    {
        LeaveMainScene(ScreenRegistry.MainSceneName);
    }

    public void Photozoneclick()
    {
        NewBtnManage.Photo();
        Alloff();
    }

    public void Dramazoneclick()
    {
        dramalist.SetActive(true);
        menu.SetActive(false);
    }

    public void Tourlistclick()
    {
        tourlist.SetActive(true);
        menu.SetActive(false);
    }

    public void Restaurantclick()
    {
        NewBtnManage.Restaurant();
        Alloff();
    }

    public void VRTourclick()
    {
        LeaveMainScene(ScreenRegistry.VirtualTourSceneName);
    }

    public void INUbtnClick()
    {
        Application.OpenURL(UniversityUrl);
        Alloff();
    }

    public void DreamBtnClick()
    {
        Application.OpenURL(AmbassadorBlogUrl);
        Alloff();
    }

    public void Alloff()
    {
        menu.SetActive(false);
        dramalist.SetActive(false);
        menuback.SetActive(false);
        tourlist.SetActive(false);
        ScreenNavigator.Instance.RemoveOverlay(this);
    }
    #endregion

    #region 드라마목록
    public void DramaClick(Button dramabtn)
    {
        NewBtnManage.Drama(dramabtn.name);
        Alloff();
    }

    public void DramaetcClick()
    {
        NewBtnManage.EtcDrama();
        Alloff();
    }

    public void DramaBackMenu()
    {
        dramalist.SetActive(false);
        menu.SetActive(true);
    }

    public void TourBackMenu()
    {
        tourlist.SetActive(false);
        menu.SetActive(true);
    }
    #endregion

    public void Clickinven()
    {
        ScreenNavigator.Instance.Push(ScreenId.Inven);
    }

    public void SettingClick()
    {
        ScreenNavigator.Instance.Push(ScreenId.Setting);
    }

    public void Clickstamp()
    {
        ScreenNavigator.Instance.Push(ScreenId.Stamp);
    }

    public void ClickHome()
    {
        NewBtnManage.GoToUniv();
    }

    public void ClickMe()
    {
        NewBtnManage.GoToMe();
    }

    public void GoCallList()
    {
        MarkerSearch search = GetComponent<MarkerSearch>();
        ScreenNavigator.Instance.Push(ScreenId.CallList, new CallListArgs(search.Results));
    }

    #region 투어시작버튼
    public void GoTour(string tourSceneName)
    {
        LeaveMainScene(tourSceneName);
    }

    public void AR60Tour()
    {
        LeaveMainScene("60Min Tour");
    }

    public void AR30Tour()
    {
        LeaveMainScene("30Min Tour");
    }

    public void ARliberalTour()
    {
        LeaveMainScene("Liberal Tour");
    }

    public void ARscienceTour()
    {
        LeaveMainScene("Sciences Tour");
    }

    public void ARdramaTour()
    {
        LeaveMainScene("Drama Tour");
    }
    #endregion

    /// <summary>메인 지도(DontDestroyOnLoad)를 정리하고 다른 씬으로 이동한다.</summary>
    private static void LeaveMainScene(string sceneName)
    {
        NewBtnManage.DestRoll();
        isMapCreated = false;
        SceneManager.LoadScene(sceneName);
    }
}
