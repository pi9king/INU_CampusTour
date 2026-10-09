using System;

namespace CampusTour.Tour
{
    /// <summary>
    /// 투어 화면. 사용자 입력은 이벤트로 알리고(Observer), 표시는 상태가 메서드로 요청한다.
    /// </summary>
    public interface ITourView
    {
        event Action StartRequested;
        event Action ArRequested;
        event Action ArSkipped;
        event Action InfoConfirmed;
        event Action NextRequested;
        event Action ExitRequested;

        void ShowStartGuide();
        void ShowStartButton(string routeText);
        void ShowArrivalPopup();
        void ShowStopInfo(int stopIndex);
        void ShowNextGuide(string guideText);
        void PlayCompletion();
    }
}
