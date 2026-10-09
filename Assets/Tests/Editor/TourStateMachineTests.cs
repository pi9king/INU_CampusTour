using CampusTour.Tour;
using NUnit.Framework;
using UnityEngine;

namespace CampusTour.Tests
{
    public class TourStateMachineTests
    {
        private const float Step = 0.5f;

        private FakeTourMap map;
        private FakeTourView view;
        private FakeTourHost host;
        private TourProgress progress;
        private TourContext context;

        // 경유지 3개짜리 코스. 기준점 (100, 0). 동쪽이면 1번, 서쪽이면 0번 경유지부터 시작한다.
        private static TourRoute CreateRoute()
        {
            TourRoute route = new TourRoute();
            route.centerPoint = new Vector2(100, 0);
            route.arrivalThreshold = 0.1f;
            route.startDelay = 0.9f;
            route.markerStepInterval = Step;
            route.quadrantStarts = new[]
            {
                new QuadrantStart { stopIndex = 1, routeText = "NE" },
                new QuadrantStart { stopIndex = 1, routeText = "SE" },
                new QuadrantStart { stopIndex = 0, routeText = "NW" },
                new QuadrantStart { stopIndex = 0, routeText = "SW" }
            };
            route.stops = new[]
            {
                new TourStop { displayName = "A", guideText = "A로 이동" },
                new TourStop { displayName = "B", guideText = "B로 이동" },
                new TourStop { displayName = "C", guideText = "C로 이동" }
            };
            return route;
        }

        [SetUp]
        public void SetUp()
        {
            map = new FakeTourMap();
            view = new FakeTourView();
            host = new FakeTourHost();
            progress = new TourProgress(CreateRoute());
            context = new TourContext(progress, map, view, host);
        }

        private TourStateId State
        {
            get { return context.StateMachine.CurrentId; }
        }

        private void Tick(float seconds)
        {
            context.StateMachine.Tick(seconds);
        }

        private void PrepareAndStart(Vector2 playerPosition)
        {
            map.PlayerPosition = playerPosition;
            context.ChangeState(TourStateId.Preparing);
            Tick(1f);
            view.PressStart();
        }

        // 경로 마커 애니메이션(3개 + 마지막 대기)을 끝낸 뒤 목적지로 이동한다.
        private void WalkToCurrentDestination()
        {
            Tick(Step);
            Tick(Step);
            Tick(Step);
            map.MovePlayerToMarker(progress.Route.DestinationMarkerOf(progress.CurrentStop));
            Tick(Step);
        }

        [Test]
        public void Preparing_ShowsStartButtonOnlyAfterGpsDelay()
        {
            map.PlayerPosition = new Vector2(50, -1);
            context.ChangeState(TourStateId.Preparing);

            Assert.IsTrue(view.IsStartGuideShown);
            view.PressStart();
            Assert.AreEqual(TourStateId.Preparing, State, "시작 버튼이 나오기 전 입력은 무시");

            Tick(1f);
            Assert.AreEqual("SW", view.StartRouteText);
            Assert.AreEqual(0, progress.CurrentStop);
        }

        [Test]
        public void Preparing_PicksStartStopByQuadrant()
        {
            PrepareAndStart(new Vector2(150, 5));

            Assert.AreEqual(1, progress.CurrentStop);
            Assert.AreEqual(TourStateId.Guiding, State);
        }

        [Test]
        public void Preparing_TreatsUnknownPlayerPositionAsOrigin()
        {
            map.PlayerPosition = null;
            context.ChangeState(TourStateId.Preparing);
            Tick(1f);

            Assert.AreEqual("SW", view.StartRouteText);
        }

