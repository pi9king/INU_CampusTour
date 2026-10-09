using System.Collections.Generic;
using CampusTour.Map;
using CampusTour.Network;

namespace CampusTour.UI
{
    /// <summary>화면을 열 때 전달하는 인자.</summary>
    public abstract class ScreenArgs
    {
    }

    /// <summary>지도 마커를 눌러 연 화면의 인자.</summary>
    public class MarkerArgs : ScreenArgs
    {
        public readonly string Label;
        public readonly MarkerCategory Category;
        public readonly double Latitude;
        public readonly double Longitude;

        public MarkerArgs(string label, MarkerCategory category, double latitude, double longitude)
        {
            Label = label;
            Category = category;
            Latitude = latitude;
            Longitude = longitude;
        }
    }

    /// <summary>건물/단과대/학과 이름 하나만 전달하는 인자.</summary>
    public class NameArgs : ScreenArgs
    {
        public readonly string Name;

        public NameArgs(string name)
        {
            Name = name;
        }
    }

    /// <summary>검색 결과 연락처 목록.</summary>
    public class CallListArgs : ScreenArgs
    {
        public readonly IList<SearchEntry> Entries;

        public CallListArgs(IList<SearchEntry> entries)
        {
            Entries = entries;
        }
    }
}
