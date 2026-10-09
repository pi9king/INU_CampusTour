using System.Text;

namespace CampusTour.Network.Meal
{
    /// <summary>
    /// "중식 ... 석식 ... 조식 ..."처럼 구간 제목으로 나뉜 식단표를 파싱한다.
    /// 각 구간은 제목부터 다음 제목 직전까지이고, 마지막 구간은 끝까지다.
    /// </summary>
    public class SectionMealParser : MealParserBase
    {
        private readonly string[] sectionMarkers;

        public SectionMealParser(string title, string url, params string[] sectionMarkers)
            : base(title, url)
        {
            this.sectionMarkers = sectionMarkers;
        }

        protected override string FormatBody(string menu)
        {
            int[] starts = new int[sectionMarkers.Length];
            for (int i = 0; i < sectionMarkers.Length; i++)
            {
                starts[i] = menu.IndexOf(sectionMarkers[i]);
                bool outOfOrder = i > 0 && starts[i] < starts[i - 1];
                if (starts[i] < 0 || outOfOrder)
                {
                    return null;
                }
            }

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < starts.Length; i++)
            {
                int end = i + 1 < starts.Length ? starts[i + 1] : menu.Length;
                if (i > 0)
                {
                    builder.Append('\n');
                }
                builder.Append(menu.Substring(starts[i], end - starts[i]));
            }
            return builder.ToString();
        }
    }
}
