using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CampusTour.Tour
{
    /// <summary>
    /// 투어 씬 UI. 버튼 입력을 이벤트로 알리고, 상태가 요청하는 팝업/패널을 보여준다.
    /// 버튼 이벤트가 씬에 메서드 이름으로 연결돼 있으므로 공개 메서드 이름(StartPopupOff 등)을 바꾸면 안 된다.
    /// </summary>
    public class TourView : MonoBehaviour, ITourView
    {
        [SerializeField] private GameObject arrivalPopup;
        [SerializeField] private GameObject[] infoPanels;
        [SerializeField] private GameObject startGuidePopup;
        [SerializeField] private GameObject nextGuidePopup;
        [SerializeField] private Text nextGuideText;
        [SerializeField] private Text routeText;
        [SerializeField] private GameObject endPopup;
        [SerializeField] private GameObject startButton;

        public event Action StartRequested;
        public event Action ArRequested;
        public event Action ArSkipped;
        public event Action InfoConfirmed;
        public event Action NextRequested;
        public event Action ExitRequested;

        private void Awake()
        {
            TourArrivalPopup popup = arrivalPopup.GetComponent<TourArrivalPopup>();
            popup.ArRequested += delegate { Raise(ArRequested); };
            popup.Skipped += delegate { Raise(ArSkipped); };
        }

        #region 상태가 요청하는 표시
        public void ShowStartGuide()
        {
            startGuidePopup.SetActive(true);
        }

        public void ShowStartButton(string route)
        {
            routeText.text = route;
            startButton.SetActive(true);
        }

        public void ShowArrivalPopup()
        {
            arrivalPopup.SetActive(true);
        }

        public void ShowStopInfo(int stopIndex)
        {
            infoPanels[stopIndex].SetActive(true);
        }

        public void ShowNextGuide(string guideText)
        {
            nextGuideText.text = guideText;
            nextGuidePopup.SetActive(true);
        }

        public void PlayCompletion()
        {
            StartCoroutine(PlayStampThenShowEnd());
        }
        #endregion

        #region 버튼 (씬에 연결된 메서드)
        public void StartPopupOff(GameObject guidePopup)
        {
            guidePopup.SetActive(false);
            Raise(StartRequested);
        }

        public void NextTour(GameObject infoPanel)
        {
            infoPanel.SetActive(false);
            Raise(InfoConfirmed);
        }

        public void GoNext()
        {
            nextGuidePopup.SetActive(false);
            Raise(NextRequested);
        }

        public void TourEndBtn()
        {
            endPopup.SetActive(false);
            Raise(ExitRequested);
        }

        public void openURL(Text url)
        {
            Application.OpenURL(url.text);
        }
        #endregion

        private IEnumerator PlayStampThenShowEnd()
        {
            StampControl stamp = GetComponent<StampControl>();
            if (stamp != null)
            {
                yield return StartCoroutine(stamp.Stamping());
            }
            endPopup.SetActive(true);
        }

        private static void Raise(Action handler)
        {
            if (handler != null)
            {
                handler();
            }
        }
    }
}
