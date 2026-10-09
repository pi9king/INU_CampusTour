using System;
using System.Collections.Generic;
using CampusTour.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CampusTour.UI
{
    /// <summary>
    /// Additive 화면의 열기/닫기와 뒤로가기(ESC)를 한 곳에서 처리한다.
    /// </summary>
    public class ScreenNavigator : Singleton<ScreenNavigator>
    {
        private readonly ScreenStack stack = new ScreenStack();
        private Action rootBackHandler;

        public int OpenCount
        {
            get { return stack.Count; }
        }

        protected override void Awake()
        {
            base.Awake();
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Back();
            }
        }

        public void Push(ScreenId id, ScreenArgs args = null)
        {
            if (stack.TryPush(id, args))
            {
                SceneManager.LoadScene(ScreenRegistry.GetSceneName(id), LoadSceneMode.Additive);
            }
        }

        public ScreenArgs GetArgs(ScreenId id)
        {
            return stack.GetArgs(id);
        }

        public void Close(ScreenId id)
        {
            List<ScreenId> closed = stack.CloseScreen(id);
            if (closed.Count == 0)
            {
                // 내비게이터를 거치지 않고 열린 화면도 닫을 수 있게 한다.
                closed.Add(id);
            }

            for (int i = 0; i < closed.Count; i++)
            {
                Scene scene = SceneManager.GetSceneByName(ScreenRegistry.GetSceneName(closed[i]));
                if (scene.isLoaded)
                {
                    SceneManager.UnloadSceneAsync(scene);
                }
            }
        }

        public void PushOverlay(IClosable overlay)
        {
            stack.PushOverlay(overlay);
        }

        public void RemoveOverlay(IClosable overlay)
        {
            stack.RemoveOverlay(overlay);
        }

        /// <summary>열린 화면이 없을 때 뒤로가기를 처리할 핸들러. (메인 화면의 종료 팝업)</summary>
        public void SetRootBackHandler(Action handler)
        {
            rootBackHandler = handler;
        }

        public void ClearRootBackHandler(Action handler)
        {
            if (rootBackHandler == handler)
            {
                rootBackHandler = null;
            }
        }

        public void Back()
        {
            IClosable overlay;
            ScreenId screen;
            if (stack.TryPeekOverlay(out overlay))
            {
                stack.RemoveOverlay(overlay);
                if (IsAlive(overlay))
                {
                    overlay.Close();
                }
            }
            else if (stack.TryPeekScreen(out screen))
            {
                Close(screen);
            }
            else if (rootBackHandler != null)
            {
                rootBackHandler();
            }
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            if (mode == LoadSceneMode.Single)
            {
                stack.Clear();
            }
        }

        private static bool IsAlive(IClosable overlay)
        {
            UnityEngine.Object unityObject = overlay as UnityEngine.Object;
            return !(overlay is UnityEngine.Object) || unityObject != null;
        }
    }
}
