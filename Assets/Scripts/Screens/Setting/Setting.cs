using CampusTour.UI;
using UnityEngine;

/// <summary>
/// 설정 화면. 언어 선택 값만 저장한다(1: 영어, 2: 한국어).
/// </summary>
public class Setting : ScreenBase
{
    private const string LanguageKey = "Check";
    private const int English = 1;
    private const int Korean = 2;

    protected override void OnOpen(ScreenArgs args)
    {
    }

    public void EnglishToKorea()
    {
        PlayerPrefs.SetInt(LanguageKey, Korean);
    }

    public void KoreaToEnglish()
    {
        PlayerPrefs.SetInt(LanguageKey, English);
    }

    public void ExitSetting()
    {
        Close();
    }
}
