using System;
using System.Text;

namespace CampusTour.Network.Meal
{
    public abstract class MealParserBase : IMealParser
    {
        public const string NoMenuMessage = "등록된 메뉴 정보가 없습니다.";

        private readonly string title;
        private readonly string url;

        protected MealParserBase(string title, string url)
        {
            this.title = title;
            this.url = url;
        }

        public string Title
        {
            get { return title; }
        }

        public string Url
        {
            get { return url; }
        }

        public string Format(string cleanedMenu, DateTime date)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(title).Append('(').Append(date.ToString("yyyy년 MM월 dd일")).Append(")\n\n");

            string body = string.IsNullOrEmpty(cleanedMenu) ? null : FormatBody(cleanedMenu);
            builder.Append(string.IsNullOrEmpty(body) ? NoMenuMessage : body);
            return builder.ToString();
        }

        /// <summary>식단 본문만 만든다. 형식이 맞지 않으면 null을 반환한다.</summary>
        protected abstract string FormatBody(string menu);
    }
}
