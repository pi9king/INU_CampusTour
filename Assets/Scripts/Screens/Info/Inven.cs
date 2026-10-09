using CampusTour.UI;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 학교 정보(인벤토리) 화면. 버튼 태그로 열 화면을, 버튼 이름으로 대상(단과대/건물)을 정한다.
/// 투어 씬의 정보 패널에서도 같은 버튼 처리를 쓴다.
/// </summary>
public class Inven : ScreenBase
{
    protected override void OnOpen(ScreenArgs args)
    {
    }

    public void Btnclick()
    {
        GameObject selected = EventSystem.current.currentSelectedGameObject;
        ScreenId target;
        if (TryGetTarget(selected.tag, out target))
        {
            ScreenNavigator.Instance.Push(target, new NameArgs(selected.name));
        }
    }

    public void ExitBtn()
    {
        Close();
    }

    private static bool TryGetTarget(string buttonTag, out ScreenId target)
    {
        switch (buttonTag)
        {
            case "Univ":
                target = ScreenId.UnivInfo;
                return true;
            case "Building1":
                target = ScreenId.Building1;
                return true;
            case "Building2":
                target = ScreenId.Building2;
                return true;
            default:
                target = default(ScreenId);
                return false;
        }
    }
}
