using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using CampusTour.Network;
using CampusTour.Network.Meal;
using CampusTour.UI;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 학식 메뉴 화면. 식당별 파싱 방식은 IMealParser 전략으로 분리돼 있다.
/// </summary>
public class Parser : ScreenBase
{
    private const string LoadingMessage = "메뉴를 불러오는 중입니다...";
    private const string LoadFailedMessage = "메뉴 정보를 불러올 수 없습니다.";

    public Text title;
    public GameObject introPanel, menuPanel;
    public Text resultset;

    private bool isMenuLoaded;
    private Coroutine loadRoutine;

    protected override void OnOpen(ScreenArgs args)
    {
        MarkerArgs marker = args as MarkerArgs;
        string label = marker != null ? marker.Label : string.Empty;
        title.text = label;
    }

    public void Click_Intro()
    {
        introPanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void Click_Menu()
    {
        introPanel.SetActive(false);
        menuPanel.SetActive(true);
        if (!isMenuLoaded && loadRoutine == null)
        {
            loadRoutine = StartCoroutine(LoadAllMenus(MealParsers.All));
        }
    }

    public void Close_Restaurant()
    {
        Close();
    }

    private IEnumerator LoadAllMenus(IList<IMealParser> parsers)
    {
        resultset.text = LoadingMessage;
        string[] sections = new string[parsers.Count];
        DateTime today = DateTime.Now;

        for (int i = 0; i < parsers.Count; i++)
        {
            IMealParser parser = parsers[i];
            ApiResult<string> response = null;
            yield return ApiClient.Instance.GetText(parser.Url, delegate(ApiResult<string> result) { response = result; });

            sections[i] = response.Success
                ? parser.Format(MealHtmlCleaner.ExtractMenu(response.Data), today)
                : parser.Title + "\n\n" + LoadFailedMessage;
        }

        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < sections.Length; i++)
        {
            if (i > 0)
            {
                builder.Append("\n\n");
            }
            builder.Append(sections[i]);
        }
        resultset.text = builder.ToString();
        isMenuLoaded = true;
        loadRoutine = null;
    }
}
