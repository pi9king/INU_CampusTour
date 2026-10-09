using CampusTour.Core;
using UnityEngine;

namespace CampusTour.Tour.States
{
    /// <summary>
    /// 현재 경유지까지의 경로 마커를 하나씩 보여준 뒤, 사용자가 목적지에 가까워지면 도착 상태로 넘어간다.
    /// </summary>
    public class GuidingState : TourStateBase
    {
        private int nextMarker;
        private int destinationMarker;
        private float stepTimer;
        private bool isAnimationFinished;

        public override TourStateId Id
        {
            get { return TourStateId.Guiding; }
        }

        public override void Enter(TourContext context)
        {
            int stop = context.Progress.CurrentStop;
            nextMarker = context.Route.FirstMarkerOf(stop);
            destinationMarker = context.Route.DestinationMarkerOf(stop);
            isAnimationFinished = false;
            ShowNextMarker(context);
        }

        public override void Tick(TourContext context, float deltaTime)
        {
            if (!isAnimationFinished)
            {
                stepTimer += deltaTime;
                if (stepTimer >= context.Route.markerStepInterval)
                {
                    ShowNextMarker(context);
                }
                return;
            }

            Vector2 player;
            if (!context.Map.TryGetPlayerPosition(out player))
            {
                return;
            }
            float distance = GeoUtil.DegreeDistance(player, context.Map.GetMarkerPosition(destinationMarker));
            if (distance < context.Route.arrivalThreshold)
            {
                context.ChangeState(TourStateId.Arrived);
            }
        }

        // 마지막 마커를 보여준 뒤에도 한 간격을 더 기다린 다음 도착 판정을 시작한다.
        private void ShowNextMarker(TourContext context)
        {
            stepTimer = 0f;
            if (nextMarker > destinationMarker)
            {
                isAnimationFinished = true;
                return;
            }
            context.Map.ShowOnlyMarker(nextMarker);
            nextMarker++;
        }
    }
}
