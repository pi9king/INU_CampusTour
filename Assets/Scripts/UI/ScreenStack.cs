using System.Collections.Generic;

namespace CampusTour.UI
{
    /// <summary>
    /// 열린 화면과 오버레이의 순서를 관리하는 순수 로직. (씬 로드와 분리해 테스트할 수 있다)
    /// </summary>
    public class ScreenStack
    {
        private class Entry
        {
            public readonly bool IsOverlay;
            public readonly ScreenId Screen;
            public readonly ScreenArgs Args;
            public readonly IClosable Overlay;

            public Entry(ScreenId screen, ScreenArgs args)
            {
                Screen = screen;
                Args = args;
            }

            public Entry(IClosable overlay)
            {
                IsOverlay = true;
                Overlay = overlay;
            }
        }

        private readonly List<Entry> entries = new List<Entry>();

        public int Count
        {
            get { return entries.Count; }
        }

        public bool IsOpen(ScreenId id)
        {
            return IndexOf(id) >= 0;
        }

        /// <summary>이미 열린 화면이면 false를 반환한다.</summary>
        public bool TryPush(ScreenId id, ScreenArgs args)
        {
            if (IsOpen(id))
            {
                return false;
            }
            entries.Add(new Entry(id, args));
            return true;
        }

        public ScreenArgs GetArgs(ScreenId id)
        {
            int index = IndexOf(id);
            return index < 0 ? null : entries[index].Args;
        }

        public void PushOverlay(IClosable overlay)
        {
            RemoveOverlay(overlay);
            entries.Add(new Entry(overlay));
        }

        public void RemoveOverlay(IClosable overlay)
        {
            entries.RemoveAll(entry => entry.IsOverlay && entry.Overlay == overlay);
        }

        /// <summary>
        /// 화면과 그 위에 쌓인 화면/오버레이를 모두 제거하고, 닫아야 할 화면 목록(위쪽부터)을 반환한다.
        /// </summary>
        public List<ScreenId> CloseScreen(ScreenId id)
        {
            List<ScreenId> closed = new List<ScreenId>();
            int index = IndexOf(id);
            if (index < 0)
            {
                return closed;
            }

            for (int i = entries.Count - 1; i >= index; i--)
            {
                if (!entries[i].IsOverlay)
                {
                    closed.Add(entries[i].Screen);
                }
                entries.RemoveAt(i);
            }
            return closed;
        }

        public bool TryPeekOverlay(out IClosable overlay)
        {
            overlay = null;
            if (entries.Count == 0 || !Top.IsOverlay)
            {
                return false;
            }
            overlay = Top.Overlay;
            return true;
        }

        public bool TryPeekScreen(out ScreenId id)
        {
            id = default(ScreenId);
            if (entries.Count == 0 || Top.IsOverlay)
            {
                return false;
            }
            id = Top.Screen;
            return true;
        }

        public void Clear()
        {
            entries.Clear();
        }

        private Entry Top
        {
            get { return entries[entries.Count - 1]; }
        }

        private int IndexOf(ScreenId id)
        {
            return entries.FindIndex(entry => !entry.IsOverlay && entry.Screen == id);
        }
    }
}
