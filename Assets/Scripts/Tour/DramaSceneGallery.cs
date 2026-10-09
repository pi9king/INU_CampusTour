using CampusTour.Network;
using UnityEngine;
using UnityEngine.UI;

namespace CampusTour.Tour
{
    /// <summary>
    /// 드라마 투어 정보 패널의 촬영지 사진들을 서버에서 불러온다. 오브젝트 이름이 서버 파일 이름이다.
    /// </summary>
    public class DramaSceneGallery : MonoBehaviour
    {
        private const string ImageScope = "DramaTour";

        [SerializeField] private GameObject[] images;

        private void Start()
        {
            for (int i = 0; i < images.Length; i++)
            {
                Button target = images[i].GetComponent<Button>();
                ImageLoader.Instance.Load(ApiEndpoints.DramaSceneImage(target.name), ImageScope, sprite =>
                {
                    if (target != null)
                    {
                        target.image.sprite = sprite;
                    }
                });
            }
        }

        private void OnDestroy()
        {
            if (ImageLoader.HasInstance)
            {
                ImageLoader.Instance.ReleaseScope(ImageScope);
            }
        }
    }
}
