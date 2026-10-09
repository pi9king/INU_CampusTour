using UnityEngine;

namespace CampusTour.Tour.States
{
    /// <summary>
    /// 시작 안내 팝업을 띄우고, GPS를 잠시 기다린 뒤 사용자 위치(사분면)로 첫 경유지를 고른다.
    /// 첫 경유지가 정해져야 시작 버튼이 나타난다.
    /// </summary>
    public class PreparingState : TourStateBase
    {
        private float elapsed;
        private bool isStartSelected;

        public override TourStateId Id
        {
            get { return TourStateId.Preparing; }
        }

        public override void Enter(TourContext context)
        {
            elapsed = 0f;
            isStartSelected = false;
            context.View.ShowStartGuide();
        }

        public override void Tick(TourContext context, float deltaTime)
        {
            if (isStartSelected)
            {
                return;
            }

            elapsed += deltaTime;
            if (elapsed < context.Route.startDelay)
            {
                return;
            }

            Vector2 player;
            if (!context.Map.TryGetPlayerPosition(out player))
            {
                // 위치를 모르면 (0, 0)으로 판정한다.
                player = Vector2.zero;
            }
            QuadrantStart start = context.Route.GetStartFor(player);
            context.Progress.StartAt(start.stopIndex);
            context.View.ShowStartButton(start.routeText);
            isStartSelected = true;
        }

        public override void OnStartRequested(TourContext context)
        {
            if (isStartSelected)
            {
                context.ChangeState(TourStateId.Guiding);
            }
        }
    }
}
