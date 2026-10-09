using UnityEngine;

namespace CampusTour.Tour
{
    /// <summary>
    /// 개발용 버튼. 캠퍼스에 가지 않고도 투어를 진행해 볼 수 있게 사용자 위치를 목적지로 옮긴다.
    /// 에디터와 개발 빌드에서만 동작한다.
    /// </summary>
    public class TourDebugPanel : MonoBehaviour
    {
        public void TeleportToTarget()
        {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            if (!TourSession.IsActive)
            {
                return;
            }
            OnlineMapsTourMap map = TourSession.Map as OnlineMapsTourMap;
            if (map == null)
            {
                return;
            }
            int destination = TourSession.Progress.Route.DestinationMarkerOf(TourSession.Progress.CurrentStop);
            map.TeleportPlayer(map.GetMarkerPosition(destination));
#endif
        }

        public void LogState()
        {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
            TourController controller = FindObjectOfType<TourController>();
            if (controller != null && TourSession.IsActive)
            {
                Debug.Log("[Tour] state=" + controller.CurrentState +
                          " stop=" + TourSession.Progress.CurrentStop +
                          " visited=" + TourSession.Progress.VisitedCount + "/" + TourSession.Progress.Route.StopCount);
            }
#endif
        }
    }
}
