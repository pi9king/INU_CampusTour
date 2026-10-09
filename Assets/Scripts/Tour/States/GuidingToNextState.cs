namespace CampusTour.Tour.States
{
    /// <summary>
    /// "다음은 ○○으로 이동해 주세요" 안내. 확인하면 다음 경유지 경로 안내를 시작한다.
    /// </summary>
    public class GuidingToNextState : TourStateBase
    {
        public override TourStateId Id
        {
            get { return TourStateId.GuidingToNext; }
        }

        public override void Enter(TourContext context)
        {
            context.Progress.MoveToNextStop();
            context.View.ShowNextGuide(context.Progress.CurrentStopData.guideText);
        }

        public override void OnNextRequested(TourContext context)
        {
            context.ChangeState(TourStateId.Guiding);
        }
    }
}
