using CampusTour.Tour;
using NUnit.Framework;
using UnityEngine;

namespace CampusTour.Tests
{
    public class TourRouteTests
    {
        private static TourRoute CreateRoute(int stopCount)
        {
            TourRoute route = new TourRoute();
            route.centerPoint = new Vector2(126.6337f, 37.37588f);
            route.stops = new TourStop[stopCount];
            route.quadrantStarts = new[]
            {
                new QuadrantStart { stopIndex = 2 },
                new QuadrantStart { stopIndex = 5 },
                new QuadrantStart { stopIndex = 0 },
                new QuadrantStart { stopIndex = 6 }
            };
            return route;
        }

        [Test]
        public void MarkerNumbers_FollowThreeMarkersPerStop()
        {
            // 지도 프리팹의 경로 마커는 경유지마다 경로 점 2개 + 목적지 1개
            TourRoute route = CreateRoute(15);

            Assert.AreEqual(1, route.FirstMarkerOf(0));
            Assert.AreEqual(3, route.DestinationMarkerOf(0));
            Assert.AreEqual(43, route.FirstMarkerOf(14));
            Assert.AreEqual(45, route.DestinationMarkerOf(14));
        }

        [Test]
        public void NextStop_WrapsToFirstStop()
        {
            TourRoute route = CreateRoute(15);

            Assert.AreEqual(1, route.NextStopOf(0));
            Assert.AreEqual(0, route.NextStopOf(14));
        }

        [TestCase(126.64f, 37.38f, 2)]
        [TestCase(126.64f, 37.37f, 5)]
        [TestCase(126.63f, 37.38f, 0)]
        [TestCase(126.63f, 37.37f, 6)]
        public void StartStop_IsChosenByQuadrantAroundCenter(float longitude, float latitude, int expectedStop)
        {
            // 경도가 기준보다 크면 동쪽(북동/남동), 위도가 크면 북쪽
            TourRoute route = CreateRoute(15);

            Assert.AreEqual(expectedStop, route.GetStartFor(new Vector2(longitude, latitude)).stopIndex);
        }

        [Test]
        public void Progress_CompletesAfterVisitingEveryStop()
        {
            TourProgress progress = new TourProgress(CreateRoute(2));
            progress.StartAt(1);

            progress.MarkCurrentVisited();
            Assert.IsFalse(progress.IsComplete);
            progress.MoveToNextStop();
            Assert.AreEqual(0, progress.CurrentStop);

            progress.MarkCurrentVisited();
            Assert.IsTrue(progress.IsComplete);
        }
    }
}
