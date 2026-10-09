using UnityEngine;

namespace CampusTour.Tour
{
    /// <summary>
    /// 투어 로직이 지도에 요구하는 기능. 지도 플러그인은 OnlineMapsTourMap(Adapter)이 감싼다.
    /// 테스트에서는 가짜 구현으로 사용자 위치를 직접 넣을 수 있다.
    /// </summary>
    public interface ITourMap
    {
        /// <summary>사용자 위치(경도, 위도). 아직 GPS 마커가 없으면 false.</summary>
        bool TryGetPlayerPosition(out Vector2 position);

        Vector2 GetMarkerPosition(int markerNumber);

        /// <summary>경로 마커 중 하나만 보이게 한다. (사용자 위치 마커는 항상 표시)</summary>
        void ShowOnlyMarker(int markerNumber);

        void Dispose();
    }
}
