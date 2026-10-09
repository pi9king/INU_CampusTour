using CampusTour.UI;

namespace CampusTour.Map
{
    /// <summary>
    /// 마커 클릭 시 종류에 맞는 상세 화면을 연다.
    /// </summary>
    public static class MarkerClickRouter
    {
        public static void Route(OnlineMapsMarkerBase marker)
        {
            MarkerCategory category = MarkerCategoryResolver.Resolve(marker.scale);
            ScreenId screen;
            if (!TryGetScreen(category, out screen))
            {
                return;
            }
            double longitude, latitude;
            marker.GetPosition(out longitude, out latitude);
            ScreenNavigator.Instance.Push(screen, new MarkerArgs(marker.label, category, latitude, longitude));
        }

        public static bool TryGetScreen(MarkerCategory category, out ScreenId screen)
        {
            switch (category)
            {
                case MarkerCategory.PhotoZone:
                    screen = ScreenId.PhotoZone;
                    return true;
                case MarkerCategory.StarDramaScene:
                case MarkerCategory.OtherDramaScene:
                    screen = ScreenId.Media;
                    return true;
                case MarkerCategory.Restaurant:
                    screen = ScreenId.Restaurant;
                    return true;
                case MarkerCategory.Cafeteria:
                    screen = ScreenId.MealMenu;
                    return true;
                default:
                    screen = default(ScreenId);
                    return false;
            }
        }
    }
}
