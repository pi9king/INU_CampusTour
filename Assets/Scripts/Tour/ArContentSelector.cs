using System;
using UnityEngine;

namespace CampusTour.Tour
{
    /// <summary>
    /// AR 씬에서 현재 투어의 현재 경유지에 해당하는 AR 콘텐츠만 켠다.
    /// </summary>
    public class ArContentSelector : MonoBehaviour
    {
        [Serializable]
        public class TourContents
        {
            public TourDefinition tour;

            [Tooltip("경유지 순서대로")]
            public GameObject[] contents;
        }

        [SerializeField] private TourContents[] tourContents;

        private void Start()
        {
            if (!TourSession.IsActive)
            {
                return;
            }

            for (int i = 0; i < tourContents.Length; i++)
            {
                if (tourContents[i].tour == TourSession.Definition)
                {
                    tourContents[i].contents[TourSession.Progress.CurrentStop].SetActive(true);
                    return;
                }
            }
        }
    }
}
