using System.Collections.Generic;

namespace CampusTour.Network.Meal
{
    /// <summary>
    /// 화면에 표시하는 순서대로 식당별 파서를 제공한다.
    /// 식당이 추가되면 여기에 전략 하나만 등록하면 된다.
    /// </summary>
    public static class MealParsers
    {
        private static readonly IMealParser[] all =
        {
            new CornerMealParser("학생 식당 메뉴",
                ApiEndpoints.SchoolMeal("foodList1.do?siteId=inu&id=inu_050110010000"), 5),
            new SectionMealParser("생활원 식당 메뉴",
                ApiEndpoints.SchoolMeal("foodList2.do?siteId=inu&id=inu_050110030000"), "중식", "석식", "조식"),
            new SectionMealParser("교직원 식당 메뉴",
                ApiEndpoints.SchoolMeal("foodList3.do?siteId=inu&id=inu_050110040000"), "중식", "석식"),
            new SectionMealParser("카페테리아(제 2학식) 식당 메뉴",
                ApiEndpoints.SchoolMeal("foodList4.do?siteId=inu&id=inu_050110050000"), "A코너(중식)", "A코너(석식)", "B코너")
        };

        public static IList<IMealParser> All
        {
            get { return all; }
        }
    }
}
