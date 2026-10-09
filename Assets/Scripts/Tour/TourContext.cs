namespace CampusTour.Tour
{
    /// <summary>상태들이 공유하는 투어 진행 정보와 협력 객체.</summary>
    public class TourContext
    {
        public readonly TourProgress Progress;
        public readonly ITourMap Map;
        public readonly ITourView View;
        public readonly ITourHost Host;
        public readonly TourStateMachine StateMachine;

        public TourContext(TourProgress progress, ITourMap map, ITourView view, ITourHost host)
        {
            Progress = progress;
            Map = map;
            View = view;
            Host = host;
            StateMachine = new TourStateMachine(this);
        }

        public TourRoute Route
        {
            get { return Progress.Route; }
        }

        public void ChangeState(TourStateId id)
        {
            StateMachine.ChangeState(id);
        }
    }
}
