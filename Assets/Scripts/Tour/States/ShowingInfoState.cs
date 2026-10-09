namespace CampusTour.Tour.States
{
    /// <summary>
    /// 도착한 경유지의 정보 패널을 보여준다. 확인하면 방문 처리 후 다음 경유지 안내 또는 완주로 넘어간다.
    /// </summary>
    public class ShowingInfoState : TourStateBase
    {
        public override TourStateId Id
        {
            get { return TourStateId.ShowingInfo; }
        }

        public override void Enter(TourContext context)
        {
            context.View.ShowStopInfo(context.Progress.CurrentStop);
        }

        public override void OnInfoConfirmed(TourContext context)
        {
            context.Progress.MarkCurrentVisited();
            context.ChangeState(context.Progress.IsComplete ? TourStateId.Completed : TourStateId.GuidingToNext);
        }
    }
}
