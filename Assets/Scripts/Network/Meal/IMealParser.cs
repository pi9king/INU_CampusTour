using System;

namespace CampusTour.Network.Meal
{
    /// <summary>
    /// 식당마다 홈페이지 식단표 구조가 달라 파싱 방법을 전략으로 분리한다.
    /// </summary>
    public interface IMealParser
    {
        string Title { get; }
        string Url { get; }

        /// <summary>정리된 식단 텍스트를 화면 표시용 문자열로 변환한다. 실패해도 예외 대신 안내 문구를 반환한다.</summary>
        string Format(string cleanedMenu, DateTime date);
    }
}
