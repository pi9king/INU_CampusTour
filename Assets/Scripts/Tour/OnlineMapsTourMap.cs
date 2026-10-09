using UnityEngine;

namespace CampusTour.Tour
{
    /// <summary>
    /// Online Maps 플러그인을 ITourMap으로 감싼다(Adapter). 투어 지도 프리팹 루트에 붙는다.
    /// </summary>
    [RequireComponent(typeof(OnlineMaps))]
    public class OnlineMapsTourMap : MonoBehaviour, ITourMap
    {
        private const string PlayerLabel = "Player";

        private OnlineMaps map;

        private void Awake()
        {
            map = GetComponent<OnlineMaps>();
            // AR 씬을 다녀와도 투어 경로 지도가 유지돼야 한다.
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            ShowOnlyMarker(0);
        }

        public bool TryGetPlayerPosition(out Vector2 position)
        {
            OnlineMapsMarker player = FindMarker(PlayerLabel);
            position = player != null ? player.position : Vector2.zero;
            return player != null;
        }

        public Vector2 GetMarkerPosition(int markerNumber)
        {
            OnlineMapsMarker marker = FindMarker(markerNumber.ToString());
            return marker != null ? marker.position : Vector2.zero;
        }

        public void ShowOnlyMarker(int markerNumber)
        {
            string label = markerNumber.ToString();
            foreach (OnlineMapsMarker marker in map.markers)
            {
                marker.enabled = marker.label == label || marker.label == PlayerLabel;
            }
        }

        /// <summary>개발용: 사용자 위치 마커를 옮긴다.</summary>
        public void TeleportPlayer(Vector2 position)
        {
            OnlineMapsMarker player = FindMarker(PlayerLabel);
            if (player != null)
            {
                player.position = position;
            }
        }

        public void Dispose()
        {
            if (this != null)
            {
                Destroy(gameObject);
            }
        }

        private OnlineMapsMarker FindMarker(string label)
        {
            foreach (OnlineMapsMarker marker in map.markers)
            {
                if (marker.label == label)
                {
                    return marker;
                }
            }
            return null;
        }
    }
}
