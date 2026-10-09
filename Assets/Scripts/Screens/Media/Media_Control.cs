using System.Collections;
using CampusTour.Network;
using CampusTour.UI;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 드라마/예능 촬영지 상세 화면.
/// </summary>
public class Media_Control : ScreenBase
{
    private const string ImageScope = "Media";
    private const string StarDramaKeyword = "별에서온그대";

    public Text title, explaintext, introduce, mediaexplain;
    public MediaContentControl mcc;

    protected override void OnOpen(ScreenArgs args)
    {
        MarkerArgs marker = args as MarkerArgs;
        string label = marker != null ? marker.Label : string.Empty;
        title.text = label;
        explaintext.text = label.Contains(StarDramaKeyword) ? "장면소개" : "방송사";
        StartCoroutine(LoadMedia(label));
    }

    private void OnDestroy()
    {
        if (ImageLoader.HasInstance)
        {
            ImageLoader.Instance.ReleaseScope(ImageScope);
        }
    }

    public void exitMedia()
    {
        Close();
    }

    private IEnumerator LoadMedia(string label)
    {
        ApiResult<string> infoResponse = null;
        yield return ApiClient.Instance.GetText(ApiEndpoints.MediaInfo(label), result => infoResponse = result);
        MediaInfo info = infoResponse.Success ? ResponseParser.ParseMedia(infoResponse.Data) : null;
        if (info == null)
        {
            yield break;
        }

        title.text = label.Contains(StarDramaKeyword) ? StarDramaKeyword : "[" + info.Broadcaster + "]" + info.Title;
        introduce.text = info.Broadcaster;
        mediaexplain.text = info.Description;

        ApiResult<string> imageListResponse = null;
        yield return ApiClient.Instance.GetText(ApiEndpoints.ImageList(info.ImageTag), result => imageListResponse = result);
        if (!imageListResponse.Success)
        {
            yield break;
        }

        ImageList imageList = ResponseParser.ParseImageList(imageListResponse.Data);
        Button[] images = mcc.Build(imageList.Count);
        for (int i = 0; i < images.Length; i++)
        {
            Button image = images[i];
            ImageLoader.Instance.Load(ApiEndpoints.Image(imageList.Paths[i]), ImageScope, sprite =>
            {
                if (image != null)
                {
                    image.image.sprite = sprite;
                }
            });
            image.onClick.AddListener(() => GetComponent<ImageZoom>().ZoomIn(image));
        }
    }
}
