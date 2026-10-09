using System.Collections;
using System.Collections.Generic;
using CampusTour.Network;
using CampusTour.UI;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 맛집 상세 화면. 한 줄 소개는 앱에 내장하고, 상세 소개와 사진은 서버에서 받는다.
/// </summary>
public class Restaurant_Control : ScreenBase
{
    private const string ImageScope = "Restaurant";

    private class RestaurantEntry
    {
        public readonly string ServerTag;
        public readonly string Comment;

        public RestaurantEntry(string serverTag, string comment)
        {
            ServerTag = serverTag;
            Comment = comment;
        }
    }

    // 마커 라벨 → (서버 태그, 한 줄 소개). 서버 태그가 null이면 서버 정보가 없다.
    private static readonly Dictionary<string, RestaurantEntry> Restaurants = new Dictionary<string, RestaurantEntry>
    {
        { "공씨네주먹밥", new RestaurantEntry("riceball", "저렴하고 킹왕짱 맛을 자랑하는 주먹밥 집") },
        { "소담국밥", new RestaurantEntry("sodam", "뜨끈하고 담백한 국물이 일품인 국밥 집") },
        { "도서관 카페드림", new RestaurantEntry("bookcafe", "커피 한 잔과 함께 책 한 권 읽는 것은 어떠신가요?") },
        { "미유카페", new RestaurantEntry("meyou", "미 스터디 유 카페입니다.") },
        { "봉구스밥버거", new RestaurantEntry("bongousse", "봉구스(Bongousse)는 맛있는 한입거리라는 뜻의 프랑스어입니다. 밥버거 한 개 어떠신가요?") },
        { "샐러디", new RestaurantEntry("salady", "보기도 좋고 맛도 좋은 샐러드! 강추 드립니다~") },
        { "타워카페", new RestaurantEntry("towercafe", "경치 좋은 곳에서 커피 한 잔 어떠신가요?") },
        { "학식내 카페드림", new RestaurantEntry("inhakcafe", "식사 후 커피 한 잔은 졸음 퇴치에 아주 좋습니다!") },
        { "학식옆 카페드림", new RestaurantEntry("sidehakcafe", "식사 후 커피 한 잔은 졸음 퇴치에 아주 좋습니다!") },
        { "고기굽는집", new RestaurantEntry("gozip", "고기가 땡길 때는 역시 고기굽는 집으로!") },
        { "토마토 도시락", new RestaurantEntry("tomato", "식사할 시간이 부족할 때는 토마토 도시락을 애용하세요!") },
        { "파파이스", new RestaurantEntry(null, "@ 알립니다.\n\n메뉴 이미지를 게시하기 위하여 파파이스와 협의를 진행하였으나,\n파파이스 측이 거부 의사를 밝혔으며\n이에 따라 메뉴 이미지가 게시되지 않음을 알려드립니다.") },
        { "토스트집", new RestaurantEntry("toast", "토스트집 토스트가 왜 토스트인지 아시나요? 아시는분 inucse22.9@gmail.com 로 보내주세요. 하하핫~") },
        { "샹차이", new RestaurantEntry("china", "분위기 있는 식당에서 밥을 드시고 싶다면 샹차이를 가세요! 꺄륵~") },
        { "포썸(쌀국수집)", new RestaurantEntry("ricenoodle", "쌀국수 & 썸디쉬 전문점인 포썸! 오직 이곳에서만 맛볼 수 있는 탄탄면을 강력 추천합니다!") },
        { "그라지에", new RestaurantEntry("bakery", "학교내 존재하는 유일한 베이커리 그라지에입니다. 맛있는 빵과 커피를 같이 드셔보도록 권해드려요!") }
    };

    public Text res_title, res_intro, res_comment;
    public GameObject introPanel, menuPanel;
    public ContentControl contentcontrol;

    protected override void OnOpen(ScreenArgs args)
    {
        MarkerArgs marker = args as MarkerArgs;
        string label = marker != null ? marker.Label : string.Empty;
        ShowRestaurant(label);
    }

    private void OnDestroy()
    {
        if (ImageLoader.HasInstance)
        {
            ImageLoader.Instance.ReleaseScope(ImageScope);
        }
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
    }

    public void Close_Restaurant()
    {
        Close();
    }

    private void ShowRestaurant(string label)
    {
        introPanel.SetActive(true);

        RestaurantEntry entry;
        if (!Restaurants.TryGetValue(label, out entry))
        {
            return;
        }

        res_title.text = label;
        res_comment.text = entry.Comment;
        if (entry.ServerTag != null)
        {
            StartCoroutine(LoadDetail(entry.ServerTag));
        }
    }

    private IEnumerator LoadDetail(string serverTag)
    {
        ApiResult<string> intro = null;
        yield return ApiClient.Instance.GetText(ApiEndpoints.RestaurantInfo(serverTag), result => intro = result);
        if (intro.Success)
        {
            res_intro.text = intro.Data;
        }

        ApiResult<string> imageListResponse = null;
        yield return ApiClient.Instance.GetText(ApiEndpoints.ImageList(serverTag), result => imageListResponse = result);
        if (!imageListResponse.Success)
        {
            yield break;
        }

        ImageList imageList = ResponseParser.ParseImageList(imageListResponse.Data);
        Button[] pictures = contentcontrol.Build(imageList.Count);
        for (int i = 0; i < pictures.Length; i++)
        {
            Button picture = pictures[i];
            ImageLoader.Instance.Load(ApiEndpoints.Image(imageList.Paths[i]), ImageScope, sprite =>
            {
                if (picture != null)
                {
                    picture.image.sprite = sprite;
                }
            });
            picture.onClick.AddListener(() => GetComponent<ImageZoom>().ZoomIn(picture));
        }
    }
}
