using System;

namespace CampusTour.Map
{
    /// <summary>
    /// 마커 크기(scale) → 마커 종류 판정을 한 곳으로 모은다.
    /// 지도 프리팹에는 마커 종류가 scale 값으로 저장돼 있으므로, 비교는 모두 이 클래스를 거친다.
    /// </summary>
    public static class MarkerCategoryResolver
    {
        public const float FacilityScale = 0.45f;
        public const float StoreScale = 0.47f;
        public const float CafeteriaScale = 0.48f;
        public const float RestaurantScale = 0.49f;
        public const float PhotoZoneScale = 0.5f;
        public const float StarDramaSceneScale = 0.6f;
        public const float OtherDramaSceneScale = 0.65f;
        public const float SearchResultScale = 0.7f;

        private const float Tolerance = 0.004f;

        private static readonly float[] Scales =
        {
            FacilityScale, StoreScale, CafeteriaScale, RestaurantScale,
            PhotoZoneScale, StarDramaSceneScale, OtherDramaSceneScale, SearchResultScale
        };

        private static readonly MarkerCategory[] Categories =
        {
            MarkerCategory.Facility, MarkerCategory.Store, MarkerCategory.Cafeteria, MarkerCategory.Restaurant,
            MarkerCategory.PhotoZone, MarkerCategory.StarDramaScene, MarkerCategory.OtherDramaScene, MarkerCategory.SearchResult
        };

        public static MarkerCategory Resolve(float scale)
        {
            for (int i = 0; i < Scales.Length; i++)
            {
                if (Math.Abs(scale - Scales[i]) <= Tolerance)
                {
                    return Categories[i];
                }
            }
            return MarkerCategory.None;
        }
    }
}
