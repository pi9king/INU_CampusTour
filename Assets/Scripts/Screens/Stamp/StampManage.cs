using CampusTour.Tour;
using CampusTour.UI;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 스탬프 판 화면. 각 도장 오브젝트의 이름이 스탬프 키("60minute" 등)다.
/// </summary>
public class StampManage : ScreenBase
{
    private const string StampedSpritePath = "Stamp/INU Stamped";

    [SerializeField] GameObject[] Stamp;

    protected override void OnOpen(ScreenArgs args)
    {
        Sprite stamped = Resources.Load<Sprite>(StampedSpritePath);
        for (int i = 0; i < Stamp.Length; i++)
        {
            if (StampBook.IsCollected(Stamp[i].name))
            {
                Stamp[i].GetComponent<Image>().sprite = stamped;
            }
        }
    }

    public void ExitBtn()
    {
        Close();
    }
}
