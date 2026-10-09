using System;
using System.Collections.Generic;

namespace CampusTour.UI
{
    /// <summary>
    /// 화면과 씬 이름의 매핑. 씬 이름 문자열은 이 클래스에만 존재한다.
    /// </summary>
    public static class ScreenRegistry
    {
        public const string MainSceneName = "GUItexture(Kor)";
        public const string ArSceneName = "UFO";
        public const string VirtualTourSceneName = "Virtual Tour";
        public const string VrListSceneName = "목록 VR";

        private static readonly Dictionary<ScreenId, string> SceneNames = new Dictionary<ScreenId, string>
        {
            { ScreenId.PhotoZone, "PhotoZone" },
            { ScreenId.Media, "Media" },
            { ScreenId.Restaurant, "Restaurant" },
            { ScreenId.MealMenu, "Parser" },
            { ScreenId.Inven, "Inven" },
            { ScreenId.UnivInfo, "Univ Information(Kor)" },
            { ScreenId.DeptInfo, "Dept information(Kor)" },
            { ScreenId.DeptInfoTwoPages, "Two Curri Dept information(Kor)" },
            { ScreenId.DeptInfoThreePages, "Three Curri Dept information(Kor)" },
            { ScreenId.DeptInfoFourPages, "Four Curri Dept information(Kor)" },
            { ScreenId.Building1, "1Building" },
            { ScreenId.Building2, "2Building" },
            { ScreenId.Stamp, "Stamp" },
            { ScreenId.Setting, "Setting" },
            { ScreenId.CallList, "Call" }
        };

        public static string GetSceneName(ScreenId id)
        {
            return SceneNames[id];
        }

        public static bool TryGetScreenId(string sceneName, out ScreenId id)
        {
            foreach (KeyValuePair<ScreenId, string> pair in SceneNames)
            {
                if (string.Equals(pair.Value, sceneName, StringComparison.OrdinalIgnoreCase))
                {
                    id = pair.Key;
                    return true;
                }
            }
            id = default(ScreenId);
            return false;
        }

        /// <summary>커리큘럼 이미지 장수(1~4)에 맞는 학과 화면.</summary>
        public static ScreenId DeptInfoFor(int curriculumPageCount)
        {
            switch (curriculumPageCount)
            {
                case 2: return ScreenId.DeptInfoTwoPages;
                case 3: return ScreenId.DeptInfoThreePages;
                case 4: return ScreenId.DeptInfoFourPages;
                default: return ScreenId.DeptInfo;
            }
        }
    }
}
