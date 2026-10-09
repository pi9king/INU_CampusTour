using UnityEngine;

namespace CampusTour.Core
{
    public static class GeoUtil
    {
        private const double EarthRadiusMeters = 6378137.0;

        /// <summary>
        /// 위경도 평면 거리(단위: 도). 투어 도착 판정에 사용한다.
        /// </summary>
        public static float DegreeDistance(Vector2 a, Vector2 b)
        {
            return Vector2.Distance(a, b);
        }

        /// <summary>
        /// 지구 곡률을 고려한 두 좌표 사이 거리(단위: m).
        /// </summary>
        public static double HaversineMeters(double lat1, double lon1, double lat2, double lon2)
        {
            double dLat = ToRadian(lat2 - lat1);
            double dLon = ToRadian(lon2 - lon1);
            double a = System.Math.Sin(dLat / 2) * System.Math.Sin(dLat / 2) +
                       System.Math.Cos(ToRadian(lat1)) * System.Math.Cos(ToRadian(lat2)) *
                       System.Math.Sin(dLon / 2) * System.Math.Sin(dLon / 2);
            double c = 2 * System.Math.Atan2(System.Math.Sqrt(a), System.Math.Sqrt(1 - a));
            return EarthRadiusMeters * c;
        }

        private static double ToRadian(double degree)
        {
            return degree * System.Math.PI / 180.0;
        }
    }
}
