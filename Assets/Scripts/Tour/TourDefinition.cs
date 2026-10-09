using UnityEngine;

namespace CampusTour.Tour
{
    /// <summary>
    /// 투어 코스 하나의 설정.
    /// 새 코스는 이 에셋 하나와 경로 마커가 찍힌 지도 프리팹만 있으면 된다.
    /// </summary>
    [CreateAssetMenu(menuName = "CampusTour/Tour Definition", fileName = "TourDefinition")]
    public class TourDefinition : ScriptableObject
    {
        public string sceneName;

        [Tooltip("완주 스탬프 저장 키 (스탬프 판의 도장 오브젝트 이름과 같아야 한다)")]
        public string stampKey;

        [Tooltip("경로 마커가 찍힌 지도 프리팹. 루트에 OnlineMapsTourMap이 있어야 한다.")]
        public GameObject mapPrefab;

        public TourRoute route = new TourRoute();
    }
}
