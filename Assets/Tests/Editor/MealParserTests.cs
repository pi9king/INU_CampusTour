using System;
using CampusTour.Network.Meal;
using NUnit.Framework;

namespace CampusTour.Tests
{
    public class MealParserTests
    {
        private static readonly DateTime Today = new DateTime(2018, 5, 22);

        [Test]
        public void ExtractMenu_StripsTagsAndCollapsesSpaces()
        {
            const string html = "<html><div class=\"sickdangmenu cf\"><p>메뉴명</p>\n<b>중식</b>   비빔밥 &quot;특&quot;</div></html>";

            Assert.AreEqual(" 중식 비빔밥 특", MealHtmlCleaner.ExtractMenu(html));
        }

        [Test]
        public void ExtractMenu_ReturnsNullWhenMenuBlockIsMissing()
        {
            // 학교 홈페이지 개편 등으로 구조가 바뀌어도 예외 대신 null을 반환해야 한다.
            Assert.IsNull(MealHtmlCleaner.ExtractMenu("<html><body>점검 중</body></html>"));
            Assert.IsNull(MealHtmlCleaner.ExtractMenu(null));
        }

        [Test]
        public void SectionParser_SplitsBySectionMarkers()
        {
            IMealParser parser = new SectionMealParser("생활원 식당 메뉴", "url", "중식", "석식", "조식");

            string text = parser.Format("중식 김치찌개 석식 돈까스 조식 토스트", Today);

            Assert.AreEqual("생활원 식당 메뉴(2018년 05월 22일)\n\n중식 김치찌개 \n석식 돈까스 \n조식 토스트", text);
        }

        [Test]
        public void SectionParser_ShowsNoMenuMessageWhenMarkerIsMissing()
        {
            IMealParser parser = new SectionMealParser("교직원 식당 메뉴", "url", "중식", "석식");

            string text = parser.Format("오늘은 운영하지 않습니다", Today);

            StringAssert.EndsWith(MealParserBase.NoMenuMessage, text);
        }

        [Test]
        public void CornerParser_ListsEachCorner()
        {
            IMealParser parser = new CornerMealParser("학생 식당 메뉴", "url", 3);

            string text = parser.Format("1코너 라면 2코너 덮밥 3코너 정식", Today);

            Assert.AreEqual("학생 식당 메뉴(2018년 05월 22일)\n\n1코너  라면 \n2코너  덮밥 \n3코너  정식\n", text);
        }

        [Test]
        public void CornerParser_SkipsMissingCorners()
        {
            IMealParser parser = new CornerMealParser("학생 식당 메뉴", "url", 3);

            string text = parser.Format("1코너 라면", Today);

            StringAssert.Contains("1코너  라면", text);
            StringAssert.DoesNotContain("2코너", text);
        }

        [Test]
        public void MealParsers_ProvidesAllCafeterias()
        {
            Assert.AreEqual(4, MealParsers.All.Count);
        }
    }
}
