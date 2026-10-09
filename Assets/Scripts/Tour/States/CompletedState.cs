namespace CampusTour.Tour.States
{
    /// <summary>모든 경유지를 방문했다. 스탬프를 저장하고 완주 연출을 보여준다.</summary>
    public class CompletedState : TourStateBase
    {
        public override TourStateId Id
        {
            get { return TourStateId.Completed; }
        }

        public override void Enter(TourContext context)
        {
            context.Host.CompleteTour();
            context.View.PlayCompletion();
        }
    }
}
