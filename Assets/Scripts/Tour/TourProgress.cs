namespace CampusTour.Tour
{
    /// <summary>
    /// 진행 상황(현재 경유지, 방문 수).
    /// </summary>
    public class TourProgress
    {
        private readonly TourRoute route;

        public TourProgress(TourRoute route)
        {
            this.route = route;
        }

        public TourRoute Route
        {
            get { return route; }
        }

        public int CurrentStop { get; private set; }
        public int VisitedCount { get; private set; }

        public int NextStop
        {
            get { return route.NextStopOf(CurrentStop); }
        }

        public bool IsComplete
        {
            get { return VisitedCount >= route.StopCount; }
        }

        public TourStop CurrentStopData
        {
            get { return route.stops[CurrentStop]; }
        }

        public void StartAt(int stopIndex)
        {
            CurrentStop = stopIndex;
            VisitedCount = 0;
        }

        public void MarkCurrentVisited()
        {
            VisitedCount++;
        }

        public void MoveToNextStop()
        {
            CurrentStop = NextStop;
        }
    }
}
