using System.Collections.Generic;
using CampusTour.UI;
using NUnit.Framework;

namespace CampusTour.Tests
{
    public class ScreenStackTests
    {
        private class FakeOverlay : IClosable
        {
            public void Close()
            {
            }
        }

        private ScreenStack stack;

        [SetUp]
        public void SetUp()
        {
            stack = new ScreenStack();
        }

        [Test]
        public void TryPush_RejectsAlreadyOpenScreen()
        {
            Assert.IsTrue(stack.TryPush(ScreenId.Restaurant, null));
            Assert.IsFalse(stack.TryPush(ScreenId.Restaurant, null));
            Assert.AreEqual(1, stack.Count);
        }

        [Test]
        public void GetArgs_ReturnsArgsPassedOnPush()
        {
            NameArgs args = new NameArgs("공과대학");
            stack.TryPush(ScreenId.UnivInfo, args);

            Assert.AreSame(args, stack.GetArgs(ScreenId.UnivInfo));
            Assert.IsNull(stack.GetArgs(ScreenId.Inven));
        }

        [Test]
        public void CloseScreen_AlsoClosesScreensAboveIt()
        {
            // 인벤토리 → 단과대 → 학과 순서로 열린 상태에서 단과대를 닫으면 학과도 닫혀야 한다.
            stack.TryPush(ScreenId.Inven, null);
            stack.TryPush(ScreenId.UnivInfo, null);
            stack.TryPush(ScreenId.DeptInfoTwoPages, null);

            List<ScreenId> closed = stack.CloseScreen(ScreenId.UnivInfo);

            CollectionAssert.AreEqual(new[] { ScreenId.DeptInfoTwoPages, ScreenId.UnivInfo }, closed);
            Assert.IsTrue(stack.IsOpen(ScreenId.Inven));
            Assert.AreEqual(1, stack.Count);
        }

        [Test]
        public void CloseScreen_ReturnsEmptyForUnknownScreen()
        {
            Assert.AreEqual(0, stack.CloseScreen(ScreenId.Stamp).Count);
        }

        [Test]
        public void Peek_PrefersTopOverlay()
        {
            FakeOverlay zoom = new FakeOverlay();
            stack.TryPush(ScreenId.Media, null);
            stack.PushOverlay(zoom);

            IClosable overlay;
            ScreenId screen;
            Assert.IsTrue(stack.TryPeekOverlay(out overlay));
            Assert.AreSame(zoom, overlay);
            Assert.IsFalse(stack.TryPeekScreen(out screen));

            stack.RemoveOverlay(zoom);
            Assert.IsTrue(stack.TryPeekScreen(out screen));
            Assert.AreEqual(ScreenId.Media, screen);
        }

        [Test]
        public void PushOverlay_DoesNotDuplicateSameOverlay()
        {
            FakeOverlay menu = new FakeOverlay();
            stack.PushOverlay(menu);
            stack.PushOverlay(menu);

            Assert.AreEqual(1, stack.Count);
        }

        [Test]
        public void CloseScreen_RemovesOverlaysOpenedOnTopOfIt()
        {
            stack.TryPush(ScreenId.Media, null);
            stack.PushOverlay(new FakeOverlay());

            stack.CloseScreen(ScreenId.Media);

            Assert.AreEqual(0, stack.Count);
        }
    }
}
