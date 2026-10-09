using System.Collections;
using CampusTour.Network;
using CampusTour.UI;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 포토존 상세 화면. 소개와 사진(최대 images.Length장)을 서버에서 받는다.
/// </summary>
public class PhotoZone_Control : ScreenBase
{
    private const string ImageScope = "PhotoZone";

    public Text title, recoperson, Photoexplain;
    public Button[] images;

    protected override void OnOpen(ScreenArgs args)
    {
        MarkerArgs marker = args as MarkerArgs;
        string label = marker != null ? marker.Label : string.Empty;
        title.text = label;
        StartCoroutine(LoadPhotoZone(label));
    }

    private void OnDestroy()
    {
        if (ImageLoader.HasInstance)
        {
            ImageLoader.Instance.ReleaseScope(ImageScope);
        }
    }

    public void PhotoZoneExit()
    {
        Close();
    }

    private IEnumerator LoadPhotoZone(string label)
    {
        ApiResult<string> infoResponse = null;
        yield return ApiClient.Instance.GetText(ApiEndpoints.PhotoZoneInfo(label), result => infoResponse = result);
        PhotoZoneInfo info = infoResponse.Success ? ResponseParser.ParsePhotoZone(infoResponse.Data) : null;
        if (info == null)
        {
            yield break;
        }

        title.text = info.Title;
        recoperson.text = info.Recommendation;
        Photoexplain.text = info.Description;

        ApiResult<string> imageListResponse = null;
        yield return ApiClient.Instance.GetText(ApiEndpoints.ImageList(info.ImageTag), result => imageListResponse = result);
        if (!imageListResponse.Success)
        {
            yield break;
        }

        ImageList imageList = ResponseParser.ParseImageList(imageListResponse.Data);
        int count = Mathf.Min(imageList.Count, images.Length);
        for (int i = 0; i < count; i++)
        {
            Button target = images[i];
            ImageLoader.Instance.Load(ApiEndpoints.Image(imageList.Paths[i]), ImageScope, sprite =>
            {
                if (target != null)
                {
                    target.image.sprite = sprite;
                }
            });
        }
    }
}
