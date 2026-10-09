using UnityEngine;

namespace CampusTour.Tour
{
    /// <summary>
    /// 투어 완주 스탬프 저장소. 키는 TourDefinition.stampKey("60minute" 등)이며 PlayerPrefs에 저장한다.
    /// </summary>
    public static class StampBook
    {
        private const int Collected = 1;

        public static bool IsCollected(string stampKey)
        {
            return PlayerPrefs.GetInt(stampKey) == Collected;
        }

        public static void Collect(string stampKey)
        {
            PlayerPrefs.SetInt(stampKey, Collected);
            PlayerPrefs.Save();
        }
    }
}
