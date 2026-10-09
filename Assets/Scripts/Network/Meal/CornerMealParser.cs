using System.Text;

namespace CampusTour.Network.Meal
{
    /// <summary>
    /// "1코너 ... 2코너 ..."처럼 번호가 붙은 코너별 식단표를 파싱한다. (학생식당)
    /// </summary>
    public class CornerMealParser : MealParserBase
    {
        private const string CornerSuffix = "코너";
        private readonly int cornerCount;

        public CornerMealParser(string title, string url, int cornerCount)
            : base(title, url)
        {
            this.cornerCount = cornerCount;
        }

        protected override string FormatBody(string menu)
        {
            StringBuilder builder = new StringBuilder();
            for (int corner = 1; corner <= cornerCount; corner++)
            {
                string items = MealHtmlCleaner.Between(menu, corner + CornerSuffix, (corner + 1) + CornerSuffix);
                if (items == null)
                {
                    continue;
                }
                builder.Append(corner).Append(CornerSuffix).Append(' ').Append(items).Append('\n');
            }
            return builder.Length == 0 ? null : builder.ToString();
        }
    }
}
