namespace CampusTour.Tour
{
    /// <summary>
    /// 상태가 엔진/플랫폼 기능을 쓸 때 거치는 통로. (TourController가 구현하고, 테스트에서는 가짜로 대체)
    /// </summary>
    public interface ITourHost
    {
        void Vibrate();
        void OpenArScene();
        void CompleteTour();
        void ExitTour();
    }
}
