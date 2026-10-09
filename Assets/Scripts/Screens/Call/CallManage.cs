using System.Collections.Generic;
using CampusTour.Network;
using CampusTour.UI;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 검색 결과 연락처 화면. 전화번호가 있으면 확인 팝업 후 전화를 건다.
/// </summary>
public class CallManage : ScreenBase
{
    private const string NoPhoneIconPath = "Search/통화 불가 아이콘";

    public CallControl callcontrolScripts;
    public GameObject CallPopup;
    public GameObject NotCallPopup;

    protected override void OnOpen(ScreenArgs args)
    {
        Instantiate(CallPopup);
        Instantiate(NotCallPopup);

        CallListArgs callArgs = args as CallListArgs;
        IList<SearchEntry> entries = callArgs != null ? callArgs.Entries : new List<SearchEntry>();
        Image[] items = callcontrolScripts.initCallList(entries.Count);
        for (int i = 0; i < items.Length; i++)
        {
            items[i].GetComponentInChildren<Text>().text = entries[i].ToDisplayText();
            SetOnClick(items[i].GetComponentInChildren<Button>(), entries[i]);
        }
    }

    private void SetOnClick(Button button, SearchEntry entry)
    {
        button.onClick.RemoveAllListeners();
        if (entry.HasPhone)
        {
            string phone = entry.Phone;
            button.onClick.AddListener(() =>
            {
                CallPopup.SetActive(true);
                Button yesButton = GameObject.Find("Yes_Button").GetComponent<Button>();
                yesButton.onClick.RemoveAllListeners();
                yesButton.onClick.AddListener(() => ReadytoCall(phone));
            });
        }
        else
        {
            button.image.sprite = Resources.Load<Sprite>(NoPhoneIconPath);
            button.onClick.AddListener(() => NotCallPopup.SetActive(true));
        }
    }

    public void ReadytoCall(string tel)
    {
        Application.OpenURL("tel://" + tel);
    }

    public void CloseCallPopup()
    {
        CallPopup.SetActive(false);
    }

    public void CloseNotCallPopup()
    {
        NotCallPopup.SetActive(false);
    }

    public void OffCallList()
    {
        Close();
    }
}
