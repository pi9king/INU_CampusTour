namespace CampusTour.Tour.States
{
    /// <summary>
    /// 경유지 도착. 진동과 함께 AR 체험 여부를 묻고, 지도에는 다음 경로의 첫 마커를 미리 보여준다.
    /// </summary>
    public class ArrivedState : TourStateBase
    {
        public override TourStateId Id
        {
            get { return TourStateId.Arrived; }
        }

        public override void Enter(TourContext context)
        {
            context.Host.Vibrate();
            context.View.ShowArrivalPopup();
            context.Map.ShowOnlyMarker(context.Route.FirstMarkerOf(context.Progress.NextStop));
        }

        public override void OnArRequested(TourContext context)
        {
            // AR 씬에서 돌아오면 TourController가 ShowingInfo 상태로 재개한다.
            context.Host.OpenArScene();
        }

        public override void OnArSkipped(TourContext context)
        {
            context.ChangeState(TourStateId.ShowingInfo);
        }
    }
}
