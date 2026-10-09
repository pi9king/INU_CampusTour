using System.Text.RegularExpressions;

namespace CampusTour.Network.Meal
{
    /// <summary>
    /// 학교 홈페이지 식단 페이지 HTML에서 메뉴 영역만 꺼내 태그와 공백을 정리한다.
    /// </summary>
    public static class MealHtmlCleaner
    {
        private const string MenuBlockMarker = "sickdangmenu";
        private const string MenuBlockEnd = "</div>";

        private static readonly Regex TagPattern = new Regex(@"<(.|\n)*?>");
        private static readonly Regex SpacePattern = new Regex(" +");

        /// <summary>메뉴 영역을 찾지 못하면 null을 반환한다.</summary>
        public static string ExtractMenu(string html)
        {
            if (string.IsNullOrEmpty(html))
            {
                return null;
            }

            int start = html.IndexOf(MenuBlockMarker);
            if (start < 0)
            {
                return null;
            }
            int end = html.IndexOf(MenuBlockEnd, start);
            if (end < 0)
            {
                return null;
            }

            string block = TagPattern.Replace(html.Substring(start, end - start), string.Empty);
            block = block.Replace("sickdangmenu cf\">", string.Empty);
            block = CollapseSpaces(block);
            return block.Replace("메뉴명", string.Empty)
                        .Replace("amp;", string.Empty)
                        .Replace("&quot;", string.Empty);
        }

        /// <summary>begin과 end 사이 문자열. end가 없으면 끝까지, begin이 없으면 null.</summary>
        public static string Between(string text, string begin, string end)
        {
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }

            int beginIndex = text.IndexOf(begin);
            if (beginIndex < 0)
            {
                return null;
            }

            string rest = text.Substring(beginIndex + begin.Length);
            int endIndex = rest.IndexOf(end);
            return endIndex < 0 ? rest : rest.Substring(0, endIndex);
        }

        private static string CollapseSpaces(string text)
        {
            string flat = text.Trim().Replace("\t", " ").Replace("\r", " ").Replace("\n", " ");
            return SpacePattern.Replace(flat, " ");
        }
    }
}