        [Test]
        public void Guiding_AnimatesRouteMarkersThenDetectsArrival()
        {
            PrepareAndStart(new Vector2(50, -1));
            CollectionAssert.AreEqual(new[] { 1 }, map.ShownMarkers, "첫 마커는 즉시 표시");

            Tick(Step);
            Tick(Step);
            CollectionAssert.AreEqual(new[] { 1, 2, 3 }, map.ShownMarkers);

            map.MovePlayerToMarker(3);
            Tick(0.01f);
            Assert.AreEqual(TourStateId.Guiding, State, "애니메이션이 끝나기 전에는 도착 판정 안 함");

            Tick(Step);
            Tick(0.01f);
            Assert.AreEqual(TourStateId.Arrived, State);
        }

        [Test]
        public void Guiding_StaysWhenPlayerIsFarFromDestination()
        {
            PrepareAndStart(new Vector2(50, -1));
            Tick(Step);
            Tick(Step);
            Tick(Step);
            Tick(Step);

            Assert.AreEqual(TourStateId.Guiding, State);
        }

        [Test]
        public void Arrived_VibratesAsksForArAndPreviewsNextRoute()
        {
            PrepareAndStart(new Vector2(50, -1));
            WalkToCurrentDestination();

            Assert.AreEqual(TourStateId.Arrived, State);
            Assert.AreEqual(1, host.VibrateCount);
            Assert.AreEqual(1, view.ArrivalPopupCount);
            Assert.AreEqual(4, map.ShownMarkers[map.ShownMarkers.Count - 1], "다음 경유지(B)의 첫 마커");
        }

        [Test]
        public void Arrived_OpeningArKeepsStateForResume()
        {
            PrepareAndStart(new Vector2(50, -1));
            WalkToCurrentDestination();

            view.PressAr();

            Assert.AreEqual(1, host.OpenArCount);
            Assert.AreEqual(TourStateId.Arrived, State);
        }

        [Test]
        public void SkippingAr_ShowsInfoOfCurrentStop()
        {
            PrepareAndStart(new Vector2(150, 5));
            WalkToCurrentDestination();

            view.PressSkipAr();

            Assert.AreEqual(TourStateId.ShowingInfo, State);
            CollectionAssert.AreEqual(new[] { 1 }, view.ShownInfoPanels);
        }

        [Test]
        public void ConfirmingInfo_GuidesToNextStopAndWrapsAround()
        {
            PrepareAndStart(new Vector2(150, 5));
            progress.StartAt(2);
            context.ChangeState(TourStateId.ShowingInfo);

            view.PressInfoNext();

            Assert.AreEqual(TourStateId.GuidingToNext, State);
            Assert.AreEqual(0, progress.CurrentStop, "마지막 경유지 다음은 처음 경유지");
            Assert.AreEqual("A로 이동", view.NextGuideText);

            view.PressGoNext();
            Assert.AreEqual(TourStateId.Guiding, State);
        }

        [Test]
        public void VisitingAllStops_CompletesTourOnce()
        {
            PrepareAndStart(new Vector2(150, 5));
            for (int i = 0; i < 3; i++)
            {
                WalkToCurrentDestination();
                view.PressSkipAr();
                view.PressInfoNext();
                if (State == TourStateId.GuidingToNext)
                {
                    view.PressGoNext();
                }
            }

            Assert.AreEqual(TourStateId.Completed, State);
            Assert.AreEqual(1, host.CompleteCount);
            Assert.IsTrue(view.IsCompletionPlayed);
            CollectionAssert.AreEqual(new[] { 1, 2, 0 }, view.ShownInfoPanels);
        }

        [Test]
        public void InputsThatDoNotMatchCurrentStateAreIgnored()
        {
            PrepareAndStart(new Vector2(50, -1));

            view.PressGoNext();
            view.PressInfoNext();
            view.PressAr();

            Assert.AreEqual(TourStateId.Guiding, State);
            Assert.AreEqual(0, host.OpenArCount);
        }

        [Test]
        public void ExitCanBeRequestedFromAnyState()
        {
            PrepareAndStart(new Vector2(50, -1));

            view.PressExit();

            Assert.AreEqual(1, host.ExitCount);
        }
    }
}
