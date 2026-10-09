namespace CampusTour.Tour.States
{
    /// <summary>
    /// 투어 상태의 베이스(State 패턴). 입력 처리 메서드는 기본적으로 아무것도 하지 않으며,
    /// 그 입력이 의미 있는 상태만 재정의한다.
    /// </summary>
    public abstract class TourStateBase
    {
        public abstract TourStateId Id { get; }

        public virtual void Enter(TourContext context)
        {
        }

        public virtual void Exit(TourContext context)
        {
        }

        public virtual void Tick(TourContext context, float deltaTime)
        {
        }

        public virtual void OnStartRequested(TourContext context)
        {
        }

        public virtual void OnArRequested(TourContext context)
        {
        }

        public virtual void OnArSkipped(TourContext context)
        {
        }

        public virtual void OnInfoConfirmed(TourContext context)
        {
        }

        public virtual void OnNextRequested(TourContext context)
        {
        }
    }
}
