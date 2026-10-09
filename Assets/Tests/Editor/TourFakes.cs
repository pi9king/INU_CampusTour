using System;
using System.Collections.Generic;
using CampusTour.Tour;
using UnityEngine;

namespace CampusTour.Tests
{
    public class FakeTourMap : ITourMap
    {
        public Vector2? PlayerPosition;
        public readonly List<int> ShownMarkers = new List<int>();
        public bool IsDisposed;

        public bool TryGetPlayerPosition(out Vector2 position)
        {
            position = PlayerPosition.HasValue ? PlayerPosition.Value : Vector2.zero;
            return PlayerPosition.HasValue;
        }

        // 마커 n번은 (n, 0) 위치에 있다고 가정한다.
        public Vector2 GetMarkerPosition(int markerNumber)
        {
            return new Vector2(markerNumber, 0);
        }

        public void ShowOnlyMarker(int markerNumber)
        {
            ShownMarkers.Add(markerNumber);
        }

        public void Dispose()
        {
            IsDisposed = true;
        }

        public void MovePlayerToMarker(int markerNumber)
        {
            PlayerPosition = GetMarkerPosition(markerNumber);
        }
    }

    public class FakeTourView : ITourView
    {
        public event Action StartRequested;
        public event Action ArRequested;
        public event Action ArSkipped;
        public event Action InfoConfirmed;
        public event Action NextRequested;
        public event Action ExitRequested;

        public bool IsStartGuideShown;
        public string StartRouteText;
        public int ArrivalPopupCount;
        public readonly List<int> ShownInfoPanels = new List<int>();
        public string NextGuideText;
        public bool IsCompletionPlayed;

        public void ShowStartGuide() { IsStartGuideShown = true; }
        public void ShowStartButton(string routeText) { StartRouteText = routeText; }
        public void ShowArrivalPopup() { ArrivalPopupCount++; }
        public void ShowStopInfo(int stopIndex) { ShownInfoPanels.Add(stopIndex); }
        public void ShowNextGuide(string guideText) { NextGuideText = guideText; }
        public void PlayCompletion() { IsCompletionPlayed = true; }

        public void PressStart() { Raise(StartRequested); }
        public void PressAr() { Raise(ArRequested); }
        public void PressSkipAr() { Raise(ArSkipped); }
        public void PressInfoNext() { Raise(InfoConfirmed); }
        public void PressGoNext() { Raise(NextRequested); }
        public void PressExit() { Raise(ExitRequested); }

        private static void Raise(Action handler)
        {
            if (handler != null)
            {
                handler();
            }
        }
    }

    public class FakeTourHost : ITourHost
    {
        public int VibrateCount;
        public int OpenArCount;
        public int CompleteCount;
        public int ExitCount;

        public void Vibrate() { VibrateCount++; }
        public void OpenArScene() { OpenArCount++; }
        public void CompleteTour() { CompleteCount++; }
        public void ExitTour() { ExitCount++; }
    }
}
