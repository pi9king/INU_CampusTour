using System;
using CampusTour.Network;
using UnityEngine;

/// <summary>
/// 360° 로드뷰 구체에 서버 이미지를 텍스처로 입힌다.
/// </summary>
public class RoadViewControl : MonoBehaviour
{
    private const string ImageScope = "RoadView";

    public void LoadSphereTexture(Transform sphere, int imageNumber, Action onComplete)
    {
        ImageLoader.Instance.Load(ApiEndpoints.RoadViewImage(imageNumber), ImageScope, sprite =>
        {
            if (sphere != null && sprite != null)
            {
                sphere.GetComponent<MeshRenderer>().material.mainTexture = sprite.texture;
            }
            if (onComplete != null)
            {
                onComplete();
            }
        });
    }

    private void OnDestroy()
    {
        if (ImageLoader.HasInstance)
        {
            ImageLoader.Instance.ReleaseScope(ImageScope);
        }
    }
}
