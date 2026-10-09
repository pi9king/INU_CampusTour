using System;
using UnityEngine;

namespace CampusTour.Tour
{
    /// <summary>투어 경유지 하나.</summary>
    [Serializable]
    public class TourStop
    {
        public string displayName;

        /// <summary>이 경유지로 이동하라고 안내할 때 표시하는 문구.</summary>
        public string guideText;
    }

    /// <summary>사용자 위치 사분면별 첫 경유지.</summary>
    [Serializable]
    public class QuadrantStart
    {
        public int stopIndex;
        public string routeText;
    }

    /// <summary>
    /// 코스 데이터. 지도 프리팹의 경로 마커는 경유지마다 3개(경로 점 2개 + 목적지)이며
    /// 라벨이 "1"부터 순서대로 붙어 있다. 경유지 k의 목적지 마커는 3(k+1)번이다.
    /// </summary>
    [Serializable]
    public class TourRoute
    {
        public const int MarkersPerStop = 3;

        public const int NorthEast = 0;
        public const int SouthEast = 1;
        public const int NorthWest = 2;
        public const int SouthWest = 3;

        [Tooltip("사용자 위치로 시작 경유지를 고를 때 기준이 되는 좌표 (경도, 위도)")]
        public Vector2 centerPoint;

        [Tooltip("목적지 도착으로 판정하는 거리 (위경도 단위, 약 15m)")]
        public float arrivalThreshold = 0.00015f;

        [Tooltip("시작 경유지를 고르기 전에 GPS를 기다리는 시간(초)")]
        public float startDelay = 0.9f;

        [Tooltip("경로 마커를 하나씩 보여주는 간격(초)")]
        public float markerStepInterval = 0.5f;

        [Tooltip("북동, 남동, 북서, 남서 순서")]
        public QuadrantStart[] quadrantStarts = new QuadrantStart[4];

        public TourStop[] stops = new TourStop[0];

        public int StopCount
        {
            get { return stops.Length; }
        }

        public int FirstMarkerOf(int stopIndex)
        {
            return stopIndex * MarkersPerStop + 1;
        }

        public int DestinationMarkerOf(int stopIndex)
        {
            return (stopIndex + 1) * MarkersPerStop;
        }

        public int NextStopOf(int stopIndex)
        {
            return (stopIndex + 1) % StopCount;
        }

        public QuadrantStart GetStartFor(Vector2 playerPosition)
        {
            bool isEast = playerPosition.x > centerPoint.x;
            bool isNorth = playerPosition.y > centerPoint.y;
            int quadrant = isEast ? (isNorth ? NorthEast : SouthEast) : (isNorth ? NorthWest : SouthWest);
            return quadrantStarts[quadrant];
        }
    }
}
