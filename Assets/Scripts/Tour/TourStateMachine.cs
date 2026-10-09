using System.Collections.Generic;
using CampusTour.Tour.States;

namespace CampusTour.Tour
{
    public enum TourStateId
    {
        None,
        Preparing,
        Guiding,
        Arrived,
        ShowingInfo,
        GuidingToNext,
        Completed
    }

    /// <summary>
    /// 투어 진행 상태 머신.
    /// 화면 입력 이벤트는 현재 상태에만 전달되므로, 상태에 맞지 않는 입력은 자연스럽게 무시된다.
    /// </summary>
    public class TourStateMachine
    {
        private readonly Dictionary<TourStateId, TourStateBase> states = new Dictionary<TourStateId, TourStateBase>();
        private readonly TourContext context;
        private TourStateBase current;

        public TourStateMachine(TourContext context)
        {
            this.context = context;
            Register(new PreparingState());
            Register(new GuidingState());
            Register(new ArrivedState());
            Register(new ShowingInfoState());
            Register(new GuidingToNextState());
            Register(new CompletedState());

            context.View.StartRequested += delegate { current.OnStartRequested(context); };
            context.View.ArRequested += delegate { current.OnArRequested(context); };
            context.View.ArSkipped += delegate { current.OnArSkipped(context); };
            context.View.InfoConfirmed += delegate { current.OnInfoConfirmed(context); };
            context.View.NextRequested += delegate { current.OnNextRequested(context); };
            context.View.ExitRequested += delegate { context.Host.ExitTour(); };
        }

        public TourStateId CurrentId
        {
            get { return current == null ? TourStateId.None : current.Id; }
        }

        public void ChangeState(TourStateId id)
        {
            if (current != null)
            {
                current.Exit(context);
            }
            current = states[id];
            current.Enter(context);
        }

        public void Tick(float deltaTime)
        {
            if (current != null)
            {
                current.Tick(context, deltaTime);
            }
        }

        private void Register(TourStateBase state)
        {
            states.Add(state.Id, state);
        }
    }
}
