using System;
using UnityEngine;

namespace CampusTour.Tour
{
    /// <summary>
    /// 경유지 도착 시 "AR로 보기 / 건너뛰기"를 묻는 팝업.
    /// </summary>
    public class TourArrivalPopup : MonoBehaviour
    {
        [SerializeField] private GameObject popup;

        public event Action ArRequested;
        public event Action Skipped;

        public void Exit()
        {
            popup.SetActive(false);
            if (Skipped != null)
            {
                Skipped();
            }
        }

        public void GoAR()
        {
            popup.SetActive(false);
            if (ArRequested != null)
            {
                ArRequested();
            }
        }
    }
}
