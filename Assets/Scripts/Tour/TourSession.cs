namespace CampusTour.Tour
{
    /// <summary>
    /// 씬 전환(투어 씬 ↔ AR 씬)을 넘어 유지해야 하는 투어 진행 정보.
    /// </summary>
    public static class TourSession
    {
        public static TourDefinition Definition { get; private set; }
        public static TourProgress Progress { get; private set; }
        public static ITourMap Map { get; private set; }
        public static bool IsInAr { get; private set; }

        public static bool IsActive
        {
            get { return Definition != null; }
        }

        public static void Begin(TourDefinition definition, TourProgress progress, ITourMap map)
        {
            End();
            Definition = definition;
            Progress = progress;
            Map = map;
        }

        public static bool IsReturningFromAr(TourDefinition definition)
        {
            return IsActive && IsInAr && Definition == definition;
        }

        public static void EnterAr()
        {
            IsInAr = true;
        }

        public static void ReturnFromAr()
        {
            IsInAr = false;
        }

        /// <summary>투어를 끝내고 투어 전용 지도(DontDestroyOnLoad)를 정리한다.</summary>
        public static void End()
        {
            if (Map != null)
            {
                Map.Dispose();
            }
            Definition = null;
            Progress = null;
            Map = null;
            IsInAr = false;
        }
    }
}
